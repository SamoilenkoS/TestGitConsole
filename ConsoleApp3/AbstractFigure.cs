using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp3
{
    [Serializable]
    public abstract class AbstractFigure
    {
        public Point Begin { get; set; }
        public Point End { get; set; }
        public Color PenColor { get; set; }
        public int PenWidth { get; set; }
    }
}
