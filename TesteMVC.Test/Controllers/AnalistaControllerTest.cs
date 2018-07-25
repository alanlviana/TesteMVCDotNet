using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TesteMVC.Models;
using TesteMVC.Models.ViewModel;
using TesteMVC.Repositories;
using Xunit;

namespace TesteMVC.Controllers{
    public class AnalistaControllerTest{
        [Fact]
        public void Formulario_RetornaAViewResult_ComAnalistaViewModel(){
            var controller = criarControllerConfigurado();
            var result = controller.Formulario(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<AnalistaViewModel>(viewResult.ViewData.Model);
            
            Assert.Equal("Alan", model.Nome);
            Assert.Equal(1, model.Id);
        }
        [Fact]
        public void Formulario_RetornaStatusCodeResultCom404(){
            var controller = criarControllerConfigurado();
            var result = controller.Formulario(2);

            var viewResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, viewResult.StatusCode);
        }
        [Fact]
        public void ConfirmarExcluir_RetornaStatusCodeResultCom404(){
            var controller = criarControllerConfigurado();
            var result = controller.ConfirmarExcluir(2);

            var viewResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(404, viewResult.StatusCode);
        }

        private AnalistaController criarControllerConfigurado(){
            var analistaRepositoryMock = new Mock<IAnalistaRepository>();
            // Configurar Mock
            analistaRepositoryMock.Setup(m => m.BuscarPorCodigo(1)).Returns(buscaAnalista1());
            analistaRepositoryMock.Setup(m => m.BuscarPorCodigo(2)).Returns(buscaAnalistaNulo());


            var controller = new AnalistaController(analistaRepositoryMock.Object);
            return controller;
        }

        private Analista buscaAnalistaNulo()
        {
            return null;
        }

        private Analista buscaAnalista1()
        {
            return new Analista(){
                Id = 1,
                Nome = "Alan"
            };
        }
    }
}