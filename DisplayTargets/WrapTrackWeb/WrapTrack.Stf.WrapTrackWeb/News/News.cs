// --------------------------------------------------------------------------------------------------------------------
// <copyright file="News.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the News type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.News
{
    using System;
    using System.Linq;
    using System.Net.Http.Headers;

    using Mir.Stf.Utilities;

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.News;

    /// <summary>
    /// The News tab page - wraps section.
    /// </summary>
    public class News : WrapTrackWebShellModelBase, INews
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="News"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public News(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// The get news entry carrier story that contyains the chapter text for the wrap.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <param name="chapterText">
        /// The chapter text.
        /// </param>
        /// <returns>
        /// The <see cref="INewsEntryCarrierStory"/>.
        /// </returns>
        public INewsEntryCarrierStory GetNewsEntryCarrierStory(string wrapId, string chapterText)
        {
            var elements = WebAdapter.FindElements(By.Id("baereredskab_fortaelling"));

            if (elements.Count != 1)
            {
                StfLogger.LogError("only support 1 carrier story");
                return null;
            }

            var element = elements.First();
            if (element == null)
            {
                StfLogger.LogError("elements.first() returned a null element");
                return null;
            }

            var newsEntryCarrierStory = Get<INewsEntryCarrierStory>();

            if (newsEntryCarrierStory == null)
            {
                StfLogger.LogError("Could not newsEntryCarrierStory from Get<INewsEntryCarrierStory>");
                return null;
            }

            newsEntryCarrierStory.Text = element.Text;

            // :TODO test also for currentloggedinser at start of header text. Waiting for issue #33. See next comment line
            // if (!newsEntryCarrierStory.HeaderText.Contains(WrapTrackWebShell.CurrentLoggedInUser)
            var baseHeaderTextForNewsStory = "has written a new chapter in the story";
            if (!newsEntryCarrierStory.HeaderText.Contains(baseHeaderTextForNewsStory)
                || 
                !newsEntryCarrierStory.WrapText.Contains(wrapId)
                ||
                !newsEntryCarrierStory.ChapterText.Equals(chapterText))
            {
                return null;
            }

            return newsEntryCarrierStory;
        }
    }
}