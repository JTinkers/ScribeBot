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
        /// <param name="e">IWebElement to attach proxy to.</param>
        public WebElement(IWebElement e)
        {
            element = e;
        }

        /// <summary>
        /// Emulate a click on the element.
        /// </summary>
        public void Click() => element.Click();
    }
}
