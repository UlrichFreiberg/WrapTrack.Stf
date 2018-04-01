// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrandInfo.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the BrandInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi
{
    /// <summary>
    /// The brand info.
    /// </summary>
    public class BrandInfo
    {
        /// <summary>
        /// Gets or sets the num of patterns.
        /// </summary>
        public int NumOfPatterns { get; set; }

        /// <summary>
        /// Gets or sets the num of models.
        /// </summary>
        public int NumOfModels { get; set; }

        /// <summary>
        /// Gets or sets the num of wraps.
        /// </summary>
        public int NumOfWraps { get; set; }

        /// <summary>
        /// Gets or sets the num of reviews.
        /// </summary>
        public int NumOfReviews { get; set; }

        /// <summary>
        /// Gets or sets the prim images id.
        /// </summary>
        public string PrimImagesId { get; set; }
    }
}
