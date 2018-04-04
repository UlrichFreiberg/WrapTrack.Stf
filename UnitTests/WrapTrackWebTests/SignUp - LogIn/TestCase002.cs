// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase002.cs" company="Mir Software">
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

    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCase002 : WrapTrackTestScriptBase
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
        /// The test of system validates log in information.
        /// </summary>
        /// <remarks>
        /// After log in it's possible to acess 'MeProfile-page'
        /// </remarks>
        [TestMethod]
        public void Tc002()
        {
            // Make sure login is possible
            WrapTrackShell.Login();

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));

            // try wrong pw
            WrapTrackShell.Logout();
            WrapTrackShell.Login("mie88", "1234");

            var feedback = WrapTrackShell.InfoText("mes_loginerror");

            StfAssert.IsTrue("User got feedback: 'wrong username/pw'", feedback);

            // try unkown username
            WrapTrackShell.Login("detvillemanadrigkaldesig", "wraptrack4ever");

            var feedback2 = WrapTrackShell.InfoText("mes_loginerror");

            StfAssert.IsTrue("User got feedback: 'wrong username/pw'", feedback2);
        }
    }
}
