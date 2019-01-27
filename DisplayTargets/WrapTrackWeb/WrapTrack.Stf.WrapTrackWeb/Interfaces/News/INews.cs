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
        /// <summary>
        /// The get news entry carrier story.
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
        INewsEntryCarrierStory GetNewsEntryCarrierStory(string wrapId, string chapterText);

        /// <summary>
        /// The get news entry carrier for sale.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <param name="typeOfSale">
        /// The type Of Sale.
        /// </param>
        /// <returns>
        /// The <see cref="INewsEntryCarrierForSale"/>.
        /// </returns>
        INewsEntryCarrierForSale GetNewsEntryCarrierForSale(string wrapId, string typeOfSale);
    }
}