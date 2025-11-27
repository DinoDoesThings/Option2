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
        /// Creates a shape of the specified type at the given position.
        /// </summary>
        public Shape CreateShape(ShapeType shapeType, float x, float y)
        {
            Shape newShape;

            switch (shapeType)
            {
                case ShapeType.Circle:
                    Circle1 newCircle = new Circle1();
                    newCircle.X = x;
                    newCircle.Y = y;
                    newShape = newCircle;
                    break;

                case ShapeType.Line:
                    Line1 newLine = new Line1();
                    newLine.X = x;
                    newLine.Y = y;
                    newLine.EndX = x + 150;
                    newLine.EndY = y + 150;
                    newShape = newLine;
                    break;

                case ShapeType.Rectangle:
                default:
                    Rectangle1 newRect = new Rectangle1();
                    newRect.X = x;
                    newRect.Y = y;
                    newShape = newRect;
                    break;
            }

            return newShape;
        }
    }
}
