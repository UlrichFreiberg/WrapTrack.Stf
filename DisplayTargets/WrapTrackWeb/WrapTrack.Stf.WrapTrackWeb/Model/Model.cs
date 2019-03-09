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

        /// <summary>
        /// The review.
        /// </summary>
        /// <returns>
        /// The <see cref="IReview"/>.
        /// </returns>
        public IReview Review()
        {
            try
            {
                var buttonClick = WebAdapter.ButtonClickByXpath("(//button//span[text()='Review'])[2]");
                
                // var buttonClick = WebAdapter.ButtonClickById("butAddReview");
                if (!buttonClick)
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
            var buttonClickAdminPictures = WebAdapter.ButtonClickByXpath("(//button[@id='but_adm_pic'])[2]");

            if (!buttonClickAdminPictures)
            {
                return false;
            }

            WebAdapter.WaitForComplete(3);

            // handle the File Upload Dialog
            var nativeDialogFileUpload = WebAdapter.NativeDialogFileUpload(By.Id("userfile"), localPathToImage);

            if (!nativeDialogFileUpload)
            {
                return false;
            }

            WebAdapter.WaitForComplete(3);

            // Press upload the image
            var buttonClickUploadImage = WebAdapter.ButtonClickById("but_doupload");

            if (!buttonClickUploadImage)
            {
                return false;
            }

            WebAdapter.WaitForComplete(3);

            return true;
        }
    }
}
