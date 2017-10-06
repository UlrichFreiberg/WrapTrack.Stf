// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWrap.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWrap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces
{
    /// <summary>
    /// The Wrap interface.
    /// </summary>
    public interface IWrap
    {
        /// <summary>
        /// Gets or sets the patterns.
        /// </summary>
        int Patterns { get; set; }

        /// <summary>
        /// Gets or sets the models.
        /// </summary>
        int Models { get; set; }

        /// <summary>
        /// Gets or sets the wraps.
        /// </summary>
        int Wraps { get; set; }
        }
    }
