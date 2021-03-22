using System;
using System.Threading.Tasks;
using GameEngineTK.Engine;
using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PerlinNoise;
using PerlinNoise.Filters;
using PerlinNoise.Transformers;

namespace GameEngineTK.Scripts
{
	class NoiseScript : IScriptManager
	{
		/// <summary>
		/// Current script's entry point
		/// </summary>
		NoiseField<float> perlinNoise;
		Texture2D noiseTexture;
		public void GenerateNoiseTexture()
		{
			PerlinNoiseGenerator gen = new PerlinNoiseGenerator();
			gen.Interpolation = InterpolationAlgorithms.CosineInterpolation;

			gen.OctaveCount = 10;
			gen.Persistence = .5f;

			//perlinNoise = gen.GeneratePerlinNoise(512, 512);
			perlinNoise = gen.GeneratePerlinNoise(500, 500);


			CustomGradientColorFilter filter = new CustomGradientColorFilter();
			Texture2DTransformer transformer = new Texture2DTransformer(ScriptManager.graphicsDevice);

			filter.AddColorPoint(0.0f, 0.40f, Color.Blue);
			filter.AddColorPoint(0.4f, 0.50f, Color.Yellow);
			filter.AddColorPoint(0.50f, 0.70f, Color.Green);
			filter.AddColorPoint(0.70f, 0.90f, Color.SaddleBrown);
			filter.AddColorPoint(0.90f, 1.00f, Color.White);

			//filter.StartColor = Color.White;
			//filter.EndColor = new Color(0, 0, 0, 0);
			//filter.StartPercentage = .5f;

			noiseTexture = transformer.Transform(filter.Filter(perlinNoise));
		}
		GameObject noise;
		bool generated = false;
		public void Start()
		{
			this.GenerateNoiseTexture();
			// Here's your Initialize code
			noise = new GameObject(noiseTexture);
			noise.GetComponent<Transform>().Position = new Vector2(500, 0);
		}
		/// <summary>
		/// Method that updates script every tick
		/// </summary>
		public void Update()
		{
			if (Keyboard.GetState().IsKeyDown(Keys.F) && !generated)
			{
				Task.Run(GenerateNoiseTexture);
				generated = true;
			}
			else if (Keyboard.GetState().IsKeyUp(Keys.F))
			{
				generated = false;
			}
			noise.GetComponent<Animation>().SpriteSheet = noiseTexture;
			noise.Draw();
			// Here's your Update code
		}
	}
}
