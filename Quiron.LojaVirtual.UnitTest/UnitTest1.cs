using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.Controllers.HtmlHelpers;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestQuiron
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        //Aula 9
        [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange
            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act

            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(
                 @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                 + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                 + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                );

        }

    }
}
