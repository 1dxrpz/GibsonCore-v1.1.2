using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes;
using GameEngineTK.Engine.Prototypes.Enums;
using GameEngineTK.Engine.Prototypes.Interfaces;
using GameEngineTK.Engine.Rendering;
using GameEngineTK.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class GameObject : ComponentHandler//, IGameInstances
	{
		private Texture2D texture;
		private TextureHandler vtexture;

		public GameObject()
		{
			AddComponent(new Transform());
			AddComponent(new Renderer());
			
			texture = null;
			this.EnsureDefaults();

		}
		public GameObject(Texture2D texture)
		{
			AddComponent(new Transform());
			AddComponent(new Renderer());

			this.texture = texture;
			this.EnsureDefaults();
		}
		public GameObject(TextureHandler vtexture)
		{
			AddComponent(new Transform());
			AddComponent(new Renderer());

			this.vtexture = vtexture;
			EnsureDefaults();
		}
		public void EnsureDefaults()
		{
			var config = ConfigReader.Parse("project");
			if (config.ContainsKey("EnsureDefaults") && ConfigReader.GetBool(config, "EnsureDefaults"))
			{
				//ScriptManager.DefaultLayer.Add(this);
			}
		}

		public Texture2D Texture {
			get { return texture; }
			set {
				this.GetComponent<Animation>().SpriteSheet = value;
				texture = value;
			}
		}
		public TextureHandler VTexture {
			get { return vtexture; }
			set
			{
				this.GetComponent<Animation>().SpriteSheet = value.ToTexture2D();
				vtexture = value;
			}
		}

		/*
		private Layer ParentLayer;
		private string InstanceName;
		public Layer Parent
		{
			get
			{
				return ParentLayer;
			}

			set
			{
				ParentLayer = value;
			}
		}
		public string name
		{
			get
			{
				return InstanceName;
			}

			set
			{
				
				InstanceName = value;
			}
		}
		
		public void MoveTo(int index)
		{
			Parent.Objects[Parent.Objects.FindIndex(v => v == this)] = Parent.Objects[index];
			Parent.Objects[index] = this;
		}
		*/

		#region TEST THIS OPTION FOR OPTIMISATION ISSUES
		public float Distance(GameObject obj)
		{
			return 1;
		}
		/*
		 * the fuck is this
		 */
		public float VDistance(GameObject obj)
		{
			Vector2 opos = obj.GetComponent<Transform>().Position;
			Vector2 pos = this.GetComponent<Transform>().Position;
			return Vector2.Distance(opos, pos);
		}
		#endregion

		public void Draw()
		{
			
		}
	}
}