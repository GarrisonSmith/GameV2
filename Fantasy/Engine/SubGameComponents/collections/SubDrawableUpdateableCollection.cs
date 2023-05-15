using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	/// <summary>
	/// Represents of collection of <c>ISubDrawableUpdateableComponents</c> that can be used inside a <c>DrawableGameComponent</c>. 
	/// </summary>
	public abstract class SubDrawableUpdateableCollection : SubComponentCollection, ISubDrawableUpdateableCollection
	{
		protected bool isVisible;
		protected bool isActive;
		protected byte drawOrder;
		protected byte updateOrder;
		protected SortedDictionary<byte, List<ISubDrawableComponent>> subDrawables;
		protected SortedDictionary<byte, List<ISubUpdateableComponent>> subUpdateables;

		/// <summary>
		/// Gets or sets a value indicating whether this <c>DrawableGameComponent</c> is visible or not.
		/// </summary>
		public bool IsVisible { get => this.isVisible; set => this.isVisible = value; }
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
		/// Gets the dictionary <c>ISubDrawableComponent</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public SortedDictionary<byte, List<ISubDrawableComponent>> SubDrawables { get => this.subDrawables; protected set => this.subDrawables = value; }
		/// <summary>
		/// Gets the dictionary <c>ISubUpdateableComponent</c> lists in the <c>ISubUpdateableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher update priority.
		/// 0 priority keys are reserved for inactive subcomponent.
		/// </summary>
		public SortedDictionary<byte, List<ISubUpdateableComponent>> SubUpdateables { get => this.subUpdateables; protected set => this.subUpdateables = value; }

		/// <summary>
		/// Creates a new <c>SubDrawableUpdateableCollection</c>.
		/// </summary>
		public SubDrawableUpdateableCollection()
		{
			this.isVisible = true;
			this.isActive = true;
			this.drawOrder = 1;
			this.updateOrder = 1;
		}
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
		/// Adds a ISubComponent to the <c>SubDrawableUpdateableCollection</c>.
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

			if (subComponent is ISubUpdateableComponent subUpdateableComponent)
			{
				if (this.SubUpdateables.TryGetValue(subUpdateableComponent.UpdateOrder, out List<ISubUpdateableComponent> subUpdateableComponentList))
				{
					subUpdateableComponentList.Add(subUpdateableComponent);
				}
				else
				{
					this.SubUpdateables.Add(subUpdateableComponent.UpdateOrder, new List<ISubUpdateableComponent>() { subUpdateableComponent });
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
			this.SubUpdateables = new SortedDictionary<byte, List<ISubUpdateableComponent>>();
		}
		/// <summary>
		/// Updates the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public virtual void Update(GameTime gameTime)
		{
			foreach (List<ISubUpdateableComponent> subUpdateableComponentList in SubUpdateables.Values)
			{
				foreach (ISubUpdateableComponent subUpdateableComponent in subUpdateableComponentList)
				{
					subUpdateableComponent.Update(gameTime);
				}
			}
		}

		/// <summary>
		/// Draws the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
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
		/// Draws the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
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
