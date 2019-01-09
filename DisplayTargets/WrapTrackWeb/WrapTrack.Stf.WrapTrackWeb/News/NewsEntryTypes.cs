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
        /// baereredskab oprettet
        /// </summary>
        [Display(Name = @"baereredskab_oprettet")]
        BaereredskabOprettet,

        /// <summary>
        /// baereredskab genfundet
        /// </summary>
        [Display(Name = @"baereredskab_genfundet")]
        BaereredskabGenfundet,

        /// <summary>
        /// baereredskab fortaelling
        /// </summary>
        [Display(Name = @"baereredskab_fortaelling")]
        BaereredskabFortaelling,

        /// <summary>
        /// baereredskab paamarkedet
        /// </summary>
        [Display(Name = @"baereredskab_paamarkedet")]
        BaereredskabPaamarkedet,

        /// <summary>
        /// baereredskab videregivet
        /// </summary>
        [Display(Name = @"baereredskab_videregivet")]
        BaereredskabVideregivet,

        /// <summary>
        /// baereredskab omsyet
        /// </summary>
        [Display(Name = @"baereredskab_omsyet")]
        BaereredskabOmsyet,

        /// <summary>
        /// baereredskab omsyet_gl
        /// </summary>
        [Display(Name = @"baereredskab_omsyet_gl")]
        BaereredskabOmsyetGl,

        /// <summary>
        /// baereredskab omsyet_ny
        /// </summary>
        [Display(Name = @"baereredskab_omsyet_ny")]
        BaereredskabOmsyetNy,

        /// <summary>
        /// anmeldelse vurdering
        /// </summary>
        [Display(Name = @"anmeldelse_vurdering")]
        AnmeldelseVurdering,

        /// <summary>
        /// anmeldelse bedoemmelse
        /// </summary>
        [Display(Name = @"anmeldelse_bedoemmelse")]
        AnmeldelseBedoemmelse,

        /// <summary>
        /// anmeldelse data
        /// </summary>
        [Display(Name = @"anmeldelse_data")]
        AnmeldelseData,

        /// <summary>
        /// traad baereredskab
        /// </summary>
        [Display(Name = @"traad_baereredskab")]
        TraadBaereredskab,

        /// <summary>
        /// baereredskab ferie
        /// </summary>
        [Display(Name = @"baereredskab_ferie")]
        BaereredskabFerie,

        /// <summary>
        /// baereredskab udlejning
        /// </summary>
        [Display(Name = @"baereredskab_udlejning")]
        BaereredskabUdlejning,

        /// <summary>
        /// baereredskab test
        /// </summary>
        [Display(Name = @"baereredskab_test")]
        BaereredskabTest,

        /// <summary>
        /// baereredskab ferie videresendt
        /// </summary>
        [Display(Name = @"baereredskab_ferie_videresendt")]
        BaereredskabFerieVideresendt,

        /// <summary>
        /// baereredskab test videresendt
        /// </summary>
        [Display(Name = @"baereredskab_test_videresendt")]
        BaereredskabTestVideresendt,

        /// <summary>
        /// baereredskab ferie fortaelling
        /// </summary>
        [Display(Name = @"baereredskab_ferie_fortaelling")]
        BaereredskabFerieFortaelling,

        /// <summary>
        /// baereredskab test fortaelling
        /// </summary>
        [Display(Name = @"baereredskab_test_fortaelling")]
        BaereredskabTestFortaelling,

        /// <summary>
        /// baereredskab udlejning fortaelling
        /// </summary>
        [Display(Name = @"baereredskab_udlejning_fortaelling")]
        BaereredskabUdlejningFortaelling,

        /// <summary>
        /// baereredskab ferie retur
        /// </summary>
        [Display(Name = @"baereredskab_ferie_retur")]
        BaereredskabFerieRetur,

        /// <summary>
        /// baereredskab udlejning retur
        /// </summary>
        [Display(Name = @"baereredskab_udlejning_retur")]
        BaereredskabUdlejningRetur,

        /// <summary>
        /// baereredskab test retur
        /// </summary>
        [Display(Name = @"baereredskab_test_retur")]
        BaereredskabTestRetur,
    }
}
