// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase001.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MainPageTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WrapTrack.Stf.WrapTrackWeb.Interfaces;
using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

namespace WrapTrackWebTests.ZDeveloperTests.XBRO
{
    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCaseXb001 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The wt testscript utils.
        /// </summary>
        private WtTestscriptUtils wtTestscriptUtils;

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
            wtTestscriptUtils = new WtTestscriptUtils(StfLogger);
        }

        /// <summary>
        /// The log in test.
        /// </summary>
        /// <remarks>
        /// After log in it's possible to acess 'MeProfile-page'
        /// </remarks>
        [TestMethod]
        public void TcXb001()
        {
            // Use default user
            wrapTrackShell.Login();  
            StfAssert.IsTrue("No php erors", wtTestscriptUtils.PhpErrorFree(wrapTrackShell.WebAdapter));

            // And the result....
            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));
        }


        /// <summary>
        /// The log in test.
        /// </summary>
        /// <remarks>
        /// After log in it's possible to acess 'MeProfile-page'
        /// </remarks>
        [TestMethod]
        public void TcXb002()
        {
            // Use default user
            wrapTrackShell.Login();
            StfAssert.IsTrue("No php erors", wtTestscriptUtils.PhpErrorFree(wrapTrackShell.WebAdapter));

            // And the result....
            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));
        }

    }
}
