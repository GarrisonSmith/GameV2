using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.components
{
	/// <summary>
	/// Represents of collection of drawable and updateable subcomponents that can be used inside a <c>GameComponent</c>. 
	/// </summary>
	public abstract class SubDrawableUpdateableComponent : SubComponent, ISubDrawable, ISubUpdateable, ISubDrawableUpdateableComponent
	{
		protected bool isActive;
		protected bool isVisible;
		protected bool isAnimated;
		protected byte drawOrder;
		protected byte updateOrder;
		protected IDefinedDrawable definedDrawable;

		/// <summary>
		/// Gets or sets a value indicating whether this subcomponent is visible or not.
		/// </summary>
		public bool IsVisible { get => this.isVisible; set => this.isVisible = value; }
		/// <summary>
		/// Gets a value indicating whether this subcomponent is animated or not.
		/// </summary>
		public bool IsAnimated { get => this.isAnimated; protected set => this.isAnimated = value; }
		/// <summary>
		/// Gets or sets a value indicating if this subcomponent is being updated or not. 
		/// Inactive subcomponent are defined as those with a <cref>UpdateOrder</cref> of 0.
		/// </summary>
		public bool IsActive { get => this.isActive; set => this.isActive = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be drawn with in its <c>ISubDrawableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte DrawOrder { get => this.drawOrder; set => this.drawOrder = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte UpdateOrder { get => this.updateOrder; set => this.updateOrder = value; }
		/// <summary>
		/// Gets the defined drawable for this subcomponent.
		/// </summary>
		public IDefinedDrawable DefinedDrawable { get => this.definedDrawable; protected set => this.definedDrawable = value; }

		/// <summary>
		/// Creates a new <c>SubDrawableUpdateableComponent</c>.
		/// </summary>
		public SubDrawableUpdateableComponent() 
		{
			this.IsVisible = true;
			this.IsActive = true;
			this.DrawOrder = 1;
			this.UpdateOrder = 1;
		}
		/// <summary>
		/// Creates a new <c>SubDrawableUpdateableComponent</c> with the provided parameters.
		/// </summary>
		/// <param name="isVisible">A value indicating whether this subcomponent is visible or not.</param>
		/// <param name="isActive">A value indicating if this subcomponent is being updated or not. </param>
		/// <param name="drawOrder">The draw order.</param>
		/// <param name="updateOrder">The update order.</param>
		/// <param name="definedDrawable">The defined drawable.</param>
		public SubDrawableUpdateableComponent(bool isVisible, bool isActive, byte drawOrder, byte updateOrder, IDefinedDrawable definedDrawable)
		{
			this.IsVisible = isVisible;
			this.IsActive = isActive;
			this.DrawOrder = drawOrder;
			this.UpdateOrder = updateOrder;
			this.DefinedDrawable = definedDrawable;
		}

		/// <summary>
		/// Updates the subcomponent using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public abstract void Update(GameTime gameTime);
		/// <summary>
		/// Draws the subcomponent using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public abstract void Draw(GameTime gameTime, Color? color = null);
		/// <summary>
		/// Draws the subcomponent using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset to draw with.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public abstract void Draw(IPosition offset, GameTime gameTime, Color? color = null);
	}
}
