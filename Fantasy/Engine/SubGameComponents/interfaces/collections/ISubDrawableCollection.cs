using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.interfaces.collections
{
    /// <summary>
    /// Represents of collection of drawable subcomponents that can be used inside a <c>DrawableGameComponent</c>. 
    /// </summary>
    public interface ISubDrawableCollection : ISubComponentCollection, ISubDrawableComponent
    {
		/// <summary>
		/// Gets or sets a value indicating whether this <c>DrawableGameComponent</c> is visible or not.
		/// </summary>
		new bool IsVisible { get; set; }

		/// <summary>
		/// Gets the dictionary <c>ISubDrawableComponent</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		SortedDictionary<byte, List<ISubDrawableComponent>> SubDrawables { get; }

		/// <summary>
		/// Adds a ISubComponent to the <c>ISubDrawableCollection</c>;
		/// </summary>
		/// <param name="subComponents">The ISubComponent.</param>
		new void AddSubComponent(ISubComponent subComponents);

		/// <summary>
		/// Draws the <c>ISubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		new void Draw(GameTime gameTime, Color? color = null);

		/// <summary>
		/// Draws the <c>ISubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset to draw with.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		new void Draw(IPosition offset, GameTime gameTime, Color? color = null);
	}
}
