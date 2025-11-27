using System;

namespace Option2
{
    /// <summary>
    /// Provides functionality to scale shapes in a drawing.
    /// </summary>
    public class ShapeScaler
    {
        private float _scaleFactor;

        /// <summary>
        /// Initializes a new instance of the ShapeScaler class.
        /// </summary>
        public ShapeScaler(float scaleFactor = 0.8f)
        {
            _scaleFactor = scaleFactor;
        }

        /// <summary>
        /// Gets or sets the scale factor used for scaling shapes.
        /// </summary>
        public float ScaleFactor
        {
            get { return _scaleFactor; }
            set { _scaleFactor = value; }
        }

        /// <summary>
        /// Scales all shapes in the drawing by the specified scale factor.
        /// </summary>
        public void ScaleShapes(Drawing drawing)
        {
            foreach (Shape shape in drawing.Shapes)
            {
                ScaleShape(shape);
            }
        }

        /// <summary>
        /// Scales a single shape based on its type.
        /// </summary>
        private void ScaleShape(Shape shape)
        {
            if (shape is Rectangle1)
            {
                ScaleRectangle((Rectangle1)shape);
            }
            else if (shape is Circle1)
            {
                ScaleCircle((Circle1)shape);
            }
            else if (shape is Line1)
            {
                ScaleLine((Line1)shape);
            }
        }

        /// <summary>
        /// Scales a rectangle by reducing its width and height.
        /// </summary>
        private void ScaleRectangle(Rectangle1 rectangle)
        {
            rectangle.Width = (int)(rectangle.Width * _scaleFactor);
            rectangle.Height = (int)(rectangle.Height * _scaleFactor);
        }

        /// <summary>
        /// Scales a circle by reducing its radius.
        /// </summary>
        private void ScaleCircle(Circle1 circle)
        {
            circle.Radius = (int)(circle.Radius * _scaleFactor);
        }

        /// <summary>
        /// Scales a line by moving its end point closer to the start point.
        /// </summary>
        private void ScaleLine(Line1 line)
        {
            float deltaX = line.EndX - line.X;
            float deltaY = line.EndY - line.Y;
            line.EndX = line.X + (deltaX * _scaleFactor);
            line.EndY = line.Y + (deltaY * _scaleFactor);
        }
    }
}
