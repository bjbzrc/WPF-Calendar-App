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
        public int currentCaret = 0;
        public DateTime date1 = new DateTime(2023, 1, 1, 0, 0, 0);

        public MainWindow()
        {
            InitializeComponent();
            aptCal.SelectedDate = date1;
            inputTime.Text = date1.ToString("hh:mm tt");
        }

        private void setAptBtn(object sender, RoutedEventArgs e)
        {
            DateTime curDate = new DateTime();
            curDate = DateTime.Now;
            int dayDiff = curDate.Day - date1.Day;
            aptCal.SelectedDate = date1;
            aptText.Text = $"Your appointment is on {aptCal.SelectedDate}. " +
                $"It's {dayDiff} days from today.";
        }

        private void incrementTime(object sender, RoutedEventArgs e)
        {
            currentCaret = inputTime.CaretIndex;

            switch (inputTime.CaretIndex)
            {
                case int i when i < 3:
                    date1 = date1.AddHours(1);
                    aptText.Text = $"Caret is {inputTime.CaretIndex}. time is = {date1.ToString("hh:mm tt")}";
                    break;
                case int i when i >= 3 && i < 6:
                    date1 = date1.AddMinutes(1);
                    aptText.Text = $"Caret is {inputTime.CaretIndex}. time is = {date1.ToString("hh:mm tt")}";
                    break;
                case int i when i >= 6:
                    date1 = date1.AddHours(12);
                    aptText.Text = $"Caret is {inputTime.CaretIndex}. time is = {date1.ToString("hh:mm tt")}";
                    break;
                default:
                    break;
            }

            inputTime.Text = date1.ToString("hh:mm tt");
            inputTime.CaretIndex = currentCaret;
        }

        private void decrementTime(object sender, RoutedEventArgs e)
        {
            currentCaret = inputTime.CaretIndex;

            switch (inputTime.CaretIndex)
            {
                case int i when i < 3:
                    date1 = date1.AddHours(-1);
                    aptText.Text = $"Caret is {inputTime.CaretIndex}. time is = " + date1.ToString("hh:mm tt");
                    break;
                case int i when i >= 3 && i < 6:
                    date1 = date1.AddMinutes(-1);
                    aptText.Text = $"Caret is {inputTime.CaretIndex}. time is = " + date1.ToString("hh:mm tt");
                    break;
                case int i when i >= 6:
                    date1 = date1.AddHours(-12);
                    aptText.Text = $"Caret is {inputTime.CaretIndex}. time is = " + date1.ToString("hh:mm tt");
                    break;
                default:
                    break;
            }

            inputTime.Text = date1.ToString("hh:mm tt");
            inputTime.CaretIndex = currentCaret;
        }
    }
}
