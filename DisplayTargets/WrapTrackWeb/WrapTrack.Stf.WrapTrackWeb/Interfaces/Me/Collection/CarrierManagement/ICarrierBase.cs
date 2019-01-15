// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICarrierBase.cs" company="Mir Software">
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

    using WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement;

    /// <summary>
    /// The Base interface for all Carrier's.
    /// </summary>
    public interface ICarrierBase
    {
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
        /// Gets or sets the carrier model.
        /// </summary>
        string CarrierModel { get; set; }

        /// <summary>
        /// Gets or sets the carrier type.
        /// </summary>
        string CarrierType { get; set; }

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

        /// <summary>
        /// The select made of wrap.
        /// </summary>
        /// <param name="wrapName">
        /// The wrap name. If null, then pick a random one in the list
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool SelectMadeOfWrap(string wrapName = null);

        /// <summary>
        /// The save.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Save();
    }
}