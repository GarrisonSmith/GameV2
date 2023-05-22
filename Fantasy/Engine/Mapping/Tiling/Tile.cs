using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.components;

namespace Fantasy.Engine.Mapping.Tiling
{
	/// <summary>
	/// Represents a tile.
	/// </summary>
	public class Tile : SubDrawableComponent, IPositional<Position>
	{
		private static readonly int tileDimensions = 64;

		/// <summary>
		/// Gets the dimensions of a tile in pixels.
		/// </summary>
		public static int TILE_DIMENSION { get => tileDimensions; }

		protected readonly string tileId;
		protected readonly Position position;

		/// <summary>
		/// Gets the tile id.
		/// </summary>
		public string TileId { get => this.tileId; }
		/// <summary>
		/// Gets the position.
		/// </summary>
		public Position Position { get => this.position; }

		/// <summary>
		/// Creates a new <c>Tile</c> with the provided parameters.
		/// </summary>
		/// <param name="drawOrder">The draw order.</param>
		/// <param name="tileId">The tile id.</param>
		/// <param name="position">the position.</param>
		/// <param name="definedDrawable">the defined drawable.</param>
		/// <param name="isVisible">indicates if this <c>Tile</c> is visible or not.</param>
		public Tile(byte drawOrder, string tileId, Position position, IDefinedDrawable definedDrawable, bool isVisible = false) : base(isVisible, drawOrder, definedDrawable)
		{
			this.tileId = tileId;
			this.position = position;
		}

		/// <summary>
		/// Initializes the tile.
		/// </summary>
		public override void Initialize() { }
	}
}