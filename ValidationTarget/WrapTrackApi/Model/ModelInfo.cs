// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelInfo.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the ModelInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Model
{
    /// <summary>
    /// The Model info.
    /// </summary>
    public class ModelInfo
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand { get; set; }

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

        /// <summary>
        /// Gets or sets the num of images.
        /// </summary>
        public int NumOfImages { get; set; }

    }
}
