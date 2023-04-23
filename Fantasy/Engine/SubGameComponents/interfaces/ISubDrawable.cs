using Fantasy.Engine.Drawing;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.interfaces
{
    /// <summary>
    /// Represents a subcomponent that can be drawn inside a <c>ISubDrawableCollection</c>.
    /// </summary>
    public interface ISubDrawable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this subcomponent is visible or not.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Gets a value indicating whether this subcomponent is animated or not.
        /// </summary>
        bool IsAnimated { get; }

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
    }
}
