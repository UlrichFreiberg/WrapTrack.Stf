// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WtUtils.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WtUtils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb
{
    using System;

    /// <summary>
    /// The wt utils.
    /// </summary>
    public class WtUtils
    {
        /// <summary>
        /// The get random string. Used for signup tests
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetRandomUsername()
        {
            var newUsername = GetRandomString("TEST");

            return newUsername;
        }

        /// <summary>
        /// The get random string.
        /// </summary>
        /// <param name="prefix">
        /// The prefix.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetRandomString(string prefix = "STF")
        {
            var uniquePart = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(1, 15);
            var newUsername = $"{prefix}-{uniquePart}";

            return newUsername;
        }
    }
}
