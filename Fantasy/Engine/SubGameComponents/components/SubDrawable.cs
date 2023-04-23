
using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.components
{
    /// <summary>
    /// Represents a subcomponent that can drawn inside a <c>ISubDrawableCollection</c>.
    /// </summary>
    public abstract class SubDrawable : SubComponent, ISubDrawable, ISubDrawableComponent
	{
		protected bool isVisible;
		protected bool isAnimated;
		protected byte drawOrder;
		protected IDefinedDrawable definedDrawable;

		/// <summary>
		/// Gets or sets a value indicating whether this subcomponent is visible or not.
		/// </summary>
		public bool IsVisible { get => isVisible; set => isVisible = value; }
		/// <summary>
		/// Gets a value indicating whether this subcomponent is animated or not.
		/// </summary>
		public bool IsAnimated { get => isAnimated; }
		/// <summary>
		/// Describes the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte DrawOrder { get => drawOrder; set => drawOrder = value; }
		/// <summary>
		/// Gets the defined drawable for this subcomponent.
		/// </summary>
		public IDefinedDrawable DefinedDrawable { get => definedDrawable; }

		/// <summary>
		/// Draws the subcomponent using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public abstract void Draw(GameTime gameTime, Color? color = null);
	}
}
