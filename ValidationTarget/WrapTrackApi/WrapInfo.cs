// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrapInfo.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WrapInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi
{
    /// <summary>
    /// The wrap info.
    /// </summary>
    public class WrapInfo
    {
        internal string OwnershipNumber;

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
        public string NumOfOwnershipPic { get; set; }
    }
}
