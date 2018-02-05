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
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json.Linq;

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
            var info = this.GetWrapRestInfoByInternalId(internalId);
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
            var info = GetWrapRestInfoByTrackId(wtWrapId);
            var retVal = WrapInfoMapper(info.Result);

            return retVal;
        }

        /// <summary>
        /// The get wrap rest info.
        /// </summary>
        /// <param name="wtWrapId">
        /// The wt wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected async Task<JObject> GetWrapRestInfoByTrackId(string wtWrapId)
        {
            var uri = $"{WtApiConfiguration.Url}/wrap/0/{wtWrapId.Trim()}";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetStringAsync(uri);
            var retVal = JObject.Parse(response);

            return retVal;
        }

        /// <summary>
        /// The get wrap rest info.
        /// </summary>
        /// <param name="wtWrapId">
        /// The wt wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected async Task<JObject> GetWrapRestInfoByInternalId(string wtWrapId)
        {
            var uri = $"{WtApiConfiguration.Url}/wrap/{wtWrapId.Trim()}/0";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetStringAsync(uri);
            var retVal = JObject.Parse(response);

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

        /// <summary>
        /// The register my needed types.
        /// </summary>
        private void RegisterMyNeededTypes()
        {
        }
    }
}
