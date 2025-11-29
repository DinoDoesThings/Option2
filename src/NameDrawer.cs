using System;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Draws a name on the canvas using geometric shapes.
    /// </summary>
    public class NameDrawer
    {
        private string _name;
        private Color _color;
        private float _startX;
        private float _startY;
        private int _lineThickness;

        /// <summary>
        /// Initializes a new instance of the NameDrawer class.
        /// </summary>
        public NameDrawer(string name, Color color, float startX = 50, float startY = 250, int lineThickness = 15)
        {
            _name = name.ToUpper();
            _color = color;
            _startX = startX;
            _startY = startY;
            _lineThickness = lineThickness;
        }

        /// <summary>
        /// Draws the name on the canvas by adding shapes to the drawing.
        /// </summary>
        public void DrawName(Drawing drawing)
        {
            float currentX = _startX;

            foreach (char letter in _name)
            {
                DrawLetter(letter, currentX, drawing);
                currentX += GetLetterWidth(letter) + 10; // Add letter width plus small spacing
            }
        }

        /// <summary>
        /// Gets the width of a letter for spacing calculations.
        /// </summary>
        private float GetLetterWidth(char letter)
        {
            switch (letter)
            {
                case 'A': return 65;
                case 'L': return 60;
                case 'B': return 55;
                case 'I': return 20;
                case 'N': return 100;
                case ' ': return 30; // Space width
                default: return 40; // Default width for unknown characters
            }
        }

        /// <summary>
        /// Draws a single letter at the specified position.
        /// </summary>
        private void DrawLetter(char letter, float x, Drawing drawing)
        {
            switch (letter)
            {
                case 'A':
                    DrawLetterA(x, drawing);
                    break;
                case 'L':
                    DrawLetterL(x, drawing);
                    break;
                case 'B':
                    DrawLetterB(x, drawing);
                    break;
                case 'I':
                    DrawLetterI(x, drawing);
                    break;
                case 'N':
                    DrawLetterN(x, drawing);
                    break;
                default:
                    // Skip unknown letters
                    break;
            }
        }

        /// <summary>
        /// Draws the letter 'A' at the specified X position.
        /// </summary>
        private void DrawLetterA(float x, Drawing drawing)
        {
            drawing.AddShape(new Rectangle1(_color, x, _startY, 65, 15)); // Top horizontal
            drawing.AddShape(new Rectangle1(_color, x, _startY, 15, 100)); // Left vertical
            drawing.AddShape(new Rectangle1(_color, x, _startY + 40, 65, 20)); // Horizontal middle bar
            drawing.AddShape(new Rectangle1(_color, x + 50, _startY, 15, 100)); // Right vertical
        }

        /// <summary>
        /// Draws the letter 'L' at the specified X position.
        /// </summary>
        private void DrawLetterL(float x, Drawing drawing)
        {
            drawing.AddShape(new Rectangle1(_color, x, _startY, 20, 100)); // Vertical line
            drawing.AddShape(new Rectangle1(_color, x, _startY + 80, 60, 20)); // Horizontal base
        }

        /// <summary>
        /// Draws the letter 'B' at the specified X position.
        /// </summary>
        private void DrawLetterB(float x, Drawing drawing)
        {
            drawing.AddShape(new Rectangle1(_color, x, _startY, 30, 100)); // Vertical stem 
            drawing.AddShape(new Circle1(_color, 25) { X = x + 30, Y = _startY + 25 }); // Top curve
            drawing.AddShape(new Circle1(_color, 25) { X = x + 30, Y = _startY + 75 }); // Bottom curve
            
            // Add white circles to create holes in the B
            drawing.AddShape(new Circle1(Color.White, 15) { X = x + 30, Y = _startY + 25 }); // Top hole
            drawing.AddShape(new Circle1(Color.White, 15) { X = x + 30, Y = _startY + 75 }); // Bottom hole
        }

        /// <summary>
        /// Draws the letter 'I' at the specified X position.
        /// </summary>
        private void DrawLetterI(float x, Drawing drawing)
        {
            drawing.AddShape(new Rectangle1(_color, x, _startY, 20, 100)); // Vertical line
        }

        /// <summary>
        /// Draws the letter 'N' at the specified X position.
        /// </summary>
        private void DrawLetterN(float x, Drawing drawing)
        {
            drawing.AddShape(new Rectangle1(_color, x, _startY, 20, 100)); // Left vertical
            
            // Draw multiple lines to create thickness for the diagonal
            for (int i = 0; i < _lineThickness; i++)
            {
                drawing.AddShape(new Line1(_color, x + 10 + i, _startY, x + 80 + i, _startY + 100));
            }
            
            drawing.AddShape(new Rectangle1(_color, x + 80, _startY, 20, 100)); // Right vertical
        }
    }
}
