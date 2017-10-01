﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// The test learn more.
        /// </summary>
        /// <remarks>After log in it's possible to acess 'Me-page'</remarks>
        [TestMethod]
        public void TestLogin()
        {
            // Use default user
            wrapTrackShell.Login(); 
            StfAssert.IsTrue("No php errors", wtTestscriptUtils.PhpErrorFree(wrapTrackShell.WebAdapter));

            // And the result....
            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMe));
        }

        /// <summary>
        /// The test learn more.
        /// </summary>
        /// <remarks>After log in it's possible to acess 'Me-page'</remarks>
        [TestMethod]
        public void TestLoginWrongData()
        {
            // Make sure login is possible
            wrapTrackShell.Login("mie88", "wraptrack4ever");
            StfAssert.IsTrue("No php errors", wtTestscriptUtils.PhpErrorFree(wrapTrackShell.WebAdapter));

            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsNotNull("me", me);

            // TODO:try wrong pw
            wrapTrackShell.Logout(); 
        }

        /// <summary>
        /// The test learn more.
        /// </summary>
        /// <remarks>After log out it's not possible to acess 'Me-page'</remarks>
        [TestMethod]
        public void TestLogout()
        {
            wrapTrackShell.Login();
            wrapTrackShell.Logout();

            // And the result....
            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsNotInstanceOfType("me", me, typeof(IMe));
        }

        /// <summary>
        /// The test sign up.
        /// </summary>
        [TestMethod]
        public void TestSignUp()
        {
            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            wrapTrackShell.SignUp();

            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);
        }
    }
}
