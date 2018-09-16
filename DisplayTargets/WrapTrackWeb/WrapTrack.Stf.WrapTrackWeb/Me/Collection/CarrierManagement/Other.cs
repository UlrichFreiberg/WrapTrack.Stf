﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Other.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the StretchyWrap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The stretchy wrap.
    /// </summary>
    public class Other : CarrierBaseClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Other"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Other(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the carrier type.
        /// </summary>
        public string CarrierType { get; set; }

        /// <summary>
        /// Gets or sets the Carrier model.
        /// </summary>
        public string CarrierModel { get; set; }
    }
}
