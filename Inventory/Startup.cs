using Inventory.Domain.Abstractions;
using Inventory.Domain.Repositories;
using Inventory.Entities.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.Entities.Mappers;
using MediatR;
using System.Reflection;
using Inventory.Application.Commands;
using Inventory.Entities.DTOs;
using Inventory.Application.Handlers;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ServiceProcess;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

namespace Inventory
{
    public class Startup
    {
        readonly string _trustedOrigins = "locals";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(options => options.UseSqlServer(Configuration["Databases:Main:ConnectionString"]));
            // services.AddDbContext<MainContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ObjectMapperProfile());
                mc.AddProfile(new ListMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IMovementRepository, MovementRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IMovementTypeRepository, MovementTypeRepository>();

            // Warehouse
            services.AddTransient<IRequestHandler<CreateWarehouseCommand, WarehouseDTO>, CreateWarehouseHandler>();
            services.AddTransient<IRequestHandler<ListWarehouseCommand, List<WarehouseListDTO>>, ListWarehouseHandler>();
            services.AddTransient<IRequestHandler<GetWarehouseByIdCommand, WarehouseDTO>, GetWarehouseByIdHandler>();

            // Product
            services.AddTransient<IRequestHandler<CreateProductCommand, ProductDTO>, CreateProductHandler>();
            services.AddTransient<IRequestHandler<ListProductCommand, List<ProductDTO>>, ListProductHandler>();
            services.AddTransient<IRequestHandler<GetProductByIdCommand, ProductDTO>, GetProductByIdHandler>();
            services.AddTransient<IRequestHandler<GetProductStockCommand, ProductStockDTO>, GetProductStockHandler>();

            // Movement
            services.AddTransient<IRequestHandler<CreateMovementCommand, MovementDTO>, CreateMovementHandler>();
            services.AddTransient<IRequestHandler<ListMovementCommand, List<MovementDTO>>, ListMovementHandler>();
            services.AddTransient<IRequestHandler<GetMovementByIdCommand, MovementDTO>, GetMovementByIdHandler>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHealthChecks()
                .AddSqlServer(Configuration["Databases:Main:ConnectionString"])
                .AddDiskStorageHealthCheck(s => s.AddDrive("C:\\", 1024))
                .AddProcessAllocatedMemoryHealthCheck(512)
                .AddUrlGroup(new Uri("https://localhost:44324/api/v1/Warehouse"), "Warehouses")
                .AddUrlGroup(new Uri("https://localhost:44324/api/v1/Product"), "Products")
                .AddUrlGroup(new Uri("https://localhost:44324/api/v1/Movement"), "Movements");
            services.AddHealthChecksUI(s =>
                {
                    s.AddHealthCheckEndpoint("endpoint", "https://localhost:44324/health");
                }).
                AddInMemoryStorage();

            services.AddCors(options =>
            {
                options.AddPolicy(name: _trustedOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:44324");
                                  });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                }).RequireHost("localhost");
                endpoints.MapControllers();
            });
        }
    }
}
