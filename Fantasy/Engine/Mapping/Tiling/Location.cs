using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Mapping.Tiling
{
	/// <summary>
	/// Represents a <c>Location</c> on a grid with a column and row.
	/// </summary>
	public readonly struct Location
    {
        private readonly int col;
        private readonly int row;

		/// <summary>
		/// Gets the column of the <c>Location</c>.
		/// </summary>
		public int Col
        {
            get => col;
        }
		/// <summary>
		/// Gets the row of the <c>Location</c>.
		/// </summary>
		public int Row
        {
            get => row;
        }

		/// <summary>
		/// Creates a new <c>Location</c> with the provided parameters.
		/// </summary>
		/// <param name="vector">The vector.</param>
		public Location(Vector2 vector)
        {
            if (vector.X < 0)
            {
                col = 0;
            }
            else
            {
                col = (int)(vector.X / Tile.TILE_DIMENSION);
            }

            if (vector.Y < 0)
            {
                row = 0;
            }
            else
            {
                row = (int)(vector.Y / Tile.TILE_DIMENSION);
            }
        }
    }
}
