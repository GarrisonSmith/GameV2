using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	/// <summary>
	/// Represents of collection of <c>ISubUpdateableComponents</c> that can be used inside a <c>GameComponent</c>. 
	/// </summary>
	public abstract class SubUpdateableCollection : SubComponentCollection, ISubUpdateableCollection
	{
		protected bool isActive;
		protected byte updateOrder;
		protected SortedDictionary<byte, List<ISubUpdateableComponent>> subUpdateables;

		/// <summary>
		/// Gets or sets a value indicating if this <c>ISubUpdateableCollection</c> is being updated or not. 
		/// </summary>
		public bool IsActive { get => this.isActive; set => this.isActive = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte UpdateOrder { get => this.updateOrder; set => this.updateOrder = value; }
		/// <summary>
		/// Gets the dictionary <c>ISubUpdateableComponent</c> lists in the <c>ISubUpdateableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher update priority.
		/// 0 priority keys are reserved for inactive subcomponent.
		/// </summary>
		public SortedDictionary<byte, List<ISubUpdateableComponent>> SubUpdateables { get => this.subUpdateables; protected set => this.subUpdateables = value; }

		/// <summary>
		/// Creates a new <c>SubUpdateableCollection</c>.
		/// </summary>
		public SubUpdateableCollection() 
		{
			this.IsActive = true;
			this.UpdateOrder = 1;
		}
		/// <summary>
		/// Creates a new <c>SubUpdateableCollection</c> with the provided parameters.
		/// </summary>
		/// <param name="isActive">A value indicating if this <c>ISubUpdateableCollection</c> is being updated or not.</param>
		/// <param name="updateOrder">The update order.</param>
		public SubUpdateableCollection(bool isActive, byte updateOrder)
		{ 
			this.IsActive = isActive;
			this.UpdateOrder = updateOrder;
		}

		/// <summary>
		/// Adds a ISubComponent to the <c>SubUpdateableCollection</c>.
		/// </summary>
		/// <param name="subComponent">The ISubComponent.</param>
		public override void AddSubComponent(ISubComponent subComponent)
		{
			if (this.subComponents.Contains(subComponent))
			{
				return;
			}

			this.subComponents.Add(subComponent);
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
		/// Initializes the <c>SubUpdateableCollection</c>.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
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
	}
}
