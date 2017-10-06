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
            var nav = WebAdapter.FindElement(By.Id("nav_collection"));
          nav.Click();
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
            var nav = WebAdapter.FindElement(By.Id("nav_upload_profile"));

            nav.Click();

            var element = WebAdapter.FindElement(By.Name("userfile"));

            element.Clear();
            element.SendKeys(clientSideFilePath);

            var submitButton = WebAdapter.FindElement(By.Id("but_upl_profile"));

            submitButton.Submit();

            // Back to me again
            var navBack = WebAdapter.FindElement(By.Id("nav_back_profile"));

            navBack.Click();
            return true;
        }
    }
}