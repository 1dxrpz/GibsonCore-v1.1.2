using GameEngineTK.Engine;
using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Scripts
{
	public class CameraScript : DxScript
	{
		Transform player;
		public override void Start()
		{
			player = PlayerScript.Player.GetComponent<Transform>();
		}
		public override void Update()
		{
			Vector2 pos = player.Position;
			Camera.Position = Vector2.Lerp(Camera.Position,
				pos - new Vector2(
					1920 / 2,// - player.Width / 2,
					1080 / 2),// - player.Height / 2),
				.005f * Time.deltaTime);
		}
	}
}
