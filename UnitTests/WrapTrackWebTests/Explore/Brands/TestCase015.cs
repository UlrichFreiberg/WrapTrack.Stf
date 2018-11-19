// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase015.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The main page tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Explore.Brands
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCase015 : WrapTrackTestScriptBase
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
        /// Test of creating new pattern.
        /// </summary>
        [TestMethod]
        public void Tc015()
        {
            // Use default user
            WrapTrackShell.LoginAsAdmin();
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);

            var randomBrand = GetRandomBrand();
            var newPatternName = WtUtils.GetRandomString("StfPattern");
            var baseLineNumberOfPatterns = wtApi.BrandNumberOfPatterns(BrandId);
            var patternAdded = randomBrand.AddPattern(newPatternName);
            Wait(TimeSpan.FromSeconds(1));
            var numberOfPatterns = wtApi.BrandNumberOfPatterns(BrandId);

            StfAssert.IsTrue($"Pattern {newPatternName} Added", patternAdded);
          
            StfAssert.GreaterThan("Number of patterns for brand up by one", numberOfPatterns, baseLineNumberOfPatterns);
           
            var patternDeleted = randomBrand.DeletePattern(newPatternName);
          
            numberOfPatterns = wtApi.BrandNumberOfPatterns(BrandId);
            StfAssert.IsTrue($"Pattern {newPatternName} Deleted", patternDeleted);
            StfAssert.AreEqual($"Number of patterns for brand as baseline", numberOfPatterns, baseLineNumberOfPatterns);
        }
    }
}
