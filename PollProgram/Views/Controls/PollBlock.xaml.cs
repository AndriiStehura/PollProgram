using PollProgram.Components;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System;

namespace PollProgram.Views.Controls
{
    /// <summary>
    /// Interaction logic for PollBlock.xaml
    /// </summary>
    public partial class PollBlock : UserControl
    {
        public static readonly DependencyProperty HeaderTextProperty;
        public static readonly DependencyProperty QuestionsProperty;

        static PollBlock()
        {
            HeaderTextProperty = DependencyProperty.Register(
                nameof(HeaderText),
                typeof(string),
                typeof(PollBlock));

            QuestionsProperty = DependencyProperty.Register(
                nameof(Questions),
                typeof(object),
                typeof(PollBlock));
        }

        public PollBlock()
        {
            InitializeComponent();
        }

        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }

        public IEnumerable<object> Questions
        {
            get => (IEnumerable<object>)GetValue(QuestionsProperty);
            set => SetValue(QuestionsProperty, value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var answersCollection = Questions.SelectMany(x => (IEnumerable<object>)x
                .GetType()
                .GetProperty("Answers")
                .GetValue(x));
            foreach (var answer in answersCollection)
                answer.GetType().GetProperty("IsChecked").SetValue(answer, false);
        }
    }
}
