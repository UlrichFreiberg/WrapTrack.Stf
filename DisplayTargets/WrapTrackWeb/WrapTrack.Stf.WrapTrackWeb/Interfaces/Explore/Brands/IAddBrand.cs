// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAddBrand.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IAddBrand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore.Brands
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand;

    /// <summary>
    /// The AddBrand interface.
    /// </summary>
    public interface IAddBrand
    {
        /// <summary>
        /// Gets or sets the new brand name.
        /// </summary>
        string NewBrandName { get; set; }

        /// <summary>
        /// The save.
        /// </summary>
        /// <returns>
        /// The <see cref="IBrand"/>.
        /// </returns>
        IBrand Save();

        /// <summary>
        /// Open a registered brand.
        /// </summary>
        /// <param name="brandName">
        /// The brand name.
        /// </param>
        /// <returns>
        /// The <see cref="IBrand"/>.
        /// </returns>
        IBrand OpenRegisteredBrand(string brandName);
    }
}
