
using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.components
{
    /// <summary>
    /// Represents a subcomponent that can drawn inside a <c>ISubDrawableCollection</c>.
    /// </summary>
    public abstract class SubDrawableComponent : SubComponent, ISubDrawable, ISubDrawableComponent
	{
		protected bool isVisible;
		protected bool isAnimated;
		protected byte drawOrder;
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
		/// Describes the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte DrawOrder { get => this.drawOrder; set => this.drawOrder = value; }
		/// <summary>
		/// Gets the defined drawable for this subcomponent.
		/// </summary>
		public IDefinedDrawable DefinedDrawable { get => this.definedDrawable; protected set => this.definedDrawable = value; }

		/// <summary>
		/// Creates a new <c>SubDrawableComponent</c> with the provided parameters.
		/// </summary>
		/// <param name="isVisible">A value indicating whether this subcomponent is visible or not.</param>
		/// <param name="drawOrder">The draw order.</param>
		/// <param name="definedDrawable">The defined drawable.</param>
		public SubDrawableComponent(bool isVisible, byte drawOrder, IDefinedDrawable definedDrawable) 
		{
			this.IsVisible = isVisible;
			this.DrawOrder = drawOrder;
			this.DefinedDrawable = definedDrawable;
		}

		/// <summary>
		/// Draws the subcomponent using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public abstract void Draw(GameTime gameTime, Color? color = null);
	}
}
