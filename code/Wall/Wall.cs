using Sandbox;
using System.Collections.Generic;

public partial class Wall : Prop
{
	public List<Wall> Walls;
	public bool isGround;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/room.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Static );
		EnableDrawing = false;
	}

	public void CreateNextWall()
	{
		if ( isGround ) return;

		var wall = new Wall()
		{
			Position = Position + new Vector3( 0, 0, 400 ),
			Rotation = Rotation,
			Walls = Walls,
			EnableDrawing = EnableDrawing
		};

		Walls.Add( wall );
	}
}
