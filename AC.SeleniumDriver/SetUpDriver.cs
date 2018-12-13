using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using AC.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using Npgsql;
using CL.Configuration;

namespace AC.SeleniumDriver
{
    public class SetUpDriver : ISetUp
    {
        private const string DriverPath = @"\binaries\";
        private static AndroidDriver<RemoteWebElement> androidWebDriver;
        private static ChromeDriver chromeWebDriver;

        //WebBrowser webBrowser = WebBrowser.Chrome;
        WebBrowser webBrowser = WebBrowser.Android;

        private TimeSpan? timeout;

        private enum WebBrowser
        {
            /// <summary>
            /// The android.
            /// </summary>
            Android,

            /// <summary>
            /// The chrome.
            /// </summary>
            Chrome
        }

        /// <summary>
        /// Closes the driver.
        /// </summary>
        public void CloseDriver()
        {
            switch (webBrowser)
            {
                case WebBrowser.Android:
                    androidWebDriver?.Quit();
                    androidWebDriver?.Dispose();
                    androidWebDriver = null;
                    break;
                case WebBrowser.Chrome:
                    chromeWebDriver.Quit();
                    chromeWebDriver.Dispose();
                    chromeWebDriver = null;
                    break;
            }

        }

        /// <summary>
        /// Launches the web driver.
        /// </summary>
        /// <returns>The <see cref="IWebDriver"/></returns>
        public IWebDriver LaunchDriver()
        {
            switch (webBrowser)
            {
                case WebBrowser.Android:
                    return SetUpAppiumAndroidWebDriver();

                case WebBrowser.Chrome:
                    return SetUpSeleniumChromeWebDriver();

                default:
                    return SetUpAppiumAndroidWebDriver();
            }
        }

        /// <summary>
        /// Makes the screenshot.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns>The <see cref="string"/></returns>
        public string MakeScreenshot(string scenario)
        {
            var binDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\screenshot";
            CreateScreenShotFolder(binDirectory);
            var screenshotName = $"{DateTime.UtcNow.ToString("d-M-yyyy HH-mm-ss", CultureInfo.InvariantCulture)}_{scenario}.jpeg";
            var fullPathFile = binDirectory + @"\" + screenshotName;

            if (androidWebDriver != null)
            {
                var screenshot = ((ITakesScreenshot)androidWebDriver).GetScreenshot();
                screenshot.SaveAsFile(fullPathFile, ScreenshotImageFormat.Jpeg);
            }
            else
            {
                var screenshot = ((ITakesScreenshot)chromeWebDriver).GetScreenshot();
                screenshot.SaveAsFile(fullPathFile, ScreenshotImageFormat.Jpeg);
            }
            return fullPathFile;
        }

        /// <summary>
        /// Determines whether [is web driver null].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is web driver null]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDriverNull()
        {
            switch (webBrowser)
            {
                case WebBrowser.Android:
                    return androidWebDriver == null;
                case WebBrowser.Chrome:
                    return chromeWebDriver == null;
                default:
                    return androidWebDriver == null;
            }
        }

        public void ReopenApp()
        {
            androidWebDriver?.CloseApp();
            androidWebDriver?.LaunchApp();
        }

        public void ReopenBrowser()
        {
            SetUpSeleniumChromeWebDriver();
        }

        public void ResetApp()
        {
            androidWebDriver?.ResetApp();
        }

        public void ClearAllCookies()
        {
            chromeWebDriver.Manage().Cookies.DeleteAllCookies();
        }

        /// <summary>
        /// Set phone in Airplane mode.
        /// </summary>
        public void SetAirplaneMode()
        {
            androidWebDriver.ConnectionType = ConnectionType.AirplaneMode;
            Console.WriteLine("Connection Type enabled: " + androidWebDriver.ConnectionType);
        }

        /// <summary>
        /// Set phone in Only Data mode.
        /// </summary>
        public void SetDataOnlyMode()
        {
            androidWebDriver.ConnectionType = ConnectionType.DataOnly;
            Thread.Sleep(TimeSpan.FromSeconds(15));
            Console.WriteLine("Connection Type enabled: " + androidWebDriver.ConnectionType);
        }

        /// <summary>
        /// Set phone in Only Wifi mode.
        /// </summary>
        public void SetWifiOnlyMode()
        {
            androidWebDriver.ConnectionType = ConnectionType.WifiOnly;
            Thread.Sleep(TimeSpan.FromSeconds(15));
            Console.WriteLine("Connection Type enabled: " + androidWebDriver.ConnectionType);
        }

        /// <summary>
        /// Set phone in All Network (Data + Wifi) mode.
        /// </summary>
        public void SetAllNetworkMode()
        {
            androidWebDriver.ConnectionType = ConnectionType.AllNetworkOn;
            Thread.Sleep(TimeSpan.FromSeconds(15));
            Console.WriteLine("Connection Type enabled: " + androidWebDriver.ConnectionType);
        }

        /// <summary>
        /// Click in the Android native BACK button
        /// </summary>
        public void ClickAndroidBack()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            androidWebDriver.PressKeyCode(AndroidKeyCode.Back);
        }

        public void SetSauceLabsTestResult(string result)
        {
            //TODO - Only if SauceLabs
            ((IJavaScriptExecutor)androidWebDriver).ExecuteScript($"sauce:job-result={result}");
        }

        private IWebDriver SetUpSeleniumChromeWebDriver()
        {
            try
            {
                if (chromeWebDriver != null)
                {
                    return chromeWebDriver;
                }

                chromeWebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath);
                chromeWebDriver.Manage().Cookies.DeleteAllCookies();
                chromeWebDriver.Manage().Window.Maximize();

                //--- LOCALHOST ---//
                //chromeWebDriver.Navigate().GoToUrl("http://localhost:4200/login");

                //--- DASHBOARD ---//
                //chromeWebDriver.Navigate().GoToUrl("http://bcn-dashboard.projectschweitzer.net/login");
                //chromeWebDriver.Navigate().GoToUrl("http://staging-dashboard.projectschweitzer.net/login");

                //--- RESULT RELEASE ---//
                chromeWebDriver.Navigate().GoToUrl("http://bcn-resultrelease.projectschweitzer.net/login");
                //chromeWebDriver.Navigate().GoToUrl("http://staging-resultrelease.projectschweitzer.net/login");

                return chromeWebDriver;
            }
            catch (Exception ex)
            {
                CloseDriver();
                throw new Exception("Set up chrome web driver has failed", ex);
            }
        }

        private IWebDriver SetUpAppiumAndroidWebDriver()
        {
            try
            {
                if (androidWebDriver != null)
                {
                    return androidWebDriver;
                }

                var capabilities = new DesiredCapabilities();
                capabilities.SetCapability("deviceName", "Android GoogleAPI Emulator");
                capabilities.SetCapability("accessKey", "c124f813-697e-4ef3-abf8-4dddb0cf4628");
                capabilities.SetCapability("username", "micaerni");
                capabilities.SetCapability("platformVersion", "7");
                capabilities.SetCapability("platformName", "Android");
                capabilities.SetCapability("fullReset", "false");
                capabilities.SetCapability("noReset", "true");
                capabilities.SetCapability("unicodeKeyboard", true);
                capabilities.SetCapability("resetKeyboard", true);
                capabilities.SetCapability("autoAcceptAlerts", true);
                capabilities.SetCapability("autoGrantPermissions", true);
                capabilities.SetCapability("newCommandTimeout", 300);
                // capabilities.SetCapability("app", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath + "com.roche.rmdd.hivmonitor.patientapp.apk");
                capabilities.SetCapability("app", "sauce-storage:com.roche.rmdd.hivmonitor.patientapp.apk");
                capabilities.SetCapability("name", TestConfiguration.CurrentScenario);

                androidWebDriver = new AndroidDriver<RemoteWebElement>(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabilities, TimeSpan.FromSeconds(120));

                GetVersionName();
                //GetAnalyticExperienceRatedFromDatabase();

                return androidWebDriver;
            }
            catch (Exception ex)
            {
                CloseDriver();
                throw new Exception("Set up android web driver has failed", ex);
            }
        }

        /// <summary>
        /// Creates the screen shot folder.
        /// </summary>
        /// <param name="path">The path.</param>
        private void CreateScreenShotFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Executes adb command to get the deviceName.
        /// </summary>
        /// <param name="path">The path.</param>
        private String GetDeviceName()
        {
            //Execute adb command to get the deviceName
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "adb.exe",
                    Arguments = "devices",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            string deviceName = proc.StandardOutput.ReadToEnd().ToString();

            //Extract the deviceName for the capabilities
            deviceName = deviceName.Replace("List of devices attached", "");
            deviceName = deviceName.Replace("	device", "");

            Console.WriteLine("deviceName: " + deviceName);
            return deviceName;
        }

        /// <summary>
        /// Executes adb command to get the deviceName.
        /// </summary>
        /// <param name="path">The path.</param>
        private void GetVersionName()
        {
            //Execute adb command to get the deviceName
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "adb.exe",
                    Arguments = "shell dumpsys package com.roche.rmdd.hivmonitor.patientapp | grep versionName",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            string versionName = proc.StandardOutput.ReadToEnd().ToString();

            Console.WriteLine(versionName);
        }

        /// <summary>
        /// Open the iThemba app menu by swipe gesture.
        /// </summary>
        public void OpenMenuBySwipe()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            int Height = androidWebDriver.Manage().Window.Size.Height;
            int Width = androidWebDriver.Manage().Window.Size.Width;
            int Starty = (int)(Height / 2);
            int Startx = (int)(Width / 90);
            int Endx = (int)(Width * 0.90);
            int Endy = (int)(Height / 2);

            androidWebDriver.Swipe(Startx, Starty, Endx, Endy, 800);
        }

        /// <summary>
        /// Returns the current activity
        /// </summary>
        public String GetCurrentActivityStatus()
        {
            String appStauts = androidWebDriver.CurrentActivity;
            return appStauts;
        }

        /// <summary>
        /// Scroll down.
        /// </summary>
        public void ScrollDown()
        {
            Thread.Sleep(2);
            TouchAction ta = new TouchAction(androidWebDriver);
            ta.Press(115, 655).MoveTo(115, 350).Release().Perform();
        }

        /// <summary>
        /// Moves the Age seekbar.
        /// </summary>
        public void MoveSeekBar(int start, int end, int y)
        {
            // Select till which position you want to move the seekbar
            Random random = new Random();
            double randomDouble = random.NextDouble();
            start = (int)(end * 0.5);
            end = (int)(end * randomDouble);

            //Move it until random end position
            androidWebDriver.Swipe(start, y, end, y, 800);
        }


        /// <summary>
        /// Selects random survey value.
        /// </summary>
        public void SelectRandomSurveyValue(int start, int end, int y)
        {
            // Select till which position you want to move the seekbar
            Random random = new Random();
            double random_x = random.NextDouble() * (end - start) + start;

            /*
            Console.WriteLine("Start: " + start);
            Console.WriteLine("End: " + end);
            Console.WriteLine("Y: " + y);
            Console.WriteLine("Random_x: " + random_x);
            */

            //Move it until random end position
            androidWebDriver.Swipe((int)random_x, y, (int)(random_x + 10), y, 800);
        }



    }
}