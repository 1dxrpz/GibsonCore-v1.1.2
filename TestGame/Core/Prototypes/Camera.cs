using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Core
{
	public class Camera : CameraBase
	{
		public Action IsShaking;

		public override Vector2 Position
		{
			get => base.Position;
			set => base.Position = value + shakingOffset;
		}

		private float _counter = 0;
		private float _duration = 0;
		private float _amplitude = 0;
		private float _scale = 1;
		private bool _shaking = false;
		Vector2 shakingOffset = Vector2.Zero;

		public void Shake(float dur, float amp, float sc)
		{
			_shaking = true;
			_duration = dur;
			_amplitude = amp;
			_scale = sc;
		}
		public override void Update()
		{
			if (!_shaking && Keyboard.GetState().IsKeyDown(Keys.C))
			{
				Shake(100f, 2f, .1f);
			}
			if (_shaking)
			{
				IsShaking?.Invoke();
				shakingOffset.X = MathF.Sin(_counter / _amplitude);
				shakingOffset.Y = MathF.Cos(_counter / _amplitude);
				_counter += _scale;
				if (_counter >= _duration)
				{
					_shaking = false;
					_counter = 0;
					shakingOffset = Vector2.Zero;
				}
			}
			base.Update();
		}
	}
	public abstract class CameraBase
	{
		public Action EnableChanged;
		private bool _enabled = true;
		public CameraBase()
		{
			GameManager.UpdateEvent += Update;
		}
		public virtual Vector2 Position { get; set; }

		public bool Enabled
		{
			get => _enabled;
			set {
				EnableChanged?.Invoke();
				_enabled = value;
			}
		}
		public virtual void Update() { }
	}
}
