using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using GUT.Tests.Acceptance.Extensions;
using OpenQA.Selenium;

namespace GUT.Tests.Acceptance.Steps.Infrastructure
{
    [Binding]
    public abstract class StepDefinitionBase
    {
        protected internal string AppUrl { get { return ConfigurationManager.AppSettings["AppUrl"]; } }
    }
}
