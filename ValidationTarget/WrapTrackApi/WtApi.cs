// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WtApi.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi
{
    using System;

    using WrapTrack.Stf.Core;
    using WrapTrack.Stf.WrapTrackApi.Configuration;
    using WrapTrack.Stf.WrapTrackApi.Interfaces;

    // using https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenWithLinq.htm

    /// <summary>
    /// The wt api.
    /// </summary>
    public class WtApi : TargetBase, IWtApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WtApi"/> class.
        /// </summary>
        public WtApi()
        {
            Name = "WrapTrackApi";
            VersionInfo = new Version(1, 0, 0, 0);
        }

        /// <summary>
        /// Gets or sets the wt api configuration.
        /// </summary>
        public WtApiConfiguration WtApiConfiguration { get; set; }

        /// <summary>
        /// The init.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Init()
        {
            WtApiConfiguration = SetConfig<WtApiConfiguration>();
            RegisterMyNeededTypes();
            return true;
        }

        /// <summary>
        /// The brand info by brand id.
        /// </summary>
        /// <param name="brandId">
        /// The brand id.
        /// </param>
        /// <returns>
        /// The <see cref="BrandInfo"/>.
        /// </returns>
        public BrandInfo BrandInfoByBrandId(string brandId)
        {
            var handler = new BrandInfoHandler(StfLogger, WtApiConfiguration);
            var retVal = handler.BrandInfoByBrandId(brandId);

            return retVal;
        }

        /// <summary>
        /// The wrap info by internal id.
        /// </summary>
        /// <param name="internalId">
        /// The internal id.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        public WrapInfo WrapInfoByInternalId(string internalId)
        {
            var handler = new WrapInfoHandler(StfLogger, WtApiConfiguration);
            var retVal = handler.WrapInfoByInternalId(internalId);

            return retVal;
        }

        /// <summary>
        /// The wrap info by track id.
        /// </summary>
        /// <param name="wtWrapId">
        /// The wt wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        public WrapInfo WrapInfoByTrackId(string wtWrapId)
        {
            var handler = new WrapInfoHandler(StfLogger, WtApiConfiguration);
            var retVal = handler.WrapInfoByTrackId(wtWrapId);

            return retVal;
        }

        /// <summary>
        /// The number of patterns for brand.
        /// </summary>
        /// <param name="brandId">
        /// The brand id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int BrandNumberOfPatterns(string brandId)
        {
            var brandInfo = BrandInfoByBrandId(brandId);
            var retVal = brandInfo?.NumOfPatterns ?? -42;

            return retVal;
        }

        /// <summary>
        /// The register my needed types.
        /// </summary>
        private void RegisterMyNeededTypes()
        {
        }
    }
}
