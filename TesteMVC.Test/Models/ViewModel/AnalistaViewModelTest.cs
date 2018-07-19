using System;
using TesteMVC.Models.ViewModel;
using Xunit;

namespace TesteMVC.Test.Model.ViewModel
{
    public class AnalistaViewModelTest
    {
        [Fact]
        public void DevePoderInstanciarViewModelSemParametros(){
            AnalistaViewModel analistaViewModel = new AnalistaViewModel();
            Assert.NotNull(analistaViewModel);
        }
    }
}
