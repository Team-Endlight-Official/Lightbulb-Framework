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

    // Define a Application variable.
    Application application;

    public GameWindow()
    {
        // Create a new instance of the application and assign it's action methods.
        application = new Application();
        application.OnInit += Init;
        application.OnLoad += Load;
        application.OnUpdate += Update;
        application.OnDraw += Draw;
        application.OnClose += Unload;

        // At last run the app.
        application.Run();
    }

    void Init()
    {
        // Here you initialize your scripts and mechanics, not assets and resources.
        // Initialize the static Renderer. IMPORTANT as setting fullscreen, size and other graphics resizing depends on the Renderer.
        // It's also possible to set these by "Renderer.SetSize(width, height);".
        Renderer.Init(application);
        application.SetSize(width, height);
        application.SetTitle(title);
    }

    void Load()
    {
        // Here you load your resources/assets.
        Console.WriteLine("Hello my Window!");
    }

    void Update()
    {

    }

    void Draw()
    {
        // Clear the Renderer before drawing anything.
        Renderer.Clear(Color.Blue);
    }

    void Unload()
    {
        // Unload all your remaining resources to prevent memory leaking.
        Console.WriteLine("Goodbye my Window!");
    }
}
