using System;
using System.Windows.Input;


namespace MediaPlayer_INF0996.MVVM.ViewModel.Commands
{
	public abstract class BaseCommand : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		public virtual bool CanExecute(object? parameter)
		{
			return true;
		}

		protected void OnCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, new EventArgs());
		}

		public abstract void Execute(object? parameter);

	}
}
