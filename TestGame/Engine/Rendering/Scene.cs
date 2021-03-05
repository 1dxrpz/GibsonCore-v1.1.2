using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Scene : RenderingInstance<Theatre>, IRenderingInstance<Layout>
	{
		private List<Layout> Objects = new List<Layout>();

		public Layout this[int i]
		{
			get
			{
				return Objects[i];
			}

			set
			{
				if (value.name == null)
					value.name = "Layer" + i;
				Objects[i] = value;
			}
		}

		public Layout this[string name]
		{
			get
			{
				return Objects.Find(v => v.name == name);
			}

			set
			{
				Objects[Objects.FindIndex(v => v.name == name)] = value;
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
			Layout t = new Layout();
			t.name = name;
			t.parent = this;
			Objects.Add(t);
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
