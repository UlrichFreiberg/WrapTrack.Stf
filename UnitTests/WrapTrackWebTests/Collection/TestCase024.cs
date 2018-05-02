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
    /// The test case 020.
    /// </summary>
    [TestClass]
    public class TestCase024 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The wt testscript utils.
        /// </summary>
        private WtTestscriptUtils wtTestscriptUtils;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = this.Get<IWrapTrackWebShell>();
            wtTestscriptUtils = new WtTestscriptUtils(StfLogger);
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

            StfAssert.IsNotNull("WrapTrackShell", this.WrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));

            // Actual test 

            // Create a new wrap
            var wrapCollection = me.GetCollection();

            StfAssert.IsNotNull("check if me.GetCollection null", wrapCollection);

            var newWrapWtId = wrapCollection.AddWrap();

            // Move to the new wrap
            var wrapToSendOnHoliday = this.WrapTrackShell.GetToWrap(newWrapWtId);
            var recipient = this.GetAnotherUser();

            // Send warp away on holiday
            wrapToSendOnHoliday.SendAwayTemporarily(SendAwayReason.Holiday, recipient);

            // Validate the the wrap indeed is on holiday
            var wtApi = this.Get<IWtApi>();
            var wrapInfo = wtApi.WrapInfoByTrackId(newWrapWtId);

            StfLogger.LogInfo("The recipient user name attempted is {0} and userid from wrapInfo API is {1}", recipient, wrapInfo.VisitingUserId);
            StfAssert.IsTrue("Wrap is on holiday", wrapInfo.OnHoliday);
        }
    }
}
