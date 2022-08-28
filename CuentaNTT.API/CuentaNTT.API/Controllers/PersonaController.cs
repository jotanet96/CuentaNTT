using AutoMapper;
using CuentaNTT.Core.DTOs;
using CuentaNTT.Core.Models;
using CuentaNTT.Core.Response;
using Microsoft.AspNetCore.Mvc;
using CuentaNTT.Business.Interfaces;

namespace CuentaNTT.API.Controllers {
        [ApiController]
        [Route("api/[controller]")]

    public class PersonaController : Controller {

        private readonly IMapper _mapper;
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService, IMapper mapper) {
            _mapper = mapper;
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            try {

                ApiResponse<IEnumerable<PersonaDTO>> res = new();
                var lstPersonas = await _personaService.GetPersonasAsync();
                res.Data = _mapper.Map<IEnumerable<PersonaDTO>>(lstPersonas);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ByIdentificacion/{identificacion}", Name = "GetPersonaByIdentificacionAsync")]
        public async Task<IActionResult> GetPersonaByIdentificacionAsync(string identificacion) {
            try {

                var persona = await _personaService.GetPersonaByIdentificacionAsync(identificacion);

                ApiResponse<PersonaDTO> res = new();
                res.Data = _mapper.Map<PersonaDTO>(persona);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ById/{id}", Name = "GetPersonaByIdAsync")]
        public async Task<IActionResult> GetPersonaByIdAsync(int id) {
            try {

                var persona = await _personaService.GetPersonaByIdAsync(id);
                ApiResponse<PersonaDTO> res = new();
                res.Data = _mapper.Map<PersonaDTO>(persona);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPersonaAsync(PersonaDTO personaDTO) {
            try {

                ApiResponse<PersonaDTO> res = new();
                var persona = _mapper.Map<Persona>(personaDTO);
                Persona personaNuevo = await _personaService.AddPersonaAsync(persona);
                res.Success = true;
                res.Message = "OK";
                res.Data = _mapper.Map<PersonaDTO>(personaNuevo);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePersonaAsync([FromBody] PersonaDTO personaDTO) {
            try {

                ApiResponse<bool> res = new();
                var persona = _mapper.Map<Persona>(personaDTO);
                bool success = await _personaService.UpdatePersonaAsync(persona);
                res.Success = true;
                res.Data = success;
                res.Message = success ? "OK" : "Error al actualizar";

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("ById/{id}")]
        public async Task<IActionResult> DeletePersonaAsync(int id) {
            try {
                ApiResponse<bool> res = new();
                bool success = await _personaService.DeletePersonaAsync(id);
                res.Success = true;
                res.Data = success;
                res.Message = success ? "OK" : "Error al eliminar";
                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("ByIdentificacion/{identificacion}")]
        public async Task<IActionResult> DeletePersonaByIdentificacionAsync(string identificacion) {
            try {
                ApiResponse<bool> res = new();
                bool success = await _personaService.DeletePersonaByIdentificacionAsync(identificacion);
                res.Success = true;
                res.Data = success;
                res.Message = success ? "OK" : "Error al eliminar";
                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
