using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace test
{
	public class BaseTest
	{
		protected IWebDriver driver;

		[BeforeScenario]
		protected virtual void SetUp()
		{
			DesiredCapabilities capability = DesiredCapabilities.Firefox();
			capability.SetCapability("browserstack.user", "<USERNAME>");
			capability.SetCapability("browserstack.key", "<PASSWORD>");
			capability.SetCapability("browser", "Edge");

			driver = new RemoteWebDriver(
				new Uri("http://hub.browserstack.com/wd/hub/"), capability
			);

			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
		}

		[AfterScenario]
		protected virtual void TearDown()
		{
			driver.Close();
			driver.Quit();
			driver.Dispose();
		} 
	}
}