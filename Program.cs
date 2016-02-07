using System;
using System.Collections.Generic;

namespace MontyHallProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfAttempts = 1000000;
            int NumberOfWins = 0;
            Random rnd = new Random();

            for (int i = 1; i <= NumberOfAttempts; i++)
            {
                // Prize Randomly placed behind one of 3 doors
                var PrizeDoor = rnd.Next(1, 4);
                // Contestant randomly picks a door 
                var FirstGuessDoor = rnd.Next(1, 4);                

                // Figure out which door the host would open to reveal no prize
                List<int> HostOpenableDoors = new List<int>() { 1, 2, 3 };
                // The host can't open the prize door, so remove it from the options 
                HostOpenableDoors.Remove(PrizeDoor);
                // Also remove the door originally guessed so it won't be opened
                HostOpenableDoors.Remove(FirstGuessDoor);
                // Figure out which one of the non-prize doors the host will open                
                var HostOpenedDoor = HostOpenableDoors[rnd.Next(0, (HostOpenableDoors.Count))];

                // Figure out which door the contestant is switching to 
                List<int> SelectableDoors = new List<int>() { 1, 2, 3 };
                // Contestant no longer has the option to select the door that is open
                SelectableDoors.Remove(HostOpenedDoor);
                // Contestant doesn't want to select the first guess
                SelectableDoors.Remove(FirstGuessDoor);
                // The one left is the switched selection 
                var SwitchedGuessDoor = SelectableDoors[0];

                // Check if they would have won by switching
                if (PrizeDoor == SwitchedGuessDoor)
                {
                    NumberOfWins++;
                }
            }

            Console.WriteLine("Number of wins after switching: " + NumberOfWins.ToString() + " out of " + NumberOfAttempts.ToString());
            Console.WriteLine("Which is " + ((Convert.ToDouble(NumberOfWins) / Convert.ToDouble(NumberOfAttempts)) * 100).ToString("0.00") + "%");
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }
    }
}
;