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
        /// The users collection.
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        ICollection Get_Collection();

        /// <summary>
        /// Upload an profile image 
        /// </summary>
        /// <param name="clientSideFilePath">
        /// The client Side File Path.
        /// </param>
        /// <returns>
        /// Inidcation of success
        /// </returns>
        bool UploadProfileImage(string clientSideFilePath);
    }
}