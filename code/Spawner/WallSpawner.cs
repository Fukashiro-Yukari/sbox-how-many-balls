using Sandbox;
using System.Collections.Generic;

public class WallSpawner
{
	private Wall Ground;
	private Top TopEnt;
	private BallSpawner ballSpawner;

	static List<Wall> Walls = new();
	static List<Wall> Walls2 = new();
	static List<Wall> Walls3 = new();
	static List<Wall> Walls4 = new();

	bool isSpawn = false;

	public WallSpawner()
	{
		ballSpawner = new BallSpawner()
		{
			Position = new Vector3( 0, 0, 300 )
		};
	}

	public void SpawnProps()
	{
		if ( isSpawn )
		{
			ReSpawnProps();
			return;
		}

		isSpawn = true;

		Ground = new Wall()
		{
			Position = new Vector3(),
			isGround = true,
		};

		TopEnt = new Top()
		{
			Position = new Vector3( 0, 0, 400 ),
			wallSpawner = this
		};

		var wall1 = new Wall()
		{
			Position = new Vector3( 0, 200, 200 ),
			Rotation = Rotation.From( new Angles( 0, 0, 90 ) ),
			Walls = Walls
		};

		Walls.Add( wall1 );

		var wall2 = new Wall()
		{
			Position = new Vector3( 0, -200, 200 ),
			Rotation = Rotation.From( new Angles( 0, 0, 90 ) ),
			Walls = Walls2
		};

		Walls2.Add( wall2 );

		var wall3 = new Wall()
		{
			Position = new Vector3( 200, 0, 200 ),
			Rotation = Rotation.From( new Angles( 90, 0, 0 ) ),
			Walls = Walls3
		};

		Walls3.Add( wall3 );

		var wall4 = new Wall()
		{
			Position = new Vector3( -200, 0, 200 ),
			Rotation = Rotation.From( new Angles( 90, 0, 0 ) ),
			Walls = Walls4
		};

		Walls4.Add( wall4 );
	}

	public void ReSpawnProps()
	{
		Ground?.Delete();

		foreach ( var wall in Walls )
		{
			wall.Delete();
		}

		Walls.Clear();

		foreach ( var wall in Walls2 )
		{
			wall.Delete();
		}

		Walls2.Clear();

		foreach ( var wall in Walls3 )
		{
			wall.Delete();
		}

		Walls3.Clear();

		foreach ( var wall in Walls4 )
		{
			wall.Delete();
		}

		Walls4.Clear();

		SpawnProps();
	}

	public void CreateNextWall()
	{
		if ( Walls.Count < 1 )
			ReSpawnProps();

		Walls[Walls.Count - 1].CreateNextWall();
		Walls2[Walls2.Count - 1].CreateNextWall();
		Walls3[Walls3.Count - 1].CreateNextWall();
		Walls4[Walls4.Count - 1].CreateNextWall();
	}

	public void MoveUp()
	{
		TopEnt.MoveUp();
		ballSpawner.MoveUp();
		CreateNextWall();
	}
}
