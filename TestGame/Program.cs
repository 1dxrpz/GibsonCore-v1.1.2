using System;
using System.Collections.Generic;
using GameEngineTK.Engine;
using GameEngineTK.Scripts;

namespace GameEngineTK
{
	public static class Program
	{
		static public List<Script> scripts = new List<Script>();
		[STAThread]
		static void Main()
		{
			using (var game = new Game1())
			{
				scripts.Add(new PlayerScript());
				scripts.Add(new CameraScript());
				scripts.Add(new CursorScript());

				game.Window.IsBorderless = true;
				game.Window.AllowAltF4 = true;
				game.IsMouseVisible = false;
				game.Window.AllowUserResizing = false;
				game.Window.Title = "Game Engine";
				game.Run();
			}
		}
	}
}
