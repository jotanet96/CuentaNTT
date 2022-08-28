using AutoMapper;
using CuentaNTT.API.Controllers;
using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CuentNTT.Test.Systems.Controllers {
    public class ReporteControllerTest {
        
        [Fact]
        public async Task GetMovimientoById_OnSuccess_ReturnsCode200() {
            //NSubstitute -> Simula las interfaces para los constructores
            var reporteService = Substitute.For<IReporteService>();
            var mapper = Substitute.For<IMapper>();
            DateTime fi = new DateTime(2022, 02, 07);
            DateTime ff = new DateTime(2022, 02, 14);

            //Arrange -> Lo que queremos que pase
            var action = new ReporteController(reporteService, mapper);

            //Act -> Llamada al metodo
            var result = (OkObjectResult) await action.GetReporteAsync("3101020304", fi, ff);

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetAll_OnSuccess_ReturnsCode400() {
            //NSubstitute -> Simula las interfaces para los constructores
            var reporteService = Substitute.For<IReporteService>();
            var mapper = Substitute.For<IMapper>();
            DateTime fi = new DateTime(2022, 02, 07);
            DateTime ff = new DateTime(2022, 02, 14);

            //Arrange -> Lo que queremos que pase
            var action = new ReporteController(reporteService, mapper);

            //Act -> Llamada al metodo
            var result = (BadRequestObjectResult) await action.GetReporteAsync("5101020304", fi, ff);

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(400);
        }

    }
}