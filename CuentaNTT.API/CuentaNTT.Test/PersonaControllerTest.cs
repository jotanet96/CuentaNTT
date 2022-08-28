using CuentaNTT.API.Controllers;
using NUnit;

namespace CuentaNTT.Test {
    public class Tests {

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void AddClienteAsyncTest() {
            //Arange

            var dataStroe = A.Fake<IRecipeDatoStore>();

            var controller = new ClienteController();

            //Act
            
            //Assert
            Assert.Pass();
        }
    }
}