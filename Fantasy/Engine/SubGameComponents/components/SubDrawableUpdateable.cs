using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fantasy.Engine.SubGameComponents.components
{
	public class SubDrawableUpdateable : SubComponent, ISubDrawable, ISubUpdateable
	{
		protected bool isActive;
		protected bool isVisible;
		protected bool isAnimated;
		protected byte drawOrder;
		protected byte updateOrder;

		/// <summary>
		/// Gets or sets a value indicating whether this subcomponent is visible or not.
		/// </summary>
		public bool IsVisible { get => isVisible; set => isVisible = value; }
		/// <summary>
		/// Gets a value indicating whether this subcomponent is animated or not.
		/// </summary>
		public bool IsAnimated { get => isAnimated; }
		/// <summary>
		/// Gets or sets a value indicating if this subcomponent is being updated or not. 
		/// Inactive subcomponent are defined as those with a <cref>UpdateOrder</cref> of 0.
		/// </summary>
		public bool IsActive { get => isActive; set => isActive = value; }
		/// <summary>
		/// Describes the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte DrawOrder { get => drawOrder; set => drawOrder = value; }
		/// <summary>
		/// Describes the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for inactive subcomponent.
		/// </summary>
		public byte UpdateOrder { get => updateOrder; set => updateOrder = value; }

		/// <summary>
		/// Initializes the subcomponent.
		/// </summary>
		public override void Initialize()
		{

		}
		/// <summary>
		/// Updates the subcomponent using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public void Update(GameTime gameTime)
		{

		}
		/// <summary>
		/// Draws the subcomponent using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public void Draw(GameTime gameTime)
		{

		}
	}
}
