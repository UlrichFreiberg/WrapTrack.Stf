// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWowenWrap.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The WowenWrap interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement
{
    using System;

    /// <summary>
    /// The WowenWrap interface.
    /// </summary>
    public interface IWowenWrap
    {
        /// <summary>
        /// Gets or sets a value indicating whether home made.
        /// </summary>
        bool HomeMade { get; set; }

        /// <summary>
        /// Gets or sets the name.
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

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="brandName">
        /// The brand Name. Used to check if the save went okay or not
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Save(string brandName = null);

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
    }
}