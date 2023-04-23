using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.components
{
    public abstract class SubDrawableUpdateable : SubComponent, ISubDrawable, ISubUpdateable, ISubDrawableComponent, ISubUpdateableComponent
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
		public bool IsAnimated { get => this.isAnimated; }
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
		public IDefinedDrawable DefinedDrawable { get => this.definedDrawable; }

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
	}
}
