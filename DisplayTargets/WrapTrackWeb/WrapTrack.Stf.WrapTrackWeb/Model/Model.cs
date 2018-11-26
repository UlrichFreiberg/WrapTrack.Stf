// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Model.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Model type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Model
{
    using System;
    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The learn more.
    /// </summary>
    public class Model : WrapTrackWebShellModelBase, IModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class. 
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Model(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        public IReview Review()
        {
            try
            {
                //var reviewBtn = WebAdapter.FindElement(By.XPath("(//button//span[text()='Review'])[2]"));
                var buttonClickByXpath = WebAdapter.ButtonClickByXpath("(//button//span[text()='Review'])[2]");

                if (!buttonClickByXpath)
                {
                    return null;
                }

                var reviewDetails = Get<IReview>();

                return reviewDetails;
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"Something went wrong when opening Review. Message : [{ex.Message}]");
                throw;
            }

        }

        /// <summary>
        /// The upload picture.
        /// </summary>
        /// <param name="localPathToImage">
        /// The local path to image.
        /// </param>
        /// <returns>
        /// Indication of success.
        /// </returns>
        public bool UploadPicture(string localPathToImage)
        {
            // click the button 'Administrate pictures' 
            // WebAdapter.ButtonClickById("admModelImages");
            WebAdapter.ButtonClickByXpath("(//button[@id='admModelImages'])[2]");

            WebAdapter.WaitForComplete(3);

            // handle the File Upload Dialog
            WebAdapter.NativeDialogFileUpload(By.Id("userfile"), localPathToImage);

            WebAdapter.WaitForComplete(3);

            // Press upload the image
            WebAdapter.ButtonClickById("but_doupload");

            WebAdapter.WaitForComplete(3);

            return true;
        }
    }
}
