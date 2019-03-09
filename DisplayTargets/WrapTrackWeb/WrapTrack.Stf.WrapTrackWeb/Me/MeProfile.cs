// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeProfile.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The MeProfile interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me
{
    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The MeProfile interface.
    /// </summary>
    public class MeProfile : WrapTrackWebShellModelBase, IMeProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeProfile"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public MeProfile(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username
        {
            get
            {
                var elem = WebAdapter.FindElement(By.Id("userName"));

                return elem.Text;
            }

            set
            {
                // Gotta click for the text box to appear
                var retValClick = WebAdapter.ButtonClickById("userName");

                if (!retValClick)
                {
                    return;
                }

                // insert the value
                var retValTextSet = WebAdapter.TextboxSetTextByXpath("//input[@class='basisinputfelt']", value);

                if (!retValTextSet)
                {
                    return;
                }

                // Wait for the DOM to be rendered
                WebAdapter.WaitForComplete(2);

                // Accept new name, by clicking OK - Weird ID, but true:-)
                var retValButtonClick = WebAdapter.ButtonClickById("butUserNameOK");

                if (!retValButtonClick)
                {
                    return;
                }

                // Wait for the DOM to be rendered
                WebAdapter.WaitForComplete(2);
            }
        }

        /// <summary>
        /// The actual image related to users profile
        /// </summary>
        /// <returns>
        /// NULL if no image related, otherwise the SRC path
        /// </returns>
        public string ActualImage()
        {
            var image = WebAdapter.FindElement(By.Id("img_profile"));
            var retVal = image?.GetAttribute("src");

            return retVal;
        }

        /// <summary>
        /// Finds users collection
        /// </summary>
        /// <returns>
        /// NULL if user has no wraps in collection
        /// </returns>
        public ICollection GetCollection()
        {
            WebAdapter.ButtonClickById("nav_collection");

            var retVal = StfContainer.Get<ICollection>();

            return retVal; 
        }

        /// <summary>
        /// Upload an profile image 
        /// </summary>
        /// <param name="clientSideFilePath">
        /// The client Side File Path.
        /// </param>
        /// <returns>
        /// Inidcation of success
        /// </returns>
        public bool UploadProfileImage(string clientSideFilePath)
        {
            // Visit upload page
            WebAdapter.ButtonClickById("nav_upload_profile");

            // handle the File Upload Dialog
            WebAdapter.NativeDialogFileUpload(By.Name("userfile"), clientSideFilePath);

            var submitButton = WebAdapter.FindElement(By.Id("but_doupload"));

            if (submitButton == null)
            {
                StfLogger.LogError("Couldn't find the upload button");

                return false;
            }

            submitButton.Click();

            // Back to me again
            var navBack = WebAdapter.FindElement(By.Id("but_back"));

            navBack.Click();

            return true;
        }
    }
}