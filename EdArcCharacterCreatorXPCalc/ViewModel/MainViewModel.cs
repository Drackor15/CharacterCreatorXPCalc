using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdArcCharacterCreatorXPCalc.Model;

namespace EdArcCharacterCreatorXPCalc.ViewModel {

	internal class MainViewModel : ViewModelBase {

		private ObservableCollection<Character> characterLibrary;

		/*
		 * To read up on the syntax used in the property below, check out this site:
		 * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
		 */
		public ObservableCollection<Character> CharacterLibrary {
			get => characterLibrary;
			set => SetProperty(ref characterLibrary, value);
		}

		// When the Program starts up, load data from XML file into the characterLibrary var/property
		public MainViewModel() {
			throw new NotImplementedException();
		}
	}

}

