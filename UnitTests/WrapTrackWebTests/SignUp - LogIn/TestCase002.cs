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
    }
}
