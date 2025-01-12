using Conesoft.Hosting;
using Conesoft.PwaGenerator;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddHostConfigurationFiles()
    .AddUsersWithStorage()
    .AddHostEnvironmentInfo()
    .AddLoggingService()
    ;

builder.Services
    .AddCompiledHashCacheBuster()
    .AddRazorPages();

var app = builder.Build();
app
    .UseCompiledHashCacheBuster()
    .UseStaticFiles(new StaticFileOptions
    {
        ServeUnknownFileTypes = true,
        DefaultContentType = "application/jrd+json; charset=utf-8",
    });

app.MapPwaInformationFromAppSettings();
app.MapRazorPages();

app.Run();