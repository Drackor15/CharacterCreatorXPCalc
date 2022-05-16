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
	internal class Proficiency : XPCumulative, IDescribableCharacterTrait {

		#region XPPrices ENUM
		public enum XPPrices {     // MOVE TO A PUBLIC NAMESPACE?
			plusTwo = 50,
			plusThree = 300,
			plusFour = 700,
			plusFive = 1000,
			plusSix = 2000
		}
		#endregion

		#region Fields
		private int modifier;
		private string name;
		private string description;
        #endregion

        #region Properties
        [DataMember]
		public int Modifier {
			get {
				return modifier;
			}
			set {
				modifier = value;
			}
		}

		[DataMember]
        public string Name {
			get { return name; }
			set { name = value; }
		}

		[DataMember]
        public string Description {
			get { return description; }
			set { description = value; }
		}
        #endregion
    }
}

