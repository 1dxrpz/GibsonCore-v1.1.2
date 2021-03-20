using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameEngineTK.Engine;
using GameEngineTK.Engine.Prototypes.Interfaces;
using GameEngineTK.Engine.Rendering;
using GameEngineTK.Scripts;

namespace GameEngineTK.Engine.Utils
{
	class ConsoleInterractions : IScriptManager
	{
		[DllImport("kernel32")]
		static extern bool AllocConsole();
		public void Start()
		{
			if (ConfigReader.Parse("project").ContainsKey("EnableConsole") ? ConfigReader.Parse("project").GetBool("EnableConsole") : false)
				AllocConsole();

			foreach (var i in Theatre.Scenes)
			{
				Console.WriteLine($"- > [{i.GetType().Name}]\t[{i.IsVisible}]\t{i.Name}");
			}

			/*
			foreach (var i in Theatre.GetObjects)
			{
				Console.WriteLine($"- > [{i.GetType().Name}] {i.name}");
				foreach (var t in i.GetObjects)
				{
					Console.WriteLine($"\t└ [{t.GetType().Name}] {t.name}");
					foreach (var l in t.GetObjects)
					{
						Console.WriteLine($"\t\t└ [{l.GetType().Name}] {l.name}");
						foreach (var n in l.GetObjects)
						{
							Console.WriteLine($"\t\t\t└ [{n.GetType().Name}] {n.name}");
						}
					}
				}
			}
			*/
		}
		void ConsoleExecutor()
		{
			
		}
		public void Update()
		{
			Task.Run(ConsoleExecutor);
		}
	}
}
