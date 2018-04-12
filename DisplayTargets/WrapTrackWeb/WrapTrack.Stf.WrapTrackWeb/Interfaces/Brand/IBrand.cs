// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBrand.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Brand interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand
{
    /// <summary>
    /// The Brand interface.
    /// </summary>
    public interface IBrand
    {
        /// <summary>
        /// The patterns.
        /// </summary>
        /// <returns>
        /// The <see cref="IPatterns"/>.
        /// </returns>
        IPatterns Patterns();

        /// <summary>
        /// The models.
        /// </summary>
        /// <returns>
        /// The <see cref="IModels"/>.
        /// </returns>
        IModels Models();

        /// <summary>
        /// The wraps.
        /// </summary>
        /// <returns>
        /// The <see cref="IWraps"/>.
        /// </returns>
        IWraps Wraps();

        /// <summary>
        /// The forum.
        /// </summary>
        /// <returns>
        /// The <see cref="IForum"/>.
        /// </returns>
        IForum Forum();

        /// <summary>
        /// Add pattern to the brand.
        /// </summary>
        /// <param name="patternName">
        /// The pattern name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool AddPattern(string patternName);

        /// <summary>
        /// The delete pattern.
        /// </summary>
        /// <param name="patternNameToDelete">
        /// The pattern name to delete.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool DeletePattern(string patternNameToDelete);

        /// <summary>
        /// The add model.
        /// </summary>
        /// <param name="modelName">
        /// The model name.
        /// </param>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool AddModel(string modelName, string pattern = null);

        /// <summary>
        /// The delete model.
        /// </summary>
        /// <param name="modelNameToDelete">
        /// The model name to delete.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool DeleteModel(string modelNameToDelete);
    }
}