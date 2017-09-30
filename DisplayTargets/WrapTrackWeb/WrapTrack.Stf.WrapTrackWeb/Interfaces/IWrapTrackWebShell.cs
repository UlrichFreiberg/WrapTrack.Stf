// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWrapTrackWebShell.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IWrapTrackWebShell type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces
{
    using Adapters.WebAdapter;
    using Mir.Stf.Utilities;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The WrapTrackWebShell interface.
    /// </summary>
    public interface IWrapTrackWebShell : IStfPlugin
    {

        /// <summary>
        /// WebAdaptor needed erverywhere
        /// </summary>
        IWebAdapter WebAdapter { get; }

        /// <summary>
        /// The learn more.
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        ICollection Collection();

        /// <summary>
        /// The me.
        /// </summary>
        /// <returns>
        /// The <see cref="IMe"/>.
        /// </returns>
        IMe Me();

        /// <summary>
        /// The explorer.
        /// </summary>
        /// <returns>
        /// The <see cref="IExplorer"/>.
        /// </returns>
        IExplorer Explorer();

        /// <summary>
        /// The market.
        /// </summary>
        /// <returns>
        /// The <see cref="IMarket"/>.
        /// </returns>
        IMarket Market();

        /// <summary>
        /// The faq.
        /// </summary>
        /// <returns>
        /// The <see cref="IFaq"/>.
        /// </returns>
        IFaq Faq();


        /// <summary>
        /// Perform the login action.
        /// </summary>
        /// <returns>
        /// <param name="userName">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// The <see cref="bool"/>.
        /// Returns whether login succeeded
        /// </returns>
        bool Login(string userName = null, string password = null);

        /// <summary>
        /// The logout.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// 
        bool SignUp();
        /// <summary>
        /// The Sign up for new users.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Logout();

    }
}