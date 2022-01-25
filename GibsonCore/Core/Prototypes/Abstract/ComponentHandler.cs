using System;
using System.Collections.Generic;
using GibsonCore.Components;
using GibsonCore.Core;
using GibsonCore.Interfaces;
using Microsoft.Xna.Framework;

namespace GibsonCore.Abstract
{
	public abstract class ComponentHandler : ObjectParametrs, IDisposable
	{
		public readonly Dictionary<Type, IComponentObject> Components = new Dictionary<Type, IComponentObject>();
		public SceneManager sceneManager;

		private Scene _scene = GameEntry.scene;

		public ComponentHandler()
		{
			Transform _t = new Transform();
			_t.ParentObject = this;
			Components.Add(_t.GetType(), _t);
			_t.Init();
			Renderer _r = new Renderer();
			_r.ParentObject = this;
			Components.Add(_r.GetType(), _r);
			_r.Init();
		}
		public Scene Scene
		{
			get => _scene;
			set
			{
				foreach (var item in Components)
				{
					try
					{
						_scene.SceneDraw -= ((IDrawableObject)item.Value).Draw;
						value.SceneDraw += ((IDrawableObject)item.Value).Draw;
					}
					catch
					{

					}
					_scene.EnableChanged -= item.Value.EnableChanged;
					value.EnableChanged += item.Value.EnableChanged;

					_scene.SceneUpdate -= item.Value.Update;
					value.SceneUpdate += item.Value.Update;
					_scene = value;
				}
			}
		}

		public void AddComponent<T>() where T : DxComponent, new()
		{
			T _c = new T();
			_c.ParentObject = this;
			Components.Add(_c.GetType(), _c);
			_c.Init();
		}
		public void AddComponent(DxComponent c)
		{
			c.ParentObject = this;
			Components.Add(c.GetType(), c);
			c.Init();
		}
		public void RemoveComponent(DxComponent c)
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

		public void Dispose()
		{
			
		}
	}
}
