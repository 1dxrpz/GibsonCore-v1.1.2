using GameEngineTK.Engine.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngineTK.Engine
{
	internal abstract class ScriptManager
	{
		public static GameServiceContainer Services;
		public static ContentManager Content;
		public static SpriteBatch ctx;
		public static GraphicsDevice graphicsDevice;
		public static Scene DefaultScene;
		public static Layout DefaultLayout;
		public static Layer DefaultLayer;
	}

}
