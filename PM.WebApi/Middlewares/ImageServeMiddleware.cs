using HeyRed.Mime;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PM.WebApi.Middlewares;

public class ImageServeMiddleware
{
    private IWebHostEnvironment _env;
    private readonly RequestDelegate _next;
    private string _cacheFolder;
    private string _tempFolder;

    public ImageServeMiddleware(IWebHostEnvironment env, RequestDelegate next)
    {
        _env = env;
        _next = next;
        _cacheFolder = Path.Combine(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "cache"));
        _tempFolder = Path.Combine(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "temp"));
        CheckAndCreateCacheDir();
    }

    public async Task InvokeAsync(HttpContext context)
    {

        List<string> paths = context!.Request!.Path!.Value!.Split("/").ToList();
        if ("GET".Equals(context.Request.Method) && paths.Count >= 2)
        {
            var req = context.Request;
            byte[]? buffer = GetFile(paths.Last());
            if (buffer != null)
            {
                if (paths.Count == 2)
                {
                    context.Response.Headers.Append("Content-Type", MimeTypesMap.GetMimeType(paths.Last()));
                    await context.Response.BodyWriter.WriteAsync(buffer);
                }
                else
                {
                    int[] sizes = paths[1].ToLower().Split("x").Select(x => int.Parse(x)).ToArray();
                    if (sizes.Length == 2)
                    {
                        req.Query.TryGetValue("m", out StringValues mode);
                        string m = "crop";
                        if (mode.Count > 0)
                        {
                            m = mode!.FirstOrDefault()!;
                        }

                        if (File.Exists(Path.Combine(_cacheFolder, $"{sizes[0]}x{sizes[1]}", $"{m}_{paths.Last()}")) == false)
                        {
                            using Image thumbnail = Image.Load(buffer);
                            thumbnail.Mutate(x => x.Resize(new ResizeOptions
                            {
                                Size = new Size(sizes[0], sizes[1]),
                                Mode = m == "fill" ? ResizeMode.Pad : ResizeMode.Crop,
                                Sampler = KnownResamplers.Lanczos3,
                            }).BackgroundColor(new Rgba32(255, 255, 255)));
                            if (Directory.Exists(Path.Combine(_cacheFolder, $"{sizes[0]}x{sizes[1]}")) == false)
                            {
                                Directory.CreateDirectory(Path.Combine(_cacheFolder, $"{sizes[0]}x{sizes[1]}"));
                            }
                            thumbnail.Save(Path.Combine(_cacheFolder, $"{sizes[0]}x{sizes[1]}", $"{m}_{paths.Last()}"));
                        }



                        byte[] cacheBuffer = File.ReadAllBytes(Path.Combine(_cacheFolder, $"{sizes[0]}x{sizes[1]}", $"{m}_{paths.Last()}"));
                        //
                        await context.Response.BodyWriter.WriteAsync(cacheBuffer);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    }
                }
            }
            else if (paths[1] == "temp")
            {
                buffer = GetTempFile(paths.Last());
                if (buffer is not null)
                {
                    context.Response.Headers.Append("Content-Type", MimeTypesMap.GetMimeType(paths.Last()));
                    await context.Response.BodyWriter.WriteAsync(buffer);
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        }
        else
        {
            await _next(context);
        }
    }

    public byte[]? GetFile(string name)
    {
        if (File.Exists(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "avatar", name)))
        {
            return File.ReadAllBytes(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "avatar", name));
        }
        return null;
    }

    public byte[]? GetTempFile(string name)
    {
        if (File.Exists(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "temp", name)))
        {
            return File.ReadAllBytes(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt", "temp", name));
        }
        return null;
    }
    private void CheckAndCreateCacheDir()
    {
        if (Directory.Exists(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt")) == false)
        {
            Directory.CreateDirectory(Path.Combine(_env.ContentRootPath, "Data_Stores", "salt"));
        }
        if (Directory.Exists(_cacheFolder) == false)
        {
            Directory.CreateDirectory(_cacheFolder);
        }
        if (Directory.Exists(_tempFolder) == false)
        {
            Directory.CreateDirectory(_tempFolder);
        }
    }

}
