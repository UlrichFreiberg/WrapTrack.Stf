// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopingRestClient
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The unit test 1.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// The Response we get from the WT Rest service
        /// </summary>
        private string wtRestResponse;

        /// <summary>
        /// The test method 1.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public void TestMethod1()
        {
            DownloadData();

            Assert.AreEqual(wtRestResponse, "jj");
        }

        /// <summary>
        /// The download data.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public string DownloadData()
        {
            const string RequestUri = "https://wraptrack.org/API/maerke/200/vikler";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            wtRestResponse = await client.GetStringAsync(RequestUri);

            dynamic json = JToken.Parse(wtRestResponse);

            foreach (var item in json.RestResponse.wtRestResponse)
            {
                var txt = item.ToString();
            }
        }
    }
}
