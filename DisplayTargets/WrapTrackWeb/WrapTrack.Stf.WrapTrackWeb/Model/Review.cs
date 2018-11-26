using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapTrack.Stf.WrapTrackWeb.Interfaces;

namespace WrapTrack.Stf.WrapTrackWeb.Model
{
    /// <summary>
    /// The Review.
    /// </summary>
    public class Review : WrapTrackWebShellModelBase, IReview
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class. 
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Review(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }


        //toDo: implement when we have stable env
        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
