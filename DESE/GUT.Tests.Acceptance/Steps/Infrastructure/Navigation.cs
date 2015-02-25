using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SharpTestsEx;
using GUT.Tests.Acceptance.Extensions;
using System.Configuration;

namespace GUT.Tests.Acceptance.Steps.Infrastructure
{
    [Binding]
    public class Navigation
    {
        [When(@"eu entro com (.*) na barra de endereços")]
        public void QuandoEuEntroUrlNaBarraDeEnderecos(string url)
        {
            WebBrowser.Current.Navigate().GoToUrl(url);
        }

        [Given(@"eu cliquei no botão (.*)")]
        [When(@"clicar no botão (.*)")]
        public void QuandoPressionarOBotaoBtnG(string buttonValue)
        {
            var button = WebBrowser.Current.FindElementWait(By.XPath(string.Format("//input[@value='{0}']", buttonValue)),10);
            button.Click();

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Then(@"A página com o título ""(.*)"" deve ser exibida")]
        public void EntaoAPaginaComOTituloDeveSerExibida(string title)
        {
            WebBrowser.Current.Title.Should().Be.Equals(title);
        }

        [Then(@"devo está na página (.*)")]
        public void EntaoQueEuEstouNaPagina(string url)
        {
            WebBrowser.Current.Url.Should().Be.Equals(url);
        }

        [Given(@"que eu cliquei no link ""(.*)""")]
        [When(@"eu clicar no link ""(.*)""")]
        public void QuandoEuClicarNoLink(string linkText)
        {
            WebBrowser.Current.FindElementWait(By.LinkText(linkText),30).Click();

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [When(@"eu entro na tela inicial do sistema logado como Administrador")]
        [Given(@"eu entro na tela inicial do sistema logado como Administrador")]
        public void DadoEuEntroNaTelaInicialDoSistemaLogadoComoAdministrador()
        {
            WebBrowser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["AppUrl"]);

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }
    }
}
