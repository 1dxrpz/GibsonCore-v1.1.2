using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Enums;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	abstract public class RenderingInstance
	{
		public string Name;

		public List<RenderingInstance> Children = new List<RenderingInstance>();
		public RenderingInstance Parent;
		public VisibleState IsVisible = VisibleState.Visible;

		public RenderingInstance this[int i]
		{
			get
			{
				return Children[i];
			}

			set
			{
				if (Children.FindIndex(v => (v).Name == value.Name) != -1)
					ThrowExistException(value);
				if (value.Name == null)
					value.Name = "Unnamed GameInstance" + Parent.Children.Count;
				Children[i] = value;
			}
		}
		public void Add<C>(RenderingInstance i)
		{
			if (Children.Contains(i)) ThrowExistException(i);
			//else if () throw new Exception();
			else Children.Add(i);
		}
		public void ThrowExistException(RenderingInstance i)
		{
			throw new Exception($"{i.GetType().Name} '{i.Name}' already exists;");
		}
		/*
		public List<Child> GetObjects { get; }
		public Child this[int i]
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

		public Child this[string name]
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

		public void Add(Child instance)
		{
			if (Objects.FindIndex(v => v.name == instance.name) != -1)
				throw new ArgumentException($"GameInstance {instance.name} already exists");
			if (instance.name == null)
			{
				instance.name = "Layout" + Objects.Count;
			}
			instance.parent = (Parent)this;
			Objects.Add(instance);
		}
		/*
		public void Add(string name)
		{
			if (Objects.FindIndex(v => v.name == name) != -1)
				throw new ArgumentException($"GameInstance {name} already exists");
			Child t = new RenderingInstance<>();
			t.name = name;
			t.parent = this;
			Objects.Add(t);
		}
		
		public void Remove(string name)
		{
			Objects.Remove(this[name]);
		}

		public void Remove(Child instance)
		{
			Objects.Remove(instance);
		}
		public void Remove()
		{
			parent.Remove((Child)this);
		}

		public void SetOrder(int i)
		{
			parent.InsertObject(i, (Child)this);
		}

		public void InsertObject(int i, Child l)
		{
			Objects.Remove(l);
			Objects.Insert(i, l);
		}
		public virtual void Render()
		{

		}
		*/
	}
}
