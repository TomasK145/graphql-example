using GraphQL.Api.Data;
using GraphQL.Api.Data.Repositories;
using GraphQL.Api.GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase("LibraryDb"));

            //GraphQL
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<LibrarySchema>();
            services.AddGraphQL(options =>
            {
                options.ExposeExceptions = true;
            })
            .AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LibraryDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<LibrarySchema>(); //GraphQL middlewaru
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //middleware pre GraphQL playground
            dbContext.Seed();

            var authors = dbContext.Authors;
            var books = dbContext.Books;
            var customers = dbContext.Customers;
            var reviews = dbContext.Reviews;
        }
    }
}
