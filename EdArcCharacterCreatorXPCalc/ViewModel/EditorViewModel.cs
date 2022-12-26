using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using EdArcCharacterCreatorXPCalc.Model;

namespace EdArcCharacterCreatorXPCalc.ViewModel {
	internal class EditorViewModel : ViewModelBase {

		#region Commands
		private readonly DelegateCommand increaseAbilityScoreCommand;
		private readonly DelegateCommand decreaseAbilityScoreCommand;

		public ICommand IncreaseAbilityScoreCommand => increaseAbilityScoreCommand;
		public ICommand DecreaseAbilityScoreCommand => decreaseAbilityScoreCommand;

		private void OnIncreaseAbilityScore(object commandParameter) {
			if (CharacterToEditAbilityScorePoints > 0) {
				int index = Int32.Parse((string)commandParameter);
				CharacterToEditAbilityScoreBaseScores[index] += 1;
				CharacterToEditAbilityScorePoints -= 1;
				CharacterToEditAbilityScoreModifiers[index] = CalcModifier(index);
			} else if (CharacterToEditAbilityScorePoints == 0) {
				PurchaseAbilityScoreIncrease();
				CharacterToEditAbilityScorePoints += 2;
				CharacterToEditNumOfAbilityScoreUpgrades += 1;
			}
		}

		private bool CanIncreaseAbilityScore(object commandParameter) {
			return true; // this is a placeholder
		}

		private void OnDecreaseAbilityScore(object commandParameter) {
			int index = Int32.Parse((string)commandParameter);
			if (CharacterToEditAbilityScorePoints == 2) {
				CharacterToEditAbilityScorePoints -= 2;
				CharacterToEditNumOfAbilityScoreUpgrades -= 1;
				UnpurchaseAbilityScoreIncrease();
			}
			else if (CharacterToEditAbilityScorePoints >= 0 && CharacterToEditAbilityScoreBaseScores[index] > 0) {
				CharacterToEditAbilityScoreBaseScores[index] -= 1;
				CharacterToEditAbilityScorePoints += 1;
				CharacterToEditAbilityScoreModifiers[index] = CalcModifier(index);
			}
			
		}

		private bool CanDecreaseAbilityScore(object commandParameter) {
			return true; // this is a placeholder
		}
		#endregion

		#region Methods
		private int CalcModifier(int index) {
			if (Math.Ceiling((double)(CharacterToEditAbilityScoreBaseScores[index] - 10) / 2) > Math.Floor((double)(CharacterToEditAbilityScoreBaseScores[index] - 10) / 2)) {
				return (int)Math.Floor((double)(CharacterToEditAbilityScoreBaseScores[index] - 10) / 2);
			}
			else {
				return (int)Math.Ceiling((double)(CharacterToEditAbilityScoreBaseScores[index] - 10) / 2);
			}
		}

		/// <summary>
		/// Used to calculate Ability Score Increase XP cost
		/// </summary>
		private void PurchaseAbilityScoreIncrease() {
			int xpPrice = 0;
			switch (CharacterToEditNumOfAbilityScoreUpgrades) {
				// 1st time increasing
				case 0:
					xpPrice = 1800;
					break;

				// 2nd time
				case 1:
					xpPrice = 3500;
					break;

				// 3rd time
				case 2:
					xpPrice = 11000;
					break;

				// 4th time
				case 3:
					xpPrice = 15000;
					break;

				// 5th time
				case 4:
					xpPrice = 20000;
					break;

				// 6th time
				case 5:
					xpPrice = 30000;
					break;


				// 7th or More
				default:
					xpPrice = 40000;
					break;
			}
			CharacterToEditSpentXP += xpPrice;
			CharacterToEditRemainingXP = CharacterToEditTotalXP - CharacterToEditSpentXP;
		}

		/// <summary>
		/// Used to calculate Ability Score Decrease XP cost
		/// </summary>
		private void UnpurchaseAbilityScoreIncrease() {
			int xpPrice = 0;
			switch (CharacterToEditNumOfAbilityScoreUpgrades) {
				// 1st time increasing
				case 0:
					xpPrice = 1800;
					break;

				// 2nd time
				case 1:
					xpPrice = 3500;
					break;

				// 3rd time
				case 2:
					xpPrice = 11000;
					break;

				// 4th time
				case 3:
					xpPrice = 15000;
					break;

				// 5th time
				case 4:
					xpPrice = 20000;
					break;

				// 6th time
				case 5:
					xpPrice = 30000;
					break;


				// 7th or More
				default:
					xpPrice = 40000;
					break;
			}
			CharacterToEditSpentXP -= xpPrice;
			CharacterToEditRemainingXP = CharacterToEditTotalXP - CharacterToEditSpentXP;
		}
		#endregion

		#region Data Context
		private Character characterToEdit;
		private string characterToEditName;
		private string characterToEditDescription;
		private int characterToEditHealth;
		private int characterToEditMana;
		private int characterToEditAbilityScorePoints;
		private int characterToEditNumOfAbilityScoreUpgrades;
		private ObservableCollection<int> characterToEditAbilityScoreBaseScores;
		private ObservableCollection<int> characterToEditAbilityScoreModifiers;
		// Abilities (items that implement ObservableCollection may not need a shadow property in the viewmodel here since ObservableCollection utilizes Inotifypropertychanged, however directly binding to Character from xaml would violate MVVM)
		// Feats
		// Proficiencies
		// InstrumentsGames
		// Languages
		private int characterToEditTotalXP;
		private int characterToEditSpentXP;
		private int characterToEditRemainingXP;

		public Character CharacterToEdit {
			get => characterToEdit;
			set => SetProperty(ref characterToEdit, value);
		}

		public string CharacterToEditName {
			get => characterToEditName;
			set => SetProperty(ref characterToEditName, value);
		}

		public string CharacterToEditDescription {
			get => characterToEditDescription;
			set => SetProperty(ref characterToEditDescription, value);
		}

		public int CharacterToEditHealth {
			get => characterToEditHealth;
			set => SetProperty(ref characterToEditHealth, value);
		}

		public int CharacterToEditMana {
			get => characterToEditMana;
			set => SetProperty(ref characterToEditMana, value);
		}

		public int CharacterToEditAbilityScorePoints {
			get => characterToEditAbilityScorePoints;
			set => SetProperty(ref characterToEditAbilityScorePoints, value);
		}

		public int CharacterToEditNumOfAbilityScoreUpgrades {
			get => characterToEditNumOfAbilityScoreUpgrades;
			set => SetProperty(ref characterToEditNumOfAbilityScoreUpgrades, value);
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
			set => SetProperty(ref characterToEditAbilityScoreBaseScores, value);
		}

		/// <summary>
		/// A collection of 6 Objects which map to a Character's Modifiers of their AbilityScore types:
		/// <para>
		/// 0. Strength
		/// 1. Dexterity
		/// 2. Constitution
		/// 3. Intelligence
		/// 4. Wisdom
		/// 5. Charisma
		/// </para>
		/// </summary>
		public ObservableCollection<int> CharacterToEditAbilityScoreModifiers {
			get => characterToEditAbilityScoreModifiers;
			set => SetProperty(ref characterToEditAbilityScoreModifiers, value);
		}

		public int CharacterToEditTotalXP {
			get => characterToEditTotalXP;
			set => SetProperty(ref characterToEditTotalXP, value);
		}

		public int CharacterToEditSpentXP {
			get => characterToEditSpentXP;
			set => SetProperty(ref characterToEditSpentXP, value);
		}

		public int CharacterToEditRemainingXP {
			get => characterToEditRemainingXP;
			set => SetProperty(ref characterToEditRemainingXP, value);
		}

		// create an ability scores ENUM so that passing params is easier to read?

		#endregion

		public EditorViewModel(Character CharacterToEdit) {
			#region Commands
			increaseAbilityScoreCommand = new DelegateCommand(OnIncreaseAbilityScore, CanIncreaseAbilityScore);
			decreaseAbilityScoreCommand = new DelegateCommand(OnDecreaseAbilityScore, CanDecreaseAbilityScore);
			#endregion

			// Initialize Data Context
			characterToEdit = CharacterToEdit;
			characterToEditName = characterToEdit.Name;
			characterToEditDescription = characterToEdit.Description;
			characterToEditHealth = characterToEdit.Health;
			characterToEditMana = characterToEdit.Mana;

			#region Ability Score Data
			characterToEditAbilityScorePoints = characterToEdit.AbilityScorePoints;
			characterToEditNumOfAbilityScoreUpgrades = characterToEdit.NumOfAbilityScoreUpgrades;
			characterToEditAbilityScoreBaseScores = new ObservableCollection<int>() {
				characterToEdit.Strength.BaseScore,
				characterToEdit.Dexterity.BaseScore,
				characterToEdit.Constitution.BaseScore,
				characterToEdit.Intelligence.BaseScore,
				characterToEdit.Wisdom.BaseScore,
				characterToEdit.Charisma.BaseScore
			};

			characterToEditAbilityScoreModifiers = new ObservableCollection<int>() {
				characterToEdit.Strength.Modifier,
				characterToEdit.Dexterity.Modifier,
				characterToEdit.Constitution.Modifier,
				characterToEdit.Intelligence.Modifier,
				characterToEdit.Wisdom.Modifier,
				characterToEdit.Charisma.Modifier
			};

			for (int i = 0; i < 6; i++) {
				CharacterToEditAbilityScoreModifiers[i] = CalcModifier(i);
			}
			#endregion

			characterToEditTotalXP = characterToEdit.TotalXP;
			characterToEditSpentXP = characterToEdit.SpentXP;
			characterToEditRemainingXP = characterToEdit.RemainingXP;
		}

	}

}
