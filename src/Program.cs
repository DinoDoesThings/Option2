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
        public static void Main()
        {
            Window window = new Window("GameMain", 800, 600);
            Drawing drawing = new Drawing();

            // Feature components
            RandomShapeGenerator shapeGenerator = new RandomShapeGenerator();
            NameDrawer nameDrawer = new NameDrawer("ALBIAN", Color.Blue);
            ShapeScaler shapeScaler = new ShapeScaler(0.8f);
            ShapeType currentShapeType = ShapeType.Circle;
            ShapeFactory shapeFactory = new ShapeFactory();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);

                // --- Input Handling ---
                // Shape type selection
                if (SplashKit.KeyTyped(KeyCode.RKey)) currentShapeType = ShapeType.Rectangle;
                else if (SplashKit.KeyTyped(KeyCode.CKey)) currentShapeType = ShapeType.Circle;
                else if (SplashKit.KeyTyped(KeyCode.LKey)) currentShapeType = ShapeType.Line;

                // Create shape on left click
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    float mouseX = SplashKit.MouseX();
                    float mouseY = SplashKit.MouseY();
                    Shape newShape = shapeFactory.CreateShape(currentShapeType, mouseX, mouseY);
                    drawing.AddShape(newShape);
                }

                // Change background color
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                    drawing.Background = SplashKit.RandomRGBColor(255);

                // Select shape on right click
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                    drawing.SelectShapeAt(SplashKit.MousePosition());

                // Delete selected shapes
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in drawing.SelectedShapes)
                        drawing.RemoveShape(shape);
                }

                // Feature 1: Draw random shapes with 'M' key
                if (SplashKit.KeyTyped(KeyCode.MKey))
                    shapeGenerator.GenerateShapes(drawing);

                // Feature 2: Draw name with 'N' key
                if (SplashKit.KeyTyped(KeyCode.NKey))
                    nameDrawer.DrawName(drawing);

                // Feature 3: Scale down shapes with 'S' key
                if (SplashKit.KeyTyped(KeyCode.SKey))
                    shapeScaler.ScaleShapes(drawing);

                drawing.Draw();

                // On-screen controls legend
                string controls = "Controls: R Rectangle | C Circle | L Line | Left-click Draw | Right-click Select";
                string extrafeatures = "Space Background | M Random | N Name | S Scale | Backspace/DEL Remove";
                string current = $"Current Shape: {currentShapeType}";
                SplashKit.DrawTextOnWindow(window, controls, Color.Black, 10, 10);
                SplashKit.DrawTextOnWindow(window, extrafeatures, Color.Black, 10, 28);
                SplashKit.DrawTextOnWindow(window, current, Color.Black, 10, 46);

                SplashKit.RefreshScreen(60);
            }
            while (!SplashKit.QuitRequested());
        }
    }
}
