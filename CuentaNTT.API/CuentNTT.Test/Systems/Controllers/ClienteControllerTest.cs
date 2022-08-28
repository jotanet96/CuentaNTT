using AutoMapper;
using CuentaNTT.API.Controllers;
using CuentaNTT.Business.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CuentNTT.Test.Systems.Controllers {
    public class ClienteControllerTest {
        
        [Fact]
        public async Task GetById_OnSuccess_ReturnsCode200() {
            //NSubstitute -> Simula las interfaces para los constructores
            var clienteService = Substitute.For<IClienteService>();
            var mapper = Substitute.For<IMapper>();

            //Arrange -> Lo que queremos que pase
            var action = new ClienteController(clienteService, mapper);

            //Act -> Llamada al metodo
            var result = (OkObjectResult)await action.GetClienteByIdAsync(3);//id=3

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task DeleteById_OnSuccess_ReturnsCode200() {

            var clienteService = Substitute.For<IClienteService>();
            var mapper = Substitute.For<IMapper>();

            //Arrange -> Lo que queremos que pase
            var action = new ClienteController(clienteService, mapper);

            //Act -> Llamada al metodo
            var result = (OkObjectResult)await action.DeleteClienteAsync(3);//id=7777777

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(200);
        }


    }
}