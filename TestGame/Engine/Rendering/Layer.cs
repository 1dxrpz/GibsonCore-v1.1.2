using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	class Layer : IRenderingInstance<IGameInstances>
	{
		private List<IGameInstances> objects = new List<IGameInstances>();

		public List<IGameInstances> Objects
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsVisible
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

		public void Add(IGameInstances instance)
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