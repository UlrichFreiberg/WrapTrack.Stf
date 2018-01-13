// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteWrapOption.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the DeleteWrapOption type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection
{
    /// <summary>
    /// The delete wrap option.
    /// </summary>
    public enum DeleteWrapOption
    {

        /// <summary>
        /// The sold to stranger.
        /// </summary>
        SoldToAnotherUser,
        
        /// <summary>
        /// The sold to stranger.
        /// </summary>
        SoldToStranger,

        /// <summary>
        /// The lost wrap.
        /// </summary>
        LostWrap,

        /// <summary>
        /// The broken wrap.
        /// </summary>
        BrokenWrap,

        /// <summary>
        /// The converted wrap.
        /// </summary>
        ConvertedNonWrap,

        /// <summary>
        /// The registred-as-an-error wrap
        /// </summary>
        WasAnError,
        Converted
    }
}
