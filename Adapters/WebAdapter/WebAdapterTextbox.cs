// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebAdapterTextbox.cs" company="Mir Software">
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
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;

    using Mir.Stf.Utilities;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;

    /// <summary>
    /// The web adapter.
    /// </summary>
    public partial class WebAdapter : StfAdapterBase, IWebAdapter
    {
        /// <summary>
        /// The textbox set text by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="textToEnter">
        /// The text to enter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool TextboxSetTextById(string id, string textToEnter)
        {
            var retVal = TextboxSetTextBy(By.Id(id), textToEnter);

            return retVal;
        }

        /// <summary>
        /// The textbox set text by xpath.
        /// </summary>
        /// <param name="xpath">
        /// The xpath.
        /// </param>
        /// <param name="textToEnter">
        /// The text to enter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool TextboxSetTextByXpath(string xpath, string textToEnter)
        {
            var retVal = TextboxSetTextBy(By.Id(xpath), textToEnter);

            return retVal;
        }

        /// <summary>
        /// The textbox set text by.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <param name="textToEnter">
        /// The text to enter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool TextboxSetTextBy(By by, string textToEnter)
        {
            StfLogger.LogDebug($"Textbox : Setting text [{textToEnter}] - by=[{by}]");
            WaitForComplete(1);

            var element = FindElement(by);

            if (element == null)
            {
                StfLogger.LogError($"Can't find textbox - by=[{by}]");

                return false;
            }

            try
            {
                element.Clear();
                element.SendKeys(textToEnter);
                element.SendKeys(Keys.Tab);
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"Can't send text to textbox - ex=[{ex}]");

                return false;
            }

            return true;
        }
    }
}