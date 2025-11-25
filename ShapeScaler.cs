using System;

namespace Option2
{
    /// <summary>
    /// Provides functionality to scale shapes in a drawing.
    /// </summary>
    public class ShapeScaler
    {
        private readonly float _scaleFactor;

        /// <summary>
        /// Initializes a new instance of the ShapeScaler class.
        /// </summary>
        /// <param name="scaleFactor">The factor by which to scale shapes (e.g., 0.8 for 80% size).</param>
        public ShapeScaler(float scaleFactor = 0.8f)
        {
            _scaleFactor = scaleFactor;
        }

        /// <summary>
        /// Scales all shapes in the drawing by the specified scale factor.
        /// </summary>
        /// <param name="drawing">The drawing containing shapes to scale.</param>
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
        /// <param name="shape">The shape to scale.</param>
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
        /// <param name="rectangle">The rectangle to scale.</param>
        private void ScaleRectangle(Rectangle1 rectangle)
        {
            rectangle.Width = (int)(rectangle.Width * _scaleFactor);
            rectangle.Height = (int)(rectangle.Height * _scaleFactor);
        }

        /// <summary>
        /// Scales a circle by reducing its radius.
        /// </summary>
        /// <param name="circle">The circle to scale.</param>
        private void ScaleCircle(Circle1 circle)
        {
            circle.Radius = (int)(circle.Radius * _scaleFactor);
        }

        /// <summary>
        /// Scales a line by moving its end point closer to the start point.
        /// </summary>
        /// <param name="line">The line to scale.</param>
        private void ScaleLine(Line1 line)
        {
            float deltaX = line.EndX - line.X;
            float deltaY = line.EndY - line.Y;
            line.EndX = line.X + (deltaX * _scaleFactor);
            line.EndY = line.Y + (deltaY * _scaleFactor);
        }
    }
}
