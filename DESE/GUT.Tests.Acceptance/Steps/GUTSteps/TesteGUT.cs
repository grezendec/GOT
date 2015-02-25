using GUT.Tests.Acceptance.SeleniumHelper;
using GUT.Tests.Acceptance.Steps.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GUT.Tests.Acceptance.Steps
{
    class TesteGUT : Steps.Infrastructure.StepDefinitionBase
    {
        [Then(@"deve aparecer a imagem do caminhao")]
        public void EntaoDeveAparecerAImagemDoCaminhao()
        {
            //Exemplos
            
            //WebBrowser.Current.Navigate().GoToUrl(string.Format("{0}/Nota/Nova", AppUrl));

            //WebBrowser.Current.WaitCompleteAjaxCallBack();

            //WebBrowser.Current.FindElement(By.XPath(string.Format("//*[@id='main']/div/div/table/tbody/tr[normalize-space(td[1]) = '{0}']/td[5]/a", noteDesc)));

            //WebBrowser.Current.FindElementWait(By.XPath(string.Format("//li[text() = '{0}']", className)), 15).Click();
            
        }

    }
}
