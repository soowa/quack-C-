using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace test
{
	[Binding]
	public class Test : BaseTest
	{
		private string searchQuery = String.Empty;

		[Given(@"I opened google")]
		public void OpenPage()
		{
			driver.Navigate().GoToUrl ("https://www.google.com/");
		}

		[When(@"I search for (.*)")]
		public void EnterData(string query)
		{
			this.searchQuery = query;
			string search_box_xpath = @"//form//input[@type=""text""]";

			IWebElement elem = driver.FindElement(By.XPath(search_box_xpath));
			elem.SendKeys(this.searchQuery);
		}

		[When(@"I hit enter")]
		public void SubmitData()
		{
			string search_box_xpath = @"//form//input[@type=""text""]";

			IWebElement elem = driver.FindElement(By.XPath(search_box_xpath));
			elem.Submit();
			elem.SendKeys(Keys.Return);
		}

		[Then(@"The answer (.*) appears in the calculator")]
		public void VerifyAnswer(int answer)
		{
			StringAssert.AreEqualIgnoringCase(answer.ToString(), driver.FindElement(By.XPath(@"//span[@class=""cwcot""]")).Text);
		}

		[Then(@"The query (.*) appears in the url")]
		public void VerifyUrl(string query)
		{
			StringAssert.Contains(System.Net.WebUtility.UrlEncode(this.searchQuery), this.driver.Url);
		}
	}
}