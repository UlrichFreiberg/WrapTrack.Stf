// ------------------------½--------------------------------------------------------------------------------------------
// <copyright file="WtConfiguration.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WtConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Configuration
{
    using Mir.Stf.Utilities;

    /// <summary>
    /// The im configuration.
    /// </summary>
    public class WtConfiguration
    {
        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [StfConfiguration("DisplayTargets.WrapTrackWeb.BaseUrl")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the browser.
        /// </summary>
        [StfConfiguration("DisplayTargets.WrapTrackWeb.Browser")]
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [StfConfiguration("DisplayTargets.WrapTrackWeb.Users.UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [StfConfiguration("DisplayTargets.WrapTrackWeb.Users.Password")]
        public string Password { get; set; }
    }
}
