using System;
namespace OppgaveSimuleringFinneLoesningPaaFlaskeoppgaver
{
    public class Menu
    {
        public static void Run()
        {
            Console.WriteLine("Welcome to the bottle calculator");
            Console.WriteLine();

            while (true)
            {
                var bottleOneCapacity = AskForInt("What should the capacity of bottle one be? ");
                var bottleTwoCapacity = AskForInt("What should the capacity of bottle one be? ");
                var wantedVolume = AskForInt("Which volume do you want to reach? ");
                Console.WriteLine();

                var calculator = new Calculator(bottleOneCapacity, bottleTwoCapacity, wantedVolume);

                calculator.Calculate();

                var playAgain = Ask("Enter x to exit the program or any other to start again");

                if (playAgain == "x") break;
            }
        }
        private static string Ask(string prompt)
        {
            Console.Write(prompt);
            var response = Console.ReadLine();

            return response;
        }
        private static int AskForInt(string prompt)
        {
            return Convert.ToInt32(Ask(prompt));
        }
    }
}

