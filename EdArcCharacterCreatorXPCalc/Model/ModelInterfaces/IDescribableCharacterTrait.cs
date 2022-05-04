using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdArcCharacterCreatorXPCalc.ModelInterfaces {
	public interface IDescribableCharacterTrait {
		string Name {
			get;
			set;
		}

		string Description {
			get;
			set;
		}
	}

}