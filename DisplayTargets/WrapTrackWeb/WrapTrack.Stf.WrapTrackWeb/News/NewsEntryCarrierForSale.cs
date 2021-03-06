// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsEntryCarrierForSale.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The News interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.News
{
    using System;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.News;

    /// <summary>
    /// The News entry carrier story section - 
    /// </summary>
    public class NewsEntryCarrierForSale : WrapTrackWebShellModelBase, INewsEntryCarrierForSale
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsEntryCarrierForSale"/> class. 
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public NewsEntryCarrierForSale(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {   
            HeaderText = "Not implemented yet";
            this.StatusText = "Not implemented yet";
        }

        /// <summary>
        /// Gets the header text.
        /// </summary>
        public string HeaderText { get; private set; }

        /// <summary>
        /// Gets the chapter text.
        /// </summary>
        public string StatusText { get; private set; }

        /// <summary>
        /// Gets the wrapr text.
        /// </summary>
        public string WrapText { get; private set; }

        /// <summary>
        /// The text.All text present in the NewsEntryCarrierStory
        /// </summary>
        private string text;

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                var splittext = text.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (splittext.Length > 0)
                {
                    HeaderText = splittext[0];
                }

                if (splittext.Length >= 1)
                {
                    WrapText = splittext[1];
                }

                if (splittext.Length >= 9)
                {
                    StatusText = splittext[9];
                }
            }
        }
    }
}