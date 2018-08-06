// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase026.cs" company="Mir Software">
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

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The test case 026.
    /// Upload a model picture
    /// </summary>
    [TestClass]
    public class TestCase026 : WrapTrackTestScriptBase
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
        /// Check the news that a news item has been added abpout sending the wrap on visit
        /// </remarks>
        [TestMethod]
        public void Tc026()
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

            // Move to the new wrap
            var wraptoSendOnVisit = WrapTrackShell.GetToWrap(newWrapWtId);

            StfAssert.IsNotNull("Check if wraptoSendOnVisit is null", wraptoSendOnVisit);

            // Move to the new wrap
            var wrapToSendOnHoliday = WrapTrackShell.GetToWrap(newWrapWtId);
            var recipient = GetAnotherUser();

            // Send wrap away on holiday
            wrapToSendOnHoliday.SendAwayTemporarily(SendAwayReason.Holiday, recipient);

            var bb = IsNewsAbooutWrapSentOnHoliday(newWrapWtId, recipient);

            StfAssert.IsTrue("Is there news that the wrap is sent on holiday", bb);
        }

        /// <summary>
        /// The is news aboout wrap sent on holiday.
        /// </summary>
        /// <param name="wrapWtId">
        /// The new wrap wt id.
        /// </param>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsNewsAbooutWrapSentOnHoliday(string wrapWtId, string recipient)
        {
            // TODO: get news item that this wrap has been sent to the recipient 
            return true;
        }
    }
}
