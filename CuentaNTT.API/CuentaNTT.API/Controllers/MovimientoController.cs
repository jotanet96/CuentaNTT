using AutoMapper;
using CuentaNTT.Core.DTOs;
using CuentaNTT.Core.Models;
using CuentaNTT.Core.Response;
using Microsoft.AspNetCore.Mvc;
using CuentaNTT.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CuentaNTT.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MovimientoController : Controller {

        private readonly IMapper _mapper;
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(IMovimientoService movimientoService, IMapper mapper) {
            _movimientoService = movimientoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            try {

                ApiResponse<IEnumerable<MovimientoDTO>> res = new();
                var lstMovimientos = await _movimientoService.GetMovimientosAsync();
                res.Data = _mapper.Map<IEnumerable<MovimientoDTO>>(lstMovimientos);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ByNumeroCuenta/{numeroCuenta}", Name = "GetMovimientosByNumeroCuenta")]
        public async Task<IActionResult> GetMovimientosByNumeroCuentaAsync(string numeroCuenta) {
            try {

                var lstMovimientos = await _movimientoService.GetMovimientosByNumeroCuentaAsync(numeroCuenta);

                ApiResponse<IEnumerable<MovimientoDTO>> res = new();
                res.Data = _mapper.Map<IEnumerable<MovimientoDTO>>(lstMovimientos);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ById/{id}", Name = "GetMovimiento")]
        public async Task<IActionResult> GetMovimientoByIdAsync(int id) {
            try {

                var movimiento = await _movimientoService.GetMovimientoByIdAsync(id);

                ApiResponse<MovimientoDTO> res = new();
                res.Data = _mapper.Map<MovimientoDTO>(movimiento);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddMovimientoAsync(MovimientoDTO movimientoDTO) {
            try {

                ApiResponse<MovimientoDTO> res = new();
                var movimiento = _mapper.Map<Movimiento>(movimientoDTO);
                Movimiento movimientoNuevo = await _movimientoService.AddMovimientoAsync(movimiento);
                res.Success = true;
                res.Message = "OK";
                res.Data = _mapper.Map<MovimientoDTO>(movimientoNuevo);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMovimientoAsync([FromBody] MovimientoDTO movimientoDTO) {
            try {

                ApiResponse<bool> res = new();
                var movimiento = _mapper.Map<Movimiento>(movimientoDTO);
                bool success = await _movimientoService.UpdateMovimientoAsync(movimiento);
                res.Success = true;
                res.Data = success;
                res.Message = success ? "OK" : "Error al actualizar";

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimientoAsync(int id) {
            try {
                ApiResponse<bool> res = new();
                bool success = await _movimientoService.DeleteMovimientoAsync(id);
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
