using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdArcCharacterCreatorXPCalc.Model;

namespace EdArcCharacterCreatorXPCalc.ViewModel {
	internal class EditorViewModel : ViewModelBase {
		private Character characterToEdit;

		public EditorViewModel(Character CharacterToEdit) {
			characterToEdit = CharacterToEdit;
		}
	}

}
