﻿using AutoMapper;
using CuentaNTT.Core.DTOs;
using CuentaNTT.Core.Models;
using CuentaNTT.Core.Response;
using Microsoft.AspNetCore.Mvc;
using CuentaNTT.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CuentaNTT.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]

    public class CuentaController : Controller {

        private readonly IMapper _mapper;
        private readonly ICuentaService _cuentaService;

        public CuentaController(ICuentaService cuentaService, IMapper mapper) {
            _mapper = mapper;
            _cuentaService = cuentaService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            try {

                ApiResponse<IEnumerable<CuentaDTO>> res = new();
                var lstCuentas = await _cuentaService.GetCuentasAsync();
                res.Data = _mapper.Map<IEnumerable<CuentaDTO>>(lstCuentas);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ByClientId/{idCliente}", Name = "GetCuentasByClientIdAsync")]
        public async Task<IActionResult> GetCuentasByClientIdAsync(int idCliente) {
            try {

                ApiResponse<IEnumerable<CuentaDTO>> res = new();
                var lstCuentas = await _cuentaService.GetCuentasByClientIdAsync(idCliente);
                res.Data = _mapper.Map<IEnumerable<CuentaDTO>>(lstCuentas);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ByNumeroCuenta/{numeroCuenta}", Name = "GetCuentaByNumeroCuentaAsync")]
        public async Task<IActionResult> GetCuentaByNumeroCuentaAsync(string numeroCuenta) {
            try {
                var cuenta = await _cuentaService.GetCuentaByNumeroCuentaAsync(numeroCuenta);
                ApiResponse<CuentaDTO> res = new();
                res.Data = _mapper.Map<CuentaDTO>(cuenta);

                return Ok(res);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}", Name = "GetCuentaByIdAsync")]
        public async Task<IActionResult> GetCuentaByIdAsync(int id) {
            try {
                var cliente = await _cuentaService.GetCuentaByIdAsync(id);
                ApiResponse<CuentaDTO> res = new();
                res.Data = _mapper.Map<CuentaDTO>(cliente);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddCuentaAsync(CuentaDTO cuentaDTO) {

            if (cuentaDTO == null) {
                return BadRequest(Constants.OBJECTISNULL);
            }
            
            try {
                ApiResponse<CuentaDTO> res = new();
                var cuenta = _mapper.Map<Cuenta>(cuentaDTO);
                Cuenta cuentaNuevo = await _cuentaService.AddCuentaAsync(cuenta);
                res.Success = true;
                res.Message = "OK";
                res.Data = _mapper.Map<CuentaDTO>(cuentaNuevo);

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCuentaAsync([FromBody] CuentaDTO cuentaDTO) {
            try {
                if(cuentaDTO == null) {
                    return BadRequest(Constants.OBJECTISNULL);
                }

                ApiResponse<bool> res = new();
                var cuenta = _mapper.Map<Cuenta>(cuentaDTO);
                bool success = await _cuentaService.UpdateCuentaAsync(cuenta);
                res.Success = true;
                res.Data = success;
                res.Message = success ? "OK" : "Error al actualizar";

                return Ok(res);

            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentaAsync(int id) {
            try {
                ApiResponse<bool> res = new();
                bool success = await _cuentaService.DeleteCuentaAsync(id);
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
