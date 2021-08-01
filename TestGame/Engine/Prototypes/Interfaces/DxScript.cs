using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public class DxScript : IScriptManager
	{
		public DxScript()
		{
			GameManager.StartEvent += Start;
			GameManager.UpdateEvent += Update;
		}

		public virtual void Start() { }
		public virtual void Update() { }
	}
}
