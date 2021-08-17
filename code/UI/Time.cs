using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;

public class Time : Panel
{
    public Label Label;
    public float time = 0f;

    public Time()
    {
        Label = Add.Label("", "value");
    }

    public override void Tick()
    {
        time += RealTime.Delta;

        var times = TimeSpan.FromSeconds((double)(new decimal(time)));

        Label.Text = $"Time: {times}";
    }
}