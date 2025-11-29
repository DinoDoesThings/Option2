using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Factory class for creating different types of shapes.
    /// Implements the Factory Pattern to encapsulate shape creation logic.
    /// </summary>
    public class ShapeFactory
    {

        /// <summary>
        /// Creates a shape of the specified type at the given position with the specified color.
        /// </summary>
        public Shape CreateShape(ShapeType shapeType, float x, float y, Color color)
        {
            Shape newShape;

            switch (shapeType)
            {
                case ShapeType.Circle:
                    Circle1 newCircle = new Circle1(color, 50);
                    newCircle.X = x;
                    newCircle.Y = y;
                    newShape = newCircle;
                    break;

                case ShapeType.Line:
                    Line1 newLine = new Line1(color, x, y, x + 150, y + 150);
                    newShape = newLine;
                    break;

                case ShapeType.Rectangle:
                default:
                    Rectangle1 newRect = new Rectangle1(color, x, y, 100, 100);
                    newShape = newRect;
                    break;
            }

            return newShape;
        }
    }
}
