using Fantasy.Engine.Mapping.Tiling;
using Fantasy.Engine.SubGameComponents.collections;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Mapping
{
	/// <summary>
	/// Represents a layer of tiles in a game map.
	/// </summary>
	public class MapLayer : SubDrawableUpdateableCollection
	{
		private readonly byte layer;
		private readonly TileCollection tileLayer;

		/// <summary>
		/// Gets the layer number.
		/// </summary>
		public byte Layer
		{
			get => layer;
		}
		/// <summary>
		/// Gets the collection of tiles in the layer.
		/// </summary>
		public TileCollection TileLayer
		{
			get => tileLayer;
		}

		/// <summary>
		/// Initializes a new instance of the MapLayer class and adds it to the ActiveGameMap.
		/// </summary>
		/// <param name="game">The game object to which the layer will be added.</param>
		/// <param name="layer">The layer number of the new MapLayer.</param>
		/// <exception cref="Exception">Thrown if a layer with the same number already exists in the ActiveGameMap.</exception>
		public MapLayer(byte layer)
		{

		}

		public override void CreateCombinedTexture()
		{
			throw new NotImplementedException();
		}

		public override void Initialize()
		{
			throw new NotImplementedException();
		}

		public override void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
		}

		public override void Draw(GameTime gameTime, Color? color = null)
		{
			throw new NotImplementedException();
		}
	}
}
