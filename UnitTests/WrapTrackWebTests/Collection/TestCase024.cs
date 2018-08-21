// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase024.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The test case 020.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The test case 024.
    /// </summary>
    [TestClass]
    public class TestCase024 : WrapTrackTestScriptBase
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
        /// Wrap Visits Test. Send a wrap on holiday that is not álready on holiday 
        /// </summary>
        /// <remarks>
        /// Create a new wrap. 
        /// Search for this wrap
        /// Send it on Holiday
        /// Find the wrap again and check if its on holiday 
        /// </remarks>
        [TestMethod]
        public void Tc024()
        {
            // Set up user context for actual test
            // Use default user
            WrapTrackShell.Login();

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("WrapTrackShell", WrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));

            // Create a new wrap
            var wrapCollection = me.GetCollection();

            StfAssert.IsNotNull("check if me.GetCollection null", wrapCollection);

            var newWrapWtId = wrapCollection.AddWrap();
            var wtApi = Get<IWtApi>();
            var wrapInfoBefore = wtApi.WrapInfoByTrackId(newWrapWtId);
            var internalId = wrapInfoBefore.InternalId;

            // Move to the new wrap
            var wraptoSendOnVisit = WrapTrackShell.GetToWrap(internalId);

           // StfAssert.IsNotNull("Check if wraptoSendOnVisit is null", wraptoSendOnVisit);

            // Move to the new wrap
           // var wraptoSendOnVisit = WrapTrackShell.GetToWrap(newWrapWtId);
            var recipient = GetAnotherUser();

            // Send wrap away on holiday
            wraptoSendOnVisit.SendAwayTemporarily(SendAwayReason.Holiday, recipient);

            // Validate the the wrap indeed is on holiday
            var wrapInfoAfter = wtApi.WrapInfoByTrackId(newWrapWtId);
            var userId = wtApi.UserId(recipient);

            StfLogger.LogInfo("The recipient user name, user id attempted is {0},{1} and userid from wrapInfo API is {1}", recipient, userId, wrapInfoAfter.VisitingUserId);

            StfAssert.IsTrue("Wrap is on holiday", wrapInfoAfter.OnHoliday);
            StfAssert.AreEqual("recipient userid is same as VisitingUserId in wrap", userId, wrapInfoAfter.VisitingUserId);
        }
    }
}
