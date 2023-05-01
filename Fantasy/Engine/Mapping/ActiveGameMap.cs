using Fantasy.Engine.ContentManagement;
using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Drawing;
using Fantasy.Engine.Mapping.Tiling;
using Fantasy.Engine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml;
using System;

namespace Fantasy.Engine.Mapping
{
	/// <summary>
	/// Represents a game map consisting of multiple layers of tiles.
	/// </summary>
	public class ActiveGameMap : DrawableGameComponent
	{
		private static ActiveGameMap activeGameMap;

		/// <summary>
		/// Gets the current <c>ActiveGameMap</c>.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="mapName">The map name.</param>
		/// <returns>The current <c>ActiveGameMap</c>.</returns>
		public static ActiveGameMap GetActiveGameMap(Game game, string mapName)
		{
			activeGameMap ??= new ActiveGameMap(game, mapName);
			return activeGameMap;
		}

		protected string mapName;
		protected GameMap gameMap;
		
		/// <summary>
		/// Gets the map name.
		/// </summary>
		public string MapName { get => this.mapName; protected set => this.mapName = value; }
		/// <summary>
		/// Gets the game map.
		/// </summary>
		public GameMap GameMap { get => this.gameMap; protected set => this.gameMap = value; }

		/// <summary>
		/// Creates a new <c>ActiveGameMap</c> with the provided parameters.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="mapName">The mapName.</param>
		private ActiveGameMap(Game game, string mapName) : base(game)
		{
			this.MapName = mapName;
			this.DrawOrder = 0;
			this.UpdateOrder = 0;
			XmlDocument gameMapDocument = XmlManager.GetXMLDocument(mapName);
			this.GameMap = new GameMap(gameMapDocument);
		}

		/// <summary>
		/// Loads the content of the ActiveGameMap.
		/// </summary>
		protected override void LoadContent()
		{
			this.GameMap.Initialize();
		}

		/// <summary>
		/// Initializes the <c>ActiveGameMap</c>.
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			this.GameMap.Update(gameTime);
		}
		/// <summary>
		/// Draws the <c>ActiveGameMap</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		public override void Draw(GameTime gameTime)
		{
			this.GameMap.Draw(gameTime);
		}
	}
}