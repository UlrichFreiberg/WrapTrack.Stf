// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWtApi.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Interfaces
{
    using Mir.Stf.Utilities;

    /// <summary>
    /// The WtApi interface. For the WT REST API 
    /// </summary>
    public interface IWtApi : IStfPlugin
    {
        /// <summary>
        /// The brand info by brand id.
        /// </summary>
        /// <param name="brandId">
        /// The brand id.
        /// </param>
        /// <returns>
        /// The <see cref="BrandInfo"/>.
        /// </returns>
        BrandInfo BrandInfoByBrandId(string brandId);

        /// <summary>
        /// The wrap info by interal id.
        /// </summary>
        /// <param name="internalId">
        /// The internal Id.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        WrapInfo WrapInfoByInternalId(string internalId);

        /// <summary>
        /// The wrap info by track id.
        /// </summary>
        /// <param name="trackId">
        /// The ks 0 etu 1.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        WrapInfo WrapInfoByTrackId(string trackId);

        /// <summary>
        /// The number of patterns for brand.
        /// </summary>
        /// <param name="brandId">
        /// The brand id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int BrandNumberOfPatterns(string brandId);

        /// <summary>
        /// The brand number of models.
        /// </summary>
        /// <param name="brandId">
        /// The brand id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int BrandNumberOfModels(string brandId);
    }
}
