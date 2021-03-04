using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	class Layout : IRenderingInstance<Layer>
	{
		public Layer this[int i]
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

		public Layer this[string name]
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

		public List<Layer> Objects
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

		public IRenderingInstance<Layer> parent
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

		public void Add(Layer instance)
		{
			throw new NotImplementedException();
		}

		public void Add(string name)
		{
			throw new NotImplementedException();
		}

		public void Remove(Layer instance)
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
