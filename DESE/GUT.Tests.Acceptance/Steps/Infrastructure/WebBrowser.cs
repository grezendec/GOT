using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace GUT.Tests.Acceptance.Steps.Infrastructure
{
    [Binding]
    public class WebBrowser
    {
        public static IWebDriver Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    ScenarioContext.Current["browser"] = GetWebDriver();
                }
                return (IWebDriver)ScenarioContext.Current["browser"];
            }
        }

        private static IWebDriver GetWebDriver()
        {
            var url = ConfigurationManager.AppSettings["SeleniumRemoteServerUrl"].ToString();

            if (string.IsNullOrEmpty(url))
                return new FirefoxDriver();

            var seleniumRemoteServerUrl = new Uri(url);
            DesiredCapabilities capabilities = DesiredCapabilities.Firefox();
            IWebDriver driver = new RemoteWebDriver(seleniumRemoteServerUrl, capabilities);

            return driver;
        }

        [AfterScenario]
        public static void Close()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
            {
                Current.Quit();
            }
        }

    }
}
