using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
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
            DataContractSerializer reader = new DataContractSerializer(typeof(ObservableCollection<Character>));

            var path = "C:/ImagiSpark/applications/XPCalculator";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            path += "/CharacterLibrary.xml";
            if (!File.Exists(path)) {
                XmlWriter newFile = XmlWriter.Create(path);
                newFile.Close();
            }

            XmlReader file = XmlReader.Create(path);
            characterLibrary = (ObservableCollection<Character>)reader.ReadObject(file);
            file.Close();
        }
    }

}

