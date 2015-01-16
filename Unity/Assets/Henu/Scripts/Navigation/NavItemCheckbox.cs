﻿namespace Henu.Navigation {

	/*================================================================================================*/
	public class NavItemCheckbox : NavItem<bool> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public NavItemCheckbox(string pLabel, float pRelativeSize=1) : 
														base(ItemType.Checkbox, pLabel, pRelativeSize) {
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Select() {
			Value = !Value;
			base.Select();
		}

	}

}
