﻿using System;

namespace Henu.Navigation {

	/*================================================================================================*/
	public class NavItemSlider : NavItem<float> {

		public int Ticks { get; set; }
		public int Snaps { get; set; }
		public Func<float, string> ValueToLabel { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public NavItemSlider(string pLabel, float pRelativeSize=1) : 
														base(ItemType.Slider, pLabel, pRelativeSize) {
			ValueToLabel = (v => 
				(string.IsNullOrEmpty(Label) ? "" : Label+": ")+(v*100).ToString("0.0")+"%"
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override float Value {
			get {
				return base.Value;
			}
			set {
				base.Value = Math.Max(0, Math.Min(1, value));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void DeselectStickySelections() {
			Value = SnappedValue;
			base.DeselectStickySelections();
		}

		/*--------------------------------------------------------------------------------------------*/
		public float SnappedValue {
			get {
				if ( Snaps < 2 ) {
					return Value;
				}

				int s = Snaps-1;
				return (float)Math.Round(Value*s)/s;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool UsesStickySelection() {
			return true;
		}

	}

}
