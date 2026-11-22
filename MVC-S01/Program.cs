using Microsoft.AspNetCore.Mvc;
using MVC_S01.CustomMiddleWare;

namespace MVC_S01
{
    public class Program
    {
        //Entry Point
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            ////Addservices for api
            //builder.Services.AddControllers();

            var app = builder.Build();

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hello"); //Request
            //    await next.Invoke(context);
            //    Console.WriteLine("Bye");  //Response
            //});


            app.UseMiddleware<RequestTimingMiddleWare>();




            // Configure the HTTP request pipeline.(MiddleWare)
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();         //transfer http to https
            //app.UseStaticFiles();            //Serve static files on wwwroot
            app.UseRouting();                  //which controller and action

            app.UseAuthentication();           //who are you?(Cookie,GWT)
            app.UseAuthorization();            //Are u allowed

            app.MapStaticAssets();             //Serve static files on wwwroot(from.net 9.0)

            app.MapControllerRoute(
                name: "shop",
                pattern: "Shop/{id}",
                defaults: new
                {
                    controller = "Product",
                    action = "GetProductById"
                });
            
            app.MapControllerRoute(            //Way URL/Controller/action
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
