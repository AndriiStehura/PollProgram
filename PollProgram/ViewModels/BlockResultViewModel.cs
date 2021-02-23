using OxyPlot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace PollProgram.ViewModels
{
    class BlockResultViewModel : IPlotViewModel
    {
        public IEnumerable<DataPoint> Points { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public string Title { get; set; }

        public string Name { get; set; }
        public IEnumerable<int> Answers { get; set; }

        public Color Color { get; set; }
    }
}
