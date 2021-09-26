using Sandbox;

public partial class Top : AnimEntity
{
	public WallSpawner wallSpawner;

	TimeSince timeSinceMoveUp;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/room.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Static );

		EnableAllCollisions = false;
		EnableDrawing = false;
		EnableTouch = true;
		EnableTouchPersists = true;
	}

	public void MoveUp()
	{
		Position += new Vector3( 0, 0, 400 );
	}

	public override void StartTouch( Entity other )
	{
		if ( wallSpawner == null || other is Wall || timeSinceMoveUp < 2 ) return;

		timeSinceMoveUp = 0f;

		wallSpawner.MoveUp();
	}
}
