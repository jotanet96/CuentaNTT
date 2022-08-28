using AutoMapper;
using CuentaNTT.Core.DTOs;
using CuentaNTT.Core.Models;

namespace CuentaNTT.Repository.Mappings {
    public class AutoMapperCuentaNTTProfile : Profile{
        public AutoMapperCuentaNTTProfile() {
            CreateMap<Persona, PersonaDTO>();
            CreateMap<PersonaDTO, Persona>();

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();
            
            CreateMap<Cuenta, CuentaDTO>();
            CreateMap<CuentaDTO, Cuenta>();

            CreateMap<Movimiento, MovimientoDTO>();
            CreateMap<MovimientoDTO, Movimiento>();
        }
    }
}
