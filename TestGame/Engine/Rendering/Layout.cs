using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Layout : RenderingInstance<Scene>, IRenderingInstance<Layer>
	{
		private List<Layer> Objects = new List<Layer>();

		public Layer this[int i]
		{
			get
			{
				return Objects[i];
			}

			set
			{
				if (value.name == null)
					value.name = "Layout" + i;
				Objects[i] = value;
			}
		}

		public Layer this[string name]
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
