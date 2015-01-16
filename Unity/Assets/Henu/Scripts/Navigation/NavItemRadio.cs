﻿namespace Henu.Navigation {

	/*================================================================================================*/
	public class NavItemRadio : NavItem<bool> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public NavItemRadio(string pLabel, float pRelativeSize=1) : 
														base(ItemType.Radio, pLabel, pRelativeSize) {
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Select() {
			Value = true;
			base.Select();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override bool AllowSelection {
			get {
				return (!Value && base.AllowSelection);
			}
		}

	}

}
