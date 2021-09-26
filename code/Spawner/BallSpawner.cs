using Sandbox;
using System.Collections.Generic;

public partial class BallSpawner : Prop
{
	public static List<Prop> Balls = new();

	[Net, Predicted]
	public static int BallsCount { get; set; }

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/ball/ball.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Static );
		EnableAllCollisions = false;
		EnableDrawing = false;
	}

	private void SpawnBall()
	{
		var ball = new Prop()
		{
			Position = Position,
			//Scale = 5
		};

		ball.SetModel( "models/citizen_props/beachball.vmdl" );
		ball.Position -= (Vector3.Up * ball.CollisionBounds.Maxs.z) * Scale;

		Balls.Add( ball );
	}

	[Event.Tick.Server]
	private void OnTick()
	{
		SpawnBall();
		BallsCount = Balls.Count;
	}

	public void MoveUp()
	{
		Position += new Vector3( 0, 0, 400 );
	}
}
