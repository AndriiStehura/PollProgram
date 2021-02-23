using Newtonsoft.Json;
using OxyPlot;
using OxyPlot.Series;
using PollProgram.Components;
using PollProgram.Models;
using PollProgram.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace PollProgram.ViewModels
{
    class ResultPageViewModel: BaseViewModel
    {
        private UnitOfWork _unit;

        public ResultPageViewModel()
        {
            _unit = new UnitOfWork();
            Person = (Person)App.Current.Resources["person"];
            _unit.ResultsRepository.FilePath = $"{Person.Name}.json";
            BlockResults = _unit.ResultsRepository
                .ReadFromJson<IEnumerable<BlockResultViewModel>>();
            int maxY = BlockResults.Max(x => x.Answers.Max()) + 1;
            int maxX = BlockResults.Max(x => x.Answers.Count()) + 1;
            int i = 0;
            OxyColor[] colors = new OxyColor[] 
            { 
                OxyColor.FromRgb(78, 154, 6),
                OxyColor.FromRgb(200,141,0),
                OxyColor.FromRgb(204,0,0),
                OxyColor.FromRgb(32,74,135),
                OxyColor.FromRgb(255,0,0)
            };
            foreach(var block in BlockResults)
            {
                block.Points = block.Answers.Select((x, y) => new DataPoint(y + 1, x));
                block.Title = $"{block.Name} ({block.Answers.Sum()})";
                block.MaxX = maxX;
                block.MaxY = maxY;
                block.Color = Color.FromRgb(colors[i].R, colors[i].G, colors[i++].B);
            }
            i = 0;
            PieModel = new PlotModel();
            PieModel.Title = $"Загальний результат ({BlockResults.Sum(x => x.Answers.Sum())})";
            var serries = new PieSeries() { AngleSpan = 360, StartAngle = 0 };
            serries.Slices = BlockResults
                .Select((x, y) => new PieSlice($"{x.Name}({x.Answers.Sum()})", x.Answers.Sum()) 
                { 
                    IsExploded = true, 
                    Fill = colors[y] 
                })
                .ToList();
            serries.InsideLabelColor = OxyColor.FromRgb(255, 255, 255);
            PieModel.Series.Add(serries);
        }

        public IEnumerable<BlockResultViewModel> BlockResults { get; set; }
        public PlotModel PieModel { get; set; }
        public ICommand BackCommand => new RelayCommand(obj =>
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.MainFrame.Navigate(new OptionsPage());
        });

        public Person Person { get; set; }
    }
}
