using System;
using MontyHallLibrary.Interfaces;

namespace MontyHallLibrary
{
    public class SimulationResponseThingy : IResponseThingy
    {
        private readonly bool _isSwitching;
        private int _totalPlays = 0;
        private int _totalWins = 0; 

        public SimulationResponseThingy(bool isSwitching)
        {
            _isSwitching = isSwitching;
        }

        public int PickDoor()
        {
            var random = new Random();
            var doorNumber = random.Next(1, 4);
            //Console.WriteLine($"Door number chosen: {doorNumber}");
            return doorNumber;
        }

        public bool SwitchToOtherDoor()
        {
            return _isSwitching;
        }

        public void ShowGoatDoor(int getOtherGoatDoor)
        {
            //Console.WriteLine($"A goat is behind door {getOtherGoatDoor}");
            //Console.WriteLine(_isSwitching ? "You switch" : "You Stay");
        }

        public void ShowWinOrLose(bool winOrLose)
        {
            //Console.WriteLine(winOrLose ? "You Won" : "You Lost");
            _totalPlays++;
            if (winOrLose) _totalWins++;

            var isSwitch = _isSwitching ? "For Switching" : "For Sticking";
            //Console.WriteLine($"{isSwitch}: {_totalWins} wins out of {_totalPlays} games.\n");

            var percentage = (int) Math.Round((double) (100 * _totalWins) / _totalPlays);

            if (_totalPlays == 1000)
            {
                //Console.WriteLine($"\n{isSwitch}: {_totalWins} wins out of {_totalPlays} games.");
                Console.WriteLine($"{isSwitch}: {percentage}%");
            }
        }
    }
}