using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    public partial class Mathgame : Window
    {
        private int number1;
        private int number2;
        private int correctAnswer;
        private Random random = new Random();
        private int score = 0;
        public int GradeLevel;


        public Mathgame(int grade)
        {
            InitializeComponent();
            GradeLevel = grade;
            GenerateNewProblem();
        }

        private void GenerateNewProblem()
        {
            number1 = random.Next(1, 10);
            number2 = random.Next(1, 10);
            questionNumberTextBlock.Text = $"Question {questionCount + 1}/10";

            switch (GradeLevel)
            {
                case 1:
                    // Grade 1: Simple addition
                    correctAnswer = number1 + number2;
                    txtOperation.Text = "+";
                    break;
                case 2:
                    // Grade 2: Addition and subtraction
                    if (random.Next(2) == 0)
                    {
                        correctAnswer = number1 + number2;
                        txtOperation.Text = "+";
                    }
                    else
                    {
                        correctAnswer = number1 - number2;
                        txtOperation.Text = "-";
                    }
                    break;
                case 3:
                    // Grade 3: Addition, subtraction, and multiplication
                    int operation = random.Next(3);
                    if (operation == 0)
                    {
                        correctAnswer = number1 + number2;
                        txtOperation.Text = "+";
                    }
                    else if (operation == 1)
                    {
                        correctAnswer = number1 - number2;
                        txtOperation.Text = "-";
                    }
                    else
                    {
                        correctAnswer = number1 * number2;
                        txtOperation.Text = "*";
                    }
                    break;
                case 4:
                    // Grade 4: All operations, including division
                    operation = random.Next(4);
                    if (operation == 0)
                    {
                        correctAnswer = number1 + number2;
                        txtOperation.Text = "+";
                    }
                    else if (operation == 1)
                    {
                        correctAnswer = number1 - number2;
                        txtOperation.Text = "-";
                    }
                    else if (operation == 2)
                    {
                        correctAnswer = number1 * number2;
                        txtOperation.Text = "*";
                    }
                    else
                    {
                        while (number2 == 0 || number1 % number2 != 0)
                        {
                            number2 = random.Next(1, 10);
                        }
                        correctAnswer = number1 / number2;
                        txtOperation.Text = "/";
                    }
                    break;
                default:
                    // Default to simple addition for other cases
                    correctAnswer = number1 + number2;
                    txtOperation.Text = "+";
                    break;

            }

            txtNumber1.Text = number1.ToString();
            txtNumber2.Text = number2.ToString();
        }
        private void UpdateScoreDisplay()
        {
            scoreTextBlock.Text = $"Score: {score}";
        }
        private int correctCount = 0;
        private int incorrectCount = 0;
        private int questionCount = 0;
        private List<string> wrongAnswers = new List<string>();

        private void ResetGame()
        {
            score = 0;
            correctCount = 0;
            incorrectCount = 0;
            questionCount = 0;
            wrongAnswers.Clear(); // Clear the list of wrong answers
            UpdateScoreDisplay();
            GenerateNewProblem();
        }




        private void CheckAnswer()
        {
            if (int.TryParse(answerTextBox.Text, out int userAnswer))
            {
                questionCount++;


                if (userAnswer == correctAnswer)
                {
                    correctCount++;
                    score += 10;
                }
                else
                {
                    incorrectCount++;
                    // Store the question and the incorrect answer
                    wrongAnswers.Add($"Question: {number1} {txtOperation.Text} {number2}, Your Answer: {userAnswer}, Correct Answer: {correctAnswer}");
                }

                answerTextBox.Clear();
                UpdateScoreDisplay();

                if (questionCount < 10)
                {
                    GenerateNewProblem();
                }
                else
                {
                    // Create the summary message
                    string summary = $"Game Over!\nCorrect answers: {correctCount}\nIncorrect answers: {incorrectCount}\nScore: {score}\n\nWrong Answers:\n";
                    foreach (string wrongAnswer in wrongAnswers)
                    {
                        summary += wrongAnswer + "\n";
                    }

                    MessageBox.Show(summary);
                    this.Close();
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
            this.Close();
        }


    }
}