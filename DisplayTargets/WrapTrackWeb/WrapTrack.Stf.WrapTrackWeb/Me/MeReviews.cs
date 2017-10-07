// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeReviews.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MeReviews type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The me reviews.
    /// </summary>
    public class MeReviews : WrapTrackWebShellModelBase, IMeReviews
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeReviews"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public MeReviews(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}