// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase037.cs" company="Mir Software">
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
    /// News is generated when a user rates a wrap  
    /// </summary>
    [TestClass]
    public class TestCase037 : WrapTrackTestScriptBase
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
        /// The tc 037.
        /// News is generated when a user rates a wrap
        /// </summary>
        [TestMethod]
        public void Tc037()
        {
            const string ReviewText = "This is an automated review by TC037";
            const string BrandName = "Agossie";
            const string PatternName = "Orchid";
            const string ModelName = "Glores";

            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);
            WrapTrackShell.SignUp();

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);

            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            var newWrap = collection.AddWrap(BrandName, PatternName, ModelName);
            var wrap = GetToWrap(newWrap);

            var writeReviewForWrap = WriteReviewForWrap(wrap, ReviewText);

            StfAssert.IsTrue("Review written for wrap", writeReviewForWrap);

            var doesNewsOfCarrierReviewExist = this.DoesNewsOfCarrierReviewExist(ModelName, ReviewText);

            StfAssert.IsTrue("Does news exist that carrier has a review", doesNewsOfCarrierReviewExist);
        }

        /// <summary>
        /// The mark wrap for review.
        /// </summary>
        /// <param name="wrap">
        /// The wrap.
        /// </param>
        /// <param name="reviewText">
        /// The text to add to the review
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool WriteReviewForWrap(IWrap wrap, string reviewText)
        {
            StfAssert.IsNotNull("Wrap", wrap);
            StfAssert.IsNotNull("reviewText", reviewText);
            StfAssert.StringNotEmpty("reviewText", reviewText);

            WrapTrackShell.WebAdapter.Click(By.Id("butReview"));

            // mostly for demo purposes - you can follow what happens
            WrapTrackShell.WebAdapter.WaitForComplete(1);

            var elem = WrapTrackShell.WebAdapter.FindElement(By.XPath("//textarea[@name='fortaelling']"));

            elem.SendKeys(reviewText);
            WrapTrackShell.WebAdapter.WaitForComplete(1);

            WrapTrackShell.WebAdapter.Click(By.Id("butSaveReviewOneLang"));

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
        /// <param name="modelName">
        /// The model name
        /// </param>
        /// <param name="reviewText">
        /// The review text
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DoesNewsOfCarrierReviewExist(string modelName, string reviewText)
        {
            StfAssert.StringNotEmpty("modelId", modelName);
            StfAssert.StringNotEmpty("reviewText", reviewText);

            var news = WrapTrackShell.News();
            var newsEntry = news.GetNewsEntryCarrierReview(modelName, reviewText);

            StfAssert.IsNotNull("NewsEntry", newsEntry);

            return true;
        }
    }
}
