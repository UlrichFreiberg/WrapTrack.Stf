// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INews.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The News interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.News
{
    /// <summary>
    /// The News interface.
    /// </summary>
    public interface INews
    {
        INewsEntryCarrierStory GetNewsEntryCarrierStory(string wrapId, string chapterText);
    }
}