// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPageTests.cs" company="Mir Software">
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

    using Mir.Stf;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class MainPageTests : StfTestScriptBase
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
        /// The test cleanup.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            wrapTrackShell?.CloseDown();
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
            // Use default user
            wrapTrackShell.Login(); 
            StfAssert.IsTrue("No php errors", wtTestscriptUtils.PhpErrorFree(wrapTrackShell.WebAdapter));

            // And the result....
            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));
        }

        /// <summary>
        /// The test of system validates log in information.
        /// </summary>
        /// <remarks>
        /// After log in it's possible to acess 'MeProfile-page'
        /// </remarks>
        [TestMethod]
        public void Tc002()
        {
            // Make sure login is possible
            wrapTrackShell.Login();

            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));

            // try wrong pw
            wrapTrackShell.Logout();
            wrapTrackShell.Login("mie88", "1234");
            var feedback = wrapTrackShell.InfoText("mes_loginerror");
            StfAssert.IsTrue("User got feedback: 'wrong username/pw'", feedback);

            // try unkown username
            wrapTrackShell.Login("detvillemanadrigkaldesig", "wraptrack4ever");
            var feedback2 = wrapTrackShell.InfoText("mes_loginerror");
            StfAssert.IsTrue("User got feedback: 'wrong username/pw'", feedback2);
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

        /// <summary>
        /// The test sign up.
        /// </summary>
        [TestMethod]
        public void Tc004()
        {
            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            wrapTrackShell.SignUp();

            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);
        }
    }
}
