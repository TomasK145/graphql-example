using GraphQL.Api.Data;
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
using GraphQL.Api.GraphQL.Messaging;

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
                options.UseSqlServer(@"Server=MILL199\SQLEXPRESS;Initial Catalog=graphql_demo;Persist Security Info=False;User ID=orchardadmin;Password=OrcH@rd&^Adm1IN;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            });

            //GraphQL
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<LibrarySchema>();
            services.AddSingleton<CustomerMessageService>();
            services.AddGraphQL(options =>
            {
                options.ExposeExceptions = true;
            })
            .AddGraphTypes(ServiceLifetime.Scoped)
            .AddDataLoader() //Data Loader --> https://github.com/graphql/dataloader
            .AddWebSockets() //Web sockets --> pre moznost prace z GraphQL subscriptions
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
            app.UseWebSockets();
            app.UseGraphQLWebSockets<LibrarySchema>("/graphql");

            app.UseGraphQL<LibrarySchema>(); //GraphQL middlewaru
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //middleware pre GraphQL playground

            dbContext.Seed();
        }
    }
}
