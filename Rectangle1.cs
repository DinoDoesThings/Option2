using System;
using System.Runtime.CompilerServices;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Represents a rectangle shape that can be drawn on the canvas.
    /// </summary>
    public class Rectangle1: Shape
    {
        private int _width;
        private int _height;

        /// <summary>
        /// Initializes a new instance of the Rectangle1 class with default values.
        /// </summary>
        public Rectangle1() : this(Color.Green, 0, 0, 100, 100)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Rectangle1 class with specified properties.
        /// </summary>
        public Rectangle1(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public new int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        public new int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Draws the filled rectangle on the canvas.
        /// </summary>
        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillRectangle(Color, X, Y, _width, _height);
        }
        
        /// <summary>
        /// Draws a black outline around the rectangle to indicate selection.
        /// </summary>
        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }

        /// <summary>
        /// Determines whether the specified point is within the rectangle's boundaries.
        /// </summary>
        public override bool IsAt(Point2D pt)
        {
            Rectangle rect = new Rectangle();
            rect.X = X;
            rect.Y = Y;
            rect.Width = _width;
            rect.Height = _height;
            if(SplashKit.PointInRectangle(pt, rect))
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }
}