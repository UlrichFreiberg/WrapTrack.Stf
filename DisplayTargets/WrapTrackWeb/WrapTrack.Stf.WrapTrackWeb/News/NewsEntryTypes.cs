// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsEntryTypes.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the NewsEntryTypes type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace WrapTrack.Stf.WrapTrackWeb.News
{
    /// <summary>
    /// The news entry types.
    /// </summary>
    public enum NewsEntryTypes
    {
        /// <summary>
        /// Unknown - used when parsing string to enum
        /// </summary>
        [Display(Name = @"Unknown")]
        Unknown,

        /// <summary>
        /// Carrier created by a user
        /// </summary>
        [Display(Name = @"baereredskab_oprettet")]
        BaereredskabOprettet,

        /// <summary>
        /// A user found a carrier without owner and marked 'this is mine'
        /// </summary>
        [Display(Name = @"baereredskab_genfundet")]
        BaereredskabGenfundet,

        /// <summary>
        /// A user added a chapter/story to a carrier. Like 'I bought this one summer where there was heat wave and it saved our holiday' 
        /// </summary>
        [Display(Name = @"baereredskab_fortaelling")]
        BaereredskabFortaelling,

        /// <summary>
        /// A user marked a carrier as for sale
        /// </summary>
        [Display(Name = @"baereredskab_paamarkedet")]
        BaereredskabPaamarkedet,

        /// <summary>
        /// A user passed on a carrier to another wraptrack user (the new owner)
        /// </summary>
        [Display(Name = @"baereredskab_videregivet")]
        BaereredskabVideregivet,

        /// <summary>
        /// A carrier is converted to something else. Example a wrap size 8 is converted to a wrap size 6. Or a wrap is converted to a ring sling.
        /// </summary>
        [Display(Name = @"baereredskab_omsyet")]
        BaereredskabOmsyet,

        /// <summary>
        /// A user made a prosa review of a wrap/ring sling. 
        /// </summary>
        [Display(Name = @"anmeldelse_vurdering")]
        AnmeldelseVurdering,

        /// <summary>
        ///  A user rated a wrap/ring sling on parameters like "How good for new wrappers?" and "How much 'breaking in' is needed?"
        /// </summary>
        [Display(Name = @"anmeldelse_bedoemmelse")]
        AnmeldelseBedoemmelse,

        /// <summary>
        /// A user added her/his own data. Like my wrap (size 6) is 4,2 meter long.
        /// </summary>
        [Display(Name = @"anmeldelse_data")]
        AnmeldelseData,

        /// <summary>
        /// A user started a thread in a forum related to a specific carrier
        /// </summary>
        [Display(Name = @"traad_baereredskab")]
        TraadBaereredskab,

        /// <summary>
        /// A carrier is sent on 'holiday' at another waptrack user. Just to let her/him try this carrier.
        /// </summary>
        [Display(Name = @"baereredskab_ferie")]
        BaereredskabFerie,

        /// <summary>
        /// A carrier is rented to another wraptrack user.
        /// </summary>
        [Display(Name = @"baereredskab_udlejning")]
        BaereredskabUdlejning,

        /// <summary>
        /// A carrier is sent on test at another waptrack user to let her/him validete the wrap qualities. Often is the owner a user related to a brand,
        /// </summary>
        [Display(Name = @"baereredskab_test")]
        BaereredskabTest,

        /// <summary>
        /// A user had a carrier on holiday and has now sent it to another wraptrack user (not the owner of the wrap)
        /// </summary>
        [Display(Name = @"baereredskab_ferie_videresendt")]
        BaereredskabFerieVideresendt,

        /// <summary>
        /// A user had a carrier for test and has now sent it to another wraptrack user (not the owner of the wrap)
        /// </summary>
        [Display(Name = @"baereredskab_test_videresendt")]
        BaereredskabTestVideresendt,

        /// <summary>
        /// A user had a carrier on holiday and wrote a story about the visit. Like "I'm so happy to try get the possibility to try this wrap. It's so nice ..."
        /// </summary>
        [Display(Name = @"baereredskab_ferie_fortaelling")]
        BaereredskabFerieFortaelling,

        /// <summary>
        /// A user had a carrier on test and wrote a story about the visit. Like "I had this wrap for test for 14 days and found it ..."
        /// </summary>
        [Display(Name = @"baereredskab_test_fortaelling")]
        BaereredskabTestFortaelling,

        /// <summary>
        /// A user rented a carrier and wrote a story about the visit. Like "Marys wrap is so amazing. Don't hesitate to rent it if you ..."
        /// </summary>
        [Display(Name = @"baereredskab_udlejning_fortaelling")]
        BaereredskabUdlejningFortaelling,

        /// <summary>
        /// A user had a carrier on holiday and has now returned it to the owner
        /// </summary>
        [Display(Name = @"baereredskab_ferie_retur")]
        BaereredskabFerieRetur,

        /// <summary>
        /// A user rented a carrier and has now returned it to the owner
        /// </summary>
        [Display(Name = @"baereredskab_udlejning_retur")]
        BaereredskabUdlejningRetur,

        /// <summary>
        /// A user had a carrier for test and has now returned it to the owner
        /// </summary>
        [Display(Name = @"baereredskab_test_retur")]
        BaereredskabTestRetur,
    }
}
