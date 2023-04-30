using Fantasy.Engine.Mapping.Tiling;
using Fantasy.Engine.SubGameComponents.collections;

namespace Fantasy.Engine.Mapping
{
	/// <summary>
	/// Represents a layer in a game map.
	/// </summary>
	public class MapLayer : SubDrawableUpdateableCollection
	{
		protected readonly byte layer;
		protected TileCollection tileCollection;

		/// <summary>
		/// Gets the layer number.
		/// </summary>
		public byte Layer { get => this.layer; }
		/// <summary>
		/// Gets the collection of tiles in the layer.
		/// </summary>
		public TileCollection TileCollection { get => this.tileCollection; protected set => this.tileCollection = value; }

		/// <summary>
		/// Creates a new <c>MapLayer</c> with the provided parameters.
		/// </summary>
		/// <param name="layer">The layer number of the new MapLayer.</param>
		public MapLayer(byte layer)
		{
			this.layer = layer;
		}

		/// <summary>
		/// Initializes the <c>MapLayer</c>.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			this.TileCollection = new TileCollection();
			this.TileCollection.Initialize();
			this.AddSubComponent(this.TileCollection);
			this.AddSubDrawable(this.TileCollection);
		}
	}
}
