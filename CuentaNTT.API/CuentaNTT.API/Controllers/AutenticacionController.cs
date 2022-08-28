using CuentaNTT.Business.Helper;
using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace CuentaNTT.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : Controller {

        private readonly ILogger<AutenticacionController> _logger;
        private readonly IClienteService _clienteService;
        private readonly IConfiguration _config;


        public AutenticacionController(IClienteService clienteService, IConfiguration configuration, ILogger<AutenticacionController> logger) {
            _clienteService = clienteService;
            _config = configuration;
            _logger = logger;
        }

        // POST: api/<AutenticacionController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login login) {

            _logger.LogInformation($"[AutenticacionController] Inicio de método: {MethodBase.GetCurrentMethod().Name}");

            try {
                var usuario_ = await _clienteService.GetClienteByUsername(login.ClienteId);
                //var usuario_ = await context.usuario.Where(u => u.Username == usuario.Sic_usu_username).FirstOrDefaultAsync();

                if (usuario_ == null) { return NotFound(ErrorHelper.Response(404, "Usuario no encontrado.")); }
                if (usuario_.Estado == true) { return NotFound(ErrorHelper.Response(404, "Usuario no encontrado.")); }

                if (HashHelper.CheckHash(login.Contrasena, usuario_.Contrasena, usuario_.Salt)) {
                    var secretKey = _config.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, login.ClienteId));

                    var tokenDescriptor = new SecurityTokenDescriptor() {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    string bearer_token = tokenHandler.WriteToken(createdToken);

                    _logger.LogInformation($"[AutenticacionController] Inicio de método: {MethodBase.GetCurrentMethod().Name}");

                    return Ok(bearer_token);

                } else {

                    _logger.LogInformation($"[AutenticacionController] Inicio de método: {MethodBase.GetCurrentMethod().Name}");

                    return Forbid();
                }
            } catch (Exception e) {

                _logger.LogInformation($"[AutenticacionController] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
                
                return BadRequest(e.Message);
            }
        }
    }
}