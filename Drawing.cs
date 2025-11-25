using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Manages a collection of shapes and handles drawing operations on a canvas.
    /// </summary>
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        /// <summary>
        /// Initializes a new instance of the Drawing class with the specified background color.
        /// </summary>
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        /// <summary>
        /// Initializes a new instance of the Drawing class with a white background.
        /// </summary>
        public Drawing() : this(Color.White)
        {
        }

        /// <summary>
        /// Gets the list of all shapes in the drawing.
        /// </summary>
        public List<Shape> Shapes
        {
            get { return _shapes; }
        }

        /// <summary>
        /// Gets or sets the background color of the drawing canvas.
        /// </summary>
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        /// <summary>
        /// Gets the total number of shapes in the drawing.
        /// </summary>
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        /// <summary>
        /// Adds a shape to the drawing.
        /// </summary>
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        /// <summary>
        /// Draws all shapes in the drawing on the canvas with the background color.
        /// </summary>
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }

        /// <summary>
        /// Selects the shape at the specified point and deselects all other shapes.
        /// </summary>
        public void SelectShapeAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt) == true)
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }

        /// <summary>
        /// Gets a list of all currently selected shapes.
        /// </summary>
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result;
                result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected == true)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Removes the specified shape from the drawing.
        /// </summary>
        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }
    }
}
