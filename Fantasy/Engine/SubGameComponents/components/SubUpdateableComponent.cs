using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.components
{
    /// <summary>
    /// Represents a subcomponent that can updated inside a <c>ISubUpdateableCollection</c>
    /// </summary>
    public abstract class SubUpdateableComponent : SubComponent, ISubUpdateable, ISubUpdateableComponent
	{
		protected bool isActive;
		protected byte updateOrder;

		/// <summary>
		/// Gets or sets a value indicating if this subcomponent is being updated or not. 
		/// Inactive subcomponent are defined as those with a <cref>UpdateOrder</cref> of 0.
		/// </summary>
		public bool IsActive { get => this.isActive; set => this.isActive = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte UpdateOrder { get => this.updateOrder; set => this.updateOrder = value; }

		/// <summary>
		/// Creates a new <c>SubUpdateableComponent</c>.
		/// </summary>
		public SubUpdateableComponent()
		{
			this.IsActive = true;
			this.UpdateOrder = 1;
		}
		/// <summary>
		/// Creates a new <c>SubUpdateableComponent</c> with the provided parameters.
		/// </summary>
		/// <param name="isActive">A value indicating if this subcomponent is being updated or not. </param>
		/// <param name="updateOrder">The update order.</param>
		public SubUpdateableComponent(bool isActive, byte updateOrder)
		{
			this.IsActive = isActive;
			this.UpdateOrder = updateOrder;
		}

		/// <summary>
		/// Updates the subcomponent using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public abstract void Update(GameTime gameTime);
	}
}
