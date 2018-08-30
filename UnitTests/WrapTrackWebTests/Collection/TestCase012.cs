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

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
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
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.Login();
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
        /// The TC012.
        /// </summary>
        [TestMethod]
        public void Tc012()
        {
            // User #1: Add a wrap
            var collection = GetCurrentUserCollection();

            // Find a random wrap
            var wrapToGo = collection.GetRandomWrap();
            var wtId = wrapToGo.WtId; 
            var wtApi = Get<IWtApi>();
            var wrapInfo = wtApi.WrapInfoByTrackId(wtId);
            var internalId = wrapInfo.InternalId;

            WrapTrackShell.Logout();

            // user #2 want the wrap
            var anotherUser = GetAnotherUser(WrapTrackShell);
            
            // TODO: pw should not be hardcoded
            WrapTrackShell.Login(anotherUser, "wraptrack4ever");

            // Move to the new wrap
            var desiredWrap = WrapTrackShell.GetToWrap(internalId);

            desiredWrap.AskFor();
            WrapTrackShell.Logout();

            // User #1: Lets wrap go
            WrapTrackShell.Login(); // Default user
            WrapTrackShell.Me();

            // navigate to the news page - and then to request page
            WrapTrackShell.WebAdapter.ButtonClickById("nav_home");
            WrapTrackShell.WebAdapter.ButtonClickById("navRequests");

            var testNoRequests = WrapTrackShell.WebAdapter.FindElement(By.Id("textNoRequests"));
            var respons = testNoRequests.Displayed;
            
            StfAssert.IsFalse("Dont want to hear 'no pending requests'", respons);

            StfAssert.MissingImplementation("Finish: Steps below");

            // On actual page: Find button id="butAcceptReq". But be sure it's the right button. Link above the button must be related to wrap named <wtId> (see text related to link 'lin_wrap'). 
            // Click to accept the request
            // Find button 'Are you sure?' (id="butDoRequest")
            // Assert: The link to <wtId> is gone (request handled)
            // Log on as user #2 one more time: WrapTrackShell.Login(anotherUser, "wraptrack4ever");
            // Assert: On laning page (users collection) is a link (id="lin_wrap") to  <wtId>  (user #2 is now the owner)
        }
    }
}
