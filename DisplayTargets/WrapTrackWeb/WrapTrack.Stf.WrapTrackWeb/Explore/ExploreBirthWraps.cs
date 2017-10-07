// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExploreBirthWraps.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IExplorerWraps type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

    namespace WrapTrack.Stf.WrapTrackWeb.Explore
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;

    /// <summary>
    /// The explore birth wraps.
    /// </summary>
    public class ExploreBirthWraps : WrapTrackWebShellModelBase, IExploreBirthWraps
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExploreBirthWraps"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public ExploreBirthWraps(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}