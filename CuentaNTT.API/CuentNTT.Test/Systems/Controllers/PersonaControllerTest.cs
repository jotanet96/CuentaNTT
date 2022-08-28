using AutoMapper;
using CuentaNTT.API.Controllers;
using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CuentNTT.Test.Systems.Controllers {
    public class PersonaControllerTest {
        
        [Fact]
        public async Task Post_OnSuccess_ReturnsCode200() {
            //NSubstitute -> Simula las interfaces para los constructores
            var personaeService = Substitute.For<IPersonaService>();
            var mapper = Substitute.For<IMapper>();

            //Arrange -> Lo que queremos que pase
            var action = new PersonaController(personaeService, mapper);
            PersonaDTO persona = new PersonaDTO();
            persona.Nombre = "Jose Lema";
            persona.Identificacion = "3001020304";
            persona.Genero = "Masculino";
            persona.Edad = 20;
            persona.Direccion = "Otavalo sn y principal";
            persona.Telefono = "098254785";

            //Act -> Llamada al metodo
            var result = (OkObjectResult)await action.AddPersonaAsync(persona);

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetAll_BadRequest_ReturnsCode400() {
            //NSubstitute -> Simula las interfaces para los constructores
            var personaeService = Substitute.For<IPersonaService>();
            var mapper = Substitute.For<IMapper>();

            //Arrange -> Lo que queremos que pase
            var action = new PersonaController(personaeService, mapper);

            //Act -> Llamada al metodo
            var result = (BadRequestObjectResult)await action.GetPersonaByIdentificacionAsync("qwerty");

            //Assert -> Afirma Resultado
            result.StatusCode.Should().Be(400);
        }

    }
}