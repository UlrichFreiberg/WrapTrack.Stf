// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelReviewProperties.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the ModelReviewProperties type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace WrapTrack.Stf.WrapTrackWeb.Review
{
    /// <summary>
    /// The wrap review properties.
    /// </summary>
    public enum ModelReviewProperties
    {
        /// <summary>
        /// Un known
        /// </summary>
        [Display(Name = @"Unknown")]
        Unknown,

        /// <summary>
        /// Easy care
        /// </summary>
        [Display(Name = @"Easycare")]
        Easycare,

        /// <summary>
        /// Low quality
        /// </summary>
        [Display(Name = @"Low quality")]
        LowQuality,

        /// <summary>
        /// No breaking in needed
        /// </summary>
        [Display(Name = @"No breaking in needed")]
        NoBreakingInNeeded,

        /// <summary>
        /// Beginner friendly
        /// </summary>
        [Display(Name = @"Beginner-friendly")]
        BeginnerFriendly,

        /// <summary>
        /// No cush
        /// </summary>
        [Display(Name = @"No cush")]
        NoCush,

        /// <summary>
        /// No bounce
        /// </summary>
        [Display(Name = @"No bounce")]
        NoBounce,

        /// <summary>
        /// Not squish-worthy
        /// </summary>
        [Display(Name = @"Not squish-worthy")]
        NotSquishWorthy,

        /// <summary>
        /// Not toddler-worthy
        /// </summary>
        [Display(Name = @"Not toddler-worthy")]
        NotToddlerWorthy,

        /// <summary>
        /// Not summer-worthy
        /// </summary>
        [Display(Name = @"Not summer-worthy")]
        NotSummerWorthy,

        /// <summary>
        /// Not winter-worthy
        /// </summary>
        [Display(Name = @"Not winter-worthy")]
        NotWinterWorthy,

        /// <summary>
        /// Short to size
        /// </summary>
        [Display(Name = @"Short to size")]
        ShortToSize,

        /// <summary>
        /// Thin Wrap
        /// </summary>
        [Display(Name = @"Thin")]
        Thin,

        /// <summary>
        /// Airy Wrap
        /// </summary>
        [Display(Name = @"Airy")]
        Airy,

        /// <summary>
        /// Solid Wrap
        /// </summary>
        [Display(Name = @"Solid")]
        Solid,

        /// <summary>
        /// Stiff Wrap
        /// </summary>
        [Display(Name = @"Stiff")]
        Stiff,

        /// <summary>
        /// Slippery Wrap
        /// </summary>
        [Display(Name = @"Slippery")]
        Slippery,

        /// <summary>
        /// Soapy Wrap
        /// </summary>
        [Display(Name = @"Soapy")]
        Soapy,

        /// <summary>
        /// Smooth Wrap
        /// </summary>
        [Display(Name = @"Smooth")]
        Smooth,

        /// <summary>
        /// Flat Wrap
        /// </summary>
        [Display(Name = @"Flat")]
        Flat,
    }
}
