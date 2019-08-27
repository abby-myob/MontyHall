using System.Collections.Generic;
using MontyHallLibrary;
using MontyHallLibrary.Interfaces;
using Moq;
using Xunit;

namespace MontyHallTests
{
    public class GameTests
    {
        [Fact]
        public void produce_which_door_has_car_prize()
        {
            // Arrange  
            var doors = new FakeDoors(new List<IDoor>() {new Door(), new Door(), new Door()});
            doors.SetAllToGoats();
            doors.RandomlyPlaceCar();

            var game = new Game(doors, new SimulationResponseThingy(true));

            // Act 
            var doorNumber = game.GetCarDoor();

            // Assert
            Assert.Equal(1, doorNumber);
        }

        [Fact]
        public void pick_goat_produce_other_door_with_goat()
        {
            // Arrange  
            var doors = new FakeDoors(new List<IDoor>() {new Door(), new Door(), new Door()});
            doors.SetAllToGoats();
            doors.RandomlyPlaceCar();

            var game = new Game(doors, new SimulationResponseThingy(true));

            // Act 
            var doorNumber = game.GetOtherGoatDoor(2);

            // Assert
            Assert.Equal(3, doorNumber);
        }

        [Fact]
        public void pick_car_produce_other_door_with_goat()
        {
            // Arrange  
            var doors = new FakeDoors(new List<IDoor>() {new Door(), new Door(), new Door()});
            doors.SetAllToGoats();
            doors.RandomlyPlaceCar();

            var game = new Game(doors, new SimulationResponseThingy(true));

            // Act 
            var doorNumber = game.GetOtherGoatDoor(1);

            // Assert
            Assert.Equal(2, doorNumber);
        }

        [Fact]
        public void play_game_calls_doors_setAllToGoats()
        {
            // Arrange  
            var fakeDoors = new Mock<IDoors>();
            var fakeResponseThingy = new Mock<IResponseThingy>();
            var game = new Game(fakeDoors.Object, fakeResponseThingy.Object);

            // Act 
            game.SetUpDoors();

            // Assert
            fakeDoors.Verify(d => d.SetAllToGoats(), Times.Once);
        }

        [Fact]
        public void play_game_calls_doors_RandomlyPlaceCar()
        {
            // Arrange  
            var fakeDoors = new Mock<IDoors>();
            var fakeResponseThingy = new Mock<IResponseThingy>();
            var game = new Game(fakeDoors.Object, fakeResponseThingy.Object);
            
            // Act 
            game.SetUpDoors();

            // Assert
            fakeDoors.Verify(d => d.RandomlyPlaceCar(), Times.Once);
        }
        
        [Theory]
        [InlineData(true, 2, 3, true)]
        [InlineData(true, 3, 3, false)]
        [InlineData(false, 2, 3, false)]
        [InlineData(false, 1, 1, true)]
        public void test_win_Or_lose_method(bool isSwitch, int pickedDoor, int carDoor, bool expected)
        {
            // Arrange  
            var fakeDoors = new Mock<IDoors>();
            var fakeResponseThingy = new Mock<IResponseThingy>();
            var game = new Game(fakeDoors.Object, fakeResponseThingy.Object);

            // Act 
            var isWin = game.WinOrLose(isSwitch, pickedDoor, carDoor);

            // Assert
            Assert.Equal(expected, isWin);
        }
    }

    public class FakeDoors : IDoors
    {
        public List<IDoor> DoorsList { get; }

        public FakeDoors(List<IDoor> doors)
        {
            DoorsList = doors;
        }

        public void SetAllToGoats()
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