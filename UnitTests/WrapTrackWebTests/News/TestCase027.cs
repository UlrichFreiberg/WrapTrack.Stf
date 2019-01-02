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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

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
            const string ChapterText = "Some text to add from TC027";

            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);
            WrapTrackShell.SignUp();

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);

            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            var newWrap = collection.AddWrap("Ali Dover", "Hygge", "blue");
            var wrap = GetToWrap(newWrap);
            var addChapter = AddChapter(wrap, ChapterText);

            StfAssert.IsTrue("Added Chapter", addChapter);

            var doesNewsExist = DoesNewsExist(newWrap, ChapterText);

            StfAssert.IsTrue("Does news exist for the added Chapter", doesNewsExist);
            StfLogger.LogInfo("Hi Brian, here is the currently logged in user {0}", WrapTrackShell.CurrentLoggedInUser);
        }

        /// <summary>
        /// The add chapter.
        /// </summary>
        /// <param name="wrap">
        /// The wrap.
        /// </param>
        /// <param name="chapterText">
        /// The chapter text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool AddChapter(IWrap wrap, string chapterText)
        {
            StfAssert.IsNotNull("Wrap", wrap);
            WrapTrackShell.WebAdapter.ButtonClickById("butStories");
            WrapTrackShell.WebAdapter.Click(By.XPath("//ejerskab_fortaelling//i"));

            var element = WrapTrackShell.WebAdapter.FindElement(By.XPath("//ejerskab_fortaelling//textarea"));

            element.SendKeys(chapterText);
            WrapTrackShell.WebAdapter.Click(By.XPath("//ejerskab_fortaelling//button[text()='ok']"));

            return true;
        }

        /// <summary>
        /// The get to wrap.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="IWrap"/>.
        /// </returns>
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

        /// <summary>
        /// The does news exist.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <param name="chapterText">
        /// The chapter text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DoesNewsExist(string wrapId, string chapterText)
        {
            StfAssert.StringNotEmpty("WrapId", wrapId);

            var news = WrapTrackShell.News();
            var newsEntry = news.GetNewsEntryCarrierStory(wrapId, chapterText);

            StfAssert.IsNotNull("NewsEntry", newsEntry);

            return true;
        }
    }
}
