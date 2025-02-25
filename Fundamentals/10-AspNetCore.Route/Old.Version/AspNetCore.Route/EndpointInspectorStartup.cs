﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Route
{
    public class EndpointInspectorStartup
    {
        #region snippet
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(next => context =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint is null)
                {
                    return Task.CompletedTask;
                }
                Console.WriteLine($"Endpoint: {endpoint.DisplayName}");
                if (endpoint is RouteEndpoint routeEndpoint)
                {
                    Console.WriteLine("Endpoint has route pattern: " +routeEndpoint.RoutePattern.RawText);
                }
                foreach (var metadata in endpoint.Metadata)
                {
                    Console.WriteLine($"Endpoint has metadata: {metadata}");
                }
                return Task.CompletedTask;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/hello", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
        #endregion
    }
}
