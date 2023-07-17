using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Threading;

namespace MediaPlayer_INF0996.MVVM.View
{
	public partial class MediaPlayerView : UserControl
	{
		public DispatcherTimer MediaTimer { get; set; }

		public MediaPlayerView()
		{
			InitializeComponent();

			MediaTimer = new DispatcherTimer();
			MediaTimer.Interval = TimeSpan.FromMilliseconds(500);
			MediaTimer.Tick += MediaTimer_Tick;
		}

		private void MediaTimer_Tick(object? sender, EventArgs e)
		{
			seekSlider.Value = mediaElement.Position.TotalSeconds;
		}

		private void MediaInitializer(object sender, RoutedEventArgs e)
		{
			mediaElement.LoadedBehavior = MediaState.Manual;
			mediaElement.UnloadedBehavior = MediaState.Manual;
		}

		private void SearchMediaButton(object sender, RoutedEventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

			fileDialog.Filter = "All files (*.*)|*.*|MP3 Files (*.mp3)|*.mp3|MP4 File (*.mp4)|*.mp4|3GP File (*.3gp)|*.3gp|Audio File (*.wma)|*.wma|MOV File (*.mov)|*.mov|AVI File (*.avi)|*.avi|Flash Video(*.flv)|*.flv|Video File (*.wmv)|*.wmv|MPEG-2 File (*.mpeg)|*.mpeg|WebM Video (*.webm)|*.webm";

			fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // replace with view model user preferences
			fileDialog.ShowDialog();

			try
			{
				mediaElement.Source = new Uri(fileDialog.FileName);
				mediaTitle.Text = System.IO.Path.GetFileNameWithoutExtension(fileDialog.FileName);

				mediaElement.Volume = 100;
			
				mediaElement.LoadedBehavior = MediaState.Manual;
				mediaElement.UnloadedBehavior = MediaState.Manual;

				mediaElement.Play();
			}
			catch (UriFormatException) { }
		}

		private void PlayButton(object sender, RoutedEventArgs e)
		{
			if(mediaElement.IsInitialized)
			{
				mediaElement.Play();
			}
		}

		private void PauseButton(object sender, RoutedEventArgs e)
		{
			if(mediaElement.IsInitialized)
			{
				mediaElement.Pause();
			}
		}

		private void StopButton(object sender, RoutedEventArgs e)
		{
			if(mediaElement.IsInitialized)
			{
				mediaElement.Stop();
			}
		}

		private void VolumeSliderValueChanged(object sender, RoutedEventArgs e)
		{
			mediaElement.Volume = (double)volumeSlider.Value;

			if(volumeSlider.Value == 0)
				volumeText.Text = "\uea2a ";
			else if(volumeSlider.Value < 0.20)
				volumeText.Text = "\uea29 ";
			else if(volumeSlider.Value < 0.4)
				volumeText.Text = "\uea28 ";
			else if(volumeSlider.Value < 0.7)
				volumeText.Text = "\uea27 ";
			else
				volumeText.Text = "\uea26 ";
		}

		private void SeekSliderValueChanged(object sender, RoutedEventArgs e)
		{
			mediaElement.Position = TimeSpan.FromSeconds(seekSlider.Value);
		}

		private void SeekSlider_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if(seekSlider.IsMouseCaptureWithin)
				mediaElement.Pause();

			else
				mediaElement.Play();
		}

		private void OnMediaOpened(object sender, RoutedEventArgs e)
		{
			TimeSpan timeSpan = mediaElement.NaturalDuration.TimeSpan;
			seekSlider.Maximum = timeSpan.TotalSeconds;

			volumeSlider.Minimum = 0;
			volumeSlider.Maximum = 1;

			volumeSlider.Value = mediaElement.Volume;

			MediaTimer.Start();
		}
	}
}
