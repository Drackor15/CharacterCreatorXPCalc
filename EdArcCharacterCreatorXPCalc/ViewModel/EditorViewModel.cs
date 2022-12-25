using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using EdArcCharacterCreatorXPCalc.Model;

namespace EdArcCharacterCreatorXPCalc.ViewModel {
    internal class EditorViewModel : ViewModelBase {

        #region Commands
        private readonly DelegateCommand addAbilityScorePointsCommand;
        private readonly DelegateCommand subAbilityScorePointsCommand;
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
                CharacterToEditAbilityScorePoints += 2;
            }
        }

        private bool CanIncreaseAbilityScore(object commandParameter) {
            return true; // this is a placeholder
        }

        private void OnDecreaseAbilityScore(object commandParameter) {
            int index = Int32.Parse((string)commandParameter);
            if (CharacterToEditAbilityScorePoints == 2) {
                CharacterToEditAbilityScorePoints -= 2;
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

        #region Data Context
        private Character characterToEdit;
        private string characterToEditName;
        private string characterToEditDescription;
        private int characterToEditHealth;
        private int characterToEditMana;
        private int characterToEditAbilityScorePoints;
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

        private int CalcModifier(int index) {
            if (Math.Ceiling((double)(CharacterToEditAbilityScoreBaseScores[index] - 10) / 2) > Math.Floor((double)(CharacterToEditAbilityScoreBaseScores[index] - 10) / 2)) {
                return (int)Math.Floor((double)(CharacterToEditAbilityScoreBaseScores[index] - 10) / 2);
            }
            else {
                return (int)Math.Ceiling((double)(CharacterToEditAbilityScoreBaseScores[index] - 10) / 2);
            }
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
            characterToEditAbilityScorePoints = characterToEdit.AbilityScorePoints;

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
        }

    }

}
