// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWtApi.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackApi.Interfaces
{
    using Mir.Stf.Utilities;

    /// <summary>
    /// The WtApi interface. For the WT REST API 
    /// </summary>
    public interface IWtApi : IStfPlugin
    {
        /// <summary>
        /// The wrap info by interal id.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        WrapInfo WrapInfoByInternalId(string s);

        /// <summary>
        /// The wrap info by track id.
        /// </summary>
        /// <param name="trackId">
        /// The ks 0 etu 1.
        /// </param>
        /// <returns>
        /// The <see cref="WrapInfo"/>.
        /// </returns>
        WrapInfo WrapInfoByTrackId(string trackId);
    }
}
