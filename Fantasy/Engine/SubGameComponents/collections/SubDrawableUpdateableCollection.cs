﻿using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
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
		public bool IsVisible { get => this.isVisible; set => this.isVisible = value; }
		/// <summary>
		/// Gets a value indicating whether this <c>DrawableGameComponent</c> is animated or not.
		/// </summary>
		public bool IsAnimated { get => this.isAnimated; protected set => this.isAnimated = value; }
		/// <summary>
		/// Gets or sets a value indicating whether to use a combined texture for all elements in the <c>ISubDrawableCollection</c>.
		/// </summary>
		public bool UseCombinedTexture { get => this.useCombinedTexture; set => this.useCombinedTexture = value; }
		/// <summary>
		/// Gets or sets a value indicating if this <c>ISubUpdateableCollection</c> is being updated or not. 
		/// </summary>
		public bool IsActive { get => this.isActive; set => this.isActive = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be drawn with in its <c>ISubDrawableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for invisible subcomponent.
		/// </summary>
		public byte DrawOrder { get => this.drawOrder; set => this.drawOrder = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte UpdateOrder { get => this.updateOrder; set => this.updateOrder = value; }
		/// <summary>
		/// Gets the combined texture used for all elements in the <c>ISubDrawableCollection</c>.
		/// </summary>
		public Texture2D CombinedTexture { get => this.combinedTexture; protected set => this.combinedTexture = value; }
		/// <summary>
		/// Gets the dictionary <c>ISubDrawable</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public Dictionary<byte, List<ISubDrawable>> SubDrawables { get => this.subDrawables; protected set => this.subDrawables = value; }
		/// <summary>
		/// Gets the dictionary <c>Animation</c> lists in the <c>ISubDrawableCollection</c> which are of type <c>Animation</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public Dictionary<byte, List<Animation>> AnimatedSubDrawables { get => this.animatedSubDrawables; protected set => this.animatedSubDrawables = value; }
		/// <summary>
		/// Gets the dictionary <c>Animation</c> lists in the <c>ISubDrawableCollection</c> which are not of type <c>Animation</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public Dictionary<byte, List<ISubDrawable>> StaticSubDrawables { get => this.staticSubDrawables; protected set => this.staticSubDrawables = value; }
		/// <summary>
		/// Gets the dictionary <c>ISubUpdateable</c> lists in the <c>ISubUpdateableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher update priority.
		/// 0 priority keys are reserved for inactive subcomponent.
		/// </summary>
		public Dictionary<byte, List<ISubUpdateable>> SubUpdateables { get => this.subUpdateables; protected set => this.subUpdateables = value; }

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
		/// Draws the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public abstract void Draw(GameTime gameTime, Color? color = null);
	}
}
