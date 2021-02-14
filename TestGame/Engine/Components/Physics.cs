using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class Physics : Component
	{
		public Vector2 Velocity = new Vector2();
		public Vector2 Acceleration = new Vector2();
		public bool isEnabled = false;

		public override void Update()
		{
			this.Position += this.Velocity;
		}
	}
}
