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
	/*
	 * first of all get rid wrong level of abstraction
	 * 
	 * remove this abomination from gameobject
	 */
	public class GameObject : ComponentHandler, IGameInstances
	{
		private Texture2D texture;
		private TextureHandler vtexture;

		/*
		 * why the hell do you need to call instance with this parametrs
		 */
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
				ScriptManager.DefaultLayer.Add(this);
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

		// holy shit
		public SpriteEffects Flip = SpriteEffects.None;
		private readonly List<VisualEffect> Effects = new List<VisualEffect>();

		// WHYY???
		public bool AddEffect(VisualEffect e)
		{
			if (HasEffect(e))
				return false;
			Effects.Add(e);
			return true;
		}
		public bool RemoveEffect(VisualEffect e)
		{
			if (!HasEffect(e))
				return false;
			Effects.Remove(e);
			return true;
		}
		public bool HasEffect(VisualEffect e)
		{
			return Effects.Contains(e);
		}

		#region MAKE FUNCTIONS COMPONENT
		public bool OnObjectClicked()
		{
			bool MouseDown = this.MouseDown;
			if (Mouse.GetState().LeftButton == ButtonState.Pressed && MouseDown)
				return false;
			else
			{
				if (!MouseDown && this.IsHover() && Mouse.GetState().LeftButton == ButtonState.Pressed)
					MouseDown = true;
			}
			return MouseDown;
		} // crap
		#endregion

		public bool OnObjectDragging()
		{
			
			if (this.IsHover() && Mouse.GetState().LeftButton == ButtonState.Released)
				onHover = true;
			else if (Mouse.GetState().LeftButton == ButtonState.Released)
				onHover = false;
			return onHover && Mouse.GetState().LeftButton == ButtonState.Pressed && isVisible == VisibleState.Visible;
		}
		public bool IsHover()
		{
			Transform _t = this.GetComponent<Transform>();
			Vector2 pos = _t.Position;
			return Mouse.GetState().X > pos.X &&
				Mouse.GetState().X < pos.X + _t.Width &&
				Mouse.GetState().Y > pos.Y &&
				Mouse.GetState().Y < pos.Y + _t.Width && isVisible == VisibleState.Visible;
		}

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