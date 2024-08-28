using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Movies.Model;

namespace The_Movies.ViewModel
{
    internal class ShowingViewModel : ViewModelBase
    {
		public Movie Movie { get { return showing.Movie; } }




		private Showing showing;
		public Showing Showing
		{
			get { return showing; }
			set { showing = value; }
		}

		public ShowingViewModel(Showing _showing)
		{
			this.showing = _showing;
		}
	}
}
