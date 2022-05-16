using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using EdArcCharacterCreatorXPCalc.ModelInterfaces;

namespace EdArcCharacterCreatorXPCalc.Model {
	[DataContract]
	internal class Mana : XPNonCumulative {

		#region XPPrices ENUM
		public enum XPPrices {     // MOVE TO A PUBLIC NAMESPACE?
			increaseMana = 200
		}
		#endregion

		#region Fields
		private int characterMana;
        #endregion

        #region Properties
        [DataMember]
		public int CharacterMana {
			get {
				return characterMana;
			}
			set {
				characterMana = value;
			}
		}
        #endregion
    }
}

