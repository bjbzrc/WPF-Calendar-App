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
        static int timesHoursChanged = 0;
        static int timesMinutesChanged = 0;
        static int currentCaret = 0;

        public MainWindow()
        {
            InitializeComponent();
            DateTime date1 = new DateTime();
            date1 = DateTime.Now.ToLocalTime();
            inputTime.Text = date1.ToString("hh:mm tt");
            currentCaret = inputTime.CaretIndex;
            aptCal.SelectedDate = DateTime.Now;
        }

        private void setAptBtn(object sender, RoutedEventArgs e)
        {
            aptCal.SelectedDate.ToString();
            aptText.Text = "Appointment button pressed. Selected Date: " + aptCal.SelectedDate.ToString();
        }

        private void incrementTime(object sender, RoutedEventArgs e)
        {
            var date2 = new DateTime();
            date2 = DateTime.Now.ToLocalTime();
            switch (inputTime.CaretIndex)
            {
                case int i when i < 3:
                    ++timesHoursChanged;
                    date2 = date2.AddHours(timesHoursChanged);
                    aptText.Text = $"Carret is {inputTime.CaretIndex}. time is = " + date2.ToString("hh:mm tt");
                    break;
                case int i when i >= 3 && i < 6:
                    ++timesMinutesChanged;
                    date2 = date2.AddMinutes(timesMinutesChanged);
                    aptText.Text = $"Carret is {inputTime.CaretIndex}. time is = " + date2.ToString("hh:mm tt");
                    break;
                case int i when i >= 6:
                    date2 = date2.AddHours(12);
                    aptText.Text = $"Carret is {inputTime.CaretIndex}. time is = " + date2.ToString("hh:mm tt");
                    break;
                default:
                    break;
            }
            inputTime.Text = date2.ToString("hh:mm tt");
            //aptText.Text = "Up button pressed. TextBox caret index = " + inputTime.CaretIndex;
            //debug
            //aptText.Content = date2.ToString("t");
            //aptText.Content = "Up button pressed. TextBox caret index = " + inputTime.CaretIndex;
        }

        private void decrementTime(object sender, RoutedEventArgs e)
        {
            var date2 = new DateTime();
            date2 = DateTime.Now.ToLocalTime();
            switch (inputTime.CaretIndex)
            {
                case int i when i < 3:
                    --timesHoursChanged;
                    date2 = date2.AddHours(timesHoursChanged);
                    aptText.Text = $"Carret is {inputTime.CaretIndex}. time is = " + date2.ToString("hh:mm tt");
                    break;
                case int i when i >= 3 && i < 6:
                    --timesMinutesChanged;
                    date2 = date2.AddMinutes(timesMinutesChanged);
                    aptText.Text = $"Carret is {inputTime.CaretIndex}. time is = " + date2.ToString("hh:mm tt");
                    break;
                case int i when i >= 6:
                    date2 = date2.AddHours(12);
                    aptText.Text = $"Carret is {inputTime.CaretIndex}. time is = " + date2.ToString("hh:mm tt");
                    break;
                default:
                    break;
            }
            inputTime.Text = date2.ToString("hh:mm tt");
            //aptText.Text = "Down button pressed. TextBox caret index = " + inputTime.CaretIndex;
        }
    }
}
