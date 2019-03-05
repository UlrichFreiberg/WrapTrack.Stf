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
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    using WrapTrack.Stf.Core;
    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Review;

    /// <summary>
    /// News is generated when a user rates a wrap  
    /// </summary>
    [TestClass]
    public class TestCase038 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The brand name.
        /// </summary>
        private const string BrandName = "Agossie";

        /// <summary>
        /// The pattern name.
        /// </summary>
        private const string PatternName = "Orchid";

        /// <summary>
        /// The model name.
        /// </summary>
        private const string ModelName = "Glores";

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
            var criteriaText = GetCriteriaString();
            var evaulationValue = GetEvaulationValue();

            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);
            WrapTrackShell.SignUp();

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);

            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            var newWrap = collection.AddWrap(BrandName, PatternName, ModelName);
            var wrap = GetToWrap(newWrap);
            var makeEvaluationForWrap = MakeEvaluationForWrap(wrap, criteriaText, evaulationValue);

            StfAssert.IsTrue("evaluation made for wrap", makeEvaluationForWrap);

            var doesNewsOfCarrierEvaluationExist = DoesNewsOfCarrierEvaluationExist(ModelName, criteriaText);

            StfAssert.IsTrue("Does news exist that carrier has an evaluation", doesNewsOfCarrierEvaluationExist);
        }

        /// <summary>
        /// get the evaulation value.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetEvaulationValue()
        {
            // TODO: Change the MaxEvaluationValue to 7. 
            // When this is done, need to test for other criteria strings
            const int MaxEvaluationValue = 3;
            var random = new Random();
            var evaluationNumber = random.Next(1, MaxEvaluationValue + 1);

            // evaluationNumber less than length-1 of array of criteriaTexts
            StfAssert.LessThanOrEqual("evaluationNumber within array boundaries", evaluationNumber, MaxEvaluationValue);
            StfAssert.GreaterThanOrEqual("evaluationNumber", evaluationNumber, 0);

            return evaluationNumber;
        }

        /// <summary>
        /// get the criteria string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetCriteriaString()
        {
            var retVal = EnumExtensions.GetRandomEnum<WrapReviewProperties>();

            StfLogger.LogDebug($"Criteria text {retVal}");

            return retVal.GetDisplayName();
        }

        /// <summary>
        /// The mark wrap for review.
        /// </summary>
        /// <param name="wrap">
        /// The wrap.
        /// </param>
        /// <param name="criteriaText">
        /// The criteria for the review
        /// </param>
        /// <param name="evaluationvalue">
        /// The evaulation number to assign to the criteria
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool MakeEvaluationForWrap(IWrap wrap, string criteriaText, int evaluationvalue)
        {
            StfAssert.IsNotNull("Wrap", wrap);
            StfAssert.IsNotNull("criteriaText", criteriaText);
            StfAssert.StringNotEmpty("criteriaText", criteriaText);

            WrapTrackShell.WebAdapter.Click(By.Id("butReview"));

            // mostly for demo purposes - you can follow what happens
            WrapTrackShell.WebAdapter.WaitForComplete(1);

            var xPath = "(//p/span[text()='" + 
                        criteriaText +
                        "']/../../following::div/anmeldelse_bedoemmelse_punkt[" +
                        evaluationvalue + 
                        "])[1]";

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
