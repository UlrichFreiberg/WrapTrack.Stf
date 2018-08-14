// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebAdapterEventLogger.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WebAdapterEventLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.Adapters.WebAdapter
{
    using Mir.Stf.Utilities;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Events;

    /// <summary>
    /// The web adapter event handler.
    /// </summary>
    public class WebAdapterEventLogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebAdapterEventLogger"/> class.
        /// </summary>
        /// <param name="stfLogger">
        /// The stf logger.
        /// </param>
        public WebAdapterEventLogger(StfLogger stfLogger)
        {
            StfLogger = stfLogger;
        }

        /// <summary>
        /// Gets or sets the stf logger.
        /// </summary>
        private StfLogger StfLogger { get; set; }

        /// <summary>
        /// The add logging.
        /// </summary>
        /// <param name="webDriver">
        /// The web Driver.
        /// </param>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        public IWebDriver AddLogging(IWebDriver webDriver)
        {
            var firingDriver = new EventFiringWebDriver(webDriver);

            firingDriver.ExceptionThrown += FiringDriverExceptionThrown;
            firingDriver.ElementClicked += FiringDriverElementClicked;
            firingDriver.FindElementCompleted += FiringDriverFindElementCompleted;

            return firingDriver; 
        }

        /// <summary>
        /// The firing driver_ exception thrown.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FiringDriverExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            StfLogger.LogInfo(e.ThrownException.Message);
        }

        /// <summary>
        /// The firing driver_ element clicked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FiringDriverElementClicked(object sender, WebElementEventArgs e)
        {
            StfLogger.LogInfo($"WebAdaper clicked [{e.Element}]");
        }

        /// <summary>
        /// The firing driver find element completed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FiringDriverFindElementCompleted(object sender, FindElementEventArgs e)
        {
            StfLogger.LogInfo($"WebAdaper found element [{e.FindMethod}]");
        }
    }    
}
