using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using EdArcCharacterCreatorXPCalc.ViewModel;

namespace EdArcCharacterCreatorXPCalc.View {
	/// <summary>
	/// Interaction logic for InitializeCharacterDialog.xaml
	/// </summary>
	public partial class InitializeCharacterDialog : Window {
		public InitializeCharacterDialog() {
			var initializeCharacterDialogViewModel = new InitializeCharacterDialogViewModel();

			DataContext = initializeCharacterDialogViewModel;
			InitializeComponent();
		}

		#region EventHandlers
		/*
         * Following code found in: https://stackoverflow.com/questions/14813960/how-to-accept-only-integers-in-a-wpf-textbox
         */
		private void MaskNumericInput(object sender, TextCompositionEventArgs e) {
			e.Handled = !IsTextNumber(e.Text);
		}

		private void MaskNumericPaste(object sender, DataObjectPastingEventArgs e) {
			if (e.DataObject.GetDataPresent(typeof(string))) {
				string input = (string)e.DataObject.GetData(typeof(string));
				if (!IsTextNumber(input)) {
					e.CancelCommand();
				}
			}
			else {
				e.CancelCommand();
			}
		}

		private bool IsTextNumber(string input) {
			return input.All(c => char.IsDigit(c) || char.IsControl(c));
		}
		/**************/

		private void ReplaceNullStringText(object sender, TextChangedEventArgs e) {
			var control = sender as TextBox;
			if (control.Text == "") {
				control.Text = "0";
			}
			if (control.Text.Contains(" ")) {
				control.Text = new string(control.Text.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
			}
		}
		#endregion
	}
}
