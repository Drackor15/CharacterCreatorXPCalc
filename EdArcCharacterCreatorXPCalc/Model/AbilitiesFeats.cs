using System.Runtime.Serialization;
using EdArcCharacterCreatorXPCalc.ModelInterfaces;

namespace EdArcCharacterCreatorXPCalc.Model {
    /*
     * A class used for abilities & feats. Character objects which share similar names & descriptions
     */
    [DataContract]
    internal class AbilitiesFeats : INamedCharacterTrait, IDescribableCharacterTrait {

        #region Fields
        [DataMember]
        private string name;

        [DataMember]
        private string description;
        #endregion

        #region Properties
        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }
        #endregion
    }
}
