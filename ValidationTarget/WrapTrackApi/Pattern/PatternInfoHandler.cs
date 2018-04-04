// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PatternInfoHandler.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Pattern
{
    using System;

    using Mir.Stf.Utilities.Interfaces;

    using Newtonsoft.Json.Linq;

    using WrapTrack.Stf.WrapTrackApi.Configuration;

    // using https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenWithLinq.htm

    /// <summary>
    /// The Pattern info handler.
    /// </summary>
    internal class PatternInfoHandler : InfoHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatternInfoHandler"/> class.
        /// </summary>
        /// <param name="stfLogger">
        /// The stf logger.
        /// </param>
        /// <param name="wtApiConfiguration">
        /// Wrap Track API configuration
        /// </param>
        public PatternInfoHandler(IStfLogger stfLogger, WtApiConfiguration wtApiConfiguration)
            : base(stfLogger, wtApiConfiguration)
        {
        }

        /// <summary>
        /// The wrap info by internal id.
        /// </summary>
        /// <param name="patternId">
        /// The Pattern Id.
        /// </param>
        /// <returns>
        /// The <see cref="PatternInfo"/>.
        /// </returns>
        public PatternInfo PatternInfoByPatternId(string patternId)
        {
            if (string.IsNullOrWhiteSpace(patternId))
            {
                return null;
            }

            var uri = GetWrapRestInfoByPatternIdUri(patternId);
            var info = GetWrapRestInfo(uri);
            var retVal = WrapInfoMapper(info.Result);

            return retVal;
        }

        /// <summary>
        /// The get wrap rest info by track id uri.
        /// </summary>
        /// <param name="patternId">
        /// The Pattern Id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetWrapRestInfoByPatternIdUri(string patternId)
        {
            if (string.IsNullOrEmpty(patternId))
            {
                return null;
            }

            var retVal = $"pattern/{patternId.Trim()}";

            return retVal;
        }

        /// <summary>
        /// The wrap info.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <returns>
        /// The <see cref="PatternInfo"/>.
        /// </returns>
        private PatternInfo WrapInfoMapper(JObject info)
        {
            PatternInfo retVal;

            StfLogger.LogDebug($"PatternInfoMapper: Got info = [{info}]");

            try
            {
                var bent = new PatternInfo
                {
                    Name = info["name"]?.ToString(),
                    Brand = info["brand"]?.ToString(),
                    NumOfModels = GetInteger(info["numOfModels"]?.ToString()),
                    NumOfWraps = GetInteger(info["numOfWraps"]?.ToString()),
                    NumOfReviews = GetInteger(info["numOfReviews"]?.ToString()),
                    PrimImagesId = info["primImagesId"]?.ToString()
                };

                retVal = bent;
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"PatternInfoMapper: Got ex = [{ex}]");

                return null;
            }

            return retVal;
        }
    }
}
