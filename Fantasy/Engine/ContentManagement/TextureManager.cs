using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Fantasy.Engine.ContentManagement
{
    /// <summary>
    /// Manages the texture used throughout the game.
    /// </summary>
    public static class TextureManager
    {
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		private static Game Game { get; set; }

		/// <summary>
		/// Gets or sets the SpriteSheets.
		/// </summary>
		private static Dictionary<string, Texture2D> SpriteSheets { get; set; }

		/// <summary>
		/// Initializes the <c>XmlManager</c>.
		/// </summary>
		/// <param name="game">The game.</param>
		public static void Initialize(Game game)
		{
			Game = game;
			SpriteSheets = new Dictionary<string, Texture2D>();
		}

		/// <summary>
		/// Loads the textures.
		/// </summary>
		public static void LoadTextures()
        {
            LoadSpriteSheets();
        }

        /// <summary>
        /// Loads the SpriteSheets.
        /// </summary>
        private static void LoadSpriteSheets()
        {
			List<string> spriteSheetNames = new()
			{
				"DEBUG",
				"EMPTY",
				"brickwall_spriteSheet",
				"grass_spriteSheet",
				"woodfloor_spriteSheet"
			};

			foreach (string spriteSheetName in spriteSheetNames)
			{
				if (SpriteSheets.ContainsKey(spriteSheetName))
				{
					continue;
				}

				SpriteSheets.Add(spriteSheetName, Game.Content.Load<Texture2D>(@"spritesheets\" + spriteSheetName));
			}
        }

		/// <summary>
		/// Gets the SpriteSheet with the provided name if it exists.
		/// </summary>
		/// <param name="spriteSheetName">The name of the SpriteSheet to get.</param>
		/// <returns>The SpriteSheet.</returns>
		/// <exception cref="Exception">Thrown if a SpriteSheet with the provided name does not exist.</exception>
		public static Texture2D GetSpriteSheet(string spriteSheetName)
        {
            if (SpriteSheets.TryGetValue(spriteSheetName, out Texture2D texture))
            {
                return texture;
            }

			try
			{
				SpriteSheets.Add(spriteSheetName, Game.Content.Load<Texture2D>(@"spritesheets\" + spriteSheetName));
				return SpriteSheets[spriteSheetName];
			}
			catch
			{
				throw new Exception("SpriteSheet with name " + spriteSheetName + " was not found.");
			}
		}
    }
}
