// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Me.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Me interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me
{
    using Adapters.WebAdapter;
    using Mir.Stf.Utilities;
    using OpenQA.Selenium;
    using System;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The Me interface.
    /// </summary>
    public class Me : IMe
    {
        private IWebAdapter WebAdapter { get; set; }
        //private IWebElement actualImage;

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
        /// Upload an profile image 
        /// </summary>
        /// <returns></returns>
         public IUploadProfileImage UploadProfileImage()
        {
            var image = WebAdapter.FindElement(By.Id("img_profile"));

            //return new UploadProfileImage();
            throw new NotImplementedException();
            
        }
    }
}