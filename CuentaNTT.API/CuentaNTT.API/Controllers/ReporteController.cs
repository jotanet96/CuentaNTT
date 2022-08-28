using AutoMapper;
using CuentaNTT.Core.DTOs;
using CuentaNTT.Core.Models;
using CuentaNTT.Core.Response;
using Microsoft.AspNetCore.Mvc;
using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.Exceptions;

namespace CuentaNTT.API.Controllers {
        [ApiController]
        [Route("api/[controller]")]

    public class ReporteController : Controller {

        private readonly IMapper _mapper;
        private readonly IReporteService _reporteService;

        public ReporteController(IReporteService reporteService, IMapper mapper) {
            _mapper = mapper;
            _reporteService = reporteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReporteAsync([FromQuery] string identificacion, [FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin) {
            try {

                ApiResponse<IEnumerable<ReporteMovimiento>> res = new();
                var reporteMovimientos = await _reporteService.GetMovimientosByFechaAsync(identificacion, fechaInicio, fechaFin);
                res.Data = _mapper.Map<IEnumerable<ReporteMovimiento>>(reporteMovimientos);

                if (!reporteMovimientos.Any()) {
                    return BadRequest(Constants.NONACCOUNT);
                }

                return Ok(res);

            } catch (BusinessException e) {
                return BadRequest(e.Message);
            }
        }
    }
}
