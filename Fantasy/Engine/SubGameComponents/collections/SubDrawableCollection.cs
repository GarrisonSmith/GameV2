﻿using Fantasy.Engine.Drawing;
using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
	/// <summary>
	/// Represents of collection of <c>ISubDrawableComponents</c> that can be used inside a <c>DrawableGameComponent</c>. 
	/// </summary>
	public abstract class SubDrawableCollection : SubComponentCollection, ISubDrawableCollection
	{
		protected bool isVisible;
		protected bool useCombinedTexture;
		protected byte drawOrder;
		protected CombinedTexture combinedTexture;
		protected SortedDictionary<byte, List<ISubDrawableComponent>> subDrawables;
		protected SortedDictionary<byte, List<ISubDrawableComponent>> animatedSubDrawables;

		/// <summary>
		/// Gets or sets a value indicating whether this <c>DrawableGameComponent</c> is visible or not.
		/// </summary>
		public bool IsVisible { get => this.isVisible; set => this.isVisible = value; }
		/// <summary>
		/// Gets or sets a value indicating whether to use a combined texture for all elements in the <c>ISubDrawableCollection</c>.
		/// </summary>
		public bool UseCombinedTexture { get => this.useCombinedTexture; set => this.useCombinedTexture = value; }
		/// <summary>
		/// Gets or sets a value indicating the priority this subcomponent will be drawn with in its <c>ISubDrawableCollection</c> collection.
		/// Lower numbers are higher priority.
		/// 0 priority values are reserved for invisible subcomponent.
		/// </summary>
		public byte DrawOrder { get => this.drawOrder; set => this.drawOrder = value; }
		/// <summary>
		/// Gets the combined texture used for all elements in the <c>ISubDrawableCollection</c>.
		/// </summary>
		public CombinedTexture CombinedTexture { get => this.combinedTexture; protected set => this.combinedTexture = value; }
		/// <summary>
		/// Gets the dictionary <c>ISubDrawableComponent</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public SortedDictionary<byte, List<ISubDrawableComponent>> SubDrawables { get => this.subDrawables; protected set => this.subDrawables = value; }
		/// <summary>
		/// Gets the dictionary <c>Animation</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		public SortedDictionary<byte, List<ISubDrawableComponent>> AnimatedSubDrawables { get => this.animatedSubDrawables; protected set => this.animatedSubDrawables = value; }

		/// <summary>
		/// Creates a new <c>SubDrawableCollection</c>.
		/// </summary>
		public SubDrawableCollection() 
		{
			this.isVisible = true;
			this.DrawOrder = 1;
		}
		/// <summary>
		/// Creates a new <c>SubDrawableCollection</c> with the provided parameters.
		/// </summary>
		/// <param name="isVisible">A value indicating whether this <c>SubDrawableCollection</c> is visible or not.</param>
		/// <param name="drawOrder">The draw order.</param>
		public SubDrawableCollection(bool isVisible, byte drawOrder)
		{
			this.IsVisible = isVisible;
			this.UseCombinedTexture = false;
			this.DrawOrder = drawOrder;
		}

		/// <summary>
		/// Adds a ISubDrawableComponent to the <c>SubDrawableCollection</c>;
		/// </summary>
		/// <param name="subDrawableComponent">The ISubDrawableComponent.</param>
		public void AddSubDrawable(ISubDrawableComponent subDrawableComponent)
		{
			if (this.subComponents.Contains(subDrawableComponent))
			{
				return;
			}

			this.subComponents.Add(subDrawableComponent);
			if (this.SubDrawables.TryGetValue(subDrawableComponent.DrawOrder, out List<ISubDrawableComponent> subDrawableComponentList))
			{
				subDrawableComponentList.Add(subDrawableComponent);
			}
			else
			{
				this.SubDrawables.Add(subDrawableComponent.DrawOrder, new List<ISubDrawableComponent>() { subDrawableComponent });
			}

			if (subDrawableComponent is ISubDrawable foo && foo.DefinedDrawable is Animation)
			{
				if (this.AnimatedSubDrawables.TryGetValue(subDrawableComponent.DrawOrder, out List<ISubDrawableComponent> animatedSubDrawableComponentList))
				{
					animatedSubDrawableComponentList.Add(subDrawableComponent);
				}
				else
				{
					this.AnimatedSubDrawables.Add(subDrawableComponent.DrawOrder, new List<ISubDrawableComponent>() { subDrawableComponent });
				}
			}
		}
		/// <summary>
		/// Creates the combined texture for the entire <c>SubDrawableUpdateableCollection</c>.
		/// </summary>
		public virtual void CreateCombinedTexture()
		{
			this.UseCombinedTexture = true;
			float width = 0, height = 0, x = float.MaxValue, y = float.MaxValue;
			Vector2 bottomRight;
			foreach (List<ISubDrawableComponent> subDrawableComponentList in this.SubDrawables.Values)
			{
				foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
				{
					if (subDrawableComponent is ISubDrawableCollection subDrawableCollection)
					{
						subDrawableCollection.CreateCombinedTexture();
						bottomRight = subDrawableCollection.CombinedTexture.BottomRight;
						if (bottomRight.X > width)
						{
							width = bottomRight.X;
						}
						else if (subDrawableCollection.CombinedTexture.Position.X < x)
						{
							x = subDrawableCollection.CombinedTexture.Position.X;
						}

						if (bottomRight.Y > height)
						{
							height = bottomRight.Y;
						}
						else if (subDrawableCollection.CombinedTexture.Position.Y < y)
						{
							y = subDrawableCollection.CombinedTexture.Position.Y;
						}
					}
					else if (subDrawableComponent is ISubDrawable subDrawable)
					{
						bottomRight = subDrawable.DefinedDrawable.BottomRight;
						if (bottomRight.X > width)
						{
							width = bottomRight.X;
						}
						else if (subDrawable.DefinedDrawable.Position.X < x)
						{
							x = subDrawable.DefinedDrawable.Position.X;
						}

						if (bottomRight.Y > height)
						{
							height = bottomRight.Y;
						}
						else if (subDrawable.DefinedDrawable.Position.Y < y)
						{
							y = subDrawable.DefinedDrawable.Position.Y;
						}
					}
				}
			}

			Position position = new(x, y);
			RenderTarget2D renderTarget = new RenderTarget2D(SpriteBatchHandler.GraphicsDevice, (int)width, (int)height);
			SpriteBatchHandler.GraphicsDevice.SetRenderTarget(renderTarget);

			SpriteBatchHandler.Begin();

			foreach (List<ISubDrawableComponent> subDrawableComponentList in this.SubDrawables.Values)
			{
				foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
				{
					if (!(subDrawableComponent is ISubDrawable subDrawable && subDrawable.IsAnimated))
					{
						subDrawableComponent.Draw(position, null, null);
					}
				}
			}

			SpriteBatchHandler.End();

			SpriteBatchHandler.GraphicsDevice.SetRenderTarget(null);
			Texture2D texture = new Texture2D(SpriteBatchHandler.GraphicsDevice, renderTarget.Width, renderTarget.Height);
			Color[] data = new Color[renderTarget.Width * renderTarget.Height];
			renderTarget.GetData(data);
			texture.SetData(data);
			this.CombinedTexture = new CombinedTexture(texture, position);
		}
		/// <summary>
		/// Initializes the <c>ISubDrawableCollection</c>.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			this.SubDrawables = new SortedDictionary<byte, List<ISubDrawableComponent>>();
			this.AnimatedSubDrawables = new SortedDictionary<byte, List<ISubDrawableComponent>>();
		}

		/// <summary>
		/// Draws the <c>SubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public virtual void Draw(GameTime gameTime, Color? color = null)
		{
			if (this.UseCombinedTexture)
			{
				foreach (List<ISubDrawableComponent> animatedSubDrawableComponentList in this.AnimatedSubDrawables.Values)
				{
					foreach (ISubDrawableComponent subDrawableComponent in animatedSubDrawableComponentList)
					{
						subDrawableComponent.Draw(gameTime, color);
					}
				}

				this.CombinedTexture.Draw(gameTime, color);
			}
			else
			{
				foreach (List<ISubDrawableComponent> subDrawableComponentList in this.SubDrawables.Values)
				{
					foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
					{
						subDrawableComponent.Draw(gameTime, color);
					}
				}
			}
		}
		/// <summary>
		/// Draws the <c>SubDrawableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public virtual void Draw(IPosition offset, GameTime gameTime, Color? color = null)
		{
			if (this.UseCombinedTexture)
			{
				foreach (List<ISubDrawableComponent> animatedSubDrawableComponentList in this.AnimatedSubDrawables.Values)
				{
					foreach (ISubDrawableComponent subDrawableComponent in animatedSubDrawableComponentList)
					{
						subDrawableComponent.Draw(offset, gameTime, color);
					}
				}

				this.CombinedTexture.Draw(offset, gameTime, color);
			}
			else
			{
				foreach (List<ISubDrawableComponent> subDrawableComponentList in this.SubDrawables.Values)
				{
					foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
					{
						subDrawableComponent.Draw(offset, gameTime, color);
					}
				}
			}
		}
	}
}
