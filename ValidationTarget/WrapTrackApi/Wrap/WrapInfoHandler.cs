// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrapInfoHandler.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Wrap
{
    using System;
    using System.Linq;

    using Mir.Stf.Utilities.Interfaces;

    using Newtonsoft.Json.Linq;

    using WrapTrack.Stf.WrapTrackApi.Configuration;

    // using https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenWithLinq.htm

    /// <summary>
    /// The wt api.
    /// </summary>
    internal class WrapInfoHandler : InfoHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrapInfoHandler"/> class.
        /// </summary>
        /// <param name="stfLogger">
        ///     The stf logger.
        /// </param>
        /// <param name="wtApiConfiguration">
        /// Wrap Track API configuration
        /// </param>
        public WrapInfoHandler(IStfLogger stfLogger, WtApiConfiguration wtApiConfiguration)
            : base(stfLogger, wtApiConfiguration)
        {
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
            if (string.IsNullOrWhiteSpace(internalId))
            {
                return null;
            }

            var uri = GetWrapRestInfoByInternalIdUri(internalId);
            var info = GetWrapRestInfo(uri);
            var retVal = WrapInfoMapper(info.Result);

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
            if (string.IsNullOrWhiteSpace(wtWrapId))
            {
                return null;
            }

            var uri = GetWrapRestInfoByTrackIdUri(wtWrapId);
            var info = GetWrapRestInfo(uri);
            var retVal = WrapInfoMapper(info.Result);

            return retVal;
        }

        /// <summary>
        /// The get wrap rest info by track id uri.
        /// </summary>
        /// <param name="wtWrapId">
        /// The wt wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetWrapRestInfoByTrackIdUri(string wtWrapId)
        {
            if (string.IsNullOrEmpty(wtWrapId))
            {
                return null;
            }

            var retVal = $"wrap/0/{wtWrapId.Trim()}";

            return retVal;
        }

        /// <summary>
        /// The get wrap rest info by internal id uri.
        /// </summary>
        /// <param name="internalId">
        /// The wt wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetWrapRestInfoByInternalIdUri(string internalId)
        {
            if (string.IsNullOrEmpty(internalId))
            {
                return null;
            }

            var retVal = $"wrap/{internalId.Trim()}/0";

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
        private WrapInfo WrapInfoMapper(JObject info)
        {
            WrapInfo retVal;

            if (info == null)
            {
                return null;
            }

            StfLogger.LogDebug($"WrapInfoMapper: Got info = [{info}]");

            try
            {
                var bent = new WrapInfo
                {
                    OwnerId = info["ejerskab_nuv"]?.SelectToken("bruger_id")?.ToString(),
                    OwnerName = info["ejerskab_nuv"]?.SelectToken("bruger_navn")?.ToString(),
                    InternalId = info.SelectToken("id")?.ToString(),
                    Size = info.SelectToken("id")?.ToString(),
                    OwnershipNumber = info["ejerskab_nuv"]?.SelectToken("nr")?.ToString(),
                    Status = info.SelectToken("status")?.ToString(),
                };

                retVal = bent;
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"WrapInfoMapper: Got ex = [{ex}]");
                return null;
            }

            var numOfOwnershipPic = info["ejerskab_nuv"]?.SelectToken("private_billeder")?.ToString();
            int number;

            if (int.TryParse(numOfOwnershipPic, out number))
            {
                retVal.NumOfOwnershipPic = number;
            }

            // sometime we dont have this node - if not, then the value is zero:-)
            retVal.NumOfPictures = info["billeder"]?.Count() ?? 0;

            return retVal;
        }
    }
}
