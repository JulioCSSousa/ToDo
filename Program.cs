﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Data;
using ToDo.Services;
namespace ToDo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoContext") ?? throw new InvalidOperationException("Connection string 'ToDoContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ToDoService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=ToDoList}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
