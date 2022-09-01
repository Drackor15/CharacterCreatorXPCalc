using System.Windows.Input;
using EdArcCharacterCreatorXPCalc.Model;

namespace EdArcCharacterCreatorXPCalc.ViewModel {
    internal class EditorViewModel : ViewModelBase {

        #region Commands
        private readonly DelegateCommand addAbilityScorePointsCommand;
        private readonly DelegateCommand subAbilityScorePointsCommand;
        private readonly DelegateCommand increaseAbilityScoreCommand;
        private readonly DelegateCommand decreaseAbilityScoreCommand;

        public ICommand AddAbilityScorePointsCommand => addAbilityScorePointsCommand;
        public ICommand SubAbilityScorePointsCommand => subAbilityScorePointsCommand;
        public ICommand IncreaseAbilityScoreCommand => increaseAbilityScoreCommand;
        public ICommand DecreaseAbilityScoreCommand => decreaseAbilityScoreCommand;


        private void OnAddAbilityScorePoints(object commandParameter) {
            //CharacterToEdit.AbilityScorePoints += 2;
        }

        private bool CanAddAbilityScorePoints(object commandParameter) {
            return true; // this is a placeholder
        }

        private void OnSubAbilityScorePoints(object commandParameter) {
            //CharacterToEdit.AbilityScorePoints -= 2;
        }

        private bool CanSubAbilityScorePoints(object commandParameter) {
            return true; // this is a placeholder
        }

        private void OnIncreaseAbilityScore(object commandParameter) {

        }

        private bool CanIncreaseAbilityScore(object commandParameter) {
            return true; // this is a placeholder
        }

        private void OnDecreaseAbilityScore(object commandParameter) {

        }

        private bool CanDecreaseAbilityScore(object commandParameter) {
            return true; // this is a placeholder
        }
        #endregion

        #region Data Context
        private Character characterToEdit;

        public Character CharacterToEdit {
            get => characterToEdit;
            set => SetProperty(ref characterToEdit, value);
        }
        #endregion

        public EditorViewModel(Character CharacterToEdit) {
            #region Commands
            addAbilityScorePointsCommand = new DelegateCommand(OnAddAbilityScorePoints, CanAddAbilityScorePoints);
            subAbilityScorePointsCommand = new DelegateCommand(OnSubAbilityScorePoints, CanSubAbilityScorePoints);
            increaseAbilityScoreCommand = new DelegateCommand(OnIncreaseAbilityScore, CanIncreaseAbilityScore);
            decreaseAbilityScoreCommand = new DelegateCommand(OnDecreaseAbilityScore, CanDecreaseAbilityScore);
            #endregion

            // Data Context
            characterToEdit = CharacterToEdit;
        }

    }

}
