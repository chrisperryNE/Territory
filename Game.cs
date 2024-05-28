using System;
using TerritoryClasses;

namespace TerritoryClasses
{
	public class Game
	{
        public static Game gameinstance;
        public static Game GameInstance
        {
            get
            {
                if (gameinstance == null)
                {
                    gameinstance = new Game();
                }
                return gameinstance;
            }
        }

        public int round;
		public int mapPosition;


        public void GameSetUp()
		{
			round = 0;
			mapPosition = 4;
		}

        public int GetNextRound()
        {
			round++;
			return round;
        }

        public int AdvanceMapPosition()
        {
            mapPosition++;
            return mapPosition;
        }
        public int RetreatMapPosition()
        {
            mapPosition--;
            return mapPosition;
        }

        public string MapPosition()
        {
            string newmapPosition = "";
            string map0 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║ X ║   ║   ║   ║   ║   ║   ║   ║   ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";

            string map1 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║   ║ X ║   ║   ║   ║   ║   ║   ║   ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";

            string map2 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║   ║   ║ X ║   ║   ║   ║   ║   ║   ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";

            string map3 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║   ║   ║   ║ X ║   ║   ║   ║   ║   ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";

            string map4 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║   ║   ║   ║   ║ X ║   ║   ║   ║   ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";
            string map5 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║   ║   ║   ║   ║   ║ X ║   ║   ║   ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";
            string map6 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║   ║   ║   ║   ║   ║   ║ X ║   ║   ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";
            string map7 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║   ║   ║   ║   ║   ║   ║   ║ X ║   ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";
            string map8 = @"
            ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
  Player    ║   ║   ║   ║   ║   ║   ║   ║   ║ X ║	Computer
            ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝		
                ";

            if (mapPosition == 0)
            {
                newmapPosition = map0;
            }
            if (mapPosition == 1)
            {
                newmapPosition = map1;
            }
            if (mapPosition == 2)
            {
                newmapPosition = map2;
            }
            if (mapPosition == 3)
            {
                newmapPosition = map3;
            }
            if (mapPosition == 4)
            {
                newmapPosition = map4; 
            }
            if (mapPosition == 5)
            {
                newmapPosition = map5;
            }
            if (mapPosition == 6)
            {
                newmapPosition = map6;
            }
            if (mapPosition == 7)
            {
                newmapPosition = map7;
            }
            if (mapPosition == 8)
            {
                newmapPosition = map8;
            }


            return newmapPosition;


        }

        public void Rules()
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("\nGameplay:\n" +
            "\nThe objective of the game is to capture territory and advance across the map towards the enemy's base." +
            "\nThe player will advance or be forced to retreat based on the results of daily battles." +
            "\nThe war will last for at least 8 days." +

            "\n\nDuring each day, both players (human and computer) draw three cards." +
            "\nThey must choose one card to represent their attack power." +
            "\nThey must choose one card to represent their defense power." +
            "\nWith the third card, they player can choose to add it to their attack power, their defense power or hold onto it for the next day." +
            "\nIf they hold the card, they will only draw two cards for the next day" +
            "\nIf the player's attack is successful, they will advance one space." +
            "\nIf the player's defense is successful, they will advance one space." +
            "\nIf the player ties with the computer, they will not advance." +
            "\nLosing to the computer will result in being forced to retreat." +

            "\n\nWinning:\n\nThe player who has captured the most territory wins." +
            "\n\nCard Values:\n\nAce = 1 | Jack = 10 | Queen = 10 | King = 10 | card number = value" +

            "\nAt anytime, press R to see the rules or ESC to quit.");
            
        }

    }
}

