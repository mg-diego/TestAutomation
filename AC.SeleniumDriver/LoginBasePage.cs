using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Dashboard Login page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.ILoginBasePage" />
    public class LoginBasePage : PageBase, ILoginBasePage
    {

        [FindsBy(How = How.ClassName, Using = "mat-button-wrapper")]
        private IWebElement btnLogin;

        [FindsBy(How = How.Name, Using = "Login")]
        private IWebElement inputUsername;

        [FindsBy(How = How.Name, Using = "Password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//*[(@class='btn btn-primary') and (@type='submit')]")]
        private IWebElement btnExternalLogin;

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        private IWebElement txtInvalidCredentialsPopUp;


        /// <summary>
        /// Initializes a new instance of the <see cref="LoginBasePage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public LoginBasePage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }



        /// <summary>
        /// Click in Login button.
        /// </summary>
        public void ClickLoginButton()
        {
            ClickElement(btnLogin);
        }

        /// <summary>
        /// Click in Login button.
        /// </summary>
        public void ClickExternalLoginButton()
        {
            ClickElement(btnExternalLogin);
        }

        /// <summary>
        /// Enter the username.
        /// </summary>
        public void EnterUsername(UserLogin user)
        {
            ClearElement(inputUsername);
            SendKeysElement(this.inputUsername, user.UserId);
        }

        /// <summary>
        /// Enter the username.
        /// </summary>
        public void EnterPassword(UserLogin user)
        {
            ClearElement(inputPassword);
            SendKeysElement(this.inputPassword, user.password);
        }

        /// <summary>
        /// Determines whether [is at invalid login page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at invalid login page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtLoginBasePage()
        {
            return btnLogin.Displayed;
        }

        /// <summary>
        /// Determines whether [is at invalid login page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at invalid login page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtInvalidLogin()
        {
            return txtInvalidCredentialsPopUp.Displayed;
        }
    }
}

