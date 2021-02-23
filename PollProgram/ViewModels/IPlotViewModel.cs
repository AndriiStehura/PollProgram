using OxyPlot;
using System;
using System.Collections.Generic;
using System.Text;

namespace PollProgram.ViewModels
{
    interface IPlotViewModel
    {
        public IEnumerable<DataPoint> Points { get; set; }
    }
}
