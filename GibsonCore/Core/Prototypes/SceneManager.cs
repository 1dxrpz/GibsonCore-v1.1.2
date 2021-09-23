using System;
using System.Collections.Generic;
using System.Text;

namespace GibsonCore.Core
{
	public class SceneManager
	{
		private int _currentScene = 0;
		public int CurrentScene
		{
			get => _currentScene;
		}
		private List<Scene> _scenes = new List<Scene>();
		public Action SceneChanged;

		public SceneManager()
		{
			GameManager.UpdateEvent += UpdateCurrentScene;
			GameManager.DrawtEvent += DrawCurrentScene;
		}
		public void LoadScene(int id)
		{
			_scenes[_currentScene].IsEnabled = false;
			_currentScene = id;
			_scenes[id].IsEnabled = true;
			SceneChanged?.Invoke();
		}

		private void DrawCurrentScene()
		{
			_scenes[_currentScene].SceneDraw?.Invoke();
		}
		
		private void UpdateCurrentScene()
		{
			_scenes[_currentScene].SceneUpdate?.Invoke();
		}

		public void Add(Scene scene)
		{
			_scenes.Add(scene);
		}
		public void Remove(Scene scene)
		{
			_scenes.Remove(scene);
		}
	}
}
