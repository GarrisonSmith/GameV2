using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	public class SubDrawableCollection<T> : ISubDrawableCollection<T>
	{
		public bool IsVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool ContainsAnimations => throw new NotImplementedException();

		public bool UseCombinedTexture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Texture2D CombinedTexture => throw new NotImplementedException();

		public Dictionary<T, ISubDrawable> SubDrawables => throw new NotImplementedException();

		public Dictionary<T, Animation> AnimatedSubDrawables => throw new NotImplementedException();

		public Dictionary<T, ISubDrawable> StaticSubDrawables => throw new NotImplementedException();

		public void CreateCombinedTexture()
		{
			throw new NotImplementedException();
		}

		public void Draw(GameTime gameTime)
		{
			throw new NotImplementedException();
		}
	}
}
