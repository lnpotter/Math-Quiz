using System;

namespace MathQuiz
{
    public static class Operations
    {
        private static readonly Random rand = new Random();
        private const int MAX_SIMPLE_DIFFICULTY = 3;
        private const int MAX_ADVANCED_DIFFICULTY = 5;

        public static string GenerateQuestion(int difficulty)
        {
            int operationType = rand.Next(1, difficulty > MAX_SIMPLE_DIFFICULTY ? 7 : 5);
            string question = operationType switch
            {
                1 => GenerateAdditionQuestion(difficulty),
                2 => GenerateSubtractionQuestion(difficulty),
                3 => GenerateMultiplicationQuestion(difficulty),
                4 => GenerateDivisionQuestion(difficulty),
                5 => GenerateSquareRootQuestion(difficulty),
                6 => GenerateExponentiationQuestion(difficulty),
                _ => throw new InvalidOperationException("Invalid operation type")
            };
            return question;
        }

        private static string GenerateAdditionQuestion(int difficulty)
        {
            int num1 = rand.Next(1, 10 * difficulty);
            int num2 = rand.Next(1, 10 * difficulty);
            return $"{num1} + {num2} = ?";
        }

        private static string GenerateSubtractionQuestion(int difficulty)
        {
            int num1 = rand.Next(1, 10 * difficulty);
            int num2 = rand.Next(1, num1);
            return $"{num1} - {num2} = ?";
        }

        private static string GenerateMultiplicationQuestion(int difficulty)
        {
            int num1 = rand.Next(1, 10 * difficulty);
            int num2 = rand.Next(1, 10 * difficulty);
            return $"{num1} * {num2} = ?";
        }

        private static string GenerateDivisionQuestion(int difficulty)
        {
            int num2 = rand.Next(1, 10 * difficulty);
            int num1 = num2 * rand.Next(1, 10 * difficulty);
            return $"{num1} / {num2} = ?";
        }

        private static string GenerateSquareRootQuestion(int difficulty)
        {
            int num1 = rand.Next(1, 10 * difficulty);
            return $"√{num1 * num1} = ?";
        }

        private static string GenerateExponentiationQuestion(int difficulty)
        {
            int num1 = rand.Next(1, 5);
            int num2 = rand.Next(1, difficulty);
            return $"{num1} ^ {num2} = ?";
        }

        public static bool VerifyAnswer(string question, string userAnswer)
        {
            string[] parts = question.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
            int num1 = 0, num2 = 0;
            bool isNum1Parsed = int.TryParse(parts[0], out num1);
            bool isNum2Parsed = parts.Length > 2 && int.TryParse(parts[2], out num2);

            if (isNum1Parsed && (parts.Length <= 2 || isNum2Parsed) && double.TryParse(userAnswer, out double userAnswerParsed))
            {
                char operation = parts[1][0];
                double correctAnswer = operation switch
                {
                    '+' => num1 + num2,
                    '-' => num1 - num2,
                    '*' => num1 * num2,
                    '/' => num1 / (double)num2,
                    '√' => Math.Sqrt(num1),
                    '^' => Math.Pow(num1, num2),
                    _ => throw new InvalidOperationException("Invalid operation")
                };

                return Math.Abs(correctAnswer - userAnswerParsed) < 0.001;
            }
            return false;
        }
    }
}
