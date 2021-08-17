
using Sandbox;
using System.Collections.Generic;

[Library("howmanyballs", Title = "How many balls ?")]
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

		player.Respawn();
	}

	public override void DoPlayerNoclip(Client player)
    {
		if (ConsoleSystem.GetValue("sv_cheats") == "0") return;
		if (player.Pawn is Player basePlayer)
		{
			if (basePlayer.DevController is NoclipController)
			{
				Log.Info("Noclip Mode Off");
				basePlayer.DevController = null;
			}
			else
			{
				Log.Info("Noclip Mode On");
				basePlayer.DevController = new NoclipController();
			}
		}
	}
}
