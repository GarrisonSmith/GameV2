﻿using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	/// <summary>
	/// Represents of collection of <c>ISubComponents</c> that can be used inside a <c>GameComponent</c>. 
	/// </summary>
	public abstract class SubComponentCollection : ISubComponentCollection
	{
		protected List<ISubComponent> subComponents;

		/// <summary>
		/// Gets the list of type <c>ISubComponent</c>.
		/// </summary>
		public List<ISubComponent> SubComponents { get => this.subComponents; protected set => this.subComponents = value; }

		/// <summary>
		/// Creates a new <c>SubComponentCollection</c>.
		/// </summary>
		public SubComponentCollection() { }

		/// <summary>
		/// Adds a ISubComponent to the <c>SubComponentCollection</c>.
		/// </summary>
		/// <param name="subComponent">The ISubComponent.</param>
		public virtual void AddSubComponent(ISubComponent subComponent)
		{
			if (this.subComponents.Contains(subComponent))
			{
				return;
			}

			this.subComponents.Add(subComponent);
		}

		/// <summary>
		/// Initializes the <c>ISubComponentCollection</c>.
		/// </summary>
		public virtual void Initialize()
		{
			this.SubComponents = new List<ISubComponent>();
		}
	}
}
