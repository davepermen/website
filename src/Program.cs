using Conesoft.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddHostConfiguration();
builder.Services.AddRazorPages();

var app = builder.Build();
Console.WriteLine(app.Environment.EnvironmentName);
app.UseHostingDefaults(useDefaultFiles: true, useStaticFiles: true);
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "application/jrd+json; charset=utf-8",
});
app.MapRazorPages();

app.Run();