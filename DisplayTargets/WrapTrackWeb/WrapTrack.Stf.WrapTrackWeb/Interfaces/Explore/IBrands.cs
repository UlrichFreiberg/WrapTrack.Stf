// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBrands.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IExploreWraps type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore.Brands;

    /// <summary>
    /// The ExploreWraps interface.
    /// </summary>
    public interface IBrands
    {
        /// <summary>
        /// Gets or sets the all.
        /// </summary>
        /// <returns>
        /// The <see cref="IAllBrands"/>.
        /// </returns>
        IAllBrands All();

        /// <summary>
        /// Gets or sets the add brand.
        /// </summary>
        /// <returns>
        /// The <see cref="IAddBrand"/>.
        /// </returns>
        IAddBrand AddBrand();
    }
}