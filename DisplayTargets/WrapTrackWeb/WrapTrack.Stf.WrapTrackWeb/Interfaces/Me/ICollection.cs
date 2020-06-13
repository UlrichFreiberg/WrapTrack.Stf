// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollection.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Collection interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me
{
    using System.Collections.Generic;

    /// <summary>
    /// The Collection interface.
    /// </summary>
    public interface ICollection
    {
        /// <summary>
        /// Counts number of wraps in collection
        /// </summary>
        /// <returns>
        /// Number of wraps 
        /// </returns>   
        int NumOfWraps();

        /// <summary>
        /// Add a wrap to collectio
        /// </summary>
        /// <returns>
        /// Returns true id wrap is added 
        /// </returns>
        /// <param name="brand">
        /// Brand of wrap
        /// </param>
        /// <param name="pattern">
        /// Pattern of wrap
        /// </param>
        /// <param name="model">
        /// Model of wrap 
        /// </param>
        /// <param name="size">
        /// Size of wrap 
        /// </param>
        string AddWrap(string brand = null, string pattern = null, string model = null, int size = 6);

        /// <summary>
        /// Finds a random wrap in collection
        /// </summary>
        /// <param name="wtIdContraint">
        /// Constrain the randomness to NOT return this wrap
        /// </param>
        /// <returns>
        /// The wrap 
        /// </returns>
        IWrap GetRandomWrap(string wtIdContraint = null);

        /// <summary>
        /// Find a wrap by criteria
        /// </summary>
        /// <param name="finderCriteria">
        /// The status criteria for the finder
        /// </param>
        /// <returns>a wrap that meets the criteria or null if no match</returns>
        IWrap FindBy(FinderCriteria finderCriteria);

        /// <summary>
        /// Find a wrap by a boolean criteria
        /// </summary>
        /// <param name="finderCriteria">
        /// The boolean status criteria for the finder
        /// </param>
        /// <param name="value">
        /// The boolean value for the finder
        /// </param>
        /// <returns>a wrap that meets the criteria or null if no match</returns>
        IWrap FindBy(FinderCriteria finderCriteria, bool value);

        /// <summary>
        /// The get list of wt ids.
        /// </summary>
        /// <returns>
        /// List of WtId as strings
        /// </returns>
        List<string> GetListOfWtIds();

        /// <summary>
        /// The add carrier.
        /// </summary>
        /// <typeparam name="T">
        /// The interface for a carrier add
        /// </typeparam>
        /// <returns>
        /// An instance of t
        /// </returns>
        T AddCarrier<T>();
    }
}
