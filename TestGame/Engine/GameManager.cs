using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class GameManager
	{
		static public Action UpdateEvent;
		static public Action DrawEvent;
		static public Action StartEvent;
		public void Update() => UpdateEvent?.Invoke();
		public void Draw() => DrawEvent?.Invoke();
		public void Start() => StartEvent?.Invoke();
	}
}
