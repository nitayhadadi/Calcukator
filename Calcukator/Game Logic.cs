using System;
using System.Collections.Generic;

namespace calculator
{
    public class MathGameLogic
    {
        private int number1;
        private int number2;
        private int correctAnswer;
        private Random random = new Random();
        private int score = 0;
        private int gradeLevel;
        private int correctCount = 0;
        private int incorrectCount = 0;
        private int questionCount = 0;
        private List<string> wrongAnswers = new List<string>();

        public MathGameLogic(int grade)
        {
            gradeLevel = grade;
            GenerateNewProblem();
        }

        public int Number1 => number1;
        public int Number2 => number2;
        public int CorrectAnswer => correctAnswer;
        public int Score => score;
        public int CorrectCount => correctCount;
        public int IncorrectCount => incorrectCount;
        public int QuestionCount => questionCount;
        public List<string> WrongAnswers => wrongAnswers;

        public void GenerateNewProblem()
        {
            number1 = random.Next(1, 10);
            number2 = random.Next(1, 10);

            switch (gradeLevel)
            {
                case 1:
                    // Grade 1: Simple addition
                    correctAnswer = number1 + number2;
                    break;
                case 2:
                    // Grade 2: Addition and subtraction
                    if (random.Next(2) == 0)
                    {
                        correctAnswer = number1 + number2;
                    }
                    else
                    {
                        correctAnswer = number1 - number2;
                    }
                    break;
                case 3:
                    // Grade 3: Addition, subtraction, and multiplication
                    int operation = random.Next(3);
                    if (operation == 0)
                    {
                        correctAnswer = number1 + number2;
                    }
                    else if (operation == 1)
                    {
                        correctAnswer = number1 - number2;
                    }
                    else
                    {
                        correctAnswer = number1 * number2;
                    }
                    break;
                case 4:
                    // Grade 4: All operations, including division
                    operation = random.Next(4);
                    if (operation == 0)
                    {
                        correctAnswer = number1 + number2;
                    }
                    else if (operation == 1)
                    {
                        correctAnswer = number1 - number2;
                    }
                    else if (operation == 2)
                    {
                        correctAnswer = number1 * number2;
                    }
                    else
                    {
                        while (number2 == 0 || number1 % number2 != 0)
                        {
                            number2 = random.Next(1, 10);
                        }
                        correctAnswer = number1 / number2;
                    }
                    break;
                default:
                    // Default to simple addition for other cases
                    correctAnswer = number1 + number2;
                    break;
            }
        }

        public void CheckAnswer(int userAnswer)
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
                wrongAnswers.Add($"Question: {number1} + {number2}, Your Answer: {userAnswer}, Correct Answer: {correctAnswer}");
            }

            if (questionCount < 10)
            {
                GenerateNewProblem();
            }
        }

        public string GetSummaryMessage()
        {
            // Create the summary message
            string summary = $"Game Over!\nCorrect answers: {correctCount}\nIncorrect answers: {incorrectCount}\nScore: {score}\n\nWrong Answers:\n";
            foreach (string wrongAnswer in wrongAnswers)
            {
                summary += wrongAnswer + "\n";
            }

            return summary;
        }
    }
}
