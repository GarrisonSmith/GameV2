using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.components;
using Microsoft.Xna.Framework;

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
		public Tile(byte drawOrder, string tileId, Position position, IDefinedDrawable definedDrawable, bool isVisible = false) 
		{
			this.IsVisible = isVisible;
			this.DrawOrder = drawOrder;
			this.tileId = tileId;
			this.position = position;
			this.DefinedDrawable = definedDrawable;
		}

		/// <summary>
		/// Initializes the tile.
		/// </summary>
		public override void Initialize()
		{

		}

		/// <summary>
		/// Draws the tile.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		/// <param name="color">The color.</param>
		public override void Draw(GameTime gameTime, Color? color = null)
		{
			this.DefinedDrawable.Draw(gameTime, color);
		}
		/// <summary>
		/// Draws the tile.
		/// </summary>
		/// <param name="offset">The offset.</param>
		/// <param name="gameTime">The game time.</param>
		/// <param name="color">The color.</param>
		public override void Draw(IPosition offset, GameTime gameTime, Color? color = null)
		{
			this.DefinedDrawable.Draw(offset, gameTime, color);
		}
	}
}