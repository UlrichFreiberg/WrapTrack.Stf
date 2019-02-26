// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INewsEntryCarrierForSale.cs" company="Mir Software">
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
    public interface INewsEntryCarrierEvaluation
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
        /// Gets the Criteria.
        /// </summary>
        string CriteriaText { get; }

        /// <summary>
        /// Gets the wrap text.
        /// </summary>
        string WrapText { get; }
    }
}