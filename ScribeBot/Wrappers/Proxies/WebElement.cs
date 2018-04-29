using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace ScribeBot.Wrappers.Proxies
{
    /// <summary>
    /// Proxy for Selenium's IWebElement interface.
    /// </summary>
    [MoonSharpUserData]
    class WebElement
    {
        private IWebElement element;

        /// <summary>
        /// Create an instance of WebElement proxy for a specified IWebElement.
        /// </summary>
        /// <param name="attachment">IWebElement to attach proxy to.</param>
        public WebElement(IWebElement attachment) => element = attachment;

        /// <summary>
        /// Get the elements inner text.
        /// </summary>
        public string Text => element.Text;

        /// <summary>
        /// Returns whether or not the element is enabled.
        /// </summary>
        public bool Enabled => element.Enabled;

        /// <summary>
        /// Returns whether or not the element is displayed.
        /// </summary>
        public bool Displayed => element.Displayed;

        /// <summary>
        /// Returns size of the element.
        /// </summary>
        public Types.Size Size => new Types.Size() { Width = element.Size.Width, Height = element.Size.Height };

        /// <summary>
        /// Returns location of the element.
        /// </summary>
        public Types.Point Location => new Types.Point() { X = element.Location.X, Y = element.Location.Y };

        /// <summary>
        /// Send a sequence of keys to the element.
        /// </summary>
        /// <param name="text">The sequence to send.</param>
        public void SendKeys(string text) => element.SendKeys(text);

        /// <summary>
        /// Emulate a click on the element.
        /// </summary>
        public void Click() => element.Click();

        /// <summary>
        /// Submit form the element is a part of.
        /// </summary>
        public void Submit() => element.Submit();

        /// <summary>
        /// Clear contents of the element.
        /// </summary>
        public void Clear() => element.Clear();

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="id">ID to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElement[] FindElementsById(string id)
        {
            var elems = new List<WebElement>();

            element.FindElements(By.Id(id)).ToList().ForEach(x => elems.Add(new WebElement(x)));

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

            element.FindElements(By.ClassName(name)).ToList().ForEach(x => elems.Add(new WebElement(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="link">Link to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElement[] FindElementsByLinkText(string link)
        {
            var elems = new List<WebElement>();

            element.FindElements(By.LinkText(link)).ToList().ForEach(x => elems.Add(new WebElement(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="link">Link to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElement[] FindElementsByPartialLinkText(string link)
        {
            var elems = new List<WebElement>();

            element.FindElements(By.PartialLinkText(link)).ToList().ForEach(x => elems.Add(new WebElement(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="selector">Css selector to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElement[] FindElementsByCssSelector(string selector)
        {
            var elems = new List<WebElement>();

            element.FindElements(By.CssSelector(selector)).ToList().ForEach(x => elems.Add(new WebElement(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="xpath">XPath string to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElement[] FindElementsByXPath(string xpath)
        {
            var elems = new List<WebElement>();

            element.FindElements(By.XPath(xpath)).ToList().ForEach(x => elems.Add(new WebElement(x)));

            return elems.ToArray();
        }

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="name">Name to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElement[] FindElementsByName(string name)
        {
            var elems = new List<WebElement>();

            element.FindElements(By.Name(name)).ToList().ForEach(x => elems.Add(new WebElement(x)));

            return elems.ToArray();
        }
    }
}
