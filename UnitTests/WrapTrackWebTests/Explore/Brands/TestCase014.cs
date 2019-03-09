// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase014.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MainPageTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Explore.Brands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackWeb;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCase014 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The wrap track shell.
        /// </summary>
        private IWrapTrackWebShell wrapTrackShell;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            wrapTrackShell = Get<IWrapTrackWebShell>();

            // Use default user
            wrapTrackShell.Login();
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
        /// Test of creating a new brand.
        /// </summary>
        // Uncommented as AddBrand is unsupported[TestMethod]
        public void Tc014()
        {
            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);

            var explorer = wrapTrackShell.Explore();

            StfAssert.IsInstanceOfType("explorer", explorer, typeof(IExplore));

            var brands = explorer.Brands();
            var addBrand = brands.AddBrand();

            StfAssert.IsNotNull("Add brand", addBrand);

            var newBrandName = WtUtils.GetRandomString("StfBrand");

            addBrand.NewBrandName = newBrandName;
            addBrand.Save();
        }
    }
}
