using Fantasy.Engine.Mapping.Tiling;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml;

namespace Fantasy.Engine.Mapping
{
	/// <summary>
	/// Represents a game map consisting of multiple layers of tiles.
	/// </summary>
	public class ActiveGameMap : DrawableGameComponent
	{
		public ActiveGameMap(Game game) : base(game)
		{
		}
	}
}