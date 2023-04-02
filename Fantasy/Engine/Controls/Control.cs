using Fantasy.Engine.Controls.enums;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net;

namespace Fantasy.Engine.Controls
{
	public struct Control
	{
		private bool justBegan;
		private bool isHeld;
		private TimeSpan heldDuration;
		private readonly ControlActionTypes controlActionType;
		private readonly Keys key;

		/// <summary>
		/// The Control Action Type this Control is bound to.
		/// </summary>
		public ControlActionTypes ControlActionType { get => controlActionType; }
		/// <summary>
		/// The Key this Control is bound to. 
		/// </summary>
		public Keys Key { get => key; }

		/// <summary>
		/// Creates a new Control.
		/// </summary>
		/// <param name="controlActionType">The control action type of this control.</param>
		/// <param name="key">The key of this control.</param>
		public Control(ControlActionTypes controlActionType, Keys key) 
		{
			this.justBegan = false;
			this.isHeld = false;
			heldDuration = TimeSpan.Zero;
			this.controlActionType = controlActionType;
			this.key = key;
		}
	}
}
