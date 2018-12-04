namespace WrapTrack.Stf.WrapTrackWeb.Interfaces
{
   /// <summary>
   /// The Review
   /// </summary>
   public interface IReview
    {

        /// <summary>
        /// Set description.
        /// </summary>
        string Description { set; }

        bool Add();

    }
}
