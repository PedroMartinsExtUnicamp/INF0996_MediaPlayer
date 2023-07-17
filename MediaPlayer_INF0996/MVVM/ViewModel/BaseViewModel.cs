using System;
using System.ComponentModel;

namespace MediaPlayer_INF0996.MVVM.ViewModel
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
