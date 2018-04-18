using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

//Not the best way to do things, but this will do for noow.
namespace ScribeBot.Wrappers.Proxies
{
    /// <summary>
    /// Proxy for Selenium's WebDriver.
    /// </summary>
    [MoonSharpUserData]
    class WebDriver
    {
        private ChromeDriver driver;

        /// <summary>
        /// Creates an instance of chrome driver.
        /// </summary>
        /// <param name="chromeDriverPath">The chrome driver service path.</param>
        /// <returns>An instance of chrome driver.</returns>
        public static WebDriver Create(string chromeDriverPath)
        {
            var instance = new WebDriver();
            var options = new ChromeOptions();

            options.AddArgument("--dns-prefetch-disable");

            instance.driver = new ChromeDriver(chromeDriverPath, options);

            return instance;
        }

        /// <summary>
        /// Gets the title of current browser window.
        /// </summary>
        public string Title => driver.Title;

        /// <summary>
        /// Navigate to a specified website.
        /// </summary>
        /// <param name="url">URL of a website, starting with 'http://'</param>
        public void GoToUrl(string url) => driver.Navigate().GoToUrl(url);

        /// <summary>
        /// Refresh current page.
        /// </summary>
        public void Refresh() => driver.Navigate().Refresh();

        /// <summary>
        /// Close web driver.
        /// </summary>
        public void Close() => driver.Quit();

        /// <summary>
        /// Send key press.
        /// </summary>
        /// <param name="key">Key to emulate.</param>
        public void SendKeyPress(string key) => driver.Keyboard.PressKey(key);

        /// <summary>
        /// Send key release.
        /// </summary>
        /// <param name="key">Key to emulate.</param>
        public void SendKeyRelease(string key) => driver.Keyboard.ReleaseKey(key);

        /// <summary>
        /// Send a sequence of key presses and releases.
        /// </summary>
        /// <param name="keySequence">Sequence of keys to emulate.</param>
        public void SendKeys(string keySequence) => driver.Keyboard.SendKeys(keySequence);

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="id">ID to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElement[] FindElementsById(string id)
        {
            var elems = new List<WebElement>();

            driver.FindElementsById(id).ToList().ForEach(x => elems.Add(new WebElement(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="name">Class name to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElement[] FindElementsByClass(string name)
        {
            var elems = new List<WebElement>();

            driver.FindElementsByClassName(name).ToList().ForEach(x => elems.Add(new WebElement(x)));

            return elems.ToArray();
        }
    }
}
