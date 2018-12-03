﻿using asp_back.hubs;
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
                    .WithOrigins ("http://localhost:4200");
            }));
            services.AddSingleton<GraphDbConnection> ();
            services.AddSingleton<QueueHandler>();
            services.AddSignalR ();
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }
            app.UseCors ("CorsPolicy");
            app.UseWebSockets ();
            app.UseSignalR (routes => {
                routes.MapHub<TestHub> ("/test");
            });

            // app.UseHttpsRedirection ();
            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Swagger Doc");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc ();
        }
    }
    // public partial class Startup {
    //     public void Configuration (IAppBuilder app) {
    //         app.MapSignalR ();
    //         GlobalHost.HubPipeline.RequireAuthentication ();
    //     }
    // }
}