﻿using Microsoft.Xna.Framework;
using GibsonCore.Core;
using Microsoft.Xna.Framework.Input;
using GibsonCore.Interfaces;
using GibsonCore.Abstract;
using GibsonCore.Components;
using GibsonCore.Utils;
using System;

namespace GameEngineTK.Scripts
{
	class CursorScript : DxScript
	{
		TextureHandler cursorTexture = new TextureHandler(@"\TestGame\Content\CursorSpriteSheet.png");
		public static GameObject Cursor;
		
		public override void Start()
		{
			ScriptManager.Services.GetService<ProjectSettings>().ShowColliders = true;
			Cursor = new GameObject();
			Cursor.AddComponent(new Animation());
			
			Cursor.GetComponent<Animation>().SpriteSheet = cursorTexture.ToTexture2D();
			Cursor.GetComponent<Animation>().Width = 32;
			Cursor.GetComponent<Animation>().Height = 38;
			
			

			Cursor.GetComponent<Animation>().FrameCount = 2;
			Cursor.GetComponent<Animation>().FrameSize = new Point(16, 21);
			Cursor.GetComponent<Animation>().AnimationSpeed = 0;
			Cursor.GetComponent<Transform>().Parallax = new Vector2(0, 0);
			Cursor.GetComponent<Renderer>().LayerDepth = 1;
			
		}

		public override void Update()
		{
			Cursor.GetComponent<Animation>().CurrentFrame = Mouse.GetState().LeftButton == ButtonState.Pressed ? 1 : 0;
			Cursor.GetComponent<Transform>().Position = Mouse.GetState().Position.ToVector2();
		}
		
	}
}
