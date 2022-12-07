using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using Vendor_Management.BussinessLogic;
using Vendor_Management.BussinessLogic.IBussinessLogic;
using Vendor_Management.BussinessRepository;
using Vendor_Management.BussinessRepository.IBussinessRepository;
using Vendor_Management.Migrations;
using Vendor_Management.VendorManagementContext;

namespace Vendor_Management
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
            //Repository Registration
            #region
            services.AddTransient<IVendorBl, VendorBl>();
            services.AddTransient<IVendorBr, VendorBr>();
            services.AddTransient<IMasterBl, MasterBl>();
            services.AddTransient<IMasterBr, MasterBr>();
            services.AddTransient<ICatalogueBl, CatalogueBl>();
            services.AddTransient<ICatalogueBr, CatalogueBr>();
            services.AddTransient<ICustomerBl, CustomerBl>();
            services.AddTransient<ICustomerBr, CustomerBr>();
            services.AddTransient<ILineItemsBl, LineItemsBl>();
            services.AddTransient<ILineItemsBr, LineItemsBr>();
           
            #endregion

            // Cors policy
            #region 
            services.AddCors(options =>
                options.AddPolicy(
                    "CorsPolicy",
                    builder =>
                    {
                        _ = builder.WithOrigins("http://localhost:3000")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                    }));
            #endregion

            services.AddDbContext<ERPDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("ERPDB")));
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddLogging(c => c.AddFluentMigratorConsole())
                     .AddFluentMigratorCore()
                     .ConfigureRunner(c => c
                     .AddPostgres()
                     .WithGlobalConnectionString("ERPDB")
                    .ScanIn(typeof(AddCountryTable_20221114162325).Assembly).For.Migrations().For.EmbeddedResources());
            services.AddMvc();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP v1"));
            }

            app.UseHttpsRedirection();
            migrationRunner.MigrateUp();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
