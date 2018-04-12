// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase003.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MainPageTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCase003 : WrapTrackTestScriptBase
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
        /// The test clean up.
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            WrapTrackShell?.CloseDown();
        }

        /// <summary>
        /// The test of log off.
        /// </summary>
        /// <remarks>
        /// After log out it's not possible to acess 'MeProfile-page'
        /// </remarks>
        [TestMethod]
        public void Tc003()
        {
            WrapTrackShell.Login();
            WrapTrackShell.Logout();

            // And the result....
            var me = WrapTrackShell.Me();

            StfAssert.IsNull("me", me);
        }
    }
}
