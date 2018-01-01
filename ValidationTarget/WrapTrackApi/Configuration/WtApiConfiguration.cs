// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WtApiConfiguration.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WtConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Configuration
{
    using Mir.Stf.Utilities;

    /// <summary>
    /// The configuration.
    /// </summary>
    public class WtApiConfiguration
    {
        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [StfConfiguration("ValidationTargets.WrapTrackApi.BaseUrl")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the user name. 
        /// Not used right now - might come later
        /// </summary>
        [StfConfiguration("ValidationTargets.WrapTrackApi.Users.UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// Not used right now - might come later
        /// </summary>
        [StfConfiguration("ValidationTargets.WrapTrackApi.Users.Password")]
        public string Password { get; set; }
    }
}
