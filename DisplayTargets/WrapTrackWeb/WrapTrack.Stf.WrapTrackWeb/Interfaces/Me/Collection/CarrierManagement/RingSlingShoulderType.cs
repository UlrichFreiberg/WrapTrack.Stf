// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RingSlingShoulderType.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the RingSlingShoulderType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement
{
    /// <summary>
    /// The ring sling shoulder type.
    /// </summary>
    public enum RingSlingShoulderType
    {
        /// <summary>
        /// Unknown - Used when parsing
        /// </summary>
        [Display(Name = @"Unknown")]
        Unknown,

        /// <summary>
        /// GATHERED headline
        /// </summary>
        [Display(Name = @"GATHERED")]
        Gathered,

        /// <summary>
        /// floating gathered
        /// </summary>
        [Display(Name = @"floating gathered")]
        FloatingGathered,

        /// <summary>
        /// PLEATED headline
        /// </summary>
        [Display(Name = @"PLEATED")]
        Pleated,

        /// <summary>
        /// floating pleated
        /// </summary>
        [Display(Name = @"floating pleated")]
        FloatingPleated,

        /// <summary>
        /// box pleated
        /// </summary>
        [Display(Name = @"box pleated")]
        BoxPleated,

        /// <summary>
        /// overlapping pleats
        /// </summary>
        [Display(Name = @"overlapping pleats")]
        OverlappingPleats,

        /// <summary>
        /// HYBRID headline
        /// </summary>
        [Display(Name = @"HYBRID")]
        Hybrid,

        /// <summary>
        /// eesti hybrid
        /// </summary>
        [Display(Name = @"eesti hybrid")]
        EestiHybrid,

        /// <summary>
        /// wings hybrid
        /// </summary>
        [Display(Name = @"wings hybrid")]
        WingsHybrid,

        /// <summary>
        /// little lion brothers hybrid
        /// </summary>
        [Display(Name = @"little lion brothers hybrid")]
        LittleLionBrothersHybrid,

        /// <summary>
        /// bystorm hybrid
        /// </summary>
        [Display(Name = @"bystorm hybrid")]
        BystormHybrid,

        /// <summary>
        /// HOT DOG
        /// </summary>
        [Display(Name = @"HOT DOG")]
        HotDog,
    }
}
