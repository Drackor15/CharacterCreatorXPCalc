using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using EdArcCharacterCreatorXPCalc.ModelInterfaces;

namespace EdArcCharacterCreatorXPCalc.Model {

	[DataContract]
	internal class Character : INamedCharacterTrait, IDescribableCharacterTrait {

        #region Constructor
		// instances & characterID may be unecessary
        [DataMember]
		private static int instances = 0;

		[DataMember]
		private int characterID;

		public int CharacterID {
			get { return characterID; }
		}

		public Character() {
			characterID = instances;
			instances++;
		}
		#endregion

		#region Character Trait Data (Fields & Properties)

		#region Fields
		[DataMember]
		private string name;

		[DataMember]
		private string description;


		[DataMember]
		private int health;

		[DataMember]
		private int mana;


		[DataMember]
		private AbilityScore strength;

		[DataMember]
		private AbilityScore dexterity;

		[DataMember]
		private AbilityScore constitution;

		[DataMember]
		private AbilityScore intelligence;

		[DataMember]
		private AbilityScore wisdom;

		[DataMember]
		private AbilityScore charisma;


		[DataMember]
		private ObservableCollection<AbilitiesFeats> abilities;

		[DataMember]
		private ObservableCollection<AbilitiesFeats> feats;


		[DataMember]
		private ObservableCollection<Proficiency> proficiencies;

		[DataMember]
		private ObservableCollection<Proficiency> instrumentsGames;

		[DataMember]
		private ObservableCollection<Language> languages;

        #endregion

        #region Name & Description
		public string Name {
			get { return name; }
			set { name = value; }
		}

		public string Description {
			get { return description; }
			set { description = value; }
		}
        #endregion

        #region Health & Mana
		public int Health {
			get { return health; }
			set { health = value; }
		}

		public int Mana {
			get { return mana; }
			set { mana = value; }
		}
        #endregion

        #region Ability Scores
		public AbilityScore Strength {
			get { return strength; }
			set { strength = value; }
		}

		public AbilityScore Dexterity {
			get { return dexterity; }
			set { dexterity = value; }
		}

		public AbilityScore Constitution {
			get { return constitution; }
			set { constitution = value; }
		}

		public AbilityScore Intelligence {
			get { return intelligence; }
			set { intelligence = value; }
		}

		public AbilityScore Wisdom {
			get { return wisdom; }
			set { wisdom = value; }
		}

		public AbilityScore Charisma {
			get { return charisma; }
			set { charisma = value; }
		}
        #endregion

        #region Class Abilities & Feats
		public ObservableCollection<AbilitiesFeats> Abilities {
			get { return abilities; }
			set { abilities = value; }
		}

		public ObservableCollection<AbilitiesFeats> Feats {
			get { return feats; }
			set { feats = value; }
		}
        #endregion

        #region Proficiencies
		public ObservableCollection<Proficiency> Proficiciencies {
			get { return proficiencies; }
			set { proficiencies = value; }
		}

		public ObservableCollection<Proficiency> InstrumentsGames {
			get { return instrumentsGames; }
			set { instrumentsGames = value; }
		}

		public ObservableCollection<Language> Languges {
			get { return languages; }
			set { languages = value; }
		}
        #endregion

        #endregion
    }

}
