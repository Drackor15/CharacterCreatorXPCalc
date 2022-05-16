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
	internal class InstrumentsGamesProficiency : XPCumulative, IDescribableCharacterTrait {
		// Merge with properties class but insert this class's enum? blah blah

		#region XPPrices ENUM
		public enum XPPrices {     // MOVE TO A PUBLIC NAMESPACE?
			plusTwo = 50,
			plusThree = 200,
			plusFour = 400,
			plusFive = 600,
			plusSix = 800
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
