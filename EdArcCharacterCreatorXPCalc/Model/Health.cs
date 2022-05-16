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
	internal class Health : XPNonCumulative, IXPPrices {

		[DataMember]
		public int CharacterHealth {
            get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[IgnoreDataMember]
        public int[] XPPrices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

