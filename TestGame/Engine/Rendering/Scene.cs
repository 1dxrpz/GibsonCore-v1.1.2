using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	class Scene : IRenderingInstance<Layout>
	{
		public List<Layout> Objects
		{
			get
			{
				throw new NotImplementedException();
			}

		}
		public Layout this[int i]
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

		public Layout this[string name]
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

		public IRenderingInstance<Layout> parent
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

		public void Add(Layout instance)
		{
			if (instance.name == null)
			{
				instance.name = "Layout" + Objects.Count;
			}
			instance.parent = this;
			Objects.Add(instance);
		}

		public void Add(string name)
		{
			throw new NotImplementedException();
		}

		public void Remove(IGameInstances i)
		{
			throw new NotImplementedException();
		}

		public void Remove(Layout instance)
		{
			throw new NotImplementedException();
		}

		public void Render()
		{
			
		}

		public void SetOrder()
		{
			throw new NotImplementedException();
		}
	}
}
