using System;
using Xunit;

namespace MontyHallTests
{
    public class DoorTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            //var door = new Door(Prize.GOAT);
            var doors = new Doors(new Door(), new Door(), new Door());
            
            // Act 
            doors.SetUp();
            
            // Assert
            Assert.Equal(1, doors.DoorsList.Where(door => door.Prize == Prize.CAR).Count());
        }
    }

    public class Doors
    {
        public Doors(Door door, Door door1, Door door2)
        {
            throw new NotImplementedException();
        }
    }

    public enum Prize
    {
        GOAT,
        CAR
    }
}