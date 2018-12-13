using System;
using System.Collections.Generic;
using System.Threading;
using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AC.SeleniumDriver
{
    /// <summary>
    /// The page base class.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public class PageBase : IPageBase
    {
        protected IWebDriver webDriver;

        protected WebDriverWait webDriverWait;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBase"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public PageBase(ISetUp setUpWebDriver)
        {
            this.webDriver = setUpWebDriver.LaunchDriver();

            if (this.webDriver != null)
            {
                this.webDriverWait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(15));
            }
        }

        /// <summary>
        /// The wait until.
        /// </summary>
        /// <param name="seconds">
        /// The seconds.
        /// </param>
        protected void WaitUntil(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        /// The click element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        protected void ClickElement(IWebElement element)
        {
            WaitUntilElementIsVisible(element);
            element.Click();
        }

        /// <summary>
        /// The click element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        protected void WaitUntilElementIsVisible(IWebElement element)
        {
            this.WaitUntilElementIsClickable(element);            
        }

        /// <summary>
        /// The send keys element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="keys">
        /// The keys.
        /// </param>
        protected void SendKeysElement(IWebElement element, string keys)
        {
            this.WaitUntilElementIsClickable(element);
            element.SendKeys(keys);
        }


        /// <summary>
        /// The clear element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        protected void ClearElement(IWebElement element)
        {
            this.WaitUntilElementIsClickable(element);
            element.Clear();
        }

        /// <summary>
        /// The is element enabled.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected bool IsElementEnabled(IWebElement element)
        {
            try
            {
                return element.Displayed && element.Enabled;
            }
            catch
            {
                return false;
            }
        }

		/// <summary>
		/// The is element enabled.
		/// </summary>
		/// <param name="element">
		/// The element.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		protected bool IsElementsEnabled(IList<IWebElement> list)
		{
			SetUpDriver driver = new SetUpDriver();

			try
			{
				if (list.Count < 1)
				{
					driver.ScrollDown();
					return list[0].Displayed && list[0].Enabled;
				}
			}
			catch (Exception ex)
			{
				driver.ScrollUp();
				throw new Exception($"Element {list.ToString()} has not been found", ex);
			}
			return false;
		}

		/// <summary>
		/// The wait until element.
		/// </summary>
		/// <param name="element">
		/// The element.
		/// </param>
		private void WaitUntilElementIsClickable(IWebElement element)
        {
            this.webDriverWait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(15));
            this.webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        //TBD
        /*
        public bool IsElementVisible(string element)
        {
            return webDriver.FindElements(By.XPath (element)).Count > 0
                && webDriver.FindElement(By.XPath (element)).Displayed;
        }
        

        public bool IsElementNotVisible(string element)
        {
            return !IsElementVisible(element);
        }*/

    }
}