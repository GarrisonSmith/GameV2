using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.SubGameComponents.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fantasy.Engine.Drawing
{
	public abstract class DefinedDrawable : SubDrawable, IDefinedDrawable
	{
		protected Point textureSourceTopLeft;
		protected Rectangle textureSourceTopRight;
		protected Texture2D spritesheet;

		/// <summary>
		/// Gets the top left point of this item's starting texture on its spritesheet.
		/// </summary>
		public Point TextureSourceTopLeft { get => textureSourceTopLeft; }
		/// <summary>
		/// Gets the area of the spritesheet from which the item's texture is taken.
		/// </summary>
		public Rectangle SheetBox { get => textureSourceTopRight; }
		/// <summary>
		/// Gets the spritesheet that the item's texture is taken from.
		/// </summary>
		public Texture2D Spritesheet { get => spritesheet; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="drawOrder"></param>
		/// <param name="isVisible"></param>
		public DefinedDrawable(byte drawOrder, bool isVisible = true) 
		{
			this.DrawOrder = drawOrder;
			this.isVisible = isVisible;
			this.isAnimated = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <exception cref="System.NotImplementedException"></exception>
		public override void Initialize()
		{
			throw new System.NotImplementedException();
		}
		/// <summary>
		/// Draws the item using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public override void Draw(GameTime gameTime)
		{
			SpriteBatchHandler.Draw()
		}
	}
}
