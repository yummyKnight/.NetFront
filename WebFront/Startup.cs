using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Services.Contracts;
using Client.Services.Implementations;
using Client2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Client2 {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebFront", Version = "v1"}); });
            services.AddHttpClient<IGenericServices<Booking>, GenericServices<Booking>>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
            services.AddHttpClient<IGenericServices<Models.Client>, GenericServices<Models.Client>>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
            services.AddHttpClient<IGenericServices<Payment>, GenericServices<Payment>>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
            services.AddHttpClient<IGenericServices<Room>, GenericServices<Room>>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebFront v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}