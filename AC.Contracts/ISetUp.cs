using OpenQA.Selenium;
using System.Collections.Generic;

namespace AC.Contracts
{
    /// <summary>
    /// Set up configuration.
    /// </summary>
    public interface ISetUp
    {
        /// <summary>
        /// Launches the web driver.
        /// </summary>
        /// <returns>
        /// The <see cref="IWebDriver"/>
        /// </returns>
        IWebDriver LaunchDriver();

        /// <summary>
        /// Makes the screenshot.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns>
        /// The <see cref="string"/>
        /// </returns>
        string MakeScreenshot(string stepName, string scenarioName);

        //string StaticMakeScreenshot(string scenario);

        /// <summary>
        /// Determines whether [is driver null].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is driver null]; otherwise, <c>false</c>.
        /// </returns>
        bool IsDriverNull();

        /// <summary>
        /// Closes the driver.
        /// </summary>
        void CloseDriver();

        /// <summary>
        /// Resets the application.
        /// </summary>
        void ReopenApp();

        /// <summary>
        /// Reopen the browser.
        /// </summary>
        void ReopenBrowser();

        /// <summary>
        /// Closes the application.
        /// </summary>
        void ResetApp();

        /// <summary>
        /// Set phone in Airplane mode.
        /// </summary>
        void SetAirplaneMode();

        /// <summary>
        /// Set phone in Only Data mode.
        /// </summary>
        void SetDataOnlyMode();

        /// <summary>
        /// Set phone in Only Wifi mode.
        /// </summary>
        void SetWifiOnlyMode();

        /// <summary>
        /// Set phone in All Network (Data + Wifi) mode.
        /// </summary>
        void SetAllNetworkMode();

        /// <summary>
        /// Open the iThemba app menu by swipe gesture.
        /// </summary>
        void OpenMenuBySwipe();

        /// <summary>
        /// Returns the activity beeing displayed at the moment of the executin
        /// </summary>
        string GetCurrentActivityStatus();

		/// <summary>
		/// Scroll down.
		/// </summary>
		void ScrollDown();

		/// <summary>
		/// Moves the Age seekbar.
		/// </summary>
		void MoveSeekBar(int start, int end, int y);

        /// <summary>
        /// Click Android native Back Button
        /// </summary>
        void ClickAndroidBack();

        /// <summary>
        /// Selects random survey value.
        /// </summary>
        void SelectRandomSurveyValue(int start, int end, int y);

		/// <summary>
		/// Determines whether APK is in focus.
		/// </summary>
		void IsAtPackage(string expectedActivity);

	}
}