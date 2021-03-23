using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Enums;

namespace GameEngineTK.Engine.Rendering
{
	public class Scene
	{
		public VisibleState isVisible = VisibleState.Visible;
		public List<Layout> Objects = new List<Layout>();

		public string Name;
		public string name
		{
			get
			{
				return Name;
			}
			set
			{
				if (Theatre.Scenes.FindIndex(v => v.name == value) != -1)
					throw new Exception($"Scene with name {value} already exists.");
				Name = value;
			}
		}
		public Scene()
		{
			name = "Unnamed Scene " + Theatre.Scenes.Count;
			Theatre.Add(this);
		}
		public Scene(string name)
		{
			this.name = name;
			Theatre.Add(this);
		}
		public void Add(Layout instance)
		{
			instance.Parent = this;
			if (Objects.FindIndex(v => v.name == instance.name) != -1)
				throw new Exception($"Layout with name {instance.name} already exists.");
			else
			{
				if (instance.name == null)
					instance.name = "Unnamed Layout " + Objects.Count;
				
				Objects.Add(instance);
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
				Add(value);
			}
		}
		public Layout this[int i]
		{
			get
			{
				return Objects[i];
			}
			set
			{
				if (Objects.FindIndex(v => v.name == value.name) != -1)
					throw new Exception($"Layout with name {value.name} already exists.");
				else
					Objects[i] = value;
			}
		}

		public void Remove()
		{
			Theatre.Remove(this);
		}
		public void Remove(int i)
		{
			Objects.RemoveAt(i);
		}
		public void Remove(string name)
		{
			Objects.Remove(Objects.Find(v => v.name == name));
		}
		public void Remove(Layout l)
		{
			Objects.Remove(l);
		}
		public void MoveTo(int index)
		{
			Theatre.Scenes[Theatre.Scenes.FindIndex(v => v == this)] = Theatre.Scenes[index];
			Theatre.Scenes[index] = this;
		}
	}
}
