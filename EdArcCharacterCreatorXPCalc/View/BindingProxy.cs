﻿using System.Windows;

/*
 * Source Code Found Here: https://thomaslevesque.com/2011/03/21/wpf-how-to-bind-to-data-when-the-datacontext-is-not-inherited/
 */

namespace EdArcCharacterCreatorXPCalc.View {
	public class BindingProxy : Freezable {

		protected override Freezable CreateInstanceCore() {
			return new BindingProxy();
		}

		public object Data {
			get { return (object)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}

		public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
	}
}