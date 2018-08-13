// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModel.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces
{
    /// <summary>
    /// The Model interface.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// The upload picture.
        /// </summary>
        /// <param name="localPathToImage">
        /// The local path to image.
        /// </param>
        /// <returns>
        /// Indication of success.
        /// </returns>
        bool UploadPicture(string localPathToImage);
    }
}
