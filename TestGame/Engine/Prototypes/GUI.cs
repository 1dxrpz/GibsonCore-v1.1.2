using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class GUI
	{
		
		public Rectangle Bounds;
		public bool Hover()
		{
			return true;
		}
		public virtual void Update() { }
	}
	public class Button : GUI
	{
		public override void Update()
		{
			base.Update();
		}
	}
	public class Slider : GUI
	{
		public override void Update()
		{
			base.Update();
		}
	}
	public class Memo : GUI
	{
		public override void Update()
		{
			base.Update();
		}
	}
}
