using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
	}
}
