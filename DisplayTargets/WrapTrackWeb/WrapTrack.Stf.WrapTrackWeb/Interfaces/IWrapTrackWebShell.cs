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
    using Mir.Stf.Utilities.Attributes;

    using WrapTrack.Stf.WrapTrackWeb.Configuration;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.FaqContact;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.News;

    /// <summary>
    /// The WrapTrackWebShell interface.
    /// </summary>
    [StfSingleton]
    public interface IWrapTrackWebShell : IStfPlugin
    {
        /// <summary>
        /// Gets or sets the wt configuration.
        /// </summary>
        WtConfiguration WtConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the web adapter.
        /// </summary>
        IWebAdapter WebAdapter { get; set; }

        /// <summary>
        /// Gets or sets the current Windows User in user. 
        /// </summary>
        string CurrentUser { get; set; }

        /// <summary>
        /// Gets or sets the current logged in user.
        /// </summary>
        string CurrentLoggedInUser { get; set; }

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
        /// The <see cref="IMeProfile"/>.
        /// </returns>
        IMeProfile Me();

        /// <summary>
        /// The news.
        /// </summary>
        /// <returns>
        /// The <see cref="INews"/>.
        /// </returns>
        INews News();

        /// <summary>
        /// The explorer.
        /// </summary>
        /// <returns>
        /// The <see cref="IExplore"/>.
        /// </returns>
        IExplore Explore();

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
        /// The <see cref="bool"/>.
        /// Returns whether login succeeded
        /// </returns>
        /// <param name="userName">
        /// Name of the user
        /// </param>
        /// <param name="password">
        /// Password of the user
        /// </param>
        bool Login(string userName = null, string password = null);

        /// <summary>
        /// The login as admin. 
        /// Using the same Login routine as a normal login, but with different username password
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool LoginAsAdmin(string userName = null, string password = null);

        /// <summary>
        /// The logout.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool SignUp();

        /// <summary>
        /// The sign up and login
        /// </summary>
        /// <returns></returns>
        bool SignUpAndLogin();

        /// <summary>
        /// The sign up
        /// </summary>
        /// <param name="newUserName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool SignUp(string newUserName, string password);

        /// <summary>
        /// Checks if feedback for user is shown
        /// </summary>
        /// <param name="v">
        /// The v.
        /// </param>
        /// <returns>
        /// 1: info element found
        /// </returns>
        bool InfoText(string v);

        /// <summary>
        /// The logout.
        /// </summary>
        /// <param name="doCareAboutErrors">
        /// Mostly used in close down scenarios - there we just want to close down - not really caring about success or not
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Logout(bool doCareAboutErrors = true);

        /// <summary>
        /// Logout and Close down the web adapter
        /// </summary>
        void CloseDown();

        /// <summary>
        /// The get to wrap.
        /// </summary>
        /// <param name="wrapId">
        ///     The wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="IWrap"/>.
        /// </returns>
        IWrap GetToWrap(string wrapId);

        /// <summary>
        /// The get to model.
        /// </summary>
        /// <param name="modelId">
        ///     The model id.
        /// </param>
        /// <returns>
        /// The <see cref="IModel"/>.
        /// </returns>
        IModel GetToModel(string modelId);

    }
}