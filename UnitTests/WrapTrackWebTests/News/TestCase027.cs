// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase027.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.News
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    using WrapTrack.Stf.Adapters.WebAdapter;
    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The collection tests.
    /// </summary>
    [TestClass]
    public class TestCase027 : WrapTrackTestScriptBase
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
        /// The t c 027.
        /// </summary>
        [TestMethod]
        public void Tc027()
        {
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);
            WrapTrackShell.SignUp();

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);

            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            var newWrap = collection.AddWrap("Ali Dover", "Hygge", "blue");
            var wrap = GetToWrap(newWrap);

            var chapterText = "some text to add";
            AddChapter(wrap, chapterText);

            DoesNewsExist(newWrap, chapterText);

        }

        private void AddChapter(IWrap wrap, string chapterText)
        {
            WrapTrackShell.WebAdapter.ButtonClickById("butStories");

            WrapTrackShell.WebAdapter.Click(By.XPath("//ejerskab_fortaelling//i"));

            var element = WrapTrackShell.WebAdapter.FindElement(By.XPath("//ejerskab_fortaelling//textarea"));

            element.SendKeys(chapterText);

            WrapTrackShell.WebAdapter.Click(By.XPath("//ejerskab_fortaelling//button[text()='ok']"));
        }

        private IWrap GetToWrap(string wrapId)
        {
            StfAssert.StringNotEmpty("Got ID of new wrap", wrapId);

            var wtApi = Get<IWtApi>();
            var wrapInfoBefore = wtApi.WrapInfoByTrackId(wrapId);
            var internalId = wrapInfoBefore.InternalId;

            // Move to the new wrap
            var retVal = WrapTrackShell.GetToWrap(internalId);

            return retVal;
        }

        private bool DoesNewsExist(string wrapId, string chapterText)
        {
            var news = WrapTrackShell.News();
            var newsEntry = news.GetNewsEntryCarrierStory(wrapId, chapterText);

            StfAssert.IsNotNull("NewsEntry", newsEntry);

//TODO: missing model implementation:           StfAssert.StringEqualsCi("Testing chapter text", chapterText, newsEntry.ChapterText);

            return true;
        }


    }
}
