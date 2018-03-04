// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBrand.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Brand interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand
{
    /// <summary>
    /// The Brand interface.
    /// </summary>
    public interface IBrand
    {
        /// <summary>
        /// The patterns.
        /// </summary>
        /// <returns>
        /// The <see cref="IPatterns"/>.
        /// </returns>
        IPatterns Patterns();

        /// <summary>
        /// The models.
        /// </summary>
        /// <returns>
        /// The <see cref="IModels"/>.
        /// </returns>
        IModels Models();

        /// <summary>
        /// The wraps.
        /// </summary>
        /// <returns>
        /// The <see cref="IWraps"/>.
        /// </returns>
        IWraps Wraps();

        /// <summary>
        /// The forum.
        /// </summary>
        /// <returns>
        /// The <see cref="IForum"/>.
        /// </returns>
        IForum Forum();
    }
}