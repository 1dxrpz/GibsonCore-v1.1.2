using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Enums;

namespace GameEngineTK.Engine.Rendering
{
	public class Layout
	{
		
		public VisibleState isVisible = VisibleState.Visible;
		public List<Layer> Objects = new List<Layer>();

		public Scene Parent;
		public string Name;
		public string name
		{
			get
			{
				return Name;
			}
			set
			{
				if (Parent.Objects.FindIndex(v => v.Name == value) != -1)
					throw new Exception($"Layer with name {value} already exists.");
				Name = value;
			}
		}
		public Layout(string name = null)
		{
			this.Name = name;
		}
		public void Add(Layer instance)
		{
			instance.Parent = this;
			if (Objects.FindIndex(v => v.name == instance.name) != -1)
				throw new Exception($"Layer with name {instance.name} already exists.");
			else
			{
				if (instance.name == null)
					instance.name = "Unnamed Layer " + Objects.Count;

				Objects.Add(instance);
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
				Add(value);
			}
		}
		public Layer this[int i]
		{
			get
			{
				return Objects[i];
			}
			set
			{
				if (Objects.FindIndex(v => v.name == value.name) != -1)
					throw new Exception($"Layer with name {value.name} already exists.");
				else
					Objects[i] = value;
			}
		}

		public void Remove()
		{
			Parent.Remove(this);
		}
		public void Remove(int i)
		{
			Objects.RemoveAt(i);
		}
		public void Remove(string name)
		{
			Objects.Remove(Objects.Find(v => v.name == name));
		}
		public void Remove(Layer l)
		{
			Objects.Remove(l);
		}
		public void MoveTo(int index)
		{
			Parent.Objects[Parent.Objects.FindIndex(v => v == this)] = Parent.Objects[index];
			Parent.Objects[index] = this;
		}
	}
}
