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
using ScribeBot.Engine.Containers;

namespace ScribeBot.Engine.Proxies
{
    /// <summary>
    /// Proxy for Selenium's IWebElement interface.
    /// </summary>
    [MoonSharpUserData]
    class WebElementProxy
    {
        /// <summary>
        /// Create an instance of WebElement proxy for a specified IWebElement.
        /// </summary>
        /// <param name="attachment">IWebElement to attach proxy to.</param>
        public WebElementProxy(IWebElement attachment) => Element = attachment;

        /// <summary>
        /// IWebElement that WebElementyProxy is attached to.
        /// </summary>
        public IWebElement Element { get; private set; }

        /// <summary>
        /// Get the elements inner text.
        /// </summary>
        public string Text => Element.Text;

        /// <summary>
        /// Returns whether or not the element is enabled.
        /// </summary>
        public bool Enabled => Element.Enabled;

        /// <summary>
        /// Returns whether or not the element is displayed.
        /// </summary>
        public bool Displayed => Element.Displayed;

        /// <summary>
        /// Returns size of the element.
        /// </summary>
        public SizeContainer Size => new SizeContainer() { Width = Element.Size.Width, Height = Element.Size.Height };

        /// <summary>
        /// Returns location of the element.
        /// </summary>
        public PointContainer Location => new PointContainer() { X = Element.Location.X, Y = Element.Location.Y };

        /// <summary>
        /// Send a sequence of keys to the element.
        /// </summary>
        /// <param name="text">The sequence to send.</param>
        public void SendKeys(string text) => Element.SendKeys(text);

        /// <summary>
        /// Emulate a click on the element.
        /// </summary>
        public void Click() => Element.Click();

        /// <summary>
        /// Submit form the element is a part of.
        /// </summary>
        public void Submit() => Element.Submit();

        /// <summary>
        /// Clear contents of the element.
        /// </summary>
        public void Clear() => Element.Clear();

        /// <summary>
        /// Find DOM elements on the website.
        /// </summary>
        /// <param name="id">ID to search by.</param>
        /// <returns>An array of web elements.</returns>
        public WebElementProxy[] FindElementsById(string id)
        {
            var elems = new List<WebElementProxy>();

            Element.FindElements(By.Id(id)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

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

            Element.FindElements(By.ClassName(name)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

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

            Element.FindElements(By.LinkText(link)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

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

            Element.FindElements(By.PartialLinkText(link)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

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

            Element.FindElements(By.CssSelector(selector)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

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

            Element.FindElements(By.XPath(xpath)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

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

            Element.FindElements(By.Name(name)).ToList().ForEach(x => elems.Add(new WebElementProxy(x)));

            return elems.ToArray();
        }
    }
}
