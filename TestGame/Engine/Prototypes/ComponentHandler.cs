using System;
using System.Collections.Generic;
using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Prototypes
{
	public abstract class ComponentHandler : ObjectParametrs
	{
		public readonly Dictionary<Type, IComponentObject> Components = new Dictionary<Type, IComponentObject>();
		public void AddComponent(IComponentObject c)
		{
			c.ParentObject = this;
			Components.Add(c.GetType(), c);
			c.Init();
		}
		public void RemoveComponent(IComponentObject c)
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
