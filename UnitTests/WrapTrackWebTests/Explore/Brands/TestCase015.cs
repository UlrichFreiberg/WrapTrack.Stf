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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackWeb;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCase015 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
        }

        /// <summary>
        /// The log in test.
        /// </summary>
        /// <remarks>
        /// After log in it's possible to acess 'MeProfile-page'
        /// </remarks>
        [TestMethod]
        public void Tc015()
        {
            // Use default user
            WrapTrackShell.LoginAsAdmin();
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);

            var randomBrand = GetRandomBrand();
            var newPatternName = WtUtils.GetRandomString("StfPattern");
            var patternAdded = randomBrand.AddPattern(newPatternName);

            StfAssert.IsTrue($"Pattern {newPatternName} Added", patternAdded);

            var patternDeleted = randomBrand.DeletePattern(newPatternName);

            StfAssert.IsTrue($"Pattern {newPatternName} Deleted", patternDeleted);
        }
    }
}
