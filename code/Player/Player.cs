using Sandbox;

partial class HowManyBallsPlayer : Entity
{
	public HowManyBallsPlayer()
	{
		Camera = new ObserveCamera();
		Transmit = TransmitType.Always;
	}
}
