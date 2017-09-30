// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Me.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Me interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.MeClasses
{
    using System;

    using OpenQA.Selenium;

    using WrapTrack.Stf.Adapters.WebAdapter;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The Me interface.
    /// </summary>
    public class Me : WrapTrackWebShellModelBase, IMe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Me"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Me(IWrapTrackWebShell wrapTrackWebShell)
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