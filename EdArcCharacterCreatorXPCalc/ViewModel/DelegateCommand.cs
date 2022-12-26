using System.Windows.Input;
using System;

namespace EdArcCharacterCreatorXPCalc.ViewModel {

	/*
     * This class was constructed with the help of this webpage:
     * https://intellitect.com/blog/getting-started-model-view-viewmodel-mvvm-pattern-using-windows-presentation-framework-wpf/
     */
	public class DelegateCommand : ICommand {

		private readonly Action<object> _executeAction;
		private readonly Func<object, bool> _canExecuteAction;
		public event EventHandler CanExecuteChanged;

		public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction) {
			_executeAction = executeAction;
			_canExecuteAction = canExecuteAction;
		}

		public void Execute(object parameter) => _executeAction(parameter);

		public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;

		public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

	}
}
