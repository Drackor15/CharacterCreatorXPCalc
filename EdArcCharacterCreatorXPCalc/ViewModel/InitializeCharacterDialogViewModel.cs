using System;
using System.Windows.Input;
using System.Collections.ObjectModel;

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
		private ObservableCollection<int> characterToEditAbilityScoreBaseScores;

		/// <summary>
		/// 3 different modes which determine the method by which a user fills out their ability score modifiers:
		/// <para>
		/// Standard Array
		/// Point Buy
		/// Manual
		/// </para>
		/// </summary>
		public String AbilityScoreMode {
			get => abilityScoreMode;
			private set => SetProperty(ref abilityScoreMode, value);
		}

		/// <summary>
		/// A collection of 6 Objects which map to a Character's BaseScores of their AbilityScore types:
		/// <para>
		/// 0. Strength
		/// 1. Dexterity
		/// 2. Constitution
		/// 3. Intelligence
		/// 4. Wisdom
		/// 5. Charisma
		/// </para>
		/// </summary>
		public ObservableCollection<int> CharacterToEditAbilityScoreBaseScores {
			get => characterToEditAbilityScoreBaseScores;
			set {
				SetProperty(ref characterToEditAbilityScoreBaseScores, value);
				//UpdateProperties();
			}
		}

		public InitializeCharacterDialogViewModel() {
			setAbilityScoreModeCommand = new DelegateCommand(OnSetAbilityScoreModeCommand, CanSetAbilityScoreModeCommand);

			AbilityScoreMode = "Standard Array";
		}
		#endregion
	}
}
