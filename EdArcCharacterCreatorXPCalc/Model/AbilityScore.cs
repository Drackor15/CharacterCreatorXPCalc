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
    internal class AbilityScore : XPCumulative, IXPPrices {
        [IgnoreDataMember]
        public int[] XPPrices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}
