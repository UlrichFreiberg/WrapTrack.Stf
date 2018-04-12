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

    using WrapTrack.Stf.WrapTrackApi.Brand;
    using WrapTrack.Stf.WrapTrackApi.Model;
    using WrapTrack.Stf.WrapTrackApi.Pattern;
    using WrapTrack.Stf.WrapTrackApi.Wrap;

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
        /// The pattern info by pattern id.
        /// </summary>
        /// <param name="patternId">
        /// The pattern id.
        /// </param>
        /// <returns>
        /// The <see cref="PatternInfo"/>.
        /// </returns>
        PatternInfo PatternInfoByPatternId(string patternId);

        /// <summary>
        /// The model info by model id.
        /// </summary>
        /// <param name="modelId">
        /// The model id.
        /// </param>
        /// <returns>
        /// The <see cref="ModelInfo"/>.
        /// </returns>
        ModelInfo ModelInfoByModelId(string modelId);

        /// <summary>
        /// The wrap info by internal id.
        /// </summary>
        /// <param name="internalId">
        /// The internal id.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        WrapInfo WrapInfoByInternalId(string internalId);

        /// <summary>
        /// The wrap info by track id.
        /// </summary>
        /// <param name="wtWrapId">
        /// The wt wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        WrapInfo WrapInfoByTrackId(string wtWrapId);

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
