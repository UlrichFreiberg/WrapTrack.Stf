// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase012.cs" company="Mir Software">
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
    /// Test of letting a wrap pass on from one user to another. 
    /// Another user initiatives this action.
    /// Default date.
    /// </summary>
    [TestClass]
    public class TestCase012 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // Find a random wrap
            WrapTrackShell = Get<IWrapTrackWebShell>();

            WrapTrackShell.Login(); // Default user
            var collection = GetCurrentUserCollection();

            // Find a random wrap
            var wrapToGo = collection.GetRandomWrap();
            var wtId = wrapToGo.WtId;

            WrapTrackShell.Logout(); 
        }

        /// <summary>
        /// The TC012.
        /// </summary>
        [TestMethod]
        public void Tc012()
        {
            var anotherUser = GetAnotherUser(WrapTrackShell);

            WrapTrackShell.Login(anotherUser);

            // Mark the test script as InProgress
            StfAssert.IsNotNull("TestCase NOT finished", null);

            // StfAssert.IsNotNull("Got a random wrap", wrapToGo);
            // var x = wrapToGo.PassOn(anotherUser);

            // StfAssert.IsTrue("PassedOn", x);
            // StfAssert.IsTrue("PassedOn Validated", ValidatePassOn(wtId, anotherUser));
        }
    }
}
