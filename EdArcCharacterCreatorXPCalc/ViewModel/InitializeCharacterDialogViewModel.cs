using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;

namespace EdArcCharacterCreatorXPCalc.ViewModel {
	class InitializeCharacterDialogViewModel : ViewModelBase {
		#region Dialog Commands
		private readonly DelegateCommand setAbilityScoreModeCommand;
		public ICommand SetAbilityScoreModeCommand => setAbilityScoreModeCommand;

		private void OnSetAbilityScoreModeCommand(object commandParameter) {
			AbilityScoreMode = (String)commandParameter;
		}

		private bool CanSetAbilityScoreModeCommand(object commandParameter) {
			return true;
		}
		#endregion

		#region Methods
		// to save new character data mimic the 'update' method in EditorViewModel
		#endregion

		#region Dialog Data
		private String abilityScoreMode;

		public String AbilityScoreMode {
			get => abilityScoreMode;
			private set => SetProperty(ref abilityScoreMode, value);
		}


		public InitializeCharacterDialogViewModel() {
			setAbilityScoreModeCommand = new DelegateCommand(OnSetAbilityScoreModeCommand, CanSetAbilityScoreModeCommand);

			AbilityScoreMode = "Standard Array";
		}
		#endregion
	}
}
