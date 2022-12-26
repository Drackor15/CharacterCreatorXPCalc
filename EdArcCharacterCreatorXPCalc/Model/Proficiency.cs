using System.Runtime.Serialization;
using EdArcCharacterCreatorXPCalc.ModelInterfaces;

namespace EdArcCharacterCreatorXPCalc.Model {

	/*
     * A class that describes character objects with names, descriptions, & modifiers
     */
	[DataContract]
	internal class Proficiency : INamedCharacterTrait, IDescribableCharacterTrait, IProficiecyModifier {

		#region Fields
		[DataMember]
		private string name;

		[DataMember]
		private string description;

		[DataMember]
		private int modifier;
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

		public int Modifier {
			get {
				return modifier;
			}

			set {
				if (value <= 6 && value >= -6) {
					modifier = value;
				}
				else {
					throw new System.ArgumentOutOfRangeException();
				}
			}
		}
		#endregion
	}
}
