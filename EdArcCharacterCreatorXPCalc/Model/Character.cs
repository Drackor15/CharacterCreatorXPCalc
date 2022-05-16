using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using EdArcCharacterCreatorXPCalc.ModelInterfaces;

namespace EdArcCharacterCreatorXPCalc.Model {

	[DataContract]
	internal class Character : IDescribableCharacterTrait {

		[DataMember]
		private static int instances;

		[DataMember]
		private int characterID;

		public int CharacterID {
			get {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public ObservableCollection<ClassAbility> CharacterAbilities {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public Health CharacterHealth {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public Mana CharacterMana {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public ObservableCollection<Language> CharacterLanguges {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public ObservableCollection<Proficiency> CharacterProficiciencies {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public ObservableCollection<InstrumentsGamesProficiency> CharacterInstrumentsGames {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public AbilityScore CharacterStrength {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public AbilityScore Dexterity {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public AbilityScore Constitution {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public AbilityScore Intelligence {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public AbilityScore Wisdom {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public AbilityScore Charisma {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[DataMember]
		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		[DataMember]
		public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}
