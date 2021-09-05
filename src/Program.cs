using Conesoft.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddHostConfiguration();
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseHostingDefaults(useDefaultFiles: true, useStaticFiles: true);
app.MapRazorPages();

app.Run();