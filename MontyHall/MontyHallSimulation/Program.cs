using System.Collections.Generic;
using MontyHallLibrary;
using MontyHallLibrary.Interfaces;

namespace MontyHallSimulation
{
    internal static class Program
    {
        private static void Main()
        {
            for (var j = 0; j < 20; j++)
            {
                var gameSwitching = new Game(new Doors(new List<IDoor>() {new Door(), new Door(), new Door()}),
                    new SimulationResponseThingy(true));
                var gameSticking = new Game(new Doors(new List<IDoor>() {new Door(), new Door(), new Door()}),
                    new SimulationResponseThingy(false));

                for (var i = 0; i < 1000; i++)
                {
                    gameSwitching.Play();
                    gameSticking.Play();
                }
            }
        }
    }
}