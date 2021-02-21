using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PollProgram.Views.Controls
{
    /// <summary>
    /// Interaction logic for PollBlock.xaml
    /// </summary>
    public partial class PollBlock : UserControl
    {
        private readonly DependencyProperty _headerText;
        private readonly DependencyProperty _questions;

        public PollBlock()
        {
            InitializeComponent();
            DependencyProperty.Register(nameof(HeaderText), HeaderText.GetType(), GetType());
            DependencyProperty.Register(nameof(Questions), Questions.GetType(), GetType());
        }

        public string HeaderText 
        {
            get => (string)GetValue(_headerText);
            set => SetValue(_headerText, value);
        }

        public IObservable<object> Questions 
        {
            get => (IObservable<object>)GetValue(_questions);
            set => SetValue(_questions, value);
        }
    }
}
