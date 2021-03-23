using System;
using System.Collections.Generic;
using GameEngineTK.Engine;
using GameEngineTK.Engine.Prototypes.Interfaces;
using GameEngineTK.Engine.Utils;
using GameEngineTK.Scripts;

namespace GameEngineTK
{
	public static class Program
	{
		static public List<IScriptManager> scripts = new List<IScriptManager>();
		[STAThread]
		static void Main()
		{
			using (var game = new Game1())
			{
				var config = ConfigReader.Parse("project");


				//scripts.Add(new NoiseScript());
				scripts.Add(new PlayerScript());
				scripts.Add(new CameraScript());
				scripts.Add(new CursorScript());
				scripts.Add(new ConsoleInterractions());
				game.Window.IsBorderless = true;
				game.Window.AllowAltF4 = true;
				game.IsMouseVisible = false;
				game.Window.AllowUserResizing = true;
				game.Window.Title = config.ContainsKey("title") ? config["title"] : "Unnamed Game";
				game.Run();
			}
		}
	}
}
