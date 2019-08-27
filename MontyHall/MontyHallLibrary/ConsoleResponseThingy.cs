using System;
using MontyHallLibrary.Interfaces;

namespace MontyHallLibrary
{
    public class ConsoleResponseThingy : IResponseThingy
    {
        public int PickDoor()
        {
            Console.WriteLine("what door?");
            return int.Parse(Console.ReadLine());
        }

        public bool SwitchToOtherDoor()
        {
            Console.WriteLine("switch?");
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
    }
}