using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace GameEngineTK.Engine.Utils
{
	public static class KeyboardHandler
	{
		static KeyboardState currentKeyState;
		static KeyboardState previousKeyState;

		public static KeyboardState GetState()
		{
			previousKeyState = currentKeyState;
			currentKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
			return currentKeyState;
		}

		public static bool IsPressed(Keys key)
		{
			return currentKeyState.IsKeyDown(key);
		}

		public static bool IsKeyPressed(Keys key)
		{
			return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
		}
	}
}
