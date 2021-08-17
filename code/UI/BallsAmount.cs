using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Linq;

public class BallsAmount : Panel
{
    public Label Label;

    public BallsAmount()
    {
        Label = Add.Label("", "value");
    }

    public override void Tick()
    {
        Label.Text = $"Count: {Entity.All.OfType<Prop>().Where(x => x.GetModelName() == "models/citizen_props/beachball.vmdl").Count()}";
    }
}