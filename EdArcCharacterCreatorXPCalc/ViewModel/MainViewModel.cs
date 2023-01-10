using System.IO;
using System.Xml;
using System.Windows.Input;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using EdArcCharacterCreatorXPCalc.Model;

using EdArcCharacterCreatorXPCalc.View;

namespace EdArcCharacterCreatorXPCalc.ViewModel {

	internal class MainViewModel : ViewModelBase {

		#region Application Commands
		private readonly DelegateCommand newCharacterDialogCommand;
		private readonly DelegateCommand addCharacterCommand;
		private readonly DelegateCommand deleteCharacterCommand;
		private readonly DelegateCommand editCharacterCommand;
		private readonly DelegateCommand saveLibraryCommand;
		public ICommand NewCharacterDialogCommand => newCharacterDialogCommand;
		public ICommand AddCharacterCommand => addCharacterCommand;
		public ICommand DeleteCharacterCommand => deleteCharacterCommand;
		public ICommand EditCharacterCommand => editCharacterCommand;
		public ICommand SaveLibraryCommand => saveLibraryCommand;
		
		private void OnNewCharacterDialog(object commandParameter) {
			// Instantiate window
			InitializeCharacterDialog newCharacterDialogBox = new InitializeCharacterDialog();

			// Show window modally
			// NOTE: Returns only when window is closed
			newCharacterDialogBox.ShowDialog();
			// OnCancel
			// OnOk
			// then call add character (return character you just created)
			// then open newcharacter in edit window (pass character you just created to edit command)
		}

		private bool CanNewCharacterDialog(object commandParameter) {
			/*return conditions in which OnCommand should & shouldn't execute*/
			return true; // this is a placeholder
		}

		private void OnAddCharacter(object commandParameter) {
			Character newCharacter = new Character();
			newCharacter.Name = "Name...";
			newCharacter.Description = "Description...";
			newCharacter.Health = 0;
			newCharacter.Mana = 0;
			newCharacter.TotalXP = (int)commandParameter;

			if (CharacterLibrary == null) {
				CharacterLibrary = new ObservableCollection<Character> { };
			}
			CharacterLibrary.Add(newCharacter);

			//addCharacterCommand.InvokeCanExecuteChanged();
		}

		private bool CanAddCharacter(object commandParameter) {
			/*return conditions in which OnCommand should & shouldn't execute*/
			return true; // this is a placeholder
		}

		private void OnDeleteCharacter(object commandParameter) {
			CharacterLibrary.Remove((Character)commandParameter);
		}

		private bool CanDeleteCharacter(object commandParameter) {
			/*return conditions in which OnCommand should & shouldn't execute*/
			return true; // this is a placeholder
		}

		private void OnEditCharacter(object commandParameter) {
			EditorWindow editorWindow = new EditorWindow(commandParameter, CharacterLibrary.IndexOf((Character)commandParameter));
			editorWindow.Show();
			//EditorViewModel editorViewModel = new EditorViewModel((Character)commandParameter);
		}

		private bool CanEditCharacter(object commandParameter) {
			/*return conditions in which OnCommand should & shouldn't execute*/
			return true; // this is a placeholder
		}

		private void OnSaveLibrary(object commandParameter) {
			// Create serializer for Character data type
			DataContractSerializer writer = new DataContractSerializer(typeof(ObservableCollection<Character>));

			// Path in which data will be stored
			var path = "C:/ImagiSpark/applications/XPCalculator/CharacterLibrary.xml";

			// Use path to create the file & a pointer to the file
			XmlWriter file = XmlWriter.Create(path);

			// Write Character Library to file & close the file pointer
			writer.WriteObject(file, characterLibrary);
			file.Close();
		}

		private bool CanSaveLibrary(object commandParameter) {
			/*return conditions in which OnCommand should & shouldn't execute*/
			return true; // this is a placeholder
		}
		#endregion

		#region Application Data
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

			#region Commands
			newCharacterDialogCommand = new DelegateCommand(OnNewCharacterDialog, CanNewCharacterDialog);
			addCharacterCommand = new DelegateCommand(OnAddCharacter, CanAddCharacter);
			deleteCharacterCommand = new DelegateCommand(OnDeleteCharacter, CanDeleteCharacter);
			editCharacterCommand = new DelegateCommand(OnEditCharacter, CanEditCharacter);
			saveLibraryCommand = new DelegateCommand(OnSaveLibrary, CanSaveLibrary);
			#endregion

			#region Read XML Data
			DataContractSerializer reader = new DataContractSerializer(typeof(ObservableCollection<Character>));

			var path = "C:/ImagiSpark/applications/XPCalculator/CharacterLibrary.xml";

			if (File.Exists(path)) {
				XmlReader file = XmlReader.Create(path);
				characterLibrary = (ObservableCollection<Character>)reader.ReadObject(file);
				file.Close();
			}
			#endregion
		}
		#endregion
	}

}

