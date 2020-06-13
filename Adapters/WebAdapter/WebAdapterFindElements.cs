// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebAdapterFindElements.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WebAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.Adapters.WebAdapter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Mir.Stf.Utilities;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// The web adapter.
    /// </summary>
    public partial class WebAdapter
    {
        /// <summary>
        /// The find element.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <returns>
        /// The <see cref="IWebElement"/>.
        /// </returns>
        public IWebElement FindElement(By by)
        {
            IWebElement retVal;

            HandleCheckForErrorsOnAllPages();

            try
            {
                StfLogger.LogDebug($"Looking for FindElement [{by}]");
                retVal = WebDriver.FindElement(by);
            }
            catch (Exception ex)
            {
                // this might not be an error - if we are looking for something to become rendered in a loop....
                StfLogger.LogDebug($"Couldn't find element [{by}] - got error [{ex.Message}]");
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// The find element using an explicit wait timeout
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <param name="secondsToWait">
        /// The max number of seconds to wait.
        /// </param>
        /// <returns>
        /// The <see cref="IWebElement"/>.
        /// </returns>
        public IWebElement FindElement(By by, int secondsToWait)
        {
            IWebElement retVal;

            SetImplicitlyWait(1);
            try
            {
                var webDriverWaiter = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(secondsToWait));

                retVal = webDriverWaiter.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception ex)
            {
                // this might not be an error - if we are looking for something to become rendered in a loop....
                StfLogger.LogInternal("Couldn't find element [{0}]. Waited for [{1}] seconds - got error [{2}]", by, secondsToWait, ex.Message);
                retVal = null;
            }

            ResetImplicitlyWait();
            return retVal;
        }

        /// <summary>
        /// The find elements.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <returns>
        /// The collection of elements that matches the search term.
        /// </returns>
        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            IReadOnlyCollection<IWebElement> retVal;

            try
            {
                retVal = WebDriver.FindElements(by);
            }
            catch (Exception ex)
            {
                // this might not be an error - if we are looking for something to become rendered in a loop....
                StfLogger.LogDebug($"Couldn't find one or more elements matching [{by}] - got error [{ex.Message}]");
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// The move to element. Used to scroll to an element hidden...
        /// </summary>
        /// <param name="elem">
        /// The elem.
        /// </param>
        public void MoveToElement(IWebElement elem)
        {
            WebDriver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", elem);
        }

        /// <summary>
        /// The handle check for errors on all pages.
        /// </summary>
        /// <exception cref="Exception">
        /// If a string is found the WebDriver is set to null, and an Exception is thrown
        /// </exception>
        private void HandleCheckForErrorsOnAllPages()
        {
            if (!Configuration.CheckForErrorsOnAllPages)
            {
                return;
            }

            StfLogger.LogHeader($"WebAdapter configured for checking errors on all pages matching [{Configuration.CheckForErrorsOnAllPagesText}]");

            var sourceText = WebDriver.PageSource;
            var substringsInSource = CheckForSubstringsInSource(sourceText, Configuration.CheckForErrorsOnAllPagesText);

            if (!string.IsNullOrEmpty(substringsInSource))
            {
                var errorMsg = $"Found something matching [{Configuration.CheckForErrorsOnAllPagesText}] on page";

                StfLogger.LogError($"Found [{substringsInSource}] on page");
                StfLogger.LogHeader("****************************");
                StfLogger.LogHeader("*** FOUND ERRORS ON PAGE ***");
                StfLogger.LogHeader("****************************");
                StfLogger.LogScreenshot(StfLogLevel.Error, errorMsg);

                // Ensure/enforce errors from now on! - of the exception was caught somewhere
                WebDriver = null;

                throw new Exception(errorMsg);
            }

            StfLogger.LogDebug($"Looked for errors [{Configuration.CheckForErrorsOnAllPagesText}] on page - found none");
        }

        /// <summary>
        /// The check for substrings in source.
        /// </summary>
        /// <param name="sourceText">
        /// The source text.
        /// </param>
        /// <param name="substrings">
        /// The substrings.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string CheckForSubstringsInSource(string sourceText, string substrings)
        {
            if (string.IsNullOrEmpty(sourceText) || string.IsNullOrEmpty(substrings))
            {
                return null;
            }

            var strings = substrings.Split('#').Select(p => p.Trim());
            var retVal = strings.FirstOrDefault(sourceText.Contains);

            return retVal;
        }
    }
}