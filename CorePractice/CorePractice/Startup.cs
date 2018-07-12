using CorePractice.Data;
using CorePractice.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CorePractice
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options => 
            {
                _configuration.Bind("AzureAd", options);
            })
            .AddCookie();
            services.AddSingleton<IGreeter, Greeter>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(_configuration.GetConnectionString("CorePractice")));
            services.AddScoped<IRestaurentData, DatabaseRestaurant>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(ConfigureRoutes);
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request Incoming");
            //        if (context.Request.Path.StartsWithSegments("/mvm"))
            //        {
            //            await context.Response.WriteAsync("Hittt!!!!");
            //            logger.LogInformation("Request Handled");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Request Outgoing");
            //        }
            //    };
            //});

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/wp"
            });

            app.Run(async (context) =>
            {
                var response = greeter.GetResponseMessage();
                await context.Response.WriteAsync(response);
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // Home/Index/4
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
