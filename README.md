# Lightbulb Framework
A powerful extension to MonoGame for absolute beginners or complete professionals. The intuitive API structure relies on user control and accessibility - making it suitable for **nearly** all MonoGame project types.

## Dependencies
Lightbulb hugely depends on these packages/sub-frameworks:
* MonoGame 3.8.x
* JoltPhysicsSharp 2.16.x

## Learning Curve
Lightbulb has been designed that the simple low-effort rendering stuff take less than 45+ lines to write. The learning curve might be steeper and steeper for more advanced topics in hand.

## Examples?
The Lightbulb source-code somes not only with the full API source, but also the source-codes of all Examples that are also fairly commented and documented. You can use these Example source-codes as a cheatsheet or as a learning material to guide you.

## Goal?
Lightbulb aims to become a "standard" for new complete beginners that want to learn C# and MonoGame while having all the complex stuff such as graphics, cross-platforming, etc.. out of hand.

## Example 1 Result
![image](https://github.com/user-attachments/assets/c114ba15-95ba-42fb-a581-77928ffdcd96)
A simple game window that shows a small window with a blue background color.

Thats how simple it is to create a basic application. Clean, readable and portable.
```c#
﻿using Lightbulb;
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
```
