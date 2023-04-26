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
	public class Tile : SubDrawable, ILocatable
	{
		private static readonly int tileDimensions = 64;

		/// <summary>
		/// Gets the dimensions of a tile in pixels.
		/// </summary>
		public static int TILE_DIMENSIONS
		{
			get => tileDimensions;
		}

		public static SubDrawableCollection GetTiles(XmlElement tileMapElement) 
		{
			
		}

		protected ILocation location;

		/// <summary>
		/// Gets or sets the location.
		/// </summary>
		public ILocation Location { get => location; set => location = value; }

		/// <summary>
		/// Creates a new <c>Tile</c> with the provided parameters.
		/// </summary>
		/// <param name="drawOrder">The draw order.</param>
		/// <param name="location">the location.</param>
		/// <param name="definedDrawable">the defined drawable.</param>
		/// <param name="isVisible">indicates if this <c>Tile</c> is visible or not.</param>
		public Tile(byte drawOrder, ILocation location, IDefinedDrawable definedDrawable, bool isVisible = false) 
		{
			this.IsVisible = isVisible;
			this.DrawOrder = drawOrder;
			this.Location = location;
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