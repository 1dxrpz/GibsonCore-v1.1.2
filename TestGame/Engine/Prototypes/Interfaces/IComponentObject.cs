﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public interface IComponentObject
	{
		public ComponentHandler ParentObject { get; set; }
		public void Init();
		public void Update();
	}
}