using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.interfaces.collections
{
    /// <summary>
    /// Represents of collection of drawable subcomponents that can be used inside a <c>DrawableGameComponent</c>. 
    /// </summary>
    public interface ISubDrawableCollection
    {
		/// <summary>
		/// Gets or sets a value indicating whether this <c>DrawableGameComponent</c> is visible or not.
		/// </summary>
		bool IsVisible { get; set; }

		/// <summary>
		/// Gets a value indicating whether this <c>DrawableGameComponent</c> is animated or not.
		/// </summary>
		bool IsAnimated { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to use a combined texture for all elements in the <c>ISubDrawableCollection</c>.
        /// </summary>
        bool UseCombinedTexture { get; set; }

        /// <summary>
        /// Gets the combined texture used for all elements in the <c>ISubDrawableCollection</c>.
        /// </summary>
        Texture2D CombinedTexture { get; }

		/// <summary>
		/// Gets the dictionary <c>ISubDrawable</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		Dictionary<byte, List<ISubDrawable>> SubDrawables { get; }

		/// <summary>
		/// Gets the dictionary <c>Animation</c> lists in the <c>ISubDrawableCollection</c> which are of type <c>Animation</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		Dictionary<byte, List<Animation>> AnimatedSubDrawables { get; }

		/// <summary>
		/// Gets the dictionary <c>Animation</c> lists in the <c>ISubDrawableCollection</c> which are not of type <c>Animation</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		Dictionary<byte, List<ISubDrawable>> StaticSubDrawables { get; }

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
