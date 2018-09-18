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
    using WrapTrack.Stf.WrapTrackApi.Brand;
    using WrapTrack.Stf.WrapTrackApi.Configuration;
    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackApi.Model;
    using WrapTrack.Stf.WrapTrackApi.Pattern;
    using WrapTrack.Stf.WrapTrackApi.User;
    using WrapTrack.Stf.WrapTrackApi.Wrap;

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
        /// The pattern info by pattern id.
        /// </summary>
        /// <param name="patternId">
        /// The pattern id.
        /// </param>
        /// <returns>
        /// The <see cref="PatternInfo"/>.
        /// </returns>
        public PatternInfo PatternInfoByPatternId(string patternId)
        {
            var handler = new PatternInfoHandler(StfLogger, WtApiConfiguration);
            var retVal = handler.PatternInfoByPatternId(patternId);

            return retVal;
        }

        /// <summary>
        /// The model info by model id.
        /// </summary>
        /// <param name="modelId">
        /// The model id.
        /// </param>
        /// <returns>
        /// The <see cref="ModelInfo"/>.
        /// </returns>
        public ModelInfo ModelInfoByModelId(string modelId)
        {
            var handler = new ModelInfoHandler(StfLogger, WtApiConfiguration);
            var retVal = handler.ModelInfoByModelId(modelId);

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
        /// The brand number of models.
        /// </summary>
        /// <param name="brandId">
        /// The brand id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int BrandNumberOfModels(string brandId)
        {
            var brandInfo = BrandInfoByBrandId(brandId);
            var retVal = brandInfo?.NumOfModels ?? -42;

            return retVal;
        }

        /// <summary>
        /// The user name.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string UserName(string userId)
        {
            var handler = new UserInfoHandler(StfLogger, WtApiConfiguration);
            var userInfo = handler.UserInfoById(userId);
            var retVal = userInfo?.UserName ?? "Unknown userId";

            return retVal;
        }

        /// <summary>
        /// The user id.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string UserId(string userName)
        {
            var handler = new UserInfoHandler(StfLogger, WtApiConfiguration);
            var userInfo = handler.UserInfoByUserName(userName);
            var retVal = userInfo?.UserId ?? "Unknown user name";

            return retVal;
        }

        public bool EndUserCollection(int userId)
        {
            var handler = new UserInfoHandler(StfLogger, WtApiConfiguration);
            var retVal = handler.EndUserCollection(userId);

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
