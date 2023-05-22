using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Fantasy.Engine.SubGameComponents.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Fantasy.Engine.Drawing.interfaces;

namespace Fantasy.Engine.Drawing
{
	public readonly struct CombinedTexture : IPositional<Position>
	{
		private readonly Texture2D texture;
		private readonly Position position;

		/// <summary>
		/// Gets the bottom right position of this <c>CombinedTexture</c>.
		/// </summary>
		public Vector2 BottomRight { get => new Vector2(this.Position.X + this.Texture.Width, this.Position.Y + this.Texture.Height); }
		/// <summary>
		/// Gets the combined texture.
		/// </summary>
		public Texture2D Texture { get => this.texture; }
		/// <summary>
		/// Gets the position.
		/// </summary>
		public Position Position { get => this.position; }

		/// <summary>
		/// Creates a new <c>CombinedTexture</c> with the provided parameters.
		/// </summary>
		/// <param name="subject">The sub drawable collection.</param>
		public CombinedTexture(ICombineTextures subject)
		{
			float xMin = float.MaxValue, yMin = float.MaxValue, xMax = 0, yMax = 0;
			Vector2 bottomRight;
			foreach (List<ISubDrawableComponent> subDrawableComponentList in subject.SubDrawables.Values)
			{
				foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
				{
					if (subDrawableComponent is ISubDrawable subDrawable && !subDrawable.IsAnimated)
					{
						bottomRight = subDrawable.DefinedDrawable.BottomRight;

						if (subDrawable.DefinedDrawable.Position.X < xMin)
						{
							xMin = subDrawable.DefinedDrawable.Position.X;
						}

						if (bottomRight.X > xMax)
						{
							xMax = bottomRight.X;
						}

						if (subDrawable.DefinedDrawable.Position.Y < yMin)
						{
							yMin = subDrawable.DefinedDrawable.Position.Y;
						}

						if (bottomRight.Y > yMax)
						{
							yMax = bottomRight.Y;
						}
					}
					else
					{
						if (subject.ExcludedSubDrawableComponents.TryGetValue(subDrawableComponent.DrawOrder, out List<ISubDrawableComponent> excludedSubDrawableComponentList))
						{
							excludedSubDrawableComponentList.Add(subDrawableComponent);
						}
						else
						{
							subject.ExcludedSubDrawableComponents.Add(subDrawableComponent.DrawOrder, new List<ISubDrawableComponent>() { subDrawableComponent });
						}
					}
				}
			}

			this.position = new(xMin, yMin);
			RenderTarget2D renderTarget = new RenderTarget2D(
				SpriteBatchHandler.GraphicsDevice,
				(int)(xMax - xMin),
				(int)(yMax - yMin),
				false,
				SurfaceFormat.Color,
				DepthFormat.None,
				0,
				RenderTargetUsage.PreserveContents);
			SpriteBatchHandler.GraphicsDevice.SetRenderTarget(renderTarget);

			SpriteBatchHandler.Begin();

			foreach (List<ISubDrawableComponent> subDrawableComponentList in subject.SubDrawables.Values)
			{
				foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
				{
					if (!(subDrawableComponent is ISubDrawable subDrawable && subDrawable.IsAnimated))
					{
						subDrawableComponent.Draw(position, null);
					}
				}
			}

			SpriteBatchHandler.End();

			SpriteBatchHandler.GraphicsDevice.SetRenderTarget(null);
			this.texture = new Texture2D(SpriteBatchHandler.GraphicsDevice, renderTarget.Width, renderTarget.Height);
			Color[] data = new Color[renderTarget.Width * renderTarget.Height];
			renderTarget.GetData(data);
			this.texture.SetData(data);
		}

		/// <summary>
		/// Draws the <c>CombinedTexture</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public void Draw(GameTime gameTime, Color? color = null)
		{
			SpriteBatchHandler.Draw(this.Texture, this.Position.VectorPosition, color);
		}
		/// <summary>
		/// Draws the <c>CombinedTexture</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset to draw with.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public void Draw(IPosition offset, GameTime gameTime, Color? color = null)
		{
			SpriteBatchHandler.Draw(this.Texture, this.Position.VectorPosition - offset.VectorPosition, color);
		}
	}
}
