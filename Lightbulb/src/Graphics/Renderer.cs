using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lightbulb.Graphics;

/// <summary>
/// The next Main to go for all Games made with Lightbulb/MonoGame. 
/// The Renderer, this Renderer is an abstraction and cleanup that merges the Graphics Device, Graphics Device Manager and others into one stable and static codebase!
/// </summary>
public class Renderer
{
    private static bool m_Init = false;

    // private static members
    private static Application m_App;

    // public static members

    /// <summary>
    /// The Graphics Device of the Application.
    /// </summary>
    public static GraphicsDevice Device { get; private set; }

    /// <summary>
    /// The Graphics Device Manager of the Application.
    /// </summary>
    public static GraphicsDeviceManager DeviceManager { get; private set; }

    /// <summary>
    /// The View Matrix for 3D calculations. Default testing view calculation is always made on Init.
    /// </summary>
    public static Matrix View;

    /// <summary>
    /// The Projection Matrix for 3D calculations. Default testing projection calculation is always made on Init.
    /// </summary>
    public static Matrix Projection;

    /// <summary>
    /// Gets the aspect ratio of the Application's Viewport.
    /// </summary>
    public static float AspectRatio
    {
        get
        {
            return Device.Viewport.AspectRatio;
        }
    }

    /// <summary>
    /// The Application's Viewport. can be changed directly.
    /// </summary>
    public static Viewport Viewport
    {
        get
        {
            return Device.Viewport;
        }
        set
        {
            Device.Viewport = value;
        }
    }


    // public static defaults

    /// <summary>
    /// The Default clearing options on "Renderer.Clear();"
    /// </summary>
    public static readonly ClearOptions DefaultClearOptions = (ClearOptions.Target | ClearOptions.DepthBuffer);

    /// <summary>
    /// The Default clearing depth.
    /// </summary>
    public static readonly float DefaultDepth = 1.0f;

    /// <summary>
    /// The Default clearing stencil.
    /// </summary>
    public static readonly int DefaultStencil = 0;

    
    // public static methods

    /// <summary>
    /// Initializes the Renderer's subsystem. ALWAYS CALL ONCE IN YOUR OnLoad METHOD!
    /// </summary>
    /// <param name="application">Your target application.</param>
    public static void Init(Application application)
    {
        if (m_Init) return;

        m_App = application;
        Device = m_App.GraphicsDevice;
        DeviceManager = m_App.GraphicsDeviceManager;

        View = Matrix.CreateLookAt(new Vector3(0f, 0f, 5f), Vector3.Zero, Vector3.Up);
        Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), AspectRatio, 0.1f, 1000f);

        m_Init = true;
    }

    /// <summary>
    /// Clears the graphics, making it ready to draw.
    /// </summary>
    public static void Clear()
    {
        Device.Clear(DefaultClearOptions, Color.Black, DefaultDepth, DefaultStencil);
    }

    /// <summary>
    /// Clears the graphics, making it ready to draw.
    /// </summary>
    /// <param name="clearColor">Your target clearing color.</param>
    public static void Clear(Color clearColor)
    {
        Device.Clear(DefaultClearOptions, clearColor, DefaultDepth, DefaultStencil);
    }


    /// <summary>
    /// Sets the size of your Application and the Graphical Context within.
    /// </summary>
    /// <param name="width">Your target width.</param>
    /// <param name="height">Your target height.</param>
    public static void SetSize(int width, int height)
    {
        DeviceManager.PreferredBackBufferWidth = width;
        DeviceManager.PreferredBackBufferHeight = height;
        DeviceManager.ApplyChanges();
    }

    /// <summary>
    /// Sets the fullscreen of your Application and the Graphical Context within.
    /// </summary>
    /// <param name="fullscreen">Your target fullscreen value.</param>
    public static void SetFullscreen(bool fullscreen)
    {
        DeviceManager.IsFullScreen = fullscreen;
        DeviceManager.ApplyChanges();
    }
}
