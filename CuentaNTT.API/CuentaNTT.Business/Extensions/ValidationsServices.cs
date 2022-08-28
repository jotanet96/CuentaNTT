using CuentaNTT.Business.Interfaces;
using CuentaNTT.Business.Services;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Core.Models;
using CuentaNTT.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CuentaNTT.Core.Extensions {
    public static class ValidationsServices { 

        public static IServiceCollection AddValidations(this IServiceCollection services) {
            
            services.AddTransient<IBaseRepository<Persona, int>, BaseRepository<Persona, int>>();
            services.AddTransient<IBaseRepository<Cliente, int>, BaseRepository<Cliente, int>>();
            services.AddTransient<IBaseRepository<Cuenta, int>, BaseRepository<Cuenta, int>>();
            services.AddTransient<IBaseRepository<Movimiento, int>, BaseRepository<Movimiento, int>>();

            services.AddTransient<IPersonaService, PersonaService>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();

            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();

            services.AddTransient<IMovimientoService, MovimientoService>();
            services.AddTransient<IMovimientoRepository, MovimientoRepository>();

            services.AddTransient<ICuentaService, CuentaService>();
            services.AddTransient<ICuentaRepository, CuentaRepository>();

            services.AddTransient<IReporteService, ReporteService>();

            return services;
        }
    }
}
