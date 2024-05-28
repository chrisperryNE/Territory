using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using TerritoryClasses;


namespace TerritoryClasses
{
    public class Program
    {

        public static void Main(String[] args)
        {
            Game game = Game.GameInstance;
            Deck deck = Deck.Instance;
            List<Tuple<string, int>> shuffledcards = deck.shuffledcards;
            game.GameSetUp();

            Console.WriteLine("==^==^==^==\n TERRITORY\n==^==^==^==");
            game.Rules();

            
            while (shuffledcards.Count > 5)
            {

                Console.WriteLine("\n================================");
                Hand();
                CheckForWin();
            }

        }

       
        public static void Hand()
        {
            Game game = Game.GameInstance;

            Console.WriteLine($"Day #{game.GetNextRound()}");
            Console.WriteLine($"{game.MapPosition()}");

            Deck deck = Deck.Instance;
            List<Tuple<string, int>> shuffledcards = deck.shuffledcards;

            Console.WriteLine("There are " + shuffledcards.Count + " cards left in the deck...");
            Console.WriteLine("The battle will last at least " + (shuffledcards.Count / 6) + " more days.");

            int playerAttack = 0;
            int playerDefense = 0;
            
            Console.WriteLine("\nPlayer hand:");
            Console.WriteLine(shuffledcards[0]);
            Console.WriteLine(shuffledcards[1]);
            Console.WriteLine(shuffledcards[2]);

            Random r = new Random();
            int attackorDefense = r.Next(1, 3);
            int computerAttack = 0; 
            int computerDefense = 0;

            if (attackorDefense == 1)
            {
                //Get int of tuple with Item2:  https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2?view=net-8.0
                computerAttack = shuffledcards[3].Item2 + shuffledcards[5].Item2;
                computerDefense = shuffledcards[4].Item2;
            }
            if (attackorDefense == 2)
            {
                computerAttack = shuffledcards[3].Item2;
                computerDefense = shuffledcards[4].Item2 + shuffledcards[5].Item2;
            }

            //Removing computer cards
            shuffledcards.RemoveAt(5);
            shuffledcards.RemoveAt(4);
            shuffledcards.RemoveAt(3);

            //repeating a question in a switch statement: https://stackoverflow.com/questions/72083825/how-do-i-repeat-a-question-in-a-switch-case
            bool isCorrectInput = false;
            do
            {
                Console.WriteLine("\nWhich card would you like to represent your attack value?");
                Console.WriteLine("Press 1, 2 or 3.");

                string attackChoice = Console.ReadLine();

                switch (attackChoice)
                {
                    case "1":
                        playerAttack = shuffledcards[0].Item2;
                        shuffledcards.RemoveAt(0);
                        isCorrectInput = true;
                        break;
                    case "2":
                        playerAttack = shuffledcards[1].Item2;
                        shuffledcards.RemoveAt(1);
                        isCorrectInput = true;
                        break;
                    case "3":
                        playerAttack = shuffledcards[2].Item2;
                        shuffledcards.RemoveAt(2);
                        isCorrectInput = true;
                        break;
                    case "r":
                        game.Rules();
                        Console.WriteLine("-----------------------");
             
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        Console.WriteLine("-----------------------");
                    
                        break;
                }
            } while (!isCorrectInput);

            isCorrectInput = false;
            do
            {
                Console.WriteLine("Strength of attack: " + playerAttack);
                Console.WriteLine("\nRemaining hand:");
                Console.WriteLine(shuffledcards[0]);
                Console.WriteLine(shuffledcards[1]);

                Console.WriteLine("\nWhich card would you like to represent your defense value?");
                Console.WriteLine("Press 1 or 2");
                string defenseChoice = Console.ReadLine();

                switch (defenseChoice)
                {
                    case "1":
                        playerDefense = shuffledcards[0].Item2;
                        shuffledcards.RemoveAt(0);
                        isCorrectInput = true;
                        break;

                    case "2":
                        playerDefense = shuffledcards[1].Item2;
                        shuffledcards.RemoveAt(1);
                        isCorrectInput = true;
                        break;
                    case "r":
                        game.Rules();
                        Console.WriteLine("-----------------------");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        Console.WriteLine("-----------------------");
                        break;
                }

            } while (!isCorrectInput);

            isCorrectInput = false;
            do
            {
                Console.WriteLine("Strength of defense: " + playerDefense);
                Console.WriteLine("\nRemaining card:");
                Console.WriteLine(shuffledcards[0]);
                Console.WriteLine("\nWhat would you like to do with your remaining card?");
                Console.WriteLine("\nPress 1 to add it to attack value, press 2 to add it to defense value or press 3 to keep the card in your hand until next round");

                string lastcardChoice = Console.ReadLine();

                switch (lastcardChoice)
                {
                    case "1":
                        playerAttack = playerAttack + shuffledcards[0].Item2;
                        shuffledcards.RemoveAt(0);
                        isCorrectInput = true;
                        break;
                    case "2":
                        playerDefense = playerDefense + shuffledcards[0].Item2;
                        shuffledcards.RemoveAt(0);
                        isCorrectInput = true;
                        break;
                    case "3":
                        Console.WriteLine(shuffledcards[0] + " will be held until next round.");
                        isCorrectInput = true;
                        break;
                    case "r":
                        game.Rules();
                        Console.WriteLine("-----------------------");
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        Console.WriteLine("-----------------------");
                        break;
                }
            } while (!isCorrectInput);

            //scoring
            Console.WriteLine("================================");
            Console.WriteLine("THE DAY'S RESULT:");
            int roundpoint = 0;
            if (playerAttack > computerDefense)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The player had an attack value of " + playerAttack + ".  The computer had a defense value of " + computerDefense + ".");
                Console.WriteLine("The player's attack was successful!");
                roundpoint++;
                game.AdvanceMapPosition();
                
            }
            if (playerAttack == computerDefense)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The player had an attack value of " + playerAttack + ".  The computer had a defense value of " + computerDefense + ".");
                Console.WriteLine("Neither side was victorious.");
               
            }
            if (playerAttack < computerDefense)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The player had an attack value of " + playerAttack + ".  The computer had a defense value of " + computerDefense + ".");
                Console.WriteLine("The player's attack was unsuccessful!");
                roundpoint--;
                game.RetreatMapPosition();
            }

            if (playerDefense > computerAttack)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The player had a defense value of " + playerDefense + ".  The computer had an attack value of " + computerAttack + ".");
                Console.WriteLine("The player's defense was successful!");
                roundpoint++;
                game.AdvanceMapPosition();
            }
            if (playerDefense == computerAttack)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The player had a defense value of " + playerDefense + ".  The computer had an attack value of " + computerAttack + ".");
                Console.WriteLine("Neither side was victorious.");
                
            }
            if (playerDefense < computerAttack)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The player had a defense value of " + playerDefense + ".  The computer had an attack value of " + computerAttack + ".");
                Console.WriteLine("The player's defense was unsuccessful!");
                roundpoint--;
                game.RetreatMapPosition();
            }

            

            if (roundpoint > 0)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The player has won the day.  They advance towards the computer's base.");
                //game.AdvanceMapPosition();
            }

            if (roundpoint == 0)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Neither side wins the day.  They will fight for the same territory tomorrow.");
            }

            if (roundpoint < -1)
            {
                Console.WriteLine("\n");
                Console.WriteLine("The computer has won day.  They advance towards the player's base.");
                //game.RetreatMapPosition();
            }
            
        }

        public static void CheckForWin()
        {
            Game game = Game.GameInstance;

            if (game.mapPosition < 0)
            {
                Console.WriteLine("Defeat!  Your base has been overrun.");
                Console.WriteLine("To play again, press Enter.  To leave the program, press ESC.");
                var defeatResponse = Console.ReadKey();
                if (defeatResponse.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Thanks for playing!");
                    return;
                }
                if (defeatResponse.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Resetting game...");
                    game.GameSetUp();
                    Deck.ResetInstance();
                }
                else
                    return;
            }
            if (game.mapPosition > 8)
            {
                Console.WriteLine("Victory!  You have won Territory and captured the enemy base.");
                Console.WriteLine("To play again, press Enter.  To leave the program, press ESC.");
                var victoryResponse = Console.ReadKey();
                if (victoryResponse.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Thanks for playing!");
                    return;
                }
                if (victoryResponse.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Resetting game...");
                    game.GameSetUp();
                    Deck.ResetInstance();
                    
                    
                }
                else
                    return;
            }
            else
            {
                Console.WriteLine("");
            }
        }
        

    }


}

