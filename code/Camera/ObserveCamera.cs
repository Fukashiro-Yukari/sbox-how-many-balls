
using System;
using System.Linq;

namespace Sandbox
{
	public class ObserveCamera : Camera
	{
		private float distance = 15f;
		private Vector3 LerpPos;

		public override void Update()
		{
			var ballspawner = Entity.All.OfType<BallSpawner>().FirstOrDefault();

			if (ballspawner == null)
				return;

			Rot = Input.Rotation;

			if (LerpPos.IsNaN)
				LerpPos = ballspawner.Position;

			LerpPos = Vector3.Lerp(LerpPos, ballspawner.Position, Time.Delta);
			Pos = LerpPos + Rot.Backward * 64 * distance;

			FieldOfView = 70;

			Viewer = null;
		}

		public override void BuildInput(InputBuilder input)
		{
			base.BuildInput(input);

			distance = Math.Clamp(distance - input.MouseWheel, 8f, 40f);

			if (input.Pressed(InputButton.Reload))
				distance = 15f;
		}
	}
}
