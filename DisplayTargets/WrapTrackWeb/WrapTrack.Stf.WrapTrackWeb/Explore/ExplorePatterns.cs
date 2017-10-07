// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExplorePatterns.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The explore patterns.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Explore
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;

    /// <summary>
    /// The explore patterns.
    /// </summary>
    public class ExplorePatterns : WrapTrackWebShellModelBase, IExplorePatterns
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExplorePatterns"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public ExplorePatterns(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}