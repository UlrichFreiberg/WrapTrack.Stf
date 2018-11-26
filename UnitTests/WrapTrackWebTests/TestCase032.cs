// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase032.cs" company="Mir Software">
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
    public class TestCase032 : WrapTrackTestScriptBase
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
        /// The test sign up.
        /// </summary>
        [TestMethod]
        public void Tc032()
        {
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);

            var signUpResult = WrapTrackShell.SignUpAndLogin();

            StfAssert.IsTrue("Sign up and login as test user", signUpResult);

            //toDo : should I login with this new credentials?
            // Are we creating new user here? 
            // in the UI I have : The password must be at least five characters long.
             

            var natiBabyMuluModel = WrapTrackShell.GetToModel("2624");

            StfAssert.IsNotNull("Nati Baby Mulu model", natiBabyMuluModel);

            // review is giving some errors.. 
            var review = natiBabyMuluModel.Review();

            StfAssert.IsNotNull("Review", review);

        }
    }
}
