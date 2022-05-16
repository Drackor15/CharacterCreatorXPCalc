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
	internal class Language : XPCumulative, IDescribableCharacterTrait {

		#region XPPrices ENUM
		public enum XPPrices {     // MOVE TO A PUBLIC NAMESPACE?
			increaseMana = 300
		}
		#endregion

		#region Fields
		private string proficiency;
		private string name;
		private string description;
        #endregion

        #region Properties
        [DataMember]
		public string Proficiency {
			get {
				return proficiency;
			}
			set {
				proficiency = value;
			}
		}

		[DataMember]
        public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		[DataMember]
        public string Description {
			get {
				return description;
			}
			set {
				description = value;
			}
		}
        #endregion
    }

}
