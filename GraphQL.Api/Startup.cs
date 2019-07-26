﻿using GraphQL.Api.Data;
using GraphQL.Api.Data.Repositories;
using GraphQL.Api.GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace GraphQL.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddDbContext<LibraryDbContext>(options => 
            {
                //options.UseInMemoryDatabase("LibraryDb");
                options.UseSqlServer("Server=tcp:orchardcmsdevservertk.database.windows.net,1433;Initial Catalog=testdbtk;Persist Security Info=False;User ID=orchardcmsdevtk;Password=T_K++@rchARD_C^MS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });

            //GraphQL
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<LibrarySchema>();
            services.AddGraphQL(options =>
            {
                options.ExposeExceptions = true;
            })
            .AddGraphTypes(ServiceLifetime.Scoped)
            .AddDataLoader() //Data Loader --> https://github.com/graphql/dataloader
            ;

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LibraryDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            }

            //GraphQL
            app.UseGraphQL<LibrarySchema>(); //GraphQL middlewaru
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //middleware pre GraphQL playground

            dbContext.Seed();
        }
    }
}
