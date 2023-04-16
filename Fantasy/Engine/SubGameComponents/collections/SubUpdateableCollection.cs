using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	public class SubUpdateableCollection : ISubUpdateableCollection, ISubUpdateable
	{
		public bool IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Dictionary<byte, List<ISubUpdateable>> SubUpdateables => throw new NotImplementedException();

		public byte UpdateOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
		}
	}
}
