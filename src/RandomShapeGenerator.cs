using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Generates random shapes with random properties for the drawing canvas.
    /// </summary>
    public class RandomShapeGenerator
    {
        private readonly Random _random;
        private readonly int _minShapes;
        private readonly int _maxShapes;
        private readonly float _minX;
        private readonly float _maxX;
        private readonly float _minY;
        private readonly float _maxY;

        /// <summary>
        /// Initializes a new instance of the RandomShapeGenerator class.
        /// </summary>
        public RandomShapeGenerator(int minShapes = 5, int maxShapes = 15, 
                       float minX = 50, float maxX = 750, 
                       float minY = 50, float maxY = 550)
        {
            _random = new Random();
            _minShapes = minShapes;
            _maxShapes = maxShapes;
            _minX = minX;
            _maxX = maxX;
            _minY = minY;
            _maxY = maxY;
        }

        /// <summary>
        /// Generates a random number of shapes and adds them to the drawing.
        /// </summary>
        public void GenerateShapes(Drawing drawing)
        {
            int numShapes = _random.Next(_minShapes, _maxShapes);
            
            for (int i = 0; i < numShapes; i++)
            {
                Shape newShape = CreateRandomShape();
                drawing.AddShape(newShape);
            }
        }

        /// <summary>
        /// Creates a single random shape with random type, color, and position.
        /// </summary>
        private Shape CreateRandomShape()
        {
            int shapeType = _random.Next(0, 3); // 0=Rectangle, 1=Circle, 2=Line
            Color randomColor = SplashKit.RandomRGBColor(255);
            float randomX = _random.Next((int)_minX, (int)_maxX);
            float randomY = _random.Next((int)_minY, (int)_maxY);

            Shape newShape;

            if (shapeType == 0) // Rectangle
            {
                newShape = new Rectangle1(randomColor, randomX, randomY, 80, 60);
            }
            else if (shapeType == 1) // Circle
            {
                Circle1 circle = new Circle1(randomColor, 40);
                circle.X = randomX;
                circle.Y = randomY;
                newShape = circle;
            }
            else // Line
            {
                newShape = new Line1(randomColor, randomX, randomY, randomX + 100, randomY + 100);
            }

            return newShape;
        }
    }
}
