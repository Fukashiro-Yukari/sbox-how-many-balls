using Sandbox;

partial class HowManyBalls : Game
{
	private WallSpawner wallSpawner;

	public HowManyBalls()
	{
		if ( IsServer )
		{
			_ = new HowManyBallsHud();

			wallSpawner = new WallSpawner();
			wallSpawner.SpawnProps();
		}
	}

	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		var player = new HowManyBallsPlayer();
		client.Pawn = player;
	}

	public override void DoPlayerNoclip( Client player )
	{
	}
}
