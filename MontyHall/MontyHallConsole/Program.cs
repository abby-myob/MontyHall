using System;
using System.Collections.Generic;
using MontyHallLibrary;
using MontyHallLibrary.Interfaces;

namespace MontyHallConsole
{
    class Program
    {
        static void Main(string[] args)
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