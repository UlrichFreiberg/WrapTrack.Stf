// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExploreUsers.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The explorer users.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Explore
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;

    /// <summary>
    /// The explorer users.
    /// </summary>
    public class ExploreUsers : WrapTrackWebShellModelBase, IExploreUsers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExploreUsers"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public ExploreUsers(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}