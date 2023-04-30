using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	/// <summary>
	/// Represents of collection of <c>ISubUpdateableComponents</c> that can be used inside a <c>GameComponent</c>. 
	/// </summary>
	public abstract class SubUpdateableCollection : SubComponentCollection, ISubUpdateableCollection, ISubUpdateable
	{
		protected bool isActive;
		protected byte updateOrder;
		protected SortedDictionary<byte, List<ISubUpdateable>> subUpdateables;

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
		public SortedDictionary<byte, List<ISubUpdateable>> SubUpdateables { get => this.subUpdateables; protected set => this.subUpdateables = value; }

		/// <summary>
		/// Creates a new <c>SubUpdateableCollection</c> with the provided parameters.
		/// </summary>
		/// <param name="isActive">A value indicating if this <c>ISubUpdateableCollection</c> is being updated or not.</param>
		/// <param name="updateOrder">The update order.</param>
		public SubUpdateableCollection(bool isActive, byte updateOrder)
		{ 
			this.IsActive = isActive;
			this.UpdateOrder = updateOrder;
		}

		/// <summary>
		/// Initializes the <c>SubUpdateableCollection</c>.
		/// </summary>
		public new void Initialize()
		{
			base.Initialize();
			this.SubUpdateables = new SortedDictionary<byte, List<ISubUpdateable>>();
		}
		/// <summary>
		/// Updates the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public abstract void Update(GameTime gameTime);
	}
}
