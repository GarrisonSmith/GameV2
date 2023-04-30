using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.collections;
using Fantasy.Engine.SubGameComponents.components;
using Microsoft.Xna.Framework;
using System;
using System.Xml;

namespace Fantasy.Engine.Mapping.Tiling
{
	/// <summary>
	/// Represents a tile in a MapLayer.
	/// </summary>
	public class Tile : SubDrawableComponent, ILocatable
	{
		private static readonly int tileDimensions = 64;

		/// <summary>
		/// Gets the dimensions of a tile in pixels.
		/// </summary>
		public static int TILE_DIMENSION
		{
			get => tileDimensions;
		}

		protected readonly string tileId;
		protected readonly ILocation location;

		/// <summary>
		/// Gets the tile id.
		/// </summary>
		public string TileId { get => TileId; }
		/// <summary>
		/// Gets the location.
		/// </summary>
		public ILocation Location { get => location;}

		/// <summary>
		/// Creates a new <c>Tile</c> with the provided parameters.
		/// </summary>
		/// <param name="drawOrder">The draw order.</param>
		/// <param name="tileId">The tile id.</param>
		/// <param name="location">the location.</param>
		/// <param name="definedDrawable">the defined drawable.</param>
		/// <param name="isVisible">indicates if this <c>Tile</c> is visible or not.</param>
		public Tile(byte drawOrder, string tileId, ILocation location, IDefinedDrawable definedDrawable, bool isVisible = false) 
		{
			this.IsVisible = isVisible;
			this.DrawOrder = drawOrder;
			this.tileId = tileId;
			this.location = location;
			this.DefinedDrawable = definedDrawable;
		}

		public override void Draw(GameTime gameTime, Color? color = null)
		{
			throw new NotImplementedException();
		}

		public override void Initialize()
		{
			throw new NotImplementedException();
		}
	}
}