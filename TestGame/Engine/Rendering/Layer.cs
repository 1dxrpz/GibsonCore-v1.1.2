﻿using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Layer : RenderingInstance<Layout>, IRenderingInstance<IGameInstances>
	{
		private List<IGameInstances> objects = new List<IGameInstances>();

		public IGameInstances this[int i]
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public IGameInstances this[string name]
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public List<IGameInstances> Objects
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void Add(IGameInstances instance)
		{
			throw new NotImplementedException();
		}

		public void Add(string name)
		{
			throw new NotImplementedException();
		}

		public void Remove(IGameInstances instance)
		{
			throw new NotImplementedException();
		}

		public void Render()
		{
			throw new NotImplementedException();
		}

		public void SetOrder()
		{
			throw new NotImplementedException();
		}
	}
}