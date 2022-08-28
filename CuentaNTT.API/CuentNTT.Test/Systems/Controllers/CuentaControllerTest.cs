using AutoMapper;
using CuentaNTT.API.Controllers;
using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CuentNTT.Test.Systems.Controllers {
    public class CuentaControllerTest {

        [Fact]
        public async Task UpdateCuenta_OnSuccess_ReturnsCode200() {
            //NSubstitute -> Simula las interfaces para los constructores
            var cuentaService = Substitute.For<ICuentaService>();
            var mapper = Substitute.For<IMapper>();

            //Arrange -> Lo que queremos que pase
            var action = new CuentaController(cuentaService, mapper);

            //Act -> Llamada al metodo
            var result = (OkObjectResult)await action.GetCuentaByNumeroCuentaAsync("225487");//numeroCuenta=225487

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task AddCuenta_BadRequest_ReturnsCode400() {
            //NSubstitute -> Simula las interfaces para los constructores
            var cuentaService = Substitute.For<ICuentaService>();
            var mapper = Substitute.For<IMapper>();
            CuentaDTO cuenta = null;

            //Arrange -> Lo que queremos que pase
            var action = new CuentaController(cuentaService, mapper);

            //Act -> Llamada al metodo
            var result = (BadRequestObjectResult)await action.AddCuentaAsync(cuenta);//id=7777777

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(400);
        }


    }
}