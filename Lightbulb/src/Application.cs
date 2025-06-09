using Lightbulb.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Lightbulb;

/// <summary>
/// The Main to go for all Games made in Ligthbulb/MonoGame.
/// </summary>
public class Application : Game
{
    // private members
    private GraphicsDeviceManager m_GraphicsManager;

    // public members

    /// <summary>
    /// Initialization of the Application. create, add and manage on startup your codes here. Do not load assets here.
    /// Asset loading is for OnLoad.
    /// </summary>
    public Action OnInit;

    /// <summary>
    /// Method to load your resources.
    /// </summary>
    public Action OnLoad;

    /// <summary>
    /// Manage your GameLoop, Input and Logic in here. DO NOT use the OnDraw method to manage other stuff.
    /// </summary>
    public Action OnUpdate;

    /// <summary>
    /// Manage your Rendering.
    /// </summary>
    public Action OnDraw;

    /// <summary>
    /// Method that will be called whenever the Application closes/unloads. Use this to delete remaining resources to prevent leaking.
    /// </summary>
    public Action OnClose;

    /// <summary>
    /// Event that gets invoked whenever the Application is resized. Pretty convenient for certain calculations that happen only when resizing.
    /// </summary>
    public EventHandler<EventArgs> OnResize;

    /// <summary>
    /// The Main to go for all Games made in Ligthbulb/MonoGame.
    /// </summary>
    public Application()
    {
        m_GraphicsManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }


    protected override void Initialize()
    {
        if (OnResize != null) Window.ClientSizeChanged += OnResize;
        if (OnInit != null) OnInit();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        if (OnLoad != null) OnLoad();
    }

    protected override void Update(GameTime gameTime)
    {
        if (OnUpdate != null) OnUpdate();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if (OnDraw != null) OnDraw();

        base.Draw(gameTime);
    }

    protected override void UnloadContent()
    {
        if (OnClose != null) OnClose();
        base.UnloadContent();
    }

    // public methods

    public void SetSize(int width, int height)
    {
        Renderer.SetSize(width, height);
    }

    public void SetTitle(string title)
    {
        Window.Title = title;
    }

    public void SetFullscreen(bool fullscreen)
    {
        Renderer.SetFullscreen(fullscreen);
    }

    // public members

    public GraphicsDeviceManager GraphicsDeviceManager
    {
        get
        {
            return m_GraphicsManager;
        }
    }
}
