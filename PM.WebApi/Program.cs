using PM.Application;
using PM.Infrastrcture;
using PM.WebApi;
using PM.WebApi.Middlewares;
using PM.WebApi.Notifications;

var builder = WebApplication.CreateBuilder(args);
{

    // Add services to the container.

    builder.Services.AddPresentation()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);
   
   
}
var app = builder.Build();
{

    // Configure the HTTP request pipeline.
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.Map("/_images", b => b.UseMiddleware<ImageServeMiddleware>());
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    
    app.UseCors(x => x.WithOrigins("http://localhost:5173", "http://192.168.0.23:5173").AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((x) => true)
                           .AllowCredentials());
    app.MapHub<NotificationsHub>("/notifications-services");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Management API"));
    }
    app.Run();
}
