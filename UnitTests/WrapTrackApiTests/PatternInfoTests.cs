// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PatternInfoTests.cs" company="Mir Software">
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
    /// The pattern info tests.
    /// </summary>
    [TestClass]
    public class PatternInfoTests : StfTestScriptBase
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
        /// The test basic pattern info by pattern id.
        /// </summary>
        [TestMethod]
        public void TestBasicPatternInfoByPatternId()
        {
            var info = wtApi.PatternInfoByPatternId("34");

            StfAssert.AreEqual("Name", "Marakesh", info.Name);
            StfAssert.AreEqual("Brand", "Oscha", info.Brand);
            StfAssert.AreEqual("NumOfWraps", 16, info.NumOfWraps);
            StfAssert.AreEqual("NumOfModels", 13, info.NumOfModels);
            StfAssert.AreEqual("NumOfReviews", 0, info.NumOfReviews);
            StfAssert.AreEqual("PrimImagesId", "16231", info.PrimImagesId);
        }
    }
}