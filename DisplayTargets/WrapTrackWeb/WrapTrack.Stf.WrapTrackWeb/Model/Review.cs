using OpenQA.Selenium;
using System;
using WrapTrack.Stf.WrapTrackWeb.Interfaces;

namespace WrapTrack.Stf.WrapTrackWeb.Model
{

    /// <summary>
    /// The Review.
    /// </summary>
    public class Review : WrapTrackWebShellModelBase, IReview
    {
        /// <inheritdoc />
        public Review(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <inheritdoc />
        public string Description
        {
            set
            {
                var descriptionTextArea = WebAdapter.TextboxSetTextByXpath(@"//textarea[@name='fortaelling']", value);
            }
        }

        /// <inheritdoc />
        public bool Add()
        {
            try
            {
                var addBtn = WebAdapter.ButtonClickById("butSaveReviewOneLang");

                WebAdapter.WaitForComplete(2);

                //toDo:  Button name, according to the test case it should be Add review in another.. now it is Add evaluation..
                var addBtnInAnotherLanguage = WebAdapter.FindElement(By.XPath(
                    "//button[@id='butAddAnotherLang']/p/span/span[contains(text(),'Add evaluation in another language')]"));

                if (addBtnInAnotherLanguage == null)
                {
                    StfLogger.LogError("Couldn't find button Add review in another language");

                    return false;
                }

                return addBtn && addBtnInAnotherLanguage.Displayed;
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"Something went wrong when added review. Error message : [{ex.Message}]");
                throw;
            }
        }
    }
}
