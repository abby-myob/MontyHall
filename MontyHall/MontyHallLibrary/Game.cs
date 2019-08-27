using MontyHallLibrary.Interfaces;

namespace MontyHallLibrary
{
    public class Game
    {
        private readonly IDoors _doors;
        private readonly IResponseThingy _io;

        public Game(IDoors doors, IResponseThingy io)
        {
            _doors = doors;
            _io = io;
        }
        
        public void Play()
        {
            SetUpDoors();
        }

        public int GetCarDoor()
        {
            for (var i = 0; i < 3; i++)
            {
                if (_doors.DoorsList[i].Prize == Prize.Car)
                {
                    return i + 1;
                }
            }
            return 0;
        }


        public int GetOtherGoatDoor(int pickedDoor)
        {
            var pickedDoorIndex = pickedDoor - 1;
            
            for (var i = 0; i < 3; i++)
            {
                if (_doors.DoorsList[i].Prize == Prize.Goat && i != pickedDoorIndex)
                {
                    return i + 1;
                }
            }
            
            return 3; 
        }



        private void SetUpDoors()
        {
            _doors.SetAllToGoats();
            _doors.RandomlyPlaceCar();
        }
    }
}