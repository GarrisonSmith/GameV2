using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
    /// <summary>
    /// Represents of collection of updateable subcomponents that can be used inside a <c>GameComponent</c>. 
    /// </summary>
    public abstract class SubUpdateableCollection : SubComponentCollection, ISubUpdateableCollection, ISubUpdateable
	{
		protected bool isActive;
		protected byte updateOrder;
		protected Dictionary<byte, List<ISubUpdateable>> subUpdateables;

		/// <summary>
		/// Gets or sets a value indicating if this <c>ISubUpdateableCollection</c> is being updated or not. 
		/// </summary>
		public bool IsActive { get => this.isActive; set => this.isActive = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte UpdateOrder { get => this.updateOrder; set => this.updateOrder = value; }
		/// <summary>
		/// Gets the dictionary <c>ISubUpdateable</c> lists in the <c>ISubUpdateableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher update priority.
		/// 0 priority keys are reserved for inactive subcomponent.
		/// </summary>
		public Dictionary<byte, List<ISubUpdateable>> SubUpdateables { get => this.subUpdateables; protected set => this.subUpdateables = value; }

		/// <summary>
		/// Updates the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public abstract void Update(GameTime gameTime);
	}
}
