using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrandonButtlarChallengeM5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var datet1 = new DateTime();
            datet1 = DateTime.Now.ToLocalTime();
            inputTime.Text = datet1.ToString("t");
            aptText.Content = inputTime.CaretIndex;
        }

        private void setAptBtn(object sender, RoutedEventArgs e)
        {
            aptText.Content = "Appointment button pressed. TextBox caret index = " + inputTime.CaretIndex;
        }

        private void incrementTime(object sender, RoutedEventArgs e)
        {
            aptText.Content = "Up button pressed. TextBox caret index = " + inputTime.CaretIndex;
        }

        private void decrementTime(object sender, RoutedEventArgs e)
        {
            aptText.Content = "Down button pressed. TextBox caret index = " + inputTime.CaretIndex;
        }
    }
}
