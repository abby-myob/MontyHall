using System.Collections.Generic;

namespace MontyHallLibrary.Interfaces
{
    public interface IDoors
    {
        List<IDoor> DoorsList { get; }
        void SetUp();
        void RandomlyPlaceGoat();
    }
}