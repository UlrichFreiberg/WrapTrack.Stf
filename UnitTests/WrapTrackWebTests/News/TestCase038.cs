// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase038.cs" company="Mir Software">
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
    public class TestCase038 : WrapTrackTestScriptBase
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
        /// The tc 038.
        /// News is generated when a user rates a wrap.
        /// The user adds some of the review parameters and these are checked 
        /// for entries in the news ite.
        /// </summary>
        [TestMethod]
        public void Tc038()
        {
            const string CriteriaText = "Easycare";
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

            var makeEvaluationForWrap = MakeEvaluationForWrap(wrap, CriteriaText);

            StfAssert.IsTrue("evaluation made for wrap", makeEvaluationForWrap);

            var doesNewsOfCarrierEvaluationExist = DoesNewsOfCarrierEvaluationExist(ModelName, CriteriaText);

            StfAssert.IsTrue("Does news exist that carrier has an evaluation", doesNewsOfCarrierEvaluationExist);
        }

        /// <summary>
        /// The mark wrap for review.
        /// </summary>
        /// <param name="wrap">
        /// The wrap.
        /// </param>
        /// <param name="criteriaText">
        /// The text to add to the review
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool MakeEvaluationForWrap(IWrap wrap, string criteriaText)
        {
            StfAssert.IsNotNull("Wrap", wrap);
            StfAssert.IsNotNull("criteriaText", criteriaText);
            StfAssert.StringNotEmpty("criteriaText", criteriaText);

            WrapTrackShell.WebAdapter.Click(By.Id("butReview"));

            // mostly for demo purposes - you can follow what happens
            WrapTrackShell.WebAdapter.WaitForComplete(1);

            var xPath = "(//p/span[text()='" + 
                        criteriaText + 
                        "']/../../following::div/anmeldelse_bedoemmelse_punkt[1])[1]";

            StfLogger.LogDebug("criteria text xpath ", xPath);

            var elem = WrapTrackShell.WebAdapter.FindElement(By.XPath(xPath));

            elem.Click();

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
        /// <param name="criteriaText">
        /// The review text
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DoesNewsOfCarrierEvaluationExist(string modelName, string criteriaText)
        {
            StfAssert.StringNotEmpty("modelId", modelName);
            StfAssert.StringNotEmpty("criteriaText", criteriaText);

            var news = WrapTrackShell.News();
            var newsEntry = news.GetNewsEntryCarrierEvaluation(modelName, criteriaText);

            StfAssert.IsNotNull("NewsEntry", newsEntry);

            return true;
        }
    }
}
