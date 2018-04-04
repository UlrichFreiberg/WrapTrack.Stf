// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrandInfoTests.cs" company="Mir Software">
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
    /// The brand info tests.
    /// </summary>
    [TestClass]
    public class BrandInfoTests : StfTestScriptBase
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
        /// The test basic brand info by brand id.
        /// </summary>
        [TestMethod]
        public void TestBasicBrandInfoByBrandId()
        {
            var info = wtApi.BrandInfoByBrandId("34");

            StfAssert.AreEqual("Name", "Ali Dover", info.Name);
            StfAssert.AreEqual("NumOfWraps", 106, info.NumOfWraps);
            StfAssert.AreEqual("NumOfModels", 33, info.NumOfModels);
            StfAssert.AreEqual("NumOfPatterns", 3, info.NumOfPatterns);
            StfAssert.AreEqual("NumOfReviews", 1, info.NumOfReviews);
            StfAssert.AreEqual("PrimImagesId", "22007", info.PrimImagesId);
        }

        /// <summary>
        /// The test basic brand number of.
        /// </summary>
        [TestMethod]
        public void TestBasicBrandNumberOf()
        {
            var brandNumberOfPatterns = wtApi.BrandNumberOfPatterns("34");
            var brandNumberOfModels = wtApi.BrandNumberOfModels("34");

            StfAssert.AreEqual("brandNumberOfPatterns", 3, brandNumberOfPatterns);
            StfAssert.AreEqual("brandNumberOfModels", 33, brandNumberOfModels);
        }
    }
}