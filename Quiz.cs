using System;

namespace MathQuiz
{
    public class Quiz
    {
        private int difficulty;
        private int score;

        public Quiz()
        {
            difficulty = 1;
            score = 0;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the Math Quiz!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            while (true)
            {
                string question = Operations.GenerateQuestion(difficulty);
                Console.WriteLine(question);
                string userAnswer = Console.ReadLine();

                if (Operations.VerifyAnswer(question, userAnswer))
                {
                    Console.WriteLine("Correct!");
                    score += 10;
                    IncreaseDifficulty();
                }
                else
                {
                    Console.WriteLine("Wrong!");
                    score -= 5;
                    DecreaseDifficulty();
                }

                Console.WriteLine($"Score: {score}");
                Console.WriteLine($"Difficulty: {difficulty}");
                Console.WriteLine("Press 'q' to quit or any other key to continue...");
                if (Console.ReadLine().ToLower() == "q")
                {
                    break;
                }
            }

            Console.WriteLine("Thanks for playing!");
            Console.WriteLine($"Final score: {score}");
        }

        private void IncreaseDifficulty()
        {
            difficulty++;
        }

        private void DecreaseDifficulty()
        {
            if (difficulty > 1)
            {
                difficulty--;
            }
        }
    }
}
