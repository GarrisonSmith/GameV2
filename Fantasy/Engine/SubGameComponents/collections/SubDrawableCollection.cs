using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	public class SubDrawableCollection : ISubDrawableCollection, ISubDrawable
	{
		public bool IsVisible { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public bool IsAnimated => throw new System.NotImplementedException();

		public bool ContainsAnimations => throw new System.NotImplementedException();

		public bool UseCombinedTexture { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public Texture2D CombinedTexture => throw new System.NotImplementedException();

		public Dictionary<byte, List<ISubDrawable>> SubDrawables => throw new System.NotImplementedException();

		public Dictionary<byte, List<Animation>> AnimatedSubDrawables => throw new System.NotImplementedException();

		public Dictionary<byte, List<ISubDrawable>> StaticSubDrawables => throw new System.NotImplementedException();

		public byte DrawOrder { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public void CreateCombinedTexture()
		{
			throw new System.NotImplementedException();
		}

		public void Draw(GameTime gameTime)
		{
			throw new System.NotImplementedException();
		}
	}
}
