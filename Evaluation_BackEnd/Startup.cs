﻿﻿using asp_back.hubs;
using Evaluation_BackEnd.Persistence;
using Learners.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace asp_back
{
    public partial class Startup {

        public Startup (IConfiguration configuration) {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
            // services.AddDbContext<LearnersContext> ();
            services.AddScoped<ITestMethods, LearnersMethods> ();
            services.AddCors (o => o.AddPolicy ("CorsPolicy", builder => {
                builder
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .AllowCredentials ()
                    .AllowAnyOrigin();
            }));
            services.AddSingleton<QueueHandler>();
            services.AddSignalR ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }
            app.UseCors ("CorsPolicy");
            
            app.UseSignalR (routes => {
                routes.MapHub<TestHub> ("/test");
            });

            app.UseMvc ();
        }
    }
}