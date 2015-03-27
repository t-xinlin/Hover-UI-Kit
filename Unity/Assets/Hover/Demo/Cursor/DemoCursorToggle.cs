﻿using System;
using Hover.Common.Input;
using Hover.Common.State;
using Hover.Cursor;
using Hover.Cursor.State;
using UnityEngine;

namespace Hover.Demo.Cursor {

	/*================================================================================================*/
	public class DemoCursorToggle : MonoBehaviour {

		private struct Bundle {
			public ICursorState State;
			public Func<bool> ShowFunc; 
		}

		public bool ShowLeftPalm = true;
		public bool ShowLeftThumb = true;
		public bool ShowLeftIndex = true;
		public bool ShowLeftMiddle = true;
		public bool ShowLeftRing = true;
		public bool ShowLeftPinky = true;
		public bool ShowRightPalm = true;
		public bool ShowRightThumb = true;
		public bool ShowRightIndex = true;
		public bool ShowRightMiddle = true;
		public bool ShowRightRing = true;
		public bool ShowRightPinky = true;

		public float HighlightProgress = 0;

		private HovercursorSetup vSetup;
		private Bundle[] vBundles;
		private FakeItemState vFakeItem;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
			vSetup = gameObject.GetComponent<HovercursorSetup>();
			vFakeItem = new FakeItemState();
			vFakeItem.ItemAutoId = 123;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			vBundles = new[] {
				GetBundle(CursorType.LeftPalm, () => ShowLeftPalm),
				GetBundle(CursorType.LeftThumb, () => ShowLeftThumb),
				GetBundle(CursorType.LeftIndex, () => ShowLeftIndex),
				GetBundle(CursorType.LeftMiddle, () => ShowLeftMiddle),
				GetBundle(CursorType.LeftRing, () => ShowLeftRing),
				GetBundle(CursorType.LeftPinky, () => ShowLeftPinky),
				GetBundle(CursorType.RightPalm, () => ShowRightPalm),
				GetBundle(CursorType.RightThumb, () => ShowRightThumb),
				GetBundle(CursorType.RightIndex, () => ShowRightIndex),
				GetBundle(CursorType.RightMiddle, () => ShowRightMiddle),
				GetBundle(CursorType.RightRing, () => ShowRightRing),
				GetBundle(CursorType.RightPinky, () => ShowRightPinky)
			};
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			foreach ( Bundle bundle in vBundles ) {
				bundle.State.SetDisplayStrength(CursorDomain.Hovercursor, (bundle.ShowFunc() ? 1 : 0));
				vFakeItem.MaxHighlightProgress = HighlightProgress;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Bundle GetBundle(CursorType pType, Func<bool> pShowFunc) {
			var bundle = new Bundle();
			bundle.State = vSetup.State.GetCursorState(pType);
			bundle.ShowFunc = pShowFunc;
			bundle.State.AddOrUpdateInteraction(CursorDomain.Hovercursor, vFakeItem);
			return bundle;
		}

	}


	/*================================================================================================*/
	public class FakeItemState : IBaseItemInteractionState {

		public int ItemAutoId { get; set; }
		public bool IsSelectionPrevented { get; set; }
		public float MaxHighlightProgress { get; set; }
		public float SelectionProgress { get; set; }

	}

}

