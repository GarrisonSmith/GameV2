using Fantasy.Engine.Drawing;
using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.interfaces.components
{
	/// <summary>
	/// Represents a component that can be drawn.
	/// </summary>
	public interface ISubDrawableComponent : ISubComponent
	{
		/// <summary>
		/// Gets or sets a value indicating whether this subcomponent is visible or not.
		/// </summary>
		bool IsVisible { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be drawn with in its <c>ISubDrawableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for invisible subcomponent.
		/// </summary>
		byte DrawOrder { get; set; }

		/// <summary>
		/// Draws the <c>ISubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		void Draw(GameTime gameTime, Color? color = null);

		/// <summary>
		/// Draws the <c>ISubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset to draw with.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public void Draw(IPosition offset, GameTime gameTime, Color? color = null);
	}
}
