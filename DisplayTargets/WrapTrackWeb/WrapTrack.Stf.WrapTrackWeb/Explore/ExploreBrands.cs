// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExploreBrands.cs" company="Mir Software">
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
    /// The explore brands.
    /// </summary>
    public class ExploreBrands : WrapTrackWebShellModelBase, IExploreBrands
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExploreBrands"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public ExploreBrands(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}