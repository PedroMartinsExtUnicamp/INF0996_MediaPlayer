using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer_INF0996.MVVM.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		public BaseViewModel CurrentViewModel { get; }

		public MainViewModel()
		{
			CurrentViewModel = new MediaPlayerViewModel();
		}

	}
}
