using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    public partial class Mathgame : Window
    {
        private MathGameLogic gameLogic;
        private int gradeLevel;

        public Mathgame(int grade)
        {
            InitializeComponent();
            gameLogic = new MathGameLogic(grade);
            gradeLevel = grade;

            GenerateNewProblem();
        }
        public int GradeLevel => gradeLevel;




        private void GenerateNewProblem()
        {
            // Retrieve values from the MathGameLogic instance
            txtNumber1.Text = gameLogic.Number1.ToString();
            txtNumber2.Text = gameLogic.Number2.ToString();
            txtOperation.Text = "+"; // Assuming default operation is addition
            questionNumberTextBlock.Text = $"Question {gameLogic.QuestionCount + 1}/10";
        }

        private void UpdateScoreDisplay()
        {
            scoreTextBlock.Text = $"Score: {gameLogic.Score}";
        }

        private void ResetGame()
        {
            UpdateScoreDisplay();
            GenerateNewProblem();
        }

        private void CheckAnswer()
        {
            if (int.TryParse(answerTextBox.Text, out int userAnswer))
            {
                gameLogic.CheckAnswer(userAnswer);
                answerTextBox.Clear();
                UpdateScoreDisplay();

                if (gameLogic.QuestionCount < 10)
                {
                    GenerateNewProblem();
                }
                else
                {
                    string summary = gameLogic.GetSummaryMessage();
                    MessageBox.Show(summary);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtNumber2_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle text changes if needed
        }
    }
}
