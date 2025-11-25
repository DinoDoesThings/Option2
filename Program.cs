using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Main program class for the Shape Drawing application.
    /// Entry point that creates and runs the application using OOP principles.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for the Shape Drawing application.
        /// Creates an application instance and runs it.
        /// </summary>
        public static void Main()
        {
            ShapeDrawingApplication app = new ShapeDrawingApplication("GameMain", 800, 600);
            app.Run();
        }
    }
}
