using System;
using MontyHallLibrary.Interfaces;

namespace MontyHallLibrary
{
    public class SimulationResponseThingy : IResponseThingy
    {
        private readonly bool _isSwitching;

        public SimulationResponseThingy(bool isSwitching)
        {
            _isSwitching = isSwitching;
        }
        
        public int PickDoor()
        {
            var random = new Random();
            return random.Next(1, 4);
        }

        public bool SwitchToOtherDoor()
        {
            return _isSwitching;
        }
    }
}