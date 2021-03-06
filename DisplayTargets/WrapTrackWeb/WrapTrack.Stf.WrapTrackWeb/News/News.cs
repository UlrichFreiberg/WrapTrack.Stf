// --------------------------------------------------------------------------------------------------------------------
// <copyright file="News.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the News type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.News
{
    using System.Linq;
    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.News;

    /// <summary>
    /// The News tab page - wraps section.
    /// </summary>
    public class News : WrapTrackWebShellModelBase, INews
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="News"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public News(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// The get news entry carrier story that contains the chapter text for the wrap.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <param name="chapterText">
        /// The chapter text.
        /// </param>
        /// <returns>
        /// The <see cref="INewsEntryCarrierStory"/>.
        /// </returns>
        public INewsEntryCarrierStory GetNewsEntryCarrierStory(string wrapId, string chapterText)
        {
            var elements = WebAdapter.FindElements(By.Id("baereredskab_fortaelling"));

            if (elements.Count != 1)
            {
                StfLogger.LogError("only support 1 carrier story");
                return null;
            }

            var element = elements.First();
            if (element == null)
            {
                StfLogger.LogError("elements.first() returned a null element");
                return null;
            }

            var newsEntryCarrierStory = Get<INewsEntryCarrierStory>();

            if (newsEntryCarrierStory == null)
            {
                StfLogger.LogError("Could not newsEntryCarrierStory from Get<INewsEntryCarrierStory>");
                return null;
            }

            newsEntryCarrierStory.Text = element.Text;

            // :TODO test also for currentloggedinser at start of header text. Waiting for issue #33. See next comment line
            // if (!newsEntryCarrierStory.HeaderText.Contains(WrapTrackWebShell.CurrentLoggedInUser)
            var baseHeaderTextForNewsStory = "has written a new chapter in the story";
            if (!newsEntryCarrierStory.HeaderText.Contains(baseHeaderTextForNewsStory)
                || 
                !newsEntryCarrierStory.WrapText.Contains(wrapId)
                ||
                !newsEntryCarrierStory.ChapterText.Equals(chapterText))
            {
                return null;
            }

            return newsEntryCarrierStory;
        }

        /// <summary>
        /// The get news entry carrier for sale.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <param name="typeOfSale">
        /// The type Of Sale.
        /// </param>
        /// <returns>
        /// The <see cref="INewsEntryCarrierForSale"/>.
        /// </returns>
        public INewsEntryCarrierForSale GetNewsEntryCarrierForSale(string wrapId, string typeOfSale)
        {
            var elements = WebAdapter.FindElements(By.Id("baereredskab_paamarkedet"));

            if (elements.Count != 1)
            {
                StfLogger.LogError("only support 1 carrier story");
                return null;
            }

            var element = elements.First();
            if (element == null)
            {
                StfLogger.LogError("elements.first() returned a null element");
                return null;
            }

            var newsEntryCarrierForSale = Get<INewsEntryCarrierForSale>();

            if (newsEntryCarrierForSale == null)
            {
                StfLogger.LogError("Could not get newsEntryCarrierForSale from Get<INewsEntryCarrierForSale>");
                return null;
            }

            newsEntryCarrierForSale.Text = element.Text;

            if (!newsEntryCarrierForSale.HeaderText.Contains(WrapTrackWebShell.CurrentLoggedInUser)
                ||
                !newsEntryCarrierForSale.WrapText.Contains(wrapId)
                ||
                !newsEntryCarrierForSale.StatusText.Equals(typeOfSale))
            {
                return null;
            }

            return newsEntryCarrierForSale;
        }

        /// <summary>
        /// The get news entry carrier review.
        /// </summary>
        /// <param name="modelName">
        /// The model name
        /// </param>
        /// <param name="reviewText">
        /// The text for the review
        /// </param>
        /// <returns>
        /// The <see cref="INewsEntryCarrierReview"/>.
        /// </returns>
        public INewsEntryCarrierReview GetNewsEntryCarrierReview(string modelName, string reviewText)
        {
            var elements = WebAdapter.FindElements(By.Id("anmeldelse_vurdering"));

            WebAdapter.WaitForComplete(30);

            StfLogger.LogDebug("no. carrier review stories :" + elements.Count);
            if (elements.Count != 1)
            {
                StfLogger.LogError("only support 1 carrier review");
                return null;
            }

            var element = elements.First();

            if (element == null)
            {
                StfLogger.LogError("elements.first() returned a null element");
                return null;
            }

            var newsEntryCarrierReview = Get<INewsEntryCarrierReview>();

            if (newsEntryCarrierReview == null)
            {
                StfLogger.LogError("Could not get newsEntryCarrierReview from Get<INewsEntryCarrierReview>");
                return null;
            }

            newsEntryCarrierReview.Text = element.Text;

            if (!newsEntryCarrierReview.HeaderText.Contains(WrapTrackWebShell.CurrentLoggedInUser))
            {
                StfLogger.LogDebug("Returning null as !newsEntryCarrierReview.HeaderText.Contains(WrapTrackWebShell.CurrentLoggedInUser)");
                return null;
            }

            if (!newsEntryCarrierReview.WrapText.Contains(modelName))
            {
                StfLogger.LogDebug("Returning null as !newsEntryCarrierReview.WrapText.Contains(modelId)");
                return null;
            }

            if (!newsEntryCarrierReview.ReviewText.Equals(reviewText))
            {
                StfLogger.LogDebug("Returning null as !newsEntryCarrierReview.ReviewText.Equals(reviewText)");
                return null;
            }

            return newsEntryCarrierReview;
        }

        /// <summary>
        /// The get news entry carrier evaulation
        /// </summary>
        /// <param name="modelName">
        /// The model name 
        /// </param>
        /// <param name="criteria">
        /// The criteria
        /// </param>
        /// <returns>
        /// The <see cref="INewsEntryCarrierEvaluation"/>.
        /// </returns>
        public INewsEntryCarrierEvaluation GetNewsEntryCarrierEvaluation(string modelName, string criteria)
        {
            var elements = WebAdapter.FindElements(By.Id("anmeldelse_bedoemmelse"));

            // TODO: Could be we should call the API so this becomes a bit more event driven:-) 
            WebAdapter.WaitForComplete(30);
            StfLogger.LogDebug("no. carrier evaluations :" + elements.Count);

            if (elements.Count != 1)
            {
                StfLogger.LogError($"only support 1 carrier evaluation - found {elements.Count} elements");
                return null;
            }

            var element = elements.First();

            if (element == null)
            {
                StfLogger.LogError("elements.first() returned a null element");
                return null;
            }

            var newsEntryCarrierEvaluation = Get<INewsEntryCarrierEvaluation>();

            if (newsEntryCarrierEvaluation == null)
            {
                StfLogger.LogError("Could not get newsEntryCarrierEvaluation from Get<INewsEntryCarrierEvaluation>");
                return null;
            }

            newsEntryCarrierEvaluation.Text = element.Text;

            if (!newsEntryCarrierEvaluation.HeaderText.Contains(WrapTrackWebShell.CurrentLoggedInUser))
            {
                StfLogger.LogDebug("Returning null as !newsEntryCarrierEvaluation.HeaderText.Contains(WrapTrackWebShell.CurrentLoggedInUser)");
                return null;
            }

            if (!newsEntryCarrierEvaluation.WrapText.Contains(modelName))
            {
                StfLogger.LogDebug("Returning null as !newsEntryCarrierEvaluation.WrapText.Contains(modelId)");
                return null;
            }

            if (!newsEntryCarrierEvaluation.CriteriaText.Equals(criteria))
            {
                StfLogger.LogDebug("Returning null as !newsEntryCarrierEvaluation.CriteriaText.Equals(criteria)");
                return null;
            }

            return newsEntryCarrierEvaluation;
        }
    }
}