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
    using System.Linq;
    using System.Net.Http.Headers;

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.News;

    /// <summary>
    /// The Newsr tab page - wraps section.
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

        public INewsEntryCarrierStory GetNewsEntryCarrierStory(string wrapId, string chapterText)
        {
            var elements = WebAdapter.FindElements(By.Id("baereredskab_fortaelling"));

            if (elements.Count != 1)
            {
                StfLogger.LogError("only support 1 carrier story");
                return null;
            }

            //var element = elements.First();
            // and then some validation for WrapId and Text

            var retVal = Get<INewsEntryCarrierStory>();

            return retVal;
        }
    }
}