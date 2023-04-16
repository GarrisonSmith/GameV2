using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fantasy.Engine.SubGameComponents.interfaces.components
{
    /// <summary>
    /// Represents a subcomponent that can updated inside a <c>ISubDrawableCollection</c>.
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
        /// Gets the top left point of this subcomponent's starting texture on its spritesheet.
        /// </summary>
        Point TextureSourceTopLeft { get; }

        /// <summary>
        /// Gets the area of the spritesheet from which the subcomponent's texture is taken.
        /// </summary>
        Rectangle SheetBox { get; }

        /// <summary>
        /// Gets the spritesheet that the subcomponent's texture is taken from.
        /// </summary>
        Texture2D Spritesheet { get; }

        /// <summary>
        /// Draws the subcomponent using the specified <c>GameTime</c>.
        /// </summary>
        /// <param name="gameTime">The elapsed game time since the last update.</param>
        /// <param name="layer">The layer to be drawn to.</param>
        void Draw(GameTime gameTime, int layer);
    }
}
