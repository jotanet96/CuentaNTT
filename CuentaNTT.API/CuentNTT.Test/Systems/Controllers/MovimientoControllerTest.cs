using AutoMapper;
using CuentaNTT.API.Controllers;
using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CuentNTT.Test.Systems.Controllers {
    public class MovimientoControllerTest {
        
        [Fact]
        public async Task GetMovimientoById_OnSuccess_ReturnsCode200() {
            //NSubstitute -> Simula las interfaces para los constructores
            var movimientoService = Substitute.For<IMovimientoService>();
            var mapper = Substitute.For<IMapper>();

            //Arrange -> Lo que queremos que pase
            var action = new MovimientoController(movimientoService, mapper);

            //Act -> Llamada al metodo
            var result = (OkObjectResult)await action.GetMovimientoByIdAsync(1);

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task AddMovimientoAsync_OnSuccess_ReturnsCode200() {
            //NSubstitute -> Simula las interfaces para los constructores
            var movimientoService = Substitute.For<IMovimientoService>();
            var mapper = Substitute.For<IMapper>();
            MovimientoDTO movimiento = new MovimientoDTO();
            movimiento.Fecha = DateTime.Now;
            movimiento.TipoMovimiento = "Debito";
            movimiento.Valor = 540.00;
            movimiento.CuentaId = "496825";

            //Arrange -> Lo que queremos que pase
            var action = new MovimientoController(movimientoService, mapper);

            //Act -> Llamada al metodo
            var result = (OkObjectResult)await action.AddMovimientoAsync(movimiento);

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(200);
        }

    }
}