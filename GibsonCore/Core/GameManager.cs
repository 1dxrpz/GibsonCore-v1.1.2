using System;
using System.Collections.Generic;
using System.Text;

namespace GibsonCore.Core
{
	public class GameManager
	{
		static public Action InitEvent;
		static public Action UpdateEvent;
		static public Action DrawtEvent;
		static public Action DrawFXEvent;
		static public Action UnloadEvent;
		public void Init() => InitEvent?.Invoke();
		public void Update() => UpdateEvent?.Invoke();
		public void Unload() => UnloadEvent?.Invoke();
		public void DrawDefault() => DrawtEvent?.Invoke();
		public void DrawFX() => DrawFXEvent?.Invoke();
	}
}
