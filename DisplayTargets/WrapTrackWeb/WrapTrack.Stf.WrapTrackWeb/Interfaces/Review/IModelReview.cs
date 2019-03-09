// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModelReview.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IModelReview type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Review
{
    using WrapTrack.Stf.WrapTrackWeb.Review;

    /// <summary>
    /// The ModelReview interface.
    /// </summary>
    public interface IModelReview
    {
        /// <summary>
        /// Gets or sets the review text.
        /// </summary>
        string ReviewText { get; set; }

        /// <summary>
        /// The set review property value.
        /// </summary>
        /// <param name="modelReviewProperty">
        /// The model review property.
        /// </param>
        /// <param name="modelReviewValues">
        /// The review value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool SetReviewPropertyValue(ModelReviewProperties modelReviewProperty, ModelReviewValues modelReviewValues);
    }
}