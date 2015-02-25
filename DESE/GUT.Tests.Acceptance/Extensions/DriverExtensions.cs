using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using GUT.Tests.Acceptance.SeleniumHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUT.Tests.Acceptance.Extensions
{
    public static class DriverExtensions
    {
        public static object ExecuteJavaScript(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }


        public static IWebElement FindElementByjQuery(this IWebDriver driver, FindBy.jQueryBy by)
        {
            IWebElement element = driver.ExecuteJavaScript("return " + by.Selector + ".get(0)") as IWebElement;

            if (element != null)
                return element;
            else
                throw new NoSuchElementException("No element found with jQuery command: jQuery" + by.Selector);
        }

        public static IWebElement FindElementByjQueryWait(this IWebDriver driver, FindBy.jQueryBy by, int timeoutInSeconds = 10)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(d => d.FindElementByjQuery(by));
            }
            return driver.FindElementByjQuery(by);
        }

        public static IWebElement FindElementWait(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Message = string.Format("terminou o tempo limite de {0}s", timeoutInSeconds);
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static bool ExistTextWait(this IWebDriver driver, string text, int timeoutInSeconds = 10)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Message = string.Format("terminou o tempo limite de {0}s", timeoutInSeconds);
                return wait.Until(drv => drv.FindElement(By.XPath(string.Format("//*[contains(.,'{0}')]", text))) != null);
            }

            return driver.FindElement(By.XPath(string.Format("//*[contains(.,'{0}')]", text))) != null;
        }

        public static void WaitCompleteAjaxCallBack(this IWebDriver driver, int timeout = 40)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                if (sw.Elapsed.Seconds > timeout) throw new WebDriverTimeoutException();
                var ajaxIsComplete = (bool)driver.ExecuteJavaScript("return jQuery.isReady && jQuery.active == 0");
                if (ajaxIsComplete)
                    break;
                Thread.Sleep(100);
            }
        }

        public static bool HasElement(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                
                return false;
            }

            return true;
        }
    }
}
