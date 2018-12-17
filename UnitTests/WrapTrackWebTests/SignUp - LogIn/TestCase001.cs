// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase001.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MainPageTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests
{
    using System.Security.Policy;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCase001 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The wt testscript utils.
        /// </summary>
        private WtTestscriptUtils wtTestscriptUtils;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            wtTestscriptUtils = new WtTestscriptUtils(StfLogger);
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
        public void Tc001()
        {
            // WrapTrackShell.WebAdapter.Configuration.CheckForErrorsOnAllPagesText = "Error # ParseError";
            WrapTrackShell.WebAdapter.Configuration.CheckForErrorsOnAllPagesText = "do not match # ParseError";
            WrapTrackShell.WebAdapter.Configuration.CheckForErrorsOnAllPages = true;

            // Use default user
            WrapTrackShell.Login(); 

            // And the result....
            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));
        }
    }
}
