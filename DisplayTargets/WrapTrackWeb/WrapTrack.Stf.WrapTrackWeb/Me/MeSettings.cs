// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeSettings.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MeSettings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The me settings.
    /// </summary>
    public class MeSettings : WrapTrackWebShellModelBase, IMeSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeSettings"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public MeSettings(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }
    }
}