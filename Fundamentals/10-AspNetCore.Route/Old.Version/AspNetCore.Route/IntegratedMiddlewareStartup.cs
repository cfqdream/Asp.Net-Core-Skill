﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCore.Route
{
    #region snippet
    public class IntegratedMiddlewareStartup
    { 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Location 1: Before routing runs. Can influence request before routing runs.
            app.UseHttpMethodOverride();
            app.UseRouting();
            // Location 2: After routing runs. Middleware can match based on metadata.
            app.Use(next => context =>
            {
                //判断终结点是否使用元数据
                var endpoint = context.GetEndpoint();
                if (endpoint?.Metadata.GetMetadata<AuditPolicyAttribute>()?.NeedsAudit== true)
                {
                    Console.WriteLine($"ACCESS TO SENSITIVE DATA AT: {DateTime.UtcNow}");
                }
                return next(context);
            });

            app.UseEndpoints(endpoints =>
            {         
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello world!");
                });
                // Using metadata to configure the audit policy.
                //该终结点上使用元数据
                endpoints.MapGet("/sensitive", async context =>
                {
                    await context.Response.WriteAsync("sensitive data");
                })
                .WithMetadata(new AuditPolicyAttribute(needsAudit: false));
            });

        } 
    }

    public class AuditPolicyAttribute : Attribute
    {
        public AuditPolicyAttribute(bool needsAudit)
        {
            NeedsAudit = needsAudit;
        }

        public bool NeedsAudit { get; }
    }
    #endregion
}
