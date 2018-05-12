// Copyright (c) MPGP. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mpgp.Infrastructure;
using Mpgp.RestApiServer.WebSockets;
using Mpgp.WebSocketServer.Core;

namespace Mpgp.RestApiServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddInfrastructure();
            services.AddWebSocketManager();
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{System.Reflection.Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(System.AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.SwaggerDoc("v1", GetSwaggerInfo());
                c.OperationFilter<Swashbuckle.AspNetCore.Examples.ExamplesOperationFilter>();
                c.OperationFilter<Swashbuckle.AspNetCore.Examples.DescriptionOperationFilter>();
            });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, System.IServiceProvider serviceProvider)
        {
            app.UseCors("MyPolicy");
            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

                // todo : removee
                app.UseMiddleware(typeof(Utils.ErrorHandlingMiddleware));
            }
            else
            {
                app.UseMiddleware(typeof(Utils.ErrorHandlingMiddleware));
            }

            var wsOptions = new WebSocketOptions()
            {
                KeepAliveInterval = System.TimeSpan.FromSeconds(60),
                ReceiveBufferSize = 4 * 1024
            };

            app.UseWebSockets(wsOptions);
            app.MapWebSocketManager(Configuration["Params:WebSocketPath"], serviceProvider.GetService<WebSocketRouter>());

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "MPGP API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{id?}");
            });
        }

        private Swashbuckle.AspNetCore.Swagger.Info GetSwaggerInfo()
        {
            return new Swashbuckle.AspNetCore.Swagger.Info
            {
                Version = "v1",
                Title = "MPGP API",
                Description = "Multiplayer Game Platform API",
                TermsOfService = "https://github.com/mpgp/Documentation",
                Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                {
                    Name = "loktionov129",
                    Email = "loktionov129@gmail.com",
                    Url = "https://github.com/loktionov129"
                },
                License = new Swashbuckle.AspNetCore.Swagger.License
                {
                    Name = "BSD 2-Clause \"Simplified\" License",
                    Url = "https://github.com/mpgp/Mpgp/blob/master/LICENSE"
                }
            };
        }
    }
}
