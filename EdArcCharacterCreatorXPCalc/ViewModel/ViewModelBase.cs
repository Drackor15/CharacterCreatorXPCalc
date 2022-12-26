using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace EdArcCharacterCreatorXPCalc.ViewModel {

	/*
     * The following class was made with guidance from the following website:
     * https://intellitect.com/blog/getting-started-model-view-viewmodel-mvvm-pattern-using-windows-presentation-framework-wpf/
     * click the link to see the source code
     */

	internal abstract class ViewModelBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		/*
         * Set Property Method
         * 
         * field        - a generic reference (think pointer?) to the field being changed
         * newValue     - a generic value
         * propertyName - a string that uses CallerMemberName to retrieve the poperty name that will be updated.
         *                to read up on CallerMemberName go here: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callermembernameattribute?view=net-6.0
         */
		protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null) {
			/* If the newValue doesn't equal the old one, then change the value of the field to the newValue
             * Invoke the PropertyChangedEventHandler on the property type so that the property updates.
             * This maintains synchronisity between View & Model
             */
			if (!EqualityComparer<T>.Default.Equals(field, newValue)) {
				field = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}
			return false;
		}
	}

}
