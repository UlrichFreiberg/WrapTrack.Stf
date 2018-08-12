﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterMyNeededTypes.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WrapTrackWebShell type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb
{
    using Mir.Stf.Utilities;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The demo corp web shell.
    /// </summary>
    public class RegisterMyNeededTypes
    {
        /// <summary>
        /// The stf container used to register the types for the shell
        /// </summary>
        private readonly IStfContainer stfContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMyNeededTypes"/> class.
        /// </summary>
        /// <param name="wtShell">
        /// The wt shell.
        /// </param>
        public RegisterMyNeededTypes(IWrapTrackWebShell wtShell)
        {
            stfContainer = wtShell.StfContainer;
        }

        /// <summary>
        /// The register.
        /// </summary>
        public void Register()
        {
            RegisterMeClasses();
            RegisterExploreClasses();
            RegisterBrandClasses();

            // FAQ and contact classes
            stfContainer.RegisterType<Interfaces.FaqContact.IFaq, FaqContact.Faq>();

            stfContainer.RegisterType<Interfaces.IWrap, Wrap>();

            stfContainer.RegisterType<Interfaces.IModel, Model>();
        }

        /// <summary>
        /// The register brand classes.
        /// </summary>
        private void RegisterBrandClasses()
        {
            stfContainer.RegisterType<Interfaces.Brand.IBrand, Brand.Brand>();
            stfContainer.RegisterType<Interfaces.Brand.IPatterns, Brand.Patterns>();
            stfContainer.RegisterType<Interfaces.Brand.IForum, Brand.Forum>();
            stfContainer.RegisterType<Interfaces.Brand.IModels, Brand.Models>();
            stfContainer.RegisterType<Interfaces.Brand.IWraps, Brand.Wraps>();
        }

        /// <summary>
        /// The register me classes.
        /// </summary>
        private void RegisterMeClasses()
        {
            // Me classes
            stfContainer.RegisterType<Interfaces.Me.IMeInbox, Me.MeInbox>();
            stfContainer.RegisterType<Interfaces.Me.IMeReviews, Me.MeReviews>();
            stfContainer.RegisterType<Interfaces.Me.IMeSettings, Me.MeSettings>();
            stfContainer.RegisterType<Interfaces.Me.ICollection, Me.Collection.Collection>();
            stfContainer.RegisterType<Interfaces.Me.IMeProfile, Me.MeProfile>();
        }

        /// <summary>
        /// The register explore classes.
        /// </summary>
        private void RegisterExploreClasses()
        {
            // Explore
            stfContainer.RegisterType<Interfaces.Explore.IExploreBirthWraps, Explore.ExploreBirthWraps>();
            stfContainer.RegisterType<Interfaces.Explore.IBrands, Explore.Brands>();
            stfContainer.RegisterType<Interfaces.Explore.IExploreModels, Explore.ExploreModels>();
            stfContainer.RegisterType<Interfaces.Explore.IExplorePatterns, Explore.ExplorePatterns>();
            stfContainer.RegisterType<Interfaces.Explore.IExploreUsers, Explore.ExploreUsers>();
            stfContainer.RegisterType<Interfaces.Explore.IExplore, Explore.Explore>();

            // explore - Brand
            stfContainer.RegisterType<Interfaces.Explore.Brands.IAddBrand, Explore.BrandsClasses.AddBrand>();
            stfContainer.RegisterType<Interfaces.Explore.Brands.IAllBrands, Explore.BrandsClasses.AllBrands>();

            // explore - Wraps
            stfContainer.RegisterType<Interfaces.Explore.Wraps.IWraps, Explore.Wraps.Wraps>();
        }
    }
}
