﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FullBuckle.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the FullBuckle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    /// <summary>
    /// The WrapTai wrap.
    /// </summary>
    public class FullBuckle : CarrierBaseClass, IFullBuckle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FullBuckle"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public FullBuckle(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                var retVal = WebAdapter.GetText(By.Id("inpNameHomemade"));

                return retVal;
            }

            set
            {
                WebAdapter.TextboxSetTextById("inpNameHomemade", value);
            }
        }
    }
}
