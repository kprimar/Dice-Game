using System;

namespace DiceGame
{
    class Program
    {

        static void Main(string[] args)
        {
            //NEW GAME START UP
            Introduction();
            ConfirmStart();
            Console.WriteLine("How many credits do you want to start with?\nThe minimum number of credits required to play is 10. Please only bet up to 100 credits.");
            int playerBudget = AskForBudget();
            PlayGame(playerBudget);

        }

        private static void PlayGame(int playerBudget)
        {
            Console.WriteLine("What do you think the sum of the dice will be?");
            int playerBet = AskForBet();

            int dieOne = RollDice();
            int dieTwo = RollDice();
            int dieThree = RollDice();
            int dieFour = RollDice();
            int totalRoll = (dieOne + dieTwo + dieThree + dieFour);

            Console.WriteLine("You rolled a " + dieOne + ", " + dieTwo + ", " + dieThree + ", and a " + dieFour + ".");
            Console.WriteLine("The sum of the die " + totalRoll + ". ");
            int payout = CalculateResult(totalRoll, playerBet);
            playerBudget = (playerBudget + payout);
            Console.WriteLine("\nYou now have " + playerBudget + " credits");
            PlayAgain(playerBudget);


        }

        private static void Introduction()
        {
            //GET PLAYER NAME & GIVE INSTRUCTIONS
            Console.WriteLine("Hello! What's your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine("Welcome to the casino, " + playerName + "! Do you want to play a game?");                       
            Console.WriteLine("The dice game is simple. I will roll four, six-sided dice, and you guess what the sum of the four dice will be.");
            Console.WriteLine("If you guess the exact sum of the dice, you'll win 10 more credits.\nIf you're close (+ or - 2) you'll win 5 credits. If you're way off, you lose 10 credits!\nWhaddaya say?");

            Console.WriteLine("\nPress Y to say \"Let's do it!\"");
            Console.WriteLine("\nPress N to say \"Ehh, no thanks\"");
        }

        private static void ConfirmStart()
        {
            string response = Console.ReadLine();
            if (response == "N" || response == "n")
            {
                Console.WriteLine("Okay. See ya!");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            else if (response == "Y" || response == "y")
            {
                Console.WriteLine("Alright!");
            }
            else
            {
                Console.WriteLine("I'm waiting! Yes or no?");
                ConfirmStart();
            }
        }

        private static int AskForBudget()
        {
            string budgetInput = Console.ReadLine();
            int playerBudget;
            while (!int.TryParse(budgetInput, out playerBudget))
            {
                Console.WriteLine("That's not a number...");
                budgetInput = Console.ReadLine();
            }
            if (playerBudget <= 0)
            {
                Console.WriteLine("You can't have a negative or 0 balance...");
                AskForBudget();
            }
            else if (playerBudget < 10 || playerBudget > 100)
            {
                Console.WriteLine("You need to pick a number between 10 and 100.");
                AskForBudget();
            }
            else
            {
                Console.WriteLine("Alright! You have " + playerBudget + " credits available!\n");
            }
            return playerBudget;
        }

        private static int AskForBet()
        {
            string betInput = Console.ReadLine();
            int playerBet;
            while(!int.TryParse(betInput, out playerBet))
            {
                Console.WriteLine("You need to pick a number between 4 and 24.");
                betInput = Console.ReadLine();
            }
            if(playerBet <= 3 || playerBet > 24)
            {
                Console.WriteLine("You need to pick a number between 4 and 24.");
                AskForBet();
            }
            else
            {
                Console.WriteLine("Here we go!\n.\n.\n.\n.\n.");
            }
            return playerBet;
        }

        private static int RollDice()
        {
            Random randDieRoll = new Random();
            int dieRoll = randDieRoll.Next(1, 7);
            return dieRoll;
        }

        private static int CalculateResult(int totalRoll, int playerBet)
        {
            int[] payouts = { 10, 5, -10 };

            if (playerBet == totalRoll)
            {
                Console.WriteLine("Your bet was " + playerBet + ".");
                Console.WriteLine("\nNailed it! You win the maximum prize");
                return payouts[0];
            }

            if (Math.Abs(playerBet-totalRoll) <= 2)
            {
                Console.WriteLine("Your bet was " + playerBet + ". So close!");
                return payouts[1];
            }

            else 
            {
                Console.WriteLine("Your bet was " + playerBet + ".");
                Console.WriteLine("\nYou lose! Want to try again?");
                return payouts[2];
            }

        }

        private static void PlayAgain(int playerBudget)
        {
            if (playerBudget <=0)
            {
                Console.WriteLine("Oh! You're out of credits. Come back some other time!");
                Console.ReadLine();
                Environment.Exit(-1);
            }

            Console.WriteLine("\nDo you want to keep playing?");
            string response = Console.ReadLine();
            if (response == "N" || response == "n")
            {
                Console.WriteLine("Okay. See ya!");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            else if (response == "Y" || response == "y")
            {
                PlayGame(playerBudget);
            }
            else
            {
                Console.WriteLine("I'm waiting! Yes or no?");
                PlayAgain(playerBudget);
            }
        }

    }
}
