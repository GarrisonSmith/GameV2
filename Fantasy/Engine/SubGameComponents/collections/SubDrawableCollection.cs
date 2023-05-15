using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	/// <summary>
	/// Represents of collection of <c>ISubDrawableComponents</c> that can be used inside a <c>DrawableGameComponent</c>. 
	/// </summary>
	public abstract class SubDrawableCollection : SubComponentCollection, ISubDrawableCollection
	{
		protected bool isVisible;
		protected byte drawOrder;
		protected List<ISubDrawableCollection> subDrawableCollections;
		protected SortedDictionary<byte, List<ISubDrawableComponent>> subDrawables;

		/// <summary>
		/// Gets or sets a value indicating whether this <c>DrawableGameComponent</c> is visible or not.
		/// </summary>
		public bool IsVisible { get => this.isVisible; set => this.isVisible = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be drawn with in its <c>ISubDrawableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for invisible subcomponent.
		/// </summary>
		public byte DrawOrder { get => this.drawOrder; set => this.drawOrder = value; }
		/// <summary>
		/// Gets the dictionary <c>ISubDrawableComponent</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public SortedDictionary<byte, List<ISubDrawableComponent>> SubDrawables { get => this.subDrawables; protected set => this.subDrawables = value; }

		/// <summary>
		/// Creates a new <c>SubDrawableCollection</c>.
		/// </summary>
		public SubDrawableCollection()
		{
			this.isVisible = true;
			this.DrawOrder = 1;
		}
		/// <summary>
		/// Creates a new <c>SubDrawableCollection</c> with the provided parameters.
		/// </summary>
		/// <param name="isVisible">A value indicating whether this <c>SubDrawableCollection</c> is visible or not.</param>
		/// <param name="drawOrder">The draw order.</param>
		public SubDrawableCollection(bool isVisible, byte drawOrder)
		{
			this.IsVisible = isVisible;
			this.DrawOrder = drawOrder;
		}

		/// <summary>
		/// Adds a ISubComponent to the <c>SubDrawableCollection</c>.
		/// </summary>
		/// <param name="subComponent">The ISubComponent.</param>
		public override void AddSubComponent(ISubComponent subComponent)
		{
			if (this.subComponents.Contains(subComponent))
			{
				return;
			}

			this.subComponents.Add(subComponent);
			if (subComponent is ISubDrawableComponent subDrawableComponent)
			{
				if (this.SubDrawables.TryGetValue(subDrawableComponent.DrawOrder, out List<ISubDrawableComponent> subDrawableComponentList))
				{
					subDrawableComponentList.Add(subDrawableComponent);
				}
				else
				{
					this.SubDrawables.Add(subDrawableComponent.DrawOrder, new List<ISubDrawableComponent>() { subDrawableComponent });
				}
			}
		}

		/// <summary>
		/// Initializes the <c>ISubDrawableCollection</c>.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			this.SubDrawables = new SortedDictionary<byte, List<ISubDrawableComponent>>();
		}

		/// <summary>
		/// Draws the <c>SubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public virtual void Draw(GameTime gameTime, Color? color = null)
		{
			foreach (List<ISubDrawableComponent> subDrawableComponentList in this.SubDrawables.Values)
			{
				foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
				{
					subDrawableComponent.Draw(gameTime, color);
				}
			}
		}
		/// <summary>
		/// Draws the <c>SubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public virtual void Draw(IPosition offset, GameTime gameTime, Color? color = null)
		{
			foreach (List<ISubDrawableComponent> subDrawableComponentList in this.SubDrawables.Values)
			{
				foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
				{
					subDrawableComponent.Draw(offset, gameTime, color);
				}
			}
		}
	}
}
