using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Represents a circle shape that can be drawn on the canvas.
    /// </summary>
    public class Circle1 : Shape
    {
        private int _radius;

        /// <summary>
        /// Initializes a new instance of the Circle1 class with default values.
        /// </summary>
        public Circle1() : this(Color.Green, 50)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Circle1 class with specified color and radius.
        /// </summary>
        public Circle1(Color color, int radius) : base(color)
        {
            _radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        /// <summary>
        /// Draws the filled circle on the canvas.
        /// </summary>
        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
    
        }

        /// <summary>
        /// Draws a black outline around the circle to indicate selection.
        /// </summary>
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);
        }

        /// <summary>
        /// Determines whether the specified point is within the circle's boundaries.
        /// </summary>
        public override bool IsAt(Point2D pt)
        {
            Circle c = new Circle();
            c.Radius = _radius;

            // setting the circular point
            Point2D cirPoint = new Point2D();
            cirPoint.X = X;
            cirPoint.Y = Y;

            c.Center = cirPoint;
            
            if (SplashKit.PointInCircle(pt, c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}