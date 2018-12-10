// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReview.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Review
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces
{
   /// <summary>
   /// The Review
   /// </summary>
   public interface IReview
   {
       /// <summary>
        /// Sets description.
        /// </summary>
        string Description { set; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Add();
    }
}
