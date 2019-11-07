using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace BDDComSpecFlowDemo.Tests
{
    [Binding]
    public class VisitarADocumentacaoDoSpecFlowSteps
    {
        IE browser = new IE();

        [Given(@"que eu entrei na tela inicial do site SpecFlow")]
        public void DadoQueEuEntreiNaTelaInicialDoSiteSpecFlow()
        {
            browser.GoTo("http://www.specflow.org/");
        }

        [Given(@"cliquei no item ""(.*)"", no menu horizontal do topo")]
        public void DadoCliqueiNoItemNoMenuHorizontalDoTopo(string p0)
        {
            var menuHorizontal = browser.List(Find.ById("menu-main"));

            var itemDocumentacao = menuHorizontal.OwnListItem(Find.ById("menu-item-267"));

            itemDocumentacao.Links[0].Click();

            Assert.IsTrue(browser.Uri.ToString().Equals("http://www.specflow.org/documentation/"));
        }

        [When(@"eu clicar em ""(.*)""")]
        public void QuandoEuClicarEm(string p0)
        {
            var menuVertical = browser.Div(Find.ByClass("gitdoc-toc")).Lists[0];

            var itemConfiguracao = menuVertical.OwnListItems[1]; 

            itemConfiguracao.Links[0].Click();
        }

        [Then(@"devo ser levado para a página  de demonstração da configuração padrão do SpecFlow")]
        public void EntaoDevoSerLevadoParaAPaginaDeDemonstracaoDaConfiguracaoPadraoDoSpecFlow()
        {   
            Assert.IsTrue(browser.Uri.ToString().Equals("http://www.specflow.org/documentation/Configuration/"));
        }

        [Then(@"deve ser exibido um alert dizendo ""(.*)""\.")]
        public void EntaoDeveSerExibidoUmAlertDizendo_(string p0)
        {
           var alert =  browser.Eval(("alert('Olá mundo, eu sou o Watin');"));

            Assert.IsTrue(alert.Length > 0 );
        }
    }
}
