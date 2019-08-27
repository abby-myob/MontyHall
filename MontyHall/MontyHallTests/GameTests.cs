using System.Collections.Generic;
using MontyHallLibrary;
using MontyHallLibrary.Interfaces;
using Xunit;

namespace MontyHallTests
{
    public class GameTests
    {
        [Fact]
        public void produce_which_door_has_car_prize()
        {
            // Arrange  
            var doors = new FakeDoors(new List<IDoor>()
            {
                new Door(),
                new Door(),
                new Door()
            });
            doors.SetUp();
            doors.RandomlyPlaceCar();

            var game = new GameManager(doors);
            
            // Act 
            var doorNumber = game.GetCarDoor();
            
            // Assert
            Assert.Equal(1, doorNumber);
        }
        
        [Fact]
        public void pick_goat_produce_other_door_with_goat()
        {
            // Arrange  
            var doors = new FakeDoors(new List<IDoor>()
            {
                new Door(),
                new Door(),
                new Door()
            });
            doors.SetUp();
            doors.RandomlyPlaceCar();

            var game = new GameManager(doors);
            
            // Act 
            var doorNumber = game.GetOtherGoatDoor(2);
            
            // Assert
            Assert.Equal(3, doorNumber);
        }
        
        [Fact]
        public void pick_car_produce_other_door_with_goat()
        {
            // Arrange  
            var doors = new FakeDoors(new List<IDoor>()
            {
                new Door(),
                new Door(),
                new Door()
            });
            doors.SetUp();
            doors.RandomlyPlaceCar();

            var game = new GameManager(doors);
            
            // Act 
            var doorNumber = game.GetOtherGoatDoor(1);
            
            // Assert
            Assert.Equal(2, doorNumber);
        }
    }

    public class GameManager
    {
        private readonly IDoors _doors;

        public GameManager(IDoors doors)
        {
            _doors = doors;
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
    }

    public class FakeDoors : IDoors
    {
        public List<IDoor> DoorsList { get; }
        public FakeDoors(List<IDoor> doors)
        {
            DoorsList = doors;
        }

        public void SetUp()
        {
            foreach (var door in DoorsList)
            {
                door.SetPrize(Prize.Goat);
            }
        }

        public void RandomlyPlaceCar()
        { 
            DoorsList[0].SetPrize(Prize.Car);
        }
    }
}