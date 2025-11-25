using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Main application class that orchestrates the shape drawing program.
    /// Encapsulates the game loop and coordinates between components.
    /// </summary>
    public class ShapeDrawingApplication
    {
        private readonly Window _window;
        private readonly Drawing _drawing;
        private readonly InputHandler _inputHandler;

        /// <summary>
        /// Initializes a new instance of the ShapeDrawingApplication class.
        /// </summary>
        /// <param name="windowTitle">The title of the application window.</param>
        /// <param name="windowWidth">The width of the application window.</param>
        /// <param name="windowHeight">The height of the application window.</param>
        public ShapeDrawingApplication(string windowTitle = "GameMain", int windowWidth = 800, int windowHeight = 600)
        {
            _window = new Window(windowTitle, windowWidth, windowHeight);
            _drawing = new Drawing();

            // Initialize feature components
            RandomShapeGenerator shapeGenerator = new RandomShapeGenerator();
            NameDrawer nameDrawer = new NameDrawer("ALBIAN", Color.Blue);
            ShapeScaler shapeScaler = new ShapeScaler(0.8f);

            // Initialize input handler with all features
            _inputHandler = new InputHandler(shapeGenerator, nameDrawer, shapeScaler);
        }

        /// <summary>
        /// Runs the main application loop.
        /// </summary>
        public void Run()
        {
            do
            {
                ProcessFrame();
            } while (!SplashKit.QuitRequested());
        }

        /// <summary>
        /// Processes a single frame of the application.
        /// </summary>
        private void ProcessFrame()
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen(Color.White);

            _inputHandler.ProcessInput(_drawing);
            _drawing.Draw();

            SplashKit.RefreshScreen(60);
        }
    }
}
