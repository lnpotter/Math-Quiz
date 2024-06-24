using System;

namespace MathQuiz
{
    public static class Operations
    {
        public static string GenerateQuestion(int difficulty)
        {
            Random rand = new Random();
            int operationType = rand.Next(1, difficulty > 3 ? 7 : 5); // if difficulty > 3 - ^ / √ 
            int num1, num2;
            string question = "";

            switch (operationType)
            {
                case 1:
                    num1 = rand.Next(1, 10 * difficulty);
                    num2 = rand.Next(1, 10 * difficulty);
                    question = $"{num1} + {num2} = ?";
                    break;
                case 2:
                    num1 = rand.Next(1, 10 * difficulty);
                    num2 = rand.Next(1, num1);
                    question = $"{num1} - {num2} = ?";
                    break;
                case 3:
                    num1 = rand.Next(1, 10 * difficulty);
                    num2 = rand.Next(1, 10 * difficulty);
                    question = $"{num1} * {num2} = ?";
                    break;
                case 4:
                    num2 = rand.Next(1, 10 * difficulty);
                    num1 = num2 * rand.Next(1, 10 * difficulty);
                    question = $"{num1} / {num2} = ?";
                    break;
                case 5:
                    num1 = rand.Next(1, 10 * difficulty);
                    question = $"√{num1 * num1} = ?";
                    break;
                case 6:
                    num1 = rand.Next(1, 5);
                    num2 = rand.Next(1, difficulty);
                    question = $"{num1} ^ {num2} = ?";
                    break;
            }
            return question;
        }

        public static bool VerifyAnswer(string question, string userAnswer)
        {
            string[] parts = question.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
            int num1 = int.Parse(parts[0]);
            int num2 = parts.Length > 2 ? int.Parse(parts[2]) : 0;
            char operation = parts[1][0];

            double correctAnswer = operation switch
            {
                '+' => num1 + num2,
                '-' => num1 - num2,
                '*' => num1 * num2,
                '/' => num1 / num2,
                '√' => Math.Sqrt(num1),
                '^' => Math.Pow(num1, num2),
                _ => 0
            };

            return Math.Abs(correctAnswer - double.Parse(userAnswer)) < 0.001;
        }
    }
}
