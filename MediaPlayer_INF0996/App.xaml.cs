using MediaPlayer_INF0996.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MediaPlayer_INF0996
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{

		}

		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow = new MainWindow()
			{
				DataContext = new MainViewModel()
			};
			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
