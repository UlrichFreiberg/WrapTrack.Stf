// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExploreWraps.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the ExploreWraps type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

    namespace WrapTrack.Stf.WrapTrackWeb.Explore
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;

    /// <summary>
    /// The explorer tab page - wraps section.
    /// </summary>
    public class ExploreWraps : WrapTrackWebShellModelBase, IExploreWraps
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExploreWraps"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public ExploreWraps(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}