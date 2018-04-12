// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase016.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The main page tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Explore.Brands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCase016 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The brand id. Should NOT be hardcoded - randomBrand is not that random;-)
        /// </summary>
        private const string BrandId = "306";

        /// <summary>
        /// The wt utils.
        /// </summary>
        private IWtApi wtApi;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            wtApi = Get<IWtApi>();
            WrapTrackShell = Get<IWrapTrackWebShell>();
        }

        /// <summary>
        /// The test clean up.
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            WrapTrackShell?.CloseDown();
        }

        /// <summary>
        /// The log in test.
        /// </summary>
        /// <remarks>
        /// After log in it's possible to acess 'MeProfile-page'
        /// </remarks>
        [TestMethod]
        public void Tc016()
        {
            // Use default user
            WrapTrackShell.LoginAsAdmin();
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);

            var randomBrand = GetRandomBrand();
            var newModelName = WtUtils.GetRandomString("StfModel");
            var baseLineNumberOfModels = wtApi.BrandNumberOfModels(BrandId);
            var modelAdded = randomBrand.AddModel(newModelName);
            var numberOfModels = wtApi.BrandNumberOfModels(BrandId);

            StfAssert.IsTrue($"Model {newModelName} Added", modelAdded);
            StfAssert.AreEqual("Number of models for brand up by one", numberOfModels, baseLineNumberOfModels + 1);

            var patternDeleted = randomBrand.DeleteModel(newModelName);

            numberOfModels = wtApi.BrandNumberOfModels(BrandId);
            StfAssert.IsTrue($"Model {newModelName} Deleted", patternDeleted);
            StfAssert.AreEqual($"Number of models for brand as baseline", numberOfModels, baseLineNumberOfModels);
        }
    }
}
