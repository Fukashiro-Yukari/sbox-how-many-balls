using Sandbox;
using Sandbox.UI;

[Library]
public partial class HowManyBallsHud : HudEntity<RootPanel>
{
    public HowManyBallsHud()
    {
        if (!IsClient)
            return;

        RootPanel.StyleSheet.Load("/UI/Hud.scss");

        RootPanel.AddChild<BallsAmount>();
    }
}