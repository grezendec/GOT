using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SharpTestsEx;
using GUT.Tests.Acceptance.Extensions;
using OpenQA.Selenium;

namespace GUT.Tests.Acceptance.Steps.Infrastructure
{
    [Binding]
    public class Messages
    {
        [Then(@"deve aparecer as mensagens:")]
        public void EntaoDeveAparecerAsMensagens(Table table)
        {
            foreach (var row in table.Rows)
            {
                var value = row["Mensagem"].ToString();
                EntaoDeveAparecerAMensagem(value);
            }

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Then(@"deve aparecer a mensagem ""(.*)""")]
        public void EntaoDeveAparecerAMensagem(string msg)
        {
            WebBrowser.Current.ExistTextWait(msg, 30).Should(string.Format("valor {0} deve estar na tela.", msg)).Be.True();

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }

        [Then(@"o texto ""(.*)"" não deve estar presente")]
        public void EntaoOTextoNaoDeveEstarPresente(string msg)
        {
            try
            {
                WebBrowser.Current.ExistTextWait(msg, 5).Should(string.Format("valor {0} não deve estar na tela.", msg)).Be.False();
            }
            catch (WebDriverTimeoutException)
            {
                //se não encontrar o elemento, está correto
            }

            WebBrowser.Current.WaitCompleteAjaxCallBack();
        }
    }
}
