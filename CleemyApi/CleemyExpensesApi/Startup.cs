using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cleemy.Expenses.Business;
using Cleemy.Expenses.Data;
using Cleemy.Expenses.Data.DataAccess;
using Cleemy.Expenses.Data.Expenses;
using Cleemy.Expenses.Data.Technical;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CleemyExpensesApi
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
            services.AddControllers();
            services.AddDbContext<ExpensesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ExpensesContext"),
                b => b.MigrationsAssembly(typeof(ExpensesContext).Assembly.FullName)));
            //services.AddScoped<ExpenseRepository>();
            //services.AddScoped<UserRepository>();
            services.AddScoped(typeof(IRepository<Expense>), typeof(ExpenseRepository));
            services.AddScoped(typeof(IRepository<User>), typeof(UserRepository));
            services.AddScoped<IExpenseService, ExpenseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
