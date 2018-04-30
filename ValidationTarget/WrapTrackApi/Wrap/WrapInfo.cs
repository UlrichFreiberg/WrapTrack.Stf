// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrapInfo.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WrapInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Wrap
{
    /// <summary>
    /// The wrap info.
    /// </summary>
    public class WrapInfo
    {
        /// <summary>
        /// Gets or sets the ownership number.
        /// </summary>
        public string OwnershipNumber { get; set; }

        /// <summary>
        /// Gets or sets the id of the owner.
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the name of the owner.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets number of private pictures related to the wrap
        /// Uploaded by all users of the wrap
        /// </summary>
        public int NumOfPictures { get; set; }

        /// <summary>
        /// Gets or sets the wrap status.
        /// </summary>
        public string Status { get; set;  }

        /// <summary>
        /// Gets or sets the WT internal id.
        /// </summary>
        public string InternalId { get; set; }

        /// <summary>
        /// Gets or sets the num of ownership pic.
        /// </summary>
        public int NumOfOwnershipPic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether on holiday.
        /// </summary>
        public bool OnHoliday { get; set; }

        /// <summary>
        /// Gets or sets the id of the user who the wrap is visiting.
        /// </summary>
        public string VisitingUserId { get; set; }
    }
}
