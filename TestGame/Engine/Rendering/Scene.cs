using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Scene : IRenderingInstance<Layout>
	{
		public string name;
		public bool IsVisible;

		public Scene(string name = null)
		{
			if (name == null) this.name = "Scene" + Theatre.ObjectsCount;
			else this.name = name;
			Theatre.Add(this);
		}

		private List<Layout> Objects = new List<Layout>();
		public List<Layout> GetObjects { get { return Objects; } }
		public Layout this[int i]
		{
			get
			{
				return Objects[i];
			}

			set
			{
				if (Objects.FindIndex(v => v.name == value.name) != -1)
					throw new Exception($"Layout {value.name} already exists.");
				if (value.name == null)
					value.name = "Layout" + i;
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
				if (Objects.FindIndex(v => v.name == name) != -1)
					throw new Exception($"Layout {name} already exists.");
				Objects[Objects.FindIndex(v => v.name == name)] = value;
			}
		}

		public void Add(Layout instance)
		{
			if (Objects.FindIndex(v => v.name == instance.name) != -1)
				throw new Exception($"Layout {instance.name} already exists.");
			if (instance.name == null)
			{
				instance.name = "Layout" + Objects.Count;
			}
			instance.parent = this;
			Objects.Add(instance);
		}

		public void Add(string name)
		{
			if (Objects.FindIndex(v => v.name == name) != -1)
				throw new Exception($"Layout {name} already exists.");
			Layout t = new Layout();
			t.name = name;
			t.parent = this;
			Objects.Add(t);
		}

		public void Remove(string name)
		{
			Objects.Remove(this[name]);
		}

		public void Remove(Layout instance)
		{
			Objects.Remove(instance);
		}
		public void Remove()
		{
			Theatre.Remove(this);
		}

		public void Render()
		{
			
		}

		public void SetOrder()
		{
			throw new NotImplementedException();
		}

		public void SetOrder(int i)
		{
			Theatre.InsertObject(i, this);
		}

		public void InsertObject(int i, Layout l)
		{
			Objects.Remove(l);
			Objects.Insert(i, l);
		}
	}
}
