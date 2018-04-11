// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrandInfoHandler.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Brand
{
    using System;

    using Mir.Stf.Utilities.Interfaces;

    using Newtonsoft.Json.Linq;

    using WrapTrack.Stf.WrapTrackApi.Configuration;
    using WrapTrack.Stf.WrapTrackApi.Wrap;

    // using https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenWithLinq.htm

    /// <summary>
    /// The brand info handler.
    /// </summary>
    internal class BrandInfoHandler : InfoHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandInfoHandler"/> class.
        /// </summary>
        /// <param name="stfLogger">
        /// The stf logger.
        /// </param>
        /// <param name="wtApiConfiguration">
        /// Wrap Track API configuration
        /// </param>
        public BrandInfoHandler(IStfLogger stfLogger, WtApiConfiguration wtApiConfiguration)
            : base(stfLogger, wtApiConfiguration)
        {
        }

        /// <summary>
        /// The wrap info by internal id.
        /// </summary>
        /// <param name="brandId">
        /// The brand Id.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        public BrandInfo BrandInfoByBrandId(string brandId)
        {
            if (string.IsNullOrWhiteSpace(brandId))
            {
                return null;
            }

            var uri = GetWrapRestInfoByBrandIdUri(brandId);
            var info = GetWrapRestInfo(uri);
            var retVal = WrapInfoMapper(info.Result);

            return retVal;
        }

        /// <summary>
        /// The get wrap rest info by track id uri.
        /// </summary>
        /// <param name="brandId">
        /// The brand Id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetWrapRestInfoByBrandIdUri(string brandId)
        {
            if (string.IsNullOrEmpty(brandId))
            {
                return null;
            }

            var retVal = $"brand/{brandId.Trim()}";

            return retVal;
        }

        /// <summary>
        /// The wrap info.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        private BrandInfo WrapInfoMapper(JObject info)
        {
            BrandInfo retVal;

            if (info == null)
            {
                return null;
            }

            StfLogger.LogDebug($"BrandInfoMapper: Got info = [{info}]");

            try
            {
                var bent = new BrandInfo
                {
                    Name = info["name"]?.ToString(),
                    NumOfWraps = GetInteger(info["numOfWraps"]?.ToString()),
                    NumOfModels = GetInteger(info["numOfModels"]?.ToString()),
                    NumOfPatterns = GetInteger(info["numOfPatterns"]?.ToString()),
                    NumOfReviews = GetInteger(info["numOfReviews"]?.ToString()),
                    PrimImagesId = info["primImagesId"]?.ToString()
                };

                retVal = bent;
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"BrandInfoMapper: Got ex = [{ex}]");

                return null;
            }

            return retVal;
        }
    }
}
