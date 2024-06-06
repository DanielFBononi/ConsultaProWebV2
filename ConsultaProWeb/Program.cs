
using ConsultaProWeb.Repository;
using ConsultaProWeb.Sessao;
using Microsoft.EntityFrameworkCore;

namespace ConsultaProWeb.Sessao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CPWDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt => opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
           
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IConvenioRepository, ConvenioRepository>();
            builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
            builder.Services.AddScoped<IPacientesRepository, PacientesRepository>();
            builder.Services.AddScoped<IMedEspRepository, MedEspRepository>();
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddSession(x => {
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;

            });

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
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}