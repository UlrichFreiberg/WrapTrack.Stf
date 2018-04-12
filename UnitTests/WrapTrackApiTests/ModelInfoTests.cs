// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelInfoTests.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WtApiTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackApiTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;

    /// <summary>
    /// The model info tests.
    /// </summary>
    [TestClass]
    public class ModelInfoTests : StfTestScriptBase
    {
        /// <summary>
        /// The wt api.
        /// </summary>
        private IWtApi wtApi;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            wtApi = Get<IWtApi>();
        }

        /// <summary>
        /// The test basic model info by model id.
        /// </summary>
        [TestMethod]
        public void TestBasicModelInfoByModelId()
        {
            var info = wtApi.ModelInfoByModelId("34");

            // { "name":"Sacher","brand":"Linuschka","numOfWraps":"2","numOfReviews":"0","primImagesId":"26773"}
            StfAssert.AreEqual("Name", "Sacher", info.Name);
            StfAssert.AreEqual("Brand", "Linuschka", info.Brand);
            StfAssert.AreEqual("NumOfWraps", 2, info.NumOfWraps);
            StfAssert.AreEqual("NumOfReviews", 0, info.NumOfReviews);
            StfAssert.AreEqual("PrimImagesId", "26773", info.PrimImagesId);
        }
    }
}