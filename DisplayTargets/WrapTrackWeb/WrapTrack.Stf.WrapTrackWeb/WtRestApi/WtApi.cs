// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WtApi.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.WtRestApi
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json.Linq;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces.WtRestApi;

    // using https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenWithLinq.htm

    /// <summary>
    /// The wt api.
    /// </summary>
    public class WtApi : IWtApi
    {
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
                OwnerId = info.SelectToken("ejerskab_bruger_id").ToString(),
                OwnerName = info.SelectToken("ejerskab_bruger_navn").ToString(),
                Size = info.SelectToken("stoerrelse").ToString()
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
            var uri = $"https://wraptrack.org/API/vikle/{wtWrapId.Trim()}/plus_ejerskab_nuv";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetStringAsync(uri);
            var retVal = JObject.Parse(response);

            return retVal;
        }
    }
}
