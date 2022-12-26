using System.Runtime.Serialization;
using EdArcCharacterCreatorXPCalc.ModelInterfaces;

namespace EdArcCharacterCreatorXPCalc.Model {

	/*
     * A class that used for language character objects
     */
	[DataContract]
	internal class Language : INamedCharacterTrait, ILanguageModifier {
		#region Fields
		[DataMember]
		private string name;

		[DataMember]
		private string modifier;
		#endregion

		#region Properties
		public string Name {
			get { return name; }
			set { name = value; }
		}

		public string Modifier {
			get {
				return modifier;
			}

			set {
				modifier = value;
			}
		}
		#endregion
	}
}
