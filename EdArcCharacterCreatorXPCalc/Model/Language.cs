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
	internal class Language : XPCumulative, IXPPrices, IDescribableCharacterTrait {
		[DataMember]
		public string Proficiency {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		[IgnoreDataMember]
        public int[] XPPrices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		[DataMember]
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		[DataMember]
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}
