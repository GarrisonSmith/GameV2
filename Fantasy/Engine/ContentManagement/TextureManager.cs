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
		/// Gets or sets the SpriteSheets.
		/// </summary>
		private static Dictionary<string, Texture2D> SpriteSheets { get; set; }

        /// <summary>
        /// Loads the textures.
        /// </summary>
        /// <param name="game">The game.</param>
        public static void LoadTextures(Game game)
        {
            LoadSpriteSheets(game);
        }

        /// <summary>
        /// Loads the SpriteSheets.
        /// </summary>
        /// <param name="game">The game.</param>
        private static void LoadSpriteSheets(Game game)
        {
			SpriteSheets = new Dictionary<string, Texture2D>
            {
                { "DEBUG", game.Content.Load<Texture2D>(@"spritesheets\DEBUG") },
                { "EMPTY", game.Content.Load<Texture2D>(@"spritesheets\EMPTY") },
                { "brickwall_spritesheet", game.Content.Load<Texture2D>(@"spritesheets\brickwall_spriteSheet") },
                { "grass_spritesheet", game.Content.Load<Texture2D>(@"spritesheets\grass_spriteSheet")},
                { "woodfloor_spritesheet", game.Content.Load<Texture2D>(@"spritesheets\woodfloor_spriteSheet")}
            };
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
            throw new Exception("SpriteSheet with name " + spriteSheetName + " was not found.");
        }
    }
}
