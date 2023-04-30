using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	/// <summary>
	/// Represents of collection of <c>ISubDrawableUpdateableComponents</c> that can be used inside a <c>DrawableGameComponent</c>. 
	/// </summary>
	public abstract class SubDrawableUpdateableCollection : SubComponentCollection, ISubDrawableCollection, ISubUpdateableCollection, ISubDrawable, ISubUpdateable
	{
		protected bool isVisible;
		protected bool useCombinedTexture;
		protected bool isActive;
		protected byte drawOrder;
		protected byte updateOrder;
		protected Texture2D combinedTexture;
		protected SortedDictionary<byte, List<ISubDrawable>> subDrawables;
		protected SortedDictionary<byte, List<ISubUpdateable>> subUpdateables;

		/// <summary>
		/// Gets or sets a value indicating whether this <c>DrawableGameComponent</c> is visible or not.
		/// </summary>
		public bool IsVisible { get => this.isVisible; set => this.isVisible = value; }
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
		public SortedDictionary<byte, List<ISubDrawable>> SubDrawables { get => this.subDrawables; protected set => this.subDrawables = value; }
		/// <summary>
		/// Gets the dictionary <c>ISubUpdateable</c> lists in the <c>ISubUpdateableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher update priority.
		/// 0 priority keys are reserved for inactive subcomponent.
		/// </summary>
		public SortedDictionary<byte, List<ISubUpdateable>> SubUpdateables { get => this.subUpdateables; protected set => this.subUpdateables = value; }

		/// <summary>
		/// Creates a new <c>SubDrawableUpdateableCollection</c> with the provided parameters.
		/// </summary>
		/// <param name="isVisible">A value indicating whether this <c>SubDrawableUpdateableCollection</c> is visible or not.</param>
		/// <param name="isActive">A value indicating if this <c>ISubUpdateableCollection</c> is being updated or not.</param>
		/// <param name="drawOrder">The draw order.</param>
		/// <param name="updateOrder">The update order.</param>
		public SubDrawableUpdateableCollection(bool isVisible, bool isActive, byte drawOrder, byte updateOrder)
		{
			this.IsVisible = isVisible;
			this.IsActive = isActive;
			this.DrawOrder = drawOrder;
			this.UpdateOrder = updateOrder;
		}

		/// <summary>
		/// Creates the combined texture for the entire <c>SubDrawableUpdateableCollection</c>.
		/// </summary>
		public abstract void CreateCombinedTexture();
		/// <summary>
		/// Initializes the <c>ISubDrawableCollection</c>.
		/// </summary>
		public new void Initialize()
		{
			base.Initialize();
			this.SubDrawables = new SortedDictionary<byte, List<ISubDrawable>>();
			this.SubUpdateables = new SortedDictionary<byte, List<ISubUpdateable>>();
		}
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
