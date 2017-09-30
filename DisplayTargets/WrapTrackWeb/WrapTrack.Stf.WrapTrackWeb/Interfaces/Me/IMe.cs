// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ime.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Me interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me
{
    /// <summary>
    /// The Me interface.
    /// </summary>
    public interface IMe
    {
        /// <summary>
        /// The image related to Me
        /// </summary>
        /// <returns>
        /// IWebElement containing information about the actual img 
        /// - false if no img related to Me
        /// </returns>
        string ActualImage();

        /// <summary>
        /// The actual image related to users profile
        /// </summary>
        /// <returns>
        /// NULL if no image related
        /// </returns>
        bool UploadProfileImage();
    }
}