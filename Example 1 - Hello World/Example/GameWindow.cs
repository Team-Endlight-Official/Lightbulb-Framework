using Lightbulb;
using Lightbulb.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Endlight.Example;

public class GameWindow
{
    int width = 800;
    int height = 600;
    string title = "Example 1. Hello World";

    Application application;

    public GameWindow()
    {
        application = new Application();
        application.OnInit += Init;
        application.OnLoad += Load;
        application.OnUpdate += Update;
        application.OnDraw += Draw;
        application.OnClose += Unload;

        application.Run();
    }

    void Init()
    {
        Renderer.Init(application);
        application.SetSize(width, height);
        application.SetTitle(title);
    }

    void Load()
    {
        Console.WriteLine("Hello my Window!");
    }

    void Update()
    {

    }

    void Draw()
    {
        Renderer.Clear(Color.Blue);
    }

    void Unload()
    {
        Console.WriteLine("Goodbye my Window!");
    }
}
