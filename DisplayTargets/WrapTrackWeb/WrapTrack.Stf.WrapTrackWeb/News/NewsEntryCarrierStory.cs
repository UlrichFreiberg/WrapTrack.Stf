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

    public class NewsEntryCarrierStory : WrapTrackWebShellModelBase, INewsEntryCarrierStory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="News"/> class.
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

        public string HeaderText { get; set; }

        public string ChapterText { get; set; }
    }
}