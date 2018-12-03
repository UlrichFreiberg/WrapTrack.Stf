// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMeProfile.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The MeProfile interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me
{
    /// <summary>
    /// The MeProfile interface.
    /// </summary>
    public interface IMeProfile
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The image related to MeProfile
        /// </summary>
        /// <returns>
        /// IWebElement containing information about the actual img 
        /// - false if no img related to MeProfile
        /// </returns>
        string ActualImage();

        /// <summary>
        /// The users collection.
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        ICollection GetCollection();

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