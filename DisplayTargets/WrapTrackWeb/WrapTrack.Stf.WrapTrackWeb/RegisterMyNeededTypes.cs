// --------------------------------------------------------------------------------------------------------------------
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
        public RegisterMyNeededTypes(Interfaces.IWrapTrackWebShell wtShell)
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

            stfContainer.RegisterType<Interfaces.IModel, Model.Model>();
            
            stfContainer.RegisterType<Interfaces.IReview, Model.Review>();

            stfContainer.RegisterType<Interfaces.News.INews, News.News>();
            stfContainer.RegisterType<Interfaces.News.INewsEntryCarrierStory, News.NewsEntryCarrierStory>();
            stfContainer.RegisterType<Interfaces.News.INewsEntryCarrierForSale, News.NewsEntryCarrierForSale>();
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

            RegisterCarrierManagementClasses();
        }

        /// <summary>
        /// The register carrier management classes.
        /// </summary>
        private void RegisterCarrierManagementClasses()
        {
            // CarrierManagement classes
            stfContainer.RegisterType<Interfaces.Me.Collection.CarrierManagement.IAddCarrier, Me.Collection.CarrierManagement.AddCarrier>();
            stfContainer.RegisterType<Interfaces.Me.Collection.CarrierManagement.IRingSling, Me.Collection.CarrierManagement.RingSling>();
            stfContainer.RegisterType<Interfaces.Me.Collection.CarrierManagement.IStretchyWrap, Me.Collection.CarrierManagement.StretchyWrap>();
            stfContainer.RegisterType<Interfaces.Me.Collection.CarrierManagement.IWowenWrap, Me.Collection.CarrierManagement.WowenWrap>();
            stfContainer.RegisterType<Interfaces.Me.Collection.CarrierManagement.IHybridWrap, Me.Collection.CarrierManagement.HybridWrap>();            
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
