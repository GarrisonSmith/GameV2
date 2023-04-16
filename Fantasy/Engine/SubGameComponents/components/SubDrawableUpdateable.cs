using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Engine.SubGameComponents.components
{
	public class SubDrawableUpdateable : SubComponent, ISubDrawable, ISubUpdateable
	{
		public bool IsVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool IsAnimated => throw new NotImplementedException();

		public Point TextureSourceTopLeft => throw new NotImplementedException();

		public Rectangle SheetBox => throw new NotImplementedException();

		public Texture2D Spritesheet => throw new NotImplementedException();

		public bool IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public byte UpdatePriority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void Draw(GameTime gameTime, int layer)
		{
			throw new NotImplementedException();
		}

		public void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
		}
	}
}
