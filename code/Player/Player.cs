using Sandbox;
using System;
using System.Linq;

partial class HowManyBallsPlayer : Player
{
    public override void Respawn()
    {
        Camera = new ObserveCamera();

        base.Respawn();
    }
}