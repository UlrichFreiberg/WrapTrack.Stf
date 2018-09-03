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
    using System;

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

            // On actual page: Find button id="butAcceptReq". But be sure it's the right button.  
            var xPath = $"//a[text()='{wtId}']/../../../../../..//button[@id='butAcceptReq']";
            var retVal = WrapTrackShell.WebAdapter.Click(By.XPath(xPath));

            if (!retVal)
            {
                StfAssert.IsFalse("Accept button not found", true);
            }

            // var xPath2 = "//button[@id='butDoReq']";
            var xPath2 = $"//a[text()='{wtId}']/../../../../../..//button[@id='butDoReq']";
            var retVal2 = WrapTrackShell.WebAdapter.Click(By.XPath(xPath2));

            // Click to accept the request
            if (!retVal2)
            {
                StfAssert.IsFalse("Do-it button not found", true);
            }

            // Assert: The link to <wtId> is gone (request handled)
            Wait(TimeSpan.FromSeconds(1));
            var xPath3 = $"//a[text()='{wtId}']"; 
            var retVal3 = WrapTrackShell.WebAdapter.FindElement(By.XPath(xPath3));
            StfAssert.IsNull("Reqest is gone", retVal3);

            // Assert: New owner is user#2
            var validationTarget = Get<IWtApi>();
            var wrapInfoAfter = validationTarget.WrapInfoByTrackId(wtId);
            var newOwnerName = wrapInfoAfter.OwnerName;

            StfAssert.AreEqual("User #2 is new owner", newOwnerName, anotherUser);
        }
    }
}
