using System;
using MontyHallLibrary.Interfaces;

namespace MontyHallLibrary
{
    public class ConsoleResponseThingy : IResponseThingy
    {
        public int PickDoor()
        {
            Console.WriteLine("What door would you like to pick?");
            return int.Parse(Console.ReadLine());
        }

        public bool SwitchToOtherDoor()
        {
            Console.Write("Do you want to switch? (y/n) ");
            var response = Console.ReadLine();
            switch (response)
            {
                case "y":
                case "Y":
                    return true;
                default:
                    return false;
            }
        }

        public void ShowGoatDoor(int otherGoatDoor)
        {
            Console.WriteLine($"A goat is behind door {otherGoatDoor}");
        }

        public void ShowWinOrLose(bool winOrLose)
        {
            Console.WriteLine(winOrLose ? "You Won" : "You Lost");
        }
    }
}