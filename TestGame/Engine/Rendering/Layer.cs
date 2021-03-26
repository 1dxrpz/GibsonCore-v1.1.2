using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Enums;
using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Engine.Rendering
{
	public class Layer
	{
		public Vector2 Parallax = Vector2.One;
		public VisibleState isVisible = VisibleState.Visible;

		public List<IGameInstances> Objects = new List<IGameInstances>();
		public Layout Parent;
		public string Name;
		public string name
		{
			get
			{
				return Name;
			}
			set
			{
				if (Parent.Objects.FindIndex(v => v.name == value) != -1)
					throw new Exception($"Object with name {value} already exists.");
				Name = value;
			}
		}
		public Layer(string name = null)
		{
			Name = name;
		}
		public void Add(IGameInstances instance)
		{
			instance.Parent = this;
			if (Objects.FindIndex(v => v.name == instance.name) != -1)
				throw new Exception($"Object with name {instance.name} already exists.");
			else
			{
				if (instance.name == null)
					instance.name = "Unnamed Object " + Objects.Count;

				Objects.Add(instance);
			}
		}
		public IGameInstances this[string name]
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
		public IGameInstances this[int i]
		{
			get
			{
				return Objects[i];
			}
			set
			{
				if (Objects.FindIndex(v => v.name == value.name) != -1)
					throw new Exception($"Object with name {value.name} already exists.");
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
		public void Remove(IGameInstances instance)
		{
			Remove(instance.name);
		}
		public void MoveTo(int index)
		{
			Parent.Objects[Parent.Objects.FindIndex(v => v == this)] = Parent.Objects[index];
			Parent.Objects[index] = this;
		}
	}
}
