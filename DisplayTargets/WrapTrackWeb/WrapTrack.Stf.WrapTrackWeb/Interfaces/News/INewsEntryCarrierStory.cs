// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INewsEntryCarrierStory.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The News interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.News
{
    public interface INewsEntryCarrierStory
    {
        string HeaderText { get; set; }
        string ChapterText { get; set; }
    }
}