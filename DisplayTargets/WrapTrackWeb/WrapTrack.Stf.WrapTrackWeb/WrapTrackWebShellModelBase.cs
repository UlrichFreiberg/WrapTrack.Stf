// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrapTrackWebShellModelBase.cs" company="Nordea">
//   Copyright governed by Artistic license as described here:
//   //          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The im shell model base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Mir.Stf.Utilities;

    using OpenQA.Selenium;

    using WrapTrack.Stf.Adapters.WebAdapter;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The im shell model base.
    /// </summary>
    public abstract class WrapTrackWebShellModelBase : StfModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrapTrackWebShellModelBase"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        protected WrapTrackWebShellModelBase(IWrapTrackWebShell wrapTrackWebShell)
        {
            WrapTrackWebShell = wrapTrackWebShell;
            WebAdapter = wrapTrackWebShell.WebAdapter;
        }

        /// <summary>
        /// Gets or sets the wrap track web shell.
        /// </summary>
        protected IWrapTrackWebShell WrapTrackWebShell { get; set; }

        /// <summary>
        /// Gets or sets the web adapter.
        /// </summary>
        protected IWebAdapter WebAdapter { get; set; }
    }
}