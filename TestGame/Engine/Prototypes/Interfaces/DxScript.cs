using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public class DxScript : IScriptableObject
	{
		public DxScript()
		{
			GameManager.InitEvent += Start;
			GameManager.UpdateEvent += Update;
		}

		public virtual void Start() { }
		public virtual void Update() { }
	}
}
