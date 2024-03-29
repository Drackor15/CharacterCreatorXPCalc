﻿using System.Windows;
using EdArcCharacterCreatorXPCalc.Model;
using EdArcCharacterCreatorXPCalc.ViewModel;
using System.Windows.Input;
using System.Linq;
using System.Windows.Controls;
using System;

namespace EdArcCharacterCreatorXPCalc.View {
	/// <summary>
	/// Interaction logic for EditorWindow.xaml
	/// </summary>
	public partial class EditorWindow : Window {
		public EditorWindow(object character, int characterLibraryIndex) {
			var editorViewModel = new EditorViewModel((Character)character, characterLibraryIndex);

			DataContext = editorViewModel;
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
		private void TotalXPMethods(object sender, TextChangedEventArgs e) {
			ReplaceNullStringText(sender, e);
			UpdateRemainingXPDisplay(sender, e);
		}

		private void UpdateRemainingXPDisplay(object sender, TextChangedEventArgs e) {
			EditorViewModel editorViewModel = (EditorViewModel)this.DataContext;
			TextBox totalXPTextBox = (TextBox)sender;
			Int32.TryParse(totalXPTextBox.Text, out int totalXP);
			editorViewModel.CharacterToEditRemainingXP = totalXP - editorViewModel.CharacterToEditSpentXP;
		}

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
