using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GibsonCore.Core;
using GibsonCore.Interfaces;

namespace GibsonCore.Utils
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
