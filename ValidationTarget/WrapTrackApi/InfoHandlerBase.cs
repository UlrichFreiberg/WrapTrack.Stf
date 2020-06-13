// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfoHandlerBase.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the InfoHandlerBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace WrapTrack.Stf.WrapTrackApi
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;

    using Mir.Stf.Utilities.Interfaces;

    using Newtonsoft.Json.Linq;

    using WrapTrack.Stf.WrapTrackApi.Configuration;

    /// <summary>
    /// The info handler base.
    /// </summary>
    public class InfoHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoHandlerBase"/> class.
        /// </summary>
        /// <param name="stfLogger">
        /// The stf logger.
        /// </param>
        /// <param name="wtApiConfiguration">
        /// The wt api configuration.
        /// </param>
        public InfoHandlerBase(IStfLogger stfLogger, WtApiConfiguration wtApiConfiguration)
        {
            StfLogger = stfLogger;
            WtApiConfiguration = wtApiConfiguration;
        }

        /// <summary>
        /// Gets or sets the stf logger.
        /// </summary>
        public IStfLogger StfLogger { get; set; }

        /// <summary>
        /// Gets or sets the wt api configuration.
        /// </summary>
        public WtApiConfiguration WtApiConfiguration { get; set; }

        protected async Task<HttpResponseMessage> PutWrapRestInfo(string uri)
        {
            HttpResponseMessage retVal = null;
            var client = new HttpClient();
            //HttpContent httpContent = new StringContent(new_doc.ToString(), Encoding.UTF8, "application/xml");
            var fullUri = $"{WtApiConfiguration.Url}/{uri}";

            try
            {
                retVal = await client.PutAsync(fullUri, new StreamContent(Stream.Null));
                StfLogger.LogInfo($"PutWrapRestInfo: Called [{fullUri}]");
                StfLogger.LogInfo($"PutWrapRestInfo: Got response [{retVal}]");
            }
            catch(Exception ex)
            {
                StfLogger.LogError($"PutWrapRestInfo: Got response exception[{ex}]");
            }

            return retVal;
        }

        /// <summary>
        /// The get wrap rest info.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected async Task<JObject> GetWrapRestInfo(string uri)
        {
            var client = new HttpClient();
            JObject retVal;

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var fullUri = $"{WtApiConfiguration.Url}/{uri}";
            var response = await client.GetStringAsync(fullUri);

            StfLogger.LogInfo($"GetWrapRestInfo: Called [{fullUri}]");
            StfLogger.LogInfo($"GetWrapRestInfo: Got response [{response}]");

            try
            {
                retVal = JObject.Parse(response);
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"GetWrapRestInfo: While parsing the repsonse something went wrong [{ex}]");
                retVal = default(JObject);
            }

            return retVal;
        }

        /// <summary>
        /// The get integer.
        /// </summary>
        /// <param name="intString">
        /// The int string.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected int GetInteger(string intString, int defaultValue = -42)
        {
            int retVal;

            if (!int.TryParse(intString, out retVal))
            {
                return defaultValue;
            }

            return retVal;
        }
    }
}
