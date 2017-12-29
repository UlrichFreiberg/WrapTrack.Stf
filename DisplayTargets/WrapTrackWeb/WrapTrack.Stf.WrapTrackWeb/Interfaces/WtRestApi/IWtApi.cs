// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWtApi.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWtApi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.WtRestApi
{
    using WrapTrack.Stf.WrapTrackWeb.WtRestApi;

    /// <summary>
    /// The WtApi interface. For the WT REST API 
    /// </summary>
    public interface IWtApi
    {
        /// <summary>
        /// The wrap info.
        /// </summary>
        /// <param name="wtWrapId">
        /// The wt wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        WrapInfo WrapInfo(string wtWrapId);
    }
}
