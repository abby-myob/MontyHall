using System.Collections.Generic;
using System.Linq;
using MontyHallLibrary;
using MontyHallLibrary.Interfaces;
using Xunit;

namespace MontyHallTests
{
    public class DoorTests
    {
        [Fact]
        public void check_3_goats_are_produced_on_set_up()
        {
            // Arrange  
            var doors = new Doors(new List<IDoor>()
            {
                new Door(),
                new Door(),
                new Door(),
            });
            
            // Act 
            doors.SetUp();
            
            // Assert
            Assert.Equal(3, doors.DoorsList.Count(d => d.Prize == Prize.Goat));
        }
        
        [Fact]
        public void check_1_car_is_produced()
        {
            // Arrange  
            var doors = new Doors(new List<IDoor>()
            {
                new Door(),
                new Door(),
                new Door(),
            });
            
            // Act 
            doors.SetUp();
            doors.RandomlyPlaceCar();
            
            // Assert
            Assert.Equal(1,doors.DoorsList.Count(d => d.Prize == Prize.Car));
        }
    }
}