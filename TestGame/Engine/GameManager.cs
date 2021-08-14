using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class GameManager
	{
		static public Action UpdateEvent;
		static public Action DrawEvent;
		static public Action InitEvent;
		public void Update() => UpdateEvent?.Invoke();
		public void Draw() => DrawEvent?.Invoke();
		public void Init() => InitEvent?.Invoke();
	}
}
