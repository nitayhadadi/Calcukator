using System.Windows.Controls;
using System.Windows;

namespace calculator
{
    public partial class MainWindow : Window
    {
        internal class Start
        {
            // You can add properties or methods related to the Start class here
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;

            if (int.TryParse(AgeTextBox.Text, out int gradeLevel))
            {
                // Ensure grade level is within a valid range (e.g., 1 to 4)
                if (gradeLevel >= 1 && gradeLevel <= 4)
                {
                    Mathgame gamePage = new Mathgame(gradeLevel);
                    gamePage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a valid grade level (1-4).");
                }
            }
            else
            {
                MessageBox.Show("Please enter a numeric grade level.");
            }
        }

        private void AgeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // You can add any additional logic for the text changed event if needed
        }
    }
}
