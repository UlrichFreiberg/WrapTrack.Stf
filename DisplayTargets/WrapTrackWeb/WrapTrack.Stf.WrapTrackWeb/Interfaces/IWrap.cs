// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWrap.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWrap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Review;
    using WrapTrack.Stf.WrapTrackWeb.Me.Collection;

    /// <summary>
    /// Status used for Finding by status
    /// </summary>
    [Flags]
    public enum FinderCriteria
    {
        /// <summary>
        /// Status is unknown
        /// </summary>
        Unknown = 1 << 0,

        /// <summary>
        /// Used when requesting a random wrap
        /// </summary>
        Random = 1 << 1,

        /// <summary>
        /// Wrap is on holiday
        /// </summary>
        OnHoliday = 1 << 2,

        /// <summary>
        /// Number of pictures for the Wrap
        /// </summary>
        Pictures = 1 << 3
    }

    /// <summary>
    /// The send away reason.
    /// </summary>
    public enum SendAwayReason
    {
        /// <summary>
        /// The holiday.
        /// </summary>
        Holiday,

        /// <summary>
        /// The tester.
        /// </summary>
        Tester,

        /// <summary>
        /// The rent.
        /// </summary>
        Rent
    }

    /// <summary>
    /// The Wrap interface.
    /// </summary>
    public interface IWrap
    {
        /// <summary>
        /// Gets or sets the patterns.
        /// </summary>
        int Patterns { get; set; }

        /// <summary>
        /// Gets or sets the models.
        /// </summary>
        int Models { get; set; }

        /// <summary>
        /// Gets or sets the wraps.
        /// </summary>
        int Wraps { get; set; }

        /// <summary>
        /// Gets the wt id.
        /// </summary>
        string WtId { get; }

        /// <summary>
        /// Gets or sets the num of private pictures.
        /// </summary>
        int NumPictures { get; set; }

        /// <summary>
        /// Pass on wrap to user v's collection
        /// </summary>
        /// <param name="nameOfReciever">
        /// The name of the recieving user.
        /// </param>
        /// <param name="ownershipStart">
        /// The ownership Start. If not set the default date is used.
        /// </param>
        /// <returns>
        /// Indocation of success
        /// </returns>
        bool PassOn(string nameOfReciever, string ownershipStart = null);

        /// <summary>
        /// Ask for the wrap (only possible for not-owner of wrap)
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool AskFor();

        /// <summary>
        /// Upload users own pictures of the wrap
        /// </summary>
        /// <param name="clientSideFilePat">
        /// The client Side File Pat.
        /// </param>
        /// <param name="numUploads">
        /// The num of uploads of this picture is going to be performed.
        /// </param>
        /// <returns>
        /// True if upload was success
        /// </returns>
        bool UploadWrapImage(string clientSideFilePat, int numUploads = 1);

        /// <summary>
        /// The remove ONE wrap image. 
        /// </summary>
        /// <param name="imageIndex">
        /// The index of the image to delete - if 1 then the image listed in the top
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool RemoveWrapImage(int imageIndex = 1);

        /// <summary>
        /// Remove a wrap from collection
        /// </summary>
        /// <param name="deleteOption">
        /// There is more than one reason why 
        /// the wrap should be deleted. WT treats some of the 
        /// possiblities differently
        /// </param>
        /// <returns>
        /// True if sucess else false
        /// </returns>
        bool Remove(DeleteWrapOption deleteOption);

        /// <summary>
        /// The send away temporarily.
        /// </summary>
        /// <param name="sendAwayReason">
        /// The send away reason.
        /// </param>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool SendAwayTemporarily(SendAwayReason sendAwayReason, string recipient);

        /// <summary>
        /// The review.
        /// </summary>
        /// <returns>
        /// The <see cref="IModelReview"/>.
        /// </returns>
        IModelReview Review();
    }
}
