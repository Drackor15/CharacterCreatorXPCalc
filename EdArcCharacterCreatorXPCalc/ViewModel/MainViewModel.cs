using System.IO;
using System.Xml;
using System.Windows.Input;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using EdArcCharacterCreatorXPCalc.Model;

namespace EdArcCharacterCreatorXPCalc.ViewModel {

    internal class MainViewModel : ViewModelBase {

        #region Application Commands
        private readonly DelegateCommand addCharacterCommand;
        private readonly DelegateCommand deleteCharacterCommand;
        public ICommand AddCharacterCommand => addCharacterCommand;
        public ICommand DeleteCharacterCommand => deleteCharacterCommand;

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
            
        }

        private bool CanDeleteCharacter(object commandParameter) {
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
            addCharacterCommand = new DelegateCommand(OnAddCharacter, CanAddCharacter);
            deleteCharacterCommand = new DelegateCommand(OnDeleteCharacter, CanDeleteCharacter);
            #endregion

            /*  TEST METHOD - Comment Out When Not in Use  */
            //WriteXML(characterLibrary);

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


        /*  TEST METHOD - Comment Out When Not in Use  */
        public static void WriteXML(ObservableCollection<Character> characterLibrary) {

            Character character1 = new Character();
            character1.Name = "Herald Ghan";
            character1.Description = "";
            character1.Health = 0;
            character1.Mana = 0;

            character1.Abilities = new ObservableCollection<AbilitiesFeats> { };
            character1.Feats = new ObservableCollection<AbilitiesFeats> { };
            character1.InstrumentsGames = new ObservableCollection<Proficiency> { };
            character1.Languges = new ObservableCollection<Language> { };
            character1.Proficiciencies = new ObservableCollection<Proficiency> { };

            Character character2 = new Character();
            character2.Name = "Bob Johnson";
            character2.Description = "There is no description here...";
            character2.Health = 0;
            character2.Mana = 0;

            characterLibrary = new ObservableCollection<Character> { character1, character2 };

            // Create a serializer for the data type Book
            DataContractSerializer writer = new DataContractSerializer(typeof(ObservableCollection<Character>));

            // create the path in which the data will be stored
            var path = "C:/ImagiSpark/applications/XPCalculator/CharacterLibrary.xml";

            // use the path to create the file & a pointer to the file
            XmlWriter file = XmlWriter.Create(path);

            // write the book's data to the file & close the file pointer
            writer.WriteObject(file, characterLibrary);
            file.Close();
        }
        #endregion
    }

}

