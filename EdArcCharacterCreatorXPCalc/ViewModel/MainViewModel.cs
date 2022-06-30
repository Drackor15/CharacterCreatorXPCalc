using System.IO;
using System.Xml;
using System.Windows.Input;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using EdArcCharacterCreatorXPCalc.Model;
using System.Windows;

namespace EdArcCharacterCreatorXPCalc.ViewModel {

    internal class MainViewModel : ViewModelBase {

        #region Application Commands
        private readonly DelegateCommand displayAddCharacter;
        public ICommand DisplayAddCharacter => displayAddCharacter;


        private void OnDisplayAddCharacter(object commandParameter) {
            /*command actions*/


            //displayAddCharacter.InvokeCanExecuteChanged();
        }

        private bool CanDisplayAddCharacter(object commandParameter) {
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
            displayAddCharacter = new DelegateCommand(OnDisplayAddCharacter, CanDisplayAddCharacter);
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

