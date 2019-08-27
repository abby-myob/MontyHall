using System.Collections.Generic;
using MontyHallLibrary;
using MontyHallLibrary.Interfaces;

namespace MontyHallConsole
{
    internal static class Program
    {
        private static void Main()
        {
            var game = new Game(new Doors(new List<IDoor>() {new Door(), new Door(), new Door()}),
                new ConsoleResponseThingy());

            while (true)
            {
                game.Play();
            }
        }
    }
}