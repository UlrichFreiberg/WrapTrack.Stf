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
    using System;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class MainPageTests : StfTestScriptBase
    {
        /// <summary>
        /// The test learn more.
        /// </summary>
        /// <remarks>After log in it's possible to acess 'Me-page'</remarks>
        [TestMethod]
        public void TestLogin()
        {
            var wrapTrackShell = Get<IWrapTrackWebShell>();

            // Use default user
            wrapTrackShell.Login(); 
            StfAssert.IsTrue("No php errors", Util.PhpErrorFree(wrapTrackShell.WebAdapter));

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
        public void TestLogin_wrong_data()
        {
            IWrapTrackWebShell wrapTrackShell = Get<IWrapTrackWebShell>();

            // Make sure login is possible
            wrapTrackShell.Login("mie88", "wraptrack4ever");
            StfAssert.IsTrue("No php errors", Util.PhpErrorFree(wrapTrackShell.WebAdapter));

            IMe me = wrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsNotNull("me", me);

            //try wrong pw
            wrapTrackShell.Logout(); 
        }


        /// <summary>
        /// The test learn more.
        /// </summary>
        /// <remarks>After log out it's not possible to acess 'Me-page'</remarks>
        [TestMethod]
        public void TestLogout()
        {
            IWrapTrackWebShell wrapTrackShell = Get<IWrapTrackWebShell>();
            wrapTrackShell.Login("", "");
            wrapTrackShell.Logout();

            // And the result....
            IMe me = wrapTrackShell.Me();
            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            StfAssert.IsNull("me", me);
        }

        [TestMethod]
        public void TestSignUp()
        {
            var wrapTrackShell = Get<IWrapTrackWebShell>();

            StfAssert.IsNotNull("wrapTrackShell", wrapTrackShell);
            wrapTrackShell.SignUp();

            var me = wrapTrackShell.Me();

            StfAssert.IsNull("me", me);
        }
    }
}
