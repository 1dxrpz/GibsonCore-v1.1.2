using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class GameManager
	{
		static public Action InitEvent;
		static public Action UpdateEvent;
		static public Action DrawEvent;
		public void Init() => InitEvent?.Invoke();
		private bool _init = false;
		public void Update()
		{
			if (!_init)
			{
				//Init();
				_init = !_init;
			}
			else
				UpdateEvent?.Invoke();
		}
		public void Draw() => DrawEvent?.Invoke();
	}
}
