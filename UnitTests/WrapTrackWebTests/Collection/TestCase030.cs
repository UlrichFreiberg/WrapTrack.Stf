// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase030.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// Deleting a wrap registred as an error. User is second owner.
    /// </summary>
    [TestClass]
    public class TestCase030 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.Login();

            // GetCurrentUserCollection will add one wrap if none found
            // Ensure we have enough wraps for all test instances
            this.GetCurrentUserCollection(this.WrapTrackShell);
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
        /// The tc 030.
        /// </summary>
        public void Tc030()
        {
            var collection = GetCurrentUserCollection();

            // Find a random wrap
            var wrapToGo = collection.GetRandomWrap();
            var wtId = wrapToGo.WtId;

            StfAssert.IsNotNull("Got a random wrap", wrapToGo);

            var anotherUser = GetAnotherUser(WrapTrackShell);
            var passOn = wrapToGo.PassOn(anotherUser);

            StfAssert.IsTrue("PassedOn", passOn);
            StfAssert.IsTrue("PassedOn Validated", ValidatePassOn(wtId, anotherUser));

            WrapTrackShell.Logout();

            // Log on as new user and mark that this is a mistake
            // TODO: pw should not be hardcoded
            WrapTrackShell.Login(anotherUser, "wraptrack4ever");

            StfAssert.IsTrue("Not implemented yet", false); 
        }
    }
}
