using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Handles all user input for the shape drawing application.
    /// Encapsulates input processing logic using OOP principles.
    /// </summary>
    public class InputHandler
    {
        private ShapeFactory.ShapeType _currentShapeType;
        private readonly ShapeFactory _shapeFactory;
        private readonly RandomShapeGenerator _shapeGenerator;
        private readonly NameDrawer _nameDrawer;
        private readonly ShapeScaler _shapeScaler;

        /// <summary>
        /// Initializes a new instance of the InputHandler class.
        /// </summary>
        /// <param name="shapeGenerator">The random shape generator.</param>
        /// <param name="nameDrawer">The name drawer.</param>
        /// <param name="shapeScaler">The shape scaler.</param>
        public InputHandler(RandomShapeGenerator shapeGenerator, NameDrawer nameDrawer, ShapeScaler shapeScaler)
        {
            _currentShapeType = ShapeFactory.ShapeType.Circle;
            _shapeFactory = new ShapeFactory();
            _shapeGenerator = shapeGenerator;
            _nameDrawer = nameDrawer;
            _shapeScaler = shapeScaler;
        }

        /// <summary>
        /// Processes all user input and updates the drawing accordingly.
        /// </summary>
        /// <param name="drawing">The drawing to modify based on input.</param>
        public void ProcessInput(Drawing drawing)
        {
            HandleShapeTypeSelection();
            HandleShapeCreation(drawing);
            HandleBackgroundChange(drawing);
            HandleShapeSelection(drawing);
            HandleShapeDeletion(drawing);
            HandleFeatureKeys(drawing);
        }

        /// <summary>
        /// Handles keyboard input for selecting the current shape type.
        /// </summary>
        private void HandleShapeTypeSelection()
        {
            if (SplashKit.KeyTyped(KeyCode.RKey))
            {
                _currentShapeType = ShapeFactory.ShapeType.Rectangle;
            }
            else if (SplashKit.KeyTyped(KeyCode.CKey))
            {
                _currentShapeType = ShapeFactory.ShapeType.Circle;
            }
            else if (SplashKit.KeyTyped(KeyCode.LKey))
            {
                _currentShapeType = ShapeFactory.ShapeType.Line;
            }
        }

        /// <summary>
        /// Handles mouse clicks for creating new shapes.
        /// </summary>
        /// <param name="drawing">The drawing to add shapes to.</param>
        private void HandleShapeCreation(Drawing drawing)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                float mouseX = SplashKit.MouseX();
                float mouseY = SplashKit.MouseY();
                Shape newShape = _shapeFactory.CreateShape(_currentShapeType, mouseX, mouseY);
                drawing.AddShape(newShape);
            }
        }

        /// <summary>
        /// Handles keyboard input for changing the background color.
        /// </summary>
        /// <param name="drawing">The drawing to modify.</param>
        private void HandleBackgroundChange(Drawing drawing)
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                drawing.Background = SplashKit.RandomRGBColor(255);
            }
        }

        /// <summary>
        /// Handles mouse clicks for selecting shapes.
        /// </summary>
        /// <param name="drawing">The drawing containing shapes to select.</param>
        private void HandleShapeSelection(Drawing drawing)
        {
            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                drawing.SelectShapeAt(SplashKit.MousePosition());
            }
        }

        /// <summary>
        /// Handles keyboard input for deleting selected shapes.
        /// </summary>
        /// <param name="drawing">The drawing to remove shapes from.</param>
        private void HandleShapeDeletion(Drawing drawing)
        {
            if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                foreach (Shape shape in drawing.SelectedShapes)
                {
                    drawing.RemoveShape(shape);
                }
            }
        }

        /// <summary>
        /// Handles keyboard input for special features (random shapes, name drawing, scaling).
        /// </summary>
        /// <param name="drawing">The drawing to apply features to.</param>
        private void HandleFeatureKeys(Drawing drawing)
        {
            // Feature 1: Draw random shapes with 'M' key
            if (SplashKit.KeyTyped(KeyCode.MKey))
            {
                _shapeGenerator.GenerateShapes(drawing);
            }

            // Feature 2: Draw name with 'N' key
            if (SplashKit.KeyTyped(KeyCode.NKey))
            {
                _nameDrawer.DrawName(drawing);
            }

            // Feature 3: Scale down shapes with 'S' key
            if (SplashKit.KeyTyped(KeyCode.SKey))
            {
                _shapeScaler.ScaleShapes(drawing);
            }
        }
    }
}
