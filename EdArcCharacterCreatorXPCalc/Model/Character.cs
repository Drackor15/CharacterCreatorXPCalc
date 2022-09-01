using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using EdArcCharacterCreatorXPCalc.ModelInterfaces;

namespace EdArcCharacterCreatorXPCalc.Model {

    [DataContract]
    internal class Character : INamedCharacterTrait, IDescribableCharacterTrait {

        #region Constructor
        public Character() {
            strength = new AbilityScore();
            dexterity = new AbilityScore();
            constitution = new AbilityScore();
            intelligence = new AbilityScore();
            wisdom = new AbilityScore();
            charisma = new AbilityScore();

            abilities = new ObservableCollection<AbilitiesFeats>();
            feats = new ObservableCollection<AbilitiesFeats>();
            proficiencies = new ObservableCollection<Proficiency>();
            instrumentsGames = new ObservableCollection<Proficiency>();
            languages = new ObservableCollection<Language>();
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
        private int abilityScorePoints;

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


        [DataMember]
        private int totalXP;

        [DataMember]
        private int spentXP;

        [DataMember]
        private int remainingXP;

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
        public int AbilityScorePoints {
            get { return abilityScorePoints; }
            set { abilityScorePoints = value; }
        }

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

        #region XP

        public int TotalXP {
            get { return totalXP; }
            set { totalXP = value; }
        }

        public int SpentXP {
            get { return spentXP; }
            set { spentXP = value; }
        }

        public int RemainingXP {
            get { return remainingXP; }
            set { remainingXP = value; }
        }

        #endregion

        #endregion
    }

}
