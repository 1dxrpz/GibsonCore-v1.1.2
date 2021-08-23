using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameEngineTK.Core;
using GameEngineTK.Core.Prototypes.Interfaces;
using GameEngineTK.Scripts;

namespace GameEngineTK.Core.Utils
{
	class ConsoleInterractions : IScriptableObject
	{
		[DllImport("kernel32")]
		static extern bool AllocConsole();
		public void Start()
		{
			if (ConfigReader.Parse("project").ContainsKey("EnableConsole") ? ConfigReader.Parse("project").GetBool("EnableConsole") : false)
				AllocConsole();
			Task.Run(ConsoleExecutor);
		}
		void ConsoleExecutor()
		{
			
		}
		public void Update()
		{
			
		}
	}
}
