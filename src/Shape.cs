using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Abstract base class for all drawable shapes in the application.
    /// </summary>
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;
        private Boolean _selected;

        /// <summary>
        /// Initializes a new instance of the Shape class with default white color.
        /// </summary>
        public Shape():this(Color.White)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Shape class with the specified color.
        /// </summary>
        public Shape(Color color)
        {
            _color = color;
        }

        /// <summary>
        /// Gets or sets the color of the shape.
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Gets or sets the X coordinate of the shape's position.
        /// </summary>
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Gets or sets the Y coordinate of the shape's position.
        /// </summary>
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Gets or sets the width of the shape.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Gets or sets the height of the shape.
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Gets or sets whether the shape is currently selected.
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        /// <summary>
        /// Draws the shape on the canvas.
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Draws an outline around the shape to indicate selection.
        /// </summary>
        public abstract void DrawOutline();

        /// <summary>
        /// Determines whether the specified point is within the shape's boundaries.
        /// </summary>
        public abstract Boolean IsAt(Point2D pt);
    }
}