using System;
using System.Runtime.Serialization;
using EdArcCharacterCreatorXPCalc.ModelInterfaces;

namespace EdArcCharacterCreatorXPCalc.Model {
    /*
     * A class used for character ability scores: Str, Dex, Con, Int, Wis, & Cha.
     */
    [DataContract]
    internal class AbilityScore : IBaseScore, IProficiecyModifier {

        /// <summary>
        /// Default BaseScore to 0
        /// </summary>
        internal AbilityScore() {
            BaseScore = 0;
        }

        #region Fields
        [DataMember]
        private int baseScore;

        [DataMember]
        private int modifier;
        #endregion

        #region Properties
        public int BaseScore {
            get {
                return baseScore;
            }

            set {
                if (value <= 20 && value >= 0) {
                    baseScore = value;
                }
                else {
                    throw new System.ArgumentOutOfRangeException();
                }
            }
        }

        public int Modifier {
            get {
                return modifier;
            }

            set {
                if (Math.Ceiling((double)(baseScore - 10) / 2) > Math.Floor((double)(baseScore - 10) / 2)) {
                    modifier = (int)Math.Floor((double)(baseScore - 10) / 2);
                }
                else {
                    modifier = (int)Math.Ceiling((double)(baseScore - 10) / 2);
                }
            }
        }
        #endregion
    }
}
