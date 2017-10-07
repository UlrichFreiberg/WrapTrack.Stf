// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeInbox.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MeInbox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The me inbox.
    /// </summary>
    public class MeInbox : WrapTrackWebShellModelBase, IMeInbox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeInbox"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public MeInbox(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}