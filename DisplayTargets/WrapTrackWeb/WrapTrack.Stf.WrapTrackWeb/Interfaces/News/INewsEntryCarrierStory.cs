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
    /// <summary>
    /// The INewsEntryCarrierStory interface
    /// </summary>
    public interface INewsEntryCarrierStory
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets the Header text
        /// </summary>
        string HeaderText { get; }

        /// <summary>
        /// Gets the chapter text.
        /// </summary>
        string ChapterText { get; }

        /// <summary>
        /// Gets the wrap text.
        /// </summary>
        string WrapText { get; }
    }
}