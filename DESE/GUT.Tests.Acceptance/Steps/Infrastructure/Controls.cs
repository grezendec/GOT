using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SharpTestsEx;
using GUT.Tests.Acceptance.Extensions;
using OpenQA.Selenium.Support.UI;

namespace GUT.Tests.Acceptance.Steps.Infrastructure
{
    [Binding]
    public class Controls
    {
        [Given(@"eu preenchi o campo ""(.*)"" com ""(.*)""")]
        [When(@"eu preencher o campo ""(.*)"" com ""(.*)""")]
        public void QuandoEuPreencherOCampoCom(string field, string value)
        {
            IWebElement userKey = WebBrowser.Current.FindElementWait(By.Id(field), 20);

            userKey.Clear();
            userKey.SendKeys(value);

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Given(@"o campo ""(.*)"" perdeu o foco")]
        [When(@"o campo ""(.*)"" perder o foco")]
        public void QuandoOCampoPerderOFoco(string field)
        {
            WebBrowser.Current.ExecuteJavaScript(string.Format("return document.getElementById('{0}').blur()", field));

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Then(@"o campo ""(.*)"" deve estar preenchido com ""(.*)""")]
        public void EntaoOCampoDeveEstarPreenchidoCom(string field, string value)
        {
            WebBrowser.Current.FindElementWait(By.Id(field), 20).GetAttribute("value").Should().Be(value);

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Then(@"a lista ""(.*)"" deve estar com o valor ""(.*)"" selecionado")]
        public void EntaoAListaDeveEstarComOValorSelecionado(string list, string value)
        {
            var selectElementVisitor = new SelectElement(WebBrowser.Current.FindElementWait(By.Id(list), 20));
            selectElementVisitor.SelectedOption.Text.Equals(value);

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Given(@"eu preenchi os campos:")]
        [When(@"eu preencher os campos:")]
        public void QuandoEuPreencherOsCampos(Table table)
        {
            /*Formato
             * | field 1 | field 2 | ... | field n |
             * | value 1 | value 2 | ... | value n | 
             * */

            for(int col = 0; col < table.Header.Count(); col++)
            {
                QuandoEuPreencherOCampoCom(table.Header.ElementAt(col), table.Rows[0].Values.ElementAt(col));
            }

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Then(@"o\(s\) seguinte\(s\) campo\(s\) deve\(m\) estar vazio\(s\):")]
        public void EntaoOsSeguintesCamposDevemEstarVazios(Table table)
        {
            /*Formato
             * | field 1 | field 2 | ... | field n |
             * */

            for (int col = 0; col < table.Header.Count(); col++)
            {
                EntaoOCampoDeveEstarPreenchidoCom(table.Header.ElementAt(col), "");
            }

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [When(@"eu preencher a lista ""(.*)"" com o valor ""(.*)""")]
        [Given(@"eu preenchi a lista ""(.*)"" com o valor ""(.*)""")]
        public void DadoEuPreenchiAListaComOValor(string list, string value)
        {
            var selectElementVisitor = new SelectElement(WebBrowser.Current.FindElementWait(By.Id(list), 20));
            selectElementVisitor.SelectByText(value);

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Given(@"eu cliquei no elemento ""(.*)""")]
        public void DadoEuCliqueiNoElemento(string elementId)
        {
            WebBrowser.Current.FindElementWait(By.Id(elementId), 20).Click();

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }
    }
}
