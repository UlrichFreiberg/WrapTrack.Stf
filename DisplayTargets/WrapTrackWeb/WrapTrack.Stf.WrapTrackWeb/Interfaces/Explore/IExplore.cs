// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExplore.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Explore interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore.Wraps;

    /// <summary>
    /// The Explore interface.
    /// </summary>
    public interface IExplore
    {
        /// <summary>
        /// Gets the wrap.
        /// </summary>
        /// <returns>
        /// The <see cref="IWraps"/>.
        /// </returns>
        IWraps Wraps(); 

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns>
        /// The <see cref="IBrands"/>.
        /// </returns>
        IBrands Brands();
    }
}