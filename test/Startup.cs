using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.MiddleWare;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using VueCliMiddleware;

namespace Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                lifetime.ApplicationStopping.Register(OnStopping); 
                OnStopping();
                //PidUtils.KillPort(ushort.Parse(Configuration["Port"]), true);
            }

            app.UseMiddleware<HandlerExceptionMiddleWare>();

            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "ClientApp";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                {
                    var port = int.Parse(Configuration["Port"]);
                    spa.UseVueCli(npmScript: "serve", port:port);
                }

            });

            
        }

        private void OnStopping()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;

            Process netstat = new Process();
            netstat.StartInfo = new ProcessStartInfo
            {
                FileName = "netstat",
                Arguments = "-nao",
                RedirectStandardOutput = true
            };

            netstat.Start();
            var output = netstat.StandardOutput.ReadToEnd();
            var ports = output.Split('\n');
            var port = Configuration["Port"];
            var f = ports.FirstOrDefault(p => (p.Contains("ESTABLISHED") || p.Contains("LISTENING")) &&
            (p.Contains("192.168.0.11:" + port) || p.Contains("0.0.0.0:" + port) || p.Contains("127.0.0.1:" + port)));
            if (f == null) return;
            var pid = int.Parse(f.Split(' ').Last());
            var clientServer = Process.GetProcessById(pid);
            clientServer.Kill();
            clientServer.WaitForExit();
        }
    }
}
