using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Layout : RenderingInstance<Scene>, IRenderingInstance<Layer>
	{
		private List<Layer> Objects = new List<Layer>();
		public List<Layer> GetObjects { get { return Objects; } }
		public Layer this[int i]
		{
			get
			{
				return Objects[i];
			}

			set
			{
				if (Objects.FindIndex(v => v.name == value.name) != -1)
					throw new Exception($"Layer {value.name} already exists.");
				if (value.name == null)
					value.name = "Layer" + i;
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
				if (Objects.FindIndex(v => v.name == value.name) != -1)
					throw new Exception($"Layer {value.name} already exists.");
				Objects[Objects.FindIndex(v => v.name == name)] = value;
			}
		}

		public void Add(Layer instance)
		{
			if (Objects.FindIndex(v => v.name == instance.name) != -1)
				throw new Exception($"Layer {instance.name} already exists.");
			if (instance.name == null)
			{
				instance.name = "Layer" + Objects.Count;
			}
			instance.parent = this;
			Objects.Add(instance);
		}

		public void Add(string name)
		{
			if (Objects.FindIndex(v => v.name == name) != -1)
				throw new Exception($"Layer {name} already exists.");
			Layer t = new Layer();
			t.name = name;
			t.parent = this;
			Objects.Add(t);
		}

		public void Remove(string name)
		{
			Objects.Remove(this[name]);
		}

		public void Remove(Layer instance)
		{
			Objects.Remove(instance);
		}
		public void Remove()
		{
			parent.Remove(this);
		}

		public void Render()
		{

		}

		public void SetOrder(int i)
		{
			parent.InsertObject(i, this);
			
		}
		public void InsertObject(int i, Layer l)
		{
			Objects.Remove(l);
			Objects.Insert(i, l);
		}
	}
}
