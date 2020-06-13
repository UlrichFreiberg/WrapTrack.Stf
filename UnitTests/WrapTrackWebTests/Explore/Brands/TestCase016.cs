﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// Create and delete a model (model related to pattern)
        /// </summary>
        [TestMethod]
        public void Tc016()
        {
            // For now hard coded. TOdo: Random
            const string BrandId = "289";
            const string BrandName = "Agossie";

            // Use default user
            WrapTrackShell.Login();
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);

            var randomBrand = this.GetBrand(BrandName);
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
