// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelInfoHandler.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Model
{
    using System;

    using Mir.Stf.Utilities.Interfaces;

    using Newtonsoft.Json.Linq;

    using WrapTrack.Stf.WrapTrackApi.Configuration;

    // using https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenWithLinq.htm

    /// <summary>
    /// The Model info handler.
    /// </summary>
    internal class ModelInfoHandler : InfoHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelInfoHandler"/> class. 
        /// </summary>
        /// <param name="stfLogger">
        /// The stf logger.
        /// </param>
        /// <param name="wtApiConfiguration">
        /// Wrap Track API configuration
        /// </param>
        public ModelInfoHandler(IStfLogger stfLogger, WtApiConfiguration wtApiConfiguration)
            : base(stfLogger, wtApiConfiguration)
        {
        }

        /// <summary>
        /// The wrap info by internal id.
        /// </summary>
        /// <param name="modelId">
        /// The Model Id.
        /// </param>
        /// <returns>
        /// The <see cref="ModelInfo"/>.
        /// </returns>
        public ModelInfo ModelInfoByModelId(string modelId)
        {
            if (string.IsNullOrWhiteSpace(modelId))
            {
                return null;
            }

            var uri = GetWrapRestInfoByModelIdUri(modelId);
            var info = GetWrapRestInfo(uri);
            var retVal = WrapInfoMapper(info.Result);

            return retVal;
        }

        /// <summary>
        /// The get wrap rest info by track id uri.
        /// </summary>
        /// <param name="modelId">
        /// The Model Id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetWrapRestInfoByModelIdUri(string modelId)
        {
            if (string.IsNullOrEmpty(modelId))
            {
                return null;
            }

            var retVal = $"model/{modelId.Trim()}";

            return retVal;
        }

        /// <summary>
        /// The wrap info.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <returns>
        /// The <see cref="ModelInfo"/>.
        /// </returns>
        private ModelInfo WrapInfoMapper(JObject info)
        {
            ModelInfo retVal;

            if (info == null)
            {
                return null;
            }

            StfLogger.LogDebug($"ModelInfoMapper: Got info = [{info}]");

            try
            {
                var bent = new ModelInfo
                {
                    Name = info["name"]?.ToString(),
                    Brand = info["brand"]?.ToString(),
                    NumOfWraps = GetInteger(info["numOfWraps"]?.ToString()),
                    NumOfReviews = GetInteger(info["numOfReviews"]?.ToString()),
                    PrimImagesId = info["primImagesId"]?.ToString(),
                    NumOfImages = GetInteger(info["numOfImages"]?.ToString())
                };

                retVal = bent;
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"ModelInfoMapper: Got ex = [{ex}]");

                return null;
            }

            return retVal;
        }
    }
}
