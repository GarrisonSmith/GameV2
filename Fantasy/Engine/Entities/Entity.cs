using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.components;

namespace Fantasy.Engine.Entities
{
	public abstract class Entity : SubDrawableUpdateableComponent, IPositional<Position>
	{
		protected Position position;

		/// <summary>
		/// Gets the position.
		/// </summary>
		public Position Position { get => this.position; }
	}
}
