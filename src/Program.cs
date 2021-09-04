using Conesoft.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddHostConfiguration();
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseRouting();
app.UseHostingDefaults(useDefaultFiles: true, useStaticFiles: true);
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();