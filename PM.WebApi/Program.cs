using Microsoft.OpenApi.Models;
using PM.Application;
using PM.Infrastrcture;
using PM.WebApi;

var builder = WebApplication.CreateBuilder(args);
{

// Add services to the container.

    builder.Services.AddPresentation()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project Management API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
    });
    builder.Services.AddCors();
}
var app = builder.Build();
{

// Configure the HTTP request pipeline.
app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    // app.Map("/_images", b => b.UseMiddleware<ImageServeMiddleware>());
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173","http://192.168.0.23:5173"));
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Management API"));
    }
app.Run();
}
