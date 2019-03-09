// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelReview.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the ModelReview type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Review
{
    using OpenQA.Selenium;

    using WrapTrack.Stf.Core;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Review;
    using WrapTrack.Stf.WrapTrackWeb.News;

    /// <summary>
    /// The News tab page - wraps section.
    /// </summary>
    public class ModelReview : WrapTrackWebShellModelBase, IModelReview
    {
        /// <summary>
        /// The review text xpath.
        /// </summary>
        private const string ReviewTextXpath = "//textarea[@name='fortaelling']";

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelReview"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public ModelReview(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the review text.
        /// </summary>
        public string ReviewText
        {
            get
            {
                var elem = WrapTrackWebShell.WebAdapter.FindElement(By.XPath(ReviewTextXpath));
                var retVal = elem.Text;

                return retVal;
            }

            set
            {
                var elem = WrapTrackWebShell.WebAdapter.FindElement(By.XPath(ReviewTextXpath));

                elem.SendKeys(value);
            }
        }

        /// <summary>
        /// The set review property value.
        /// </summary>
        /// <param name="modelReviewProperty">
        /// The model review property.
        /// </param>
        /// <param name="modelReviewValues">
        /// The review value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SetReviewPropertyValue(ModelReviewProperties modelReviewProperty, ModelReviewValues modelReviewValues)
        {
            var criteriaText = modelReviewProperty.GetDisplayName();
            var evaluationvalue = (int)modelReviewValues;
            var xPath = "(//p/span[text()='" +
                        criteriaText +
                        "']/../../following::div/anmeldelse_bedoemmelse_punkt[" +
                        evaluationvalue +
                        "])[1]";

            StfLogger.LogDebug("criteria text xpath ", xPath);

            var retVal = WrapTrackWebShell.WebAdapter.Click(By.XPath(xPath));

            if (!retVal)
            {
                StfLogger.LogError($"Couldn't find the criteria {modelReviewProperty}");
                return false;
            }

            WebAdapter.WaitForComplete(1);
            retVal = WebAdapter.Click(By.Id("butSaveReviewOneLang"));

            return retVal;
        }
    }
}