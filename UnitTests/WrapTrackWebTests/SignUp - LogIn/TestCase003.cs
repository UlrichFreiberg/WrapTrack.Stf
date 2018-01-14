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
            wrapTrackShell.Login();
            wrapTrackShell.Logout();

            // And the result....
            var me = wrapTrackShell.Me();

            StfAssert.IsNull("me", me);
        }
    }
}
