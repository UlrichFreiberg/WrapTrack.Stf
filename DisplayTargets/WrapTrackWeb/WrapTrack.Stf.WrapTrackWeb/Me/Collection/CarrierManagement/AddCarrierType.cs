// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddCarrierType.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The add carrier type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The add carrier type.
    /// </summary>
    public enum AddCarrierType
    {
        /// <summary>
        /// Unknown - Value used when string cannot be parsed
        /// </summary>
        [Display(Name = @"Unknown")]
        Unknown,

        /// <summary>
        /// woven wrap
        /// </summary>
        [Display(Name = @"woven wrap")]
        WovenWrap,

        /// <summary>
        /// stretchy wrap
        /// </summary>
        [Display(Name = @"stretchy wrap")]
        StretchyWrap,

        /// <summary>
        /// hybrid wrap
        /// </summary>
        [Display(Name = @"hybrid wrap")]
        HybridWrap,

        /// <summary>
        /// ring sling
        /// </summary>
        [Display(Name = @"ring sling")]
        RingSling,

        /// <summary>
        /// mei tai
        /// </summary>
        [Display(Name = @"mei tai")]
        MeiTai,

        /// <summary>
        /// half buckle mei tai
        /// </summary>
        [Display(Name = @"half buckle mei tai")]
        HalfBuckleMeiTai,

        /// <summary>
        /// wrap tai
        /// </summary>
        [Display(Name = @"wrap tai")]
        WrapTai,

        /// <summary>
        /// half buckle wrap tai
        /// </summary>
        [Display(Name = @"half buckle wrap tai")]
        HalfBuckleWrapTai,

        /// <summary>
        /// onbuhimo wrap
        /// </summary>
        [Display(Name = @"onbuhimo")]
        Onbuhimo,

        /// <summary>
        /// reverse onbuhimo
        /// </summary>
        [Display(Name = @"reverse onbuhimo")]
        ReverseOnbuhimo,

        /// <summary>
        /// buckle onbuhimo
        /// </summary>
        [Display(Name = @"buckle onbuhimo")]
        BuckleOnbuhimo,

        /// <summary>
        /// podeagi wrap
        /// </summary>
        [Display(Name = @"podeagi")]
        Podeagi,

        /// <summary>
        /// nyia wrap
        /// </summary>
        [Display(Name = @"nyia")]
        Nyia,

        /// <summary>
        /// doll sling
        /// </summary>
        [Display(Name = @"doll sling")]
        DollSling,

        /// <summary>
        /// other carrier
        /// </summary>
        [Display(Name = @"other carrier")]
        OtherCarrier,
    }
}
