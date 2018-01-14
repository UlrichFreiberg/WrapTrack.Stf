// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase004.cs" company="Mir Software">
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
    public class TestCase004 : WrapTrackTestScriptBase
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
