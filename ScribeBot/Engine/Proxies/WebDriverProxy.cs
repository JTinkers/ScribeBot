using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using MoonSharp.Interpreter;

namespace ScribeBot.Engine.Proxies
{
    /// <summary>
    /// Proxy for Selenium's WebDriver.
    /// </summary>
    [MoonSharpUserData]
    class WebDriverProxy
    {
        /// <summary>
        /// Creates an instance of chrome driver.
        /// </summary>
        /// <returns>An instance of chrome driver.</returns>
        public static WebDriverProxy Create()
        {
            var instance = new WebDriverProxy();
            var options = new ChromeOptions();
            options.AddArgument("--dns-prefetch-disable");

            instance.Driver = new ChromeDriver(DefaultDriver, options);

            return instance;
        }

        static WebDriverProxy()
        {
            DefaultDriver.HideCommandPromptWindow = true;
        }

        /// <summary>
        /// Default ChromeDriver with settings unavailable after driver creation.
        /// </summary>
        static ChromeDriverService DefaultDriver { get; set; } = ChromeDriverService.CreateDefaultService("Library Data/ChromeDriver");

        /// <summary>
        /// Driver instance that proxy is attached to.
        /// </summary>
        public ChromeDriver Driver { get; private set; }

        /// <summary>
        /// Gets the title of current browser window.
        /// </summary>
        public string Title => Driver.Title;

        /// <summary>
        /// Gets the url of currently open webpage.
        /// </summary>
        public string Url => Driver.Url;

        /// <summary>
        /// Navigate to a specified website.
        /// </summary>
        /// <param name="url">URL of a website, starting with 'http://'</param>
        public void GoToUrl(string url) => Driver.Navigate().GoToUrl(url);

        /// <summary>
        /// Refresh current page.
        /// </summary>
        public void Refresh() => Driver.Navigate().Refresh();

        /// <summary>
        /// Close web driver.
        /// </summary>
        public void Close() => Driver.Quit();

        /// <summary>
        /// Send key press.
        /// </summary>
        /// <param name="key">Key to emulate.</param>
        public void SendKeyPress(string key) => Driver.Keyboard.PressKey(key);

        /// <summary>
        /// Send key release.
        /// </summary>
        /// <param name="key">Key to emulate.</param>
        public void SendKeyRelease(string key) => Driver.Keyboard.ReleaseKey(key);

        /// <summary>
        /// Send a sequence of key presses and releases.
        /// </summary>
        /// <param name="keySequence">Sequence of keys to emulate.</param>
        public void SendKeys(string keySequence) => Driver.Keyboard.SendKeys(keySequence);

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="id">ID to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElementProxy[] FindElementsById(string id)
        {
            var elems = new List<WebElementProxy>();

            Driver.FindElementsById(id).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="name">Class name to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElementProxy[] FindElementsByClass(string name)
        {
            var elems = new List<WebElementProxy>();

            Driver.FindElementsByClassName(name).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="link">Link to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElementProxy[] FindElementsByLinkText(string link)
        {
            var elems = new List<WebElementProxy>();

            Driver.FindElements(By.LinkText(link)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="link">Link to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElementProxy[] FindElementsByPartialLinkText(string link)
        {
            var elems = new List<WebElementProxy>();

            Driver.FindElements(By.PartialLinkText(link)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="selector">Css selector to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElementProxy[] FindElementsByCssSelector(string selector)
        {
            var elems = new List<WebElementProxy>();

            Driver.FindElements(By.CssSelector(selector)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="xpath">XPath string to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElementProxy[] FindElementsByXPath(string xpath)
        {
            var elems = new List<WebElementProxy>();

            Driver.FindElements(By.XPath(xpath)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="name">Name to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElementProxy[] FindElementsByName(string name)
        {
            var elems = new List<WebElementProxy>();

            Driver.FindElements(By.Name(name)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

            return elems.ToArray();
        }
    }
}
