using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Layer : RenderingInstance<Layout>, IRenderingInstance<IGameInstances>
	{
		private List<IGameInstances> Objects = new List<IGameInstances>();
		public List<IGameInstances> GetObjects { get { return Objects; } }
		public Layer(string name = null)
		{
			if (name == null)
				this.name = "EmptyGameObject" + Objects.Count;
			else if (Objects.FindIndex(v => v.name == name) != -1)
				throw new ArgumentException($"GameInstance {name} already exists");
			this.name = name;
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
					throw new ArgumentException($"GameInstance {value.name} already exists");
				if (value.name == null) value.name = "UnnamedGameInstance" + parent.GetObjects.Count;
				Objects[i] = value;
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
				if (Objects.FindIndex(v => v.name == name) != -1)
					throw new ArgumentException($"GameInstance {name} already exists");

				Objects[Objects.FindIndex(v => v.name == name)] = value;
			}
		}

		public void Add(IGameInstances instance)
		{
			if (Objects.FindIndex(v => v.name == instance.name) != -1)
				throw new ArgumentException($"GameInstance {instance.name} already exists");
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
				throw new ArgumentException($"GameInstance {name} already exists");
			IGameInstances t = new GameObject();
			t.name = name;
			t.parent = this;
			Objects.Add(t);
		}

		public void Remove(string name)
		{
			Objects.Remove(this[name]);
		}

		public void Remove(IGameInstances instance)
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

		public void InsertObject(int i, IGameInstances l)
		{
			Objects.Remove(l);
			Objects.Insert(i, l);
		}
	}
}