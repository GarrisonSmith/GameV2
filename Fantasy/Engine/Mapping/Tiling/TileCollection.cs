using Fantasy.Engine.SubGameComponents.collections;
using System.Collections.Generic;

namespace Fantasy.Engine.Mapping.Tiling
{
	/// <summary>
	/// Represents a collection of tiles on a specific map layer.
	/// </summary>
	public class TileCollection : SubDrawableCollection
	{
		protected Dictionary<Location, Tile> tiles;

		/// <summary>
		/// Gets a dictionary mapping the location (row and column) of a tile to the tile itself.
		/// </summary>
		public Dictionary<Location, Tile> Tiles { get => tiles; }

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
		public void AddTile(Tile tile)
		{
			this.Tiles.Add(new Location(tile.Position.VectorPosition), tile);
			this.AddSubComponent(tile);
			this.AddSubDrawable(tile);
		}

		/// <summary>
		/// Initializes the <c>TileCollection</c>.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			this.tiles = new Dictionary<Location, Tile>();
		}
	}
}