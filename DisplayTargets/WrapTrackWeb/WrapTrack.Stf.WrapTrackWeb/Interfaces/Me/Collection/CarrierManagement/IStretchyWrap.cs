// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStretchyWrap.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IStretchyWrap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement
{
    using System;

    /// <summary>
    /// The StretchyWrap interface.
    /// </summary>
    public interface IStretchyWrap
    {
        /// <summary>
        /// Gets or sets a value indicating whether home made.
        /// </summary>
        bool HomeMade { get; set; }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        string Brand { get; set; }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        string Model { get; set; }

        /// <summary>
        /// Gets or sets the converted wrap.
        /// </summary>
        string MadeOfWrap { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether converted. Is the carrier result of a convertion?
        /// </summary>
        bool Converted { get; set; }

        /// <summary>
        /// Gets or sets type of converter.
        /// </summary>
        string ConvertType { get; set; }

        /// <summary>
        /// Gets or sets type of name of converter.
        /// </summary>
        string ConvertName { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        string Size { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        string Grade { get; set; }

        /// <summary>
        /// Gets or sets the acquired.
        /// </summary>
        DateTime Acquired { get; set; }
    }
}