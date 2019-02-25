// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Podeagi.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Podeagi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    /// <summary>
    /// The HalfBuckleMeiTai wrap.
    /// </summary>
    public class Podeagi : CarrierBaseClass, IPodeagi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Podeagi"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Podeagi(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                var retVal = WebAdapter.GetText(By.Id("inpNameHomemade"));

                return retVal;
            }

            set
            {
                WebAdapter.TextboxSetTextById("inpNameHomemade", value);
            }
        }
    }
}
