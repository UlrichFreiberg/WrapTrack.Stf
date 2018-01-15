﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// The wrap info.
        /// </summary>
        /// <param name="wtWrapId">
        /// The wt wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        public WrapInfo WrapInfo(string wtWrapId)
        {
            var info = GetWrapRestInfo(wtWrapId).Result;
     
            var retVal = new WrapInfo
            {
                InternalId = info.SelectToken("id").ToString(),
                OwnerId = info.SelectToken("ejerskab_bruger_id").ToString(),
                //OwnerName = info.SelectToken("ejerskab_bruger_navn").ToString(),
                OwnerName = info["ejerskab_nuv"].SelectToken("Bruger_navn").ToString(),
                NumPictures = info["billeder"].Count(),
                Size = info.SelectToken("stoerrelse").ToString(),
                Status = info.SelectToken("status").ToString()
            };

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
        protected async Task<JObject> GetWrapRestInfo(string wtWrapId)
        {
            // var uri = $"{WtApiConfiguration.Url}/vikle/null/plus_ejerskab_nuv+plus_ejerskaber+plus_billeder/{wtWrapId.Trim()}";
            var uri = $"{WtApiConfiguration.Url}/wrap/0/{wtWrapId.Trim()}";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetStringAsync(uri);
            var retVal = JObject.Parse(response);

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
