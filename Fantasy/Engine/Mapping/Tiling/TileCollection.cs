using Fantasy.Engine.Drawing;
using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.SubGameComponents.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.Mapping.Tiling
{
	/// <summary>
	/// Represents a collection of tiles on a specific map layer.
	/// </summary>
	public class TileCollection : SubDrawableCollection, ICombineTextures
	{
		protected bool useCombinedTexture;
		protected CombinedTexture combinedTexture;
		protected Dictionary<Location, Tile> tiles;
		protected SortedDictionary<byte, List<ISubDrawableComponent>> excludedSubDrawableComponents;

		/// <summary>
		/// Gets or sets a value indicating whether to use the combined texture.
		/// </summary>
		public bool UseCombinedTexture { get => useCombinedTexture; set => useCombinedTexture = value; }
		/// <summary>
		/// Gets or sets the combined texture.
		/// </summary>
		public CombinedTexture CombinedTexture { get => combinedTexture; }
		/// <summary>
		/// Gets a dictionary mapping the location (row and column) of a tile to the tile itself.
		/// </summary>
		public Dictionary<Location, Tile> Tiles { get => tiles; }
		/// <summary>
		/// Gets or sets the list of sub drawable components that are excluded from the combined texture.
		/// </summary>
		public SortedDictionary<byte, List<ISubDrawableComponent>> ExcludedSubDrawableComponents { get => excludedSubDrawableComponents; set => excludedSubDrawableComponents = value; }

		/// <summary>
		/// Creates a new <c>TileCollection</c> with the provided parameters.
		/// </summary>
		/// <param name="isVisible"></param>
		/// <param name="drawOrder"></param>
		public TileCollection(bool isVisible = true, byte drawOrder = 255) : base(isVisible, drawOrder)
		{

		}

		/// <summary>
		/// Adds the tile to this <c>TileCollection</c>.
		/// </summary>
		/// <param name="tile">The tile.</param>
		public void AddSubComponent(Tile tile)
		{
			this.Tiles.Add(new Location(tile.Position.VectorPosition), tile);
			this.AddSubComponent((ISubComponent)tile);
		}
		/// <summary>
		/// Creates the combined texture for this <c>TileCollection</c>.
		/// </summary>
		/// <param name="useCombinedTexture">A value indicating whether to use the created combined texture or not.</param>
		public void CreateCombinedTexture(bool useCombinedTexture = true)
		{
			this.UseCombinedTexture = useCombinedTexture;
			this.ExcludedSubDrawableComponents = new SortedDictionary<byte, List<ISubDrawableComponent>>();
			this.combinedTexture = new CombinedTexture(this);
		}

		/// <summary>
		/// Initializes the <c>TileCollection</c>.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			this.tiles = new Dictionary<Location, Tile>();
		}
		/// <summary>
		/// Draws the <c>TileCollection</c>.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		/// <param name="color">The color.</param>
		public override void Draw(GameTime gameTime, Color? color = null)
		{
			if (this.UseCombinedTexture)
			{
				this.CombinedTexture.Draw(gameTime, color);
				foreach (List<ISubDrawableComponent> subDrawableComponentList in this.ExcludedSubDrawableComponents.Values)
				{
					foreach (ISubDrawableComponent subDrawableComponent in subDrawableComponentList)
					{
						subDrawableComponent.Draw(gameTime, color);
					}
				}
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
	}
}