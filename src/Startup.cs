using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Davepermen.Website
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next.Invoke();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    if (context.Context.Response.Headers["Content-Type"].Count > 0)
                    {
                        var contentType = context.Context.Response.Headers["Content-Type"][0];
                        if (contentType.Contains("text") || contentType.Contains("json") || contentType.Contains("xml"))
                        {
                            context.Context.Response.Headers["Content-Type"] = contentType + "; charset=utf-8";
                        }
                    }
                    if(context.Context.Response.Headers["Cache-Control"].Count == 0)
                    {
                        context.Context.Response.Headers.Add("Cache-Control", "max-age=31536000, immutable");
                    }
                }
            });

            app.Use(async (context, next) =>
            {
                if (context.Response.Headers["Cache-Control"].Count == 0)
                {
                    context.Response.Headers.Add("Cache-Control", "no-cache");
                }
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
