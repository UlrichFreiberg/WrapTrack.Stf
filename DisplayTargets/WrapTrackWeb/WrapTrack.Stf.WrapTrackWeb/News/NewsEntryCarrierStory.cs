// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INewsEntryCarrierStory.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//   //          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The News interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.News
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.News;

    /// <summary>
    /// The News entry carrier story section - 
    /// </summary>
    public class NewsEntryCarrierStory : WrapTrackWebShellModelBase, INewsEntryCarrierStory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsEntryCarrierStory"/> class. 
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public NewsEntryCarrierStory(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
            HeaderText = "Not implemented yet";
            ChapterText = "Not implemented yet";
        }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        public string HeaderText { get; set; }

        /// <summary>
        /// Gets or sets the chapter text.
        /// </summary>
        public string ChapterText { get; set; }
    }
}