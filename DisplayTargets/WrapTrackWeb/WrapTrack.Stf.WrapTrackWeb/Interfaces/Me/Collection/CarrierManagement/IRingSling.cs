// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRingSling.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IRingSling type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement
{
    using System;

    /// <summary>
    /// The RingSling interface.
    /// </summary>
    public interface IRingSling
    {
        /// <summary>
        /// Gets or sets a value indicating whether brand produced.
        /// </summary>
        bool BrandProduced { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether woven wrap fabric is used.
        /// </summary>
        bool WovenWrapFabric { get; set; }

        /// <summary>
        /// Gets or sets a name for a ring sling not not made of woven wrap fabric.
        /// </summary>
        string Name { get; set; }

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