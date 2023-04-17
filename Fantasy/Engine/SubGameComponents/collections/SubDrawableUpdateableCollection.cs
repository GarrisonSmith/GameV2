using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	/// <summary>
	/// Represents of collection of drawable and updateable subcomponents that can be used inside a <c>DrawableGameComponent</c>. 
	/// </summary>
	public abstract class SubDrawableUpdateableCollection : SubComponentCollection, ISubDrawableCollection, ISubUpdateableCollection, ISubDrawable, ISubUpdateable
	{
		protected bool isVisible;
		protected bool isAnimated;
		protected bool useCombinedTexture;
		protected bool isActive;
		protected byte drawOrder;
		protected byte updateOrder;
		protected Texture2D combinedTexture;
		protected Dictionary<byte, List<ISubDrawable>> subDrawables;
		protected Dictionary<byte, List<Animation>> animatedSubDrawables;
		protected Dictionary<byte, List<ISubDrawable>> staticSubDrawables;
		protected Dictionary<byte, List<ISubUpdateable>> subUpdateables;

		/// <summary>
		/// Gets or sets a value indicating whether this <c>DrawableGameComponent</c> is visible or not.
		/// </summary>
		public bool IsVisible { get => isVisible; set => isVisible = value; }
		/// <summary>
		/// Gets a value indicating whether this <c>DrawableGameComponent</c> is animated or not.
		/// </summary>
		public bool IsAnimated { get => isAnimated; }
		/// <summary>
		/// Gets or sets a value indicating whether to use a combined texture for all elements in the <c>ISubDrawableCollection</c>.
		/// </summary>
		public bool UseCombinedTexture { get => useCombinedTexture; set => useCombinedTexture = value; }
		/// <summary>
		/// Gets or sets a value indicating if this <c>ISubUpdateableCollection</c> is being updated or not. 
		/// </summary>
		public bool IsActive { get => isActive; set => isActive = value; }
		/// <summary>
		/// Describes the priority this subcomponent will be drawn with in its <c>ISubDrawableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for invisible subcomponent.
		/// </summary>
		public byte DrawOrder { get => drawOrder; set => drawOrder = value; }
		/// <summary>
		/// Describes the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte UpdateOrder { get => updateOrder; set => updateOrder = value; }
		/// <summary>
		/// Gets the combined texture used for all elements in the <c>ISubDrawableCollection</c>.
		/// </summary>
		public Texture2D CombinedTexture { get => combinedTexture; }
		/// <summary>
		/// Gets the dictionary <c>ISubDrawable</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public Dictionary<byte, List<ISubDrawable>> SubDrawables { get => subDrawables; }
		/// <summary>
		/// Gets the dictionary <c>Animation</c> lists in the <c>ISubDrawableCollection</c> which are of type <c>Animation</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public Dictionary<byte, List<Animation>> AnimatedSubDrawables { get => animatedSubDrawables; }
		/// <summary>
		/// Gets the dictionary <c>Animation</c> lists in the <c>ISubDrawableCollection</c> which are not of type <c>Animation</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public Dictionary<byte, List<ISubDrawable>> StaticSubDrawables { get => staticSubDrawables; }
		/// <summary>
		/// Gets the dictionary <c>ISubUpdateable</c> lists in the <c>ISubUpdateableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher update priority.
		/// 0 priority keys are reserved for inactive subcomponent.
		/// </summary>
		public Dictionary<byte, List<ISubUpdateable>> SubUpdateables { get => subUpdateables; }

		/// <summary>
		/// Creates the combined texture for the entire <c>ISubDrawableCollection</c>.
		/// </summary>
		public abstract void CreateCombinedTexture();
		/// <summary>
		/// Updates the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public abstract void Update(GameTime gameTime);
		/// <summary>
		/// Draws the <c>ISubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public abstract void Draw(GameTime gameTime);
	}
}
