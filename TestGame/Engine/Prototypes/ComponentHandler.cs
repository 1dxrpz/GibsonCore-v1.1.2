using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Prototypes
{
	public abstract class ComponentHandler : ObjectParametrs
	{
		public readonly Dictionary<Type, IComponentInstance> Components = new Dictionary<Type, IComponentInstance>();
		public void AddComponent(IComponentInstance c)
		{
			c.ParentObject = this;
			Components.Add(c.GetType(), c);
			c.Init();
		}
		public void RemoveComponent(IComponentInstance c)
		{
			Components.Remove(c.GetType());
		}

		public T GetComponent<T>()
		{
			return (T)Components[typeof(T)];
		}
		public bool HasComponent<T>()
		{
			return Components.ContainsKey(typeof(T));
		}
	}
}
