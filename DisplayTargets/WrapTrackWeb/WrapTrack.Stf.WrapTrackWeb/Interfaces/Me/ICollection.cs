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
        bool AddWrap(string brand = null, string pattern = null, string model = null);

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
    }
}
