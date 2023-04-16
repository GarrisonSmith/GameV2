using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.Mapping;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.interfaces.collections
{
    /// <summary>
    /// Represents of collection of drawable subcomponents that can be used inside a <c>DrawableGameComponent</c>. 
    /// </summary>
    /// <typeparam name="T">The type of keys used to identify the subcomponents in the <c>ISubDrawableCollection</c>.</typeparam>
    public interface ISubDrawableCollection<T>
    {
        /// <summary>
        /// Gets a value indicating whether this <c>ISubDrawableCollection</c> is visible or not.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <c>ISubDrawableCollection</c> contains animations or not.
        /// </summary>
        bool ContainsAnimations { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to use a combined texture for all elements in the <c>ISubDrawableCollection</c>.
        /// </summary>
        bool UseCombinedTexture { get; set; }

        /// <summary>
        /// Gets the combined texture used for all elements in the <c>ISubDrawableCollection</c>.
        /// </summary>
        Texture2D CombinedTexture { get; }

        /// <summary>
        /// Gets the dictionary of type <c>ISubDrawable</c> in the <c>ISubDrawableCollection</c>, identified by keys of type <c>T</c>.
        /// </summary>
        Dictionary<T, ISubDrawable> SubDrawables { get; }

        /// <summary>
        /// Gets the dictionary of type <c>Animation</c> in the <c>ISubDrawableCollection</c>, identified by keys of type <c>T</c>.
        /// </summary>
        Dictionary<T, Animation> AnimatedSubDrawables { get; }

        /// <summary>
        /// Gets the dictionary of type <c>ISubDrawable</c> in the <c>ISubDrawableCollection</c>, identified by keys of type <c>T</c> that are static drawings.
        /// </summary>
        Dictionary<T, ISubDrawable> StaticSubDrawables { get; }

        /// <summary>
        /// Creates the combined texture for the entire <c>ISubDrawableCollection</c>.
        /// </summary>
        void CreateCombinedTexture();

        /// <summary>
        /// Draws the <c>ISubDrawableCollection</c> using the specified <c>GameTime</c>.
        /// </summary>
        /// <param name="gameTime">The elapsed game time since the last update.</param>
        void Draw(GameTime gameTime);
    }
}
