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
        /// Gets or sets the spritesheets.
        /// </summary>
        private static Dictionary<string, Texture2D> Spritesheets { get; set; }

        /// <summary>
        /// Loads the textures.
        /// </summary>
        /// <param name="game">The game.</param>
        public static void LoadTextures(Game game)
        {
            LoadSpritesheets(game);
        }

        /// <summary>
        /// Loads the spritesheets.
        /// </summary>
        /// <param name="game">The game.</param>
        private static void LoadSpritesheets(Game game)
        {
			//tileSets.Add("NAME", Global._content.Load<Texture2D>(@"spritesheets\NAME"));
			Spritesheets = new Dictionary<string, Texture2D>
            {
                { "DEBUG", game.Content.Load<Texture2D>(@"spritesheets\DEBUG") },
                { "EMPTY", game.Content.Load<Texture2D>(@"spritesheets\EMPTY") },
                { "brickwall_spritesheet", game.Content.Load<Texture2D>(@"spritesheets\brickwall_spritesheet") },
                { "grass_spritesheet", game.Content.Load<Texture2D>(@"spritesheets\grass_spritesheet")},
                { "woodfloor_spritesheet", game.Content.Load<Texture2D>(@"spritesheets\woodfloor_spritesheet")}
            };
        }

        /// <summary>
        /// Gets the spritesheet with the provided name if it exists.
        /// </summary>
        /// <param name="spritesheetName">The name of the spritesheet to get.</param>
        /// <returns>The spritesheet.</returns>
        /// <exception cref="Exception">Thrown if a spritesheet with the provided name does not exist.</exception>
        public static Texture2D GetSpritesheet(string spritesheetName)
        {
            Texture2D foo;
            if (Spritesheets.TryGetValue(spritesheetName, out foo))
            {
                return foo;
            }
            throw new Exception("Spritesheet with name " + spritesheetName + " was not found.");
        }
    }
}
