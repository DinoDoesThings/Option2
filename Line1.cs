using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Represents a line shape that can be drawn on the canvas.
    /// </summary>
    public class Line1 : Shape
    {
        private float _endX;
        private float _endY;

        /// <summary>
        /// Initializes a new instance of the Line1 class with default values.
        /// </summary>
        public Line1() : this(Color.Green, 0, 0, 100, 100)
        {       
        }

        /// <summary>
        /// Initializes a new instance of the Line1 class with specified properties.
        /// </summary>
        public Line1(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }

        /// <summary>
        /// Gets or sets the X coordinate of the line's end point.
        /// </summary>
        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        /// <summary>
        /// Gets or sets the Y coordinate of the line's end point.
        /// </summary>
        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        /// <summary>
        /// Draws the line on the canvas.
        /// </summary>
        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
        }

        /// <summary>
        /// Draws circles at the line's endpoints to indicate selection.
        /// </summary>
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 5);
            SplashKit.DrawCircle(Color.Black, _endX, _endY, 5);
        }

        /// <summary>
        /// Determines whether the specified point is on the line.
        /// </summary>
        public override bool IsAt(Point2D pt)
        {
            Line line = new Line();

            Point2D strPoint = new Point2D();
            strPoint.X = X;
            strPoint.Y = Y;

            Point2D endPoint = new Point2D();
            endPoint.X = _endX;
            endPoint.Y = _endY;

            line.StartPoint = strPoint;
            line.EndPoint = endPoint;

            if (SplashKit.PointOnLine(pt, line))
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