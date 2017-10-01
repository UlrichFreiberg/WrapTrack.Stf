﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WtTestscriptUtils.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WtTestscriptUtils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;

namespace WrapTrackWebTests
{
    using System;

    using Mir.Stf.Utilities.Interfaces;

    using WrapTrack.Stf.Adapters.WebAdapter;

    /// <summary>
    /// The util.
    /// </summary>
    public class WtTestscriptUtils
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WtTestscriptUtils"/> class.
        /// </summary>
        /// <param name="stfLogger">
        /// The stf logger.
        /// </param>
        public WtTestscriptUtils(IStfLogger stfLogger)
        {
            StfLogger = stfLogger;
        }

        /// <summary>
        /// Gets or sets the stf logger.
        /// </summary>
        public IStfLogger StfLogger { get; set; }

        /// <summary>
        /// The php error free.
        /// </summary>
        /// <param name="webAdapter">
        /// The web adapter.
        /// </param>
        /// <returns>
        /// True it no PHP errors found on current page
        /// </returns>
        public bool PhpErrorFree(IWebAdapter webAdapter)
        {
            string textToCheck;

            try
            {
                textToCheck = webAdapter.GetText(By.XPath("//*"));
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"While getting text we got this exception: [{ex}]");
                return false;
            }

            if (textToCheck.Contains("PHP ERROR"))
            {
                StfLogger.LogError("While getting text we found a PHP ERROR");
                return false;
            }

            if (textToCheck.Contains("ParseError"))
            {
                StfLogger.LogError("While getting text we found a parseError");
                return false;
            }

            return true;
        }
    }
}
