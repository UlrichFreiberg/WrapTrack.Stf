// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Brand.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Brand interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Brand
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand;

    /// <summary>
    /// The Brand interface.
    /// </summary>
    public class Brand : WrapTrackWebShellModelBase, IBrand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Brand"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Brand(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// The patterns.
        /// </summary>
        /// <returns>
        /// The <see cref="IPatterns"/>.
        /// </returns>
        public IPatterns Patterns()
        {
            var retVal = Get<IPatterns>();

            return retVal;
        }

        /// <summary>
        /// The models.
        /// </summary>
        /// <returns>
        /// The <see cref="IModels"/>.
        /// </returns>
        public IModels Models()
        {
            var retVal = Get<IModels>();

            return retVal;
        }

        /// <summary>
        /// The wraps.
        /// </summary>
        /// <returns>
        /// The <see cref="IWraps"/>.
        /// </returns>
        public IWraps Wraps()
        {
            var retVal = Get<IWraps>();

            return retVal;
        }

        /// <summary>
        /// The forum.
        /// </summary>
        /// <returns>
        /// The <see cref="IForum"/>.
        /// </returns>
        public IForum Forum()
        {
            var retVal = Get<IForum>();

            return retVal;
        }
    }
}