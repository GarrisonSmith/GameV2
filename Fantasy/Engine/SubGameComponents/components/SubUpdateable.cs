using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.components
{
	public class SubUpdateable : SubComponent, ISubUpdateable
	{
		public bool IsActive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public byte UpdatePriority { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public void Update(GameTime gameTime)
		{
			throw new System.NotImplementedException();
		}
	}
}
