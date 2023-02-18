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
    /// Made by Brandon Buttlar, SP 2023
    /// </summary>
    public partial class MainWindow : Window
    {
        public int currentCaret = 0;
        public DateTime aptTime = new DateTime(2023, 1, 1, 0, 0, 0);

        public MainWindow()
        {
            InitializeComponent();
            aptCal.SelectedDate = DateTime.Now; // avoids a possible null date
            inputTime.Text = aptTime.ToString("hh:mm tt");
        }

        private void SetAptBtn(object sender, RoutedEventArgs e)
        {
            DateTime aptDate = new DateTime();
            aptDate = (DateTime)aptCal.SelectedDate;
            string formattedAptDate = aptDate.ToString("dddd, MMMM d, yyyy") + 
                " at " + aptTime.ToString("hh:mm tt");
            int dayDiff = aptDate.DayOfYear - DateTime.Now.DayOfYear;

            if (dayDiff == 1) {
                aptText.Text = $"Your appointment is on {formattedAptDate}. " +
                    $"It's {dayDiff} day from today.";
            }
            if (dayDiff < 0)
            {
                aptText.Text = "Date selected is in the past, please pick a different date";
            }
            else
            {
                aptText.Text = $"Your appointment is on {formattedAptDate}. " +
                    $"It's {dayDiff} days from today.";
            }
        }

        // Main method used to change the input time based on the user's
        // cursor position in the input box.
        private void IncrementTime(int direction)
        {
            // We need to capture the caret position between button clicks
            // b/c inputTime loses focus on a button press.
            currentCaret = inputTime.CaretIndex;

            switch (inputTime.CaretIndex)
            {
                // Change hour val when caret is before ":"
                case int i when i < 3:
                    aptTime = aptTime.AddHours(direction);
                    break;
                // Change minute val when caret is after ":" and before AM/PM
                case int i when i >= 3 && i < 6:
                    aptTime = aptTime.AddMinutes(direction);
                    break;
                // Change AM/PM value of time
                case int i when i >= 6:
                    aptTime = aptTime.AddHours(12);
                    break;
                default:
                    break;
            }

            inputTime.Text = aptTime.ToString("hh:mm tt");
            // Whenever inputTime.text is updated, we need to reassign the caret position.
            inputTime.CaretIndex = currentCaret;
        }

        private void UpBtn(object sender, RoutedEventArgs e)
        {
            IncrementTime(1);
        }

        private void DownBtn(object sender, RoutedEventArgs e)
        {
            IncrementTime(-1);
        }
    }
}
