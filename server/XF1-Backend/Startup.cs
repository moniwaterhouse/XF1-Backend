using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF1_Backend.Models;
using Microsoft.EntityFrameworkCore;
using XF1_Backend.Services;

namespace XF1_Backend
{
    public class Startup
    {
        public static CampeonatoService campeonatoService = new CampeonatoService();
        public static CarreraService carreraService = new CarreraService();
        public static EquipoService equipoService = new EquipoService();

        public static ServiceFacade facade = new ServiceFacade(campeonatoService, carreraService, equipoService);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<CampeonatoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XF1-BackendConectionString")));
            services.AddDbContext<CarreraDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XF1-BackendConectionString")));
            services.AddDbContext<LigaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XF1-BackendConectionString")));
            services.AddDbContext<UsuarioDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XF1-BackendConectionString")));
            services.AddDbContext<UsuarioXLigaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XF1-BackendConectionString")));
            services.AddDbContext<EscuderiaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XF1-BackendConectionString")));
            services.AddDbContext<PilotoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XF1-BackendConectionString")));
            services.AddDbContext<EquipoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XF1-BackendConectionString")));
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XF1_Backend", Version = "v1" });
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options =>

            {

                options.WithOrigins("http://localhost:4200");

                options.AllowAnyMethod();

                options.AllowAnyHeader();

            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "XF1_Backend v1"));
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
