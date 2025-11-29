using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Option2
{
    /// <summary>
    /// Manages color cycling functionality for shape drawing.
    /// Allows users to cycle through preset colors using mouse scroll wheel.
    /// </summary>
    public class ColorCycler
    {
        private List<Color> _colors;
        private int _currentIndex;

        /// <summary>
        /// Initializes a new instance of the ColorCycler class with preset colors.
        /// </summary>
        public ColorCycler()
        {
            _colors = new List<Color>
            {
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Yellow,
                Color.Purple,
                Color.Orange,
                Color.Pink,
                Color.Cyan,
                Color.Magenta,
                Color.Brown
            };
            _currentIndex = 0;
        }

        /// <summary>
        /// Gets the currently selected color.
        /// </summary>
        public Color CurrentColor
        {
            get { return _colors[_currentIndex]; }
        }

        /// <summary>
        /// Gets the name of the currently selected color.
        /// </summary>
        public string CurrentColorName
        {
            get
            {
                switch (_currentIndex)
                {
                    case 0: return "Red";
                    case 1: return "Blue";
                    case 2: return "Green";
                    case 3: return "Yellow";
                    case 4: return "Purple";
                    case 5: return "Orange";
                    case 6: return "Pink";
                    case 7: return "Cyan";
                    case 8: return "Magenta";
                    case 9: return "Brown";
                    default: return "Unknown";
                }
            }
        }

        /// <summary>
        /// Cycles to the next color in the preset list.
        /// </summary>
        public void CycleNext()
        {
            _currentIndex = (_currentIndex + 1) % _colors.Count;
        }

        /// <summary>
        /// Cycles to the previous color in the preset list.
        /// </summary>
        public void CyclePrevious()
        {
            _currentIndex--;
            if (_currentIndex < 0)
            {
                _currentIndex = _colors.Count - 1;
            }
        }
    }
}
