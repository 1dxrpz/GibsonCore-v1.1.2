using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Theatre : IRenderingInstance<Scene>
	{
		public Scene this[int i]
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public Scene this[string name]
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public List<Scene> Objects
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsVisible
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public Theatre parent
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public string name
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public void Add(Scene instance)
		{
			throw new NotImplementedException();
		}

		public void Add(string name)
		{
			throw new NotImplementedException();
		}

		public void Remove(Scene instance)
		{
			throw new NotImplementedException();
		}

		public void Render()
		{
			throw new NotImplementedException();
		}

		public void SetOrder()
		{
			throw new NotImplementedException();
		}
	}
}
