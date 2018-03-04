// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wraps.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Wraps type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Brand
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand;

    /// <summary>
    /// The wraps.
    /// </summary>
    public class Wraps : WrapTrackWebShellModelBase, IWraps
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wraps"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Wraps(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}