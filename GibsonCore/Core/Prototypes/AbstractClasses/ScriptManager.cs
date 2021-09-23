using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GibsonCore.Abstract
{
	public abstract class ScriptManager
	{
		public static GameServiceContainer Services;
		public static ContentManager Content;
		public static SpriteBatch ctx;
		public static GraphicsDevice graphicsDevice;
	}

}
