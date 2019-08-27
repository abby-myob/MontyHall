using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MontyHallTests
{
    public class DoorTests
    {
//        [Fact]
//        public void Test1()
//        {
//            // Arrange 
//            var door = new Door();
//            door.SetPrize(Prize.Car);
//            var list = new List<IDoor>()
//            {
//                door,
//                new Door(),
//                new Door(), 
//            };
//            var doors = new Doors(list);
//            
//            // Act 
//            doors.SetUp();
//            
//            // Assert
//            Assert.Single(doors.DoorsList.Where(d => d.Prize == Prize.Car));
//        }
        
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
            doors.RandomlyPlaceGoat();
            
            // Assert
            Assert.Equal(1,doors.DoorsList.Count(d => d.Prize == Prize.Car));
        }
    }

    public class Doors
    {
        public IEnumerable<IDoor> DoorsList { get; }
        public Doors(IEnumerable<IDoor> doorsList)
        {
            DoorsList = doorsList;
        } 

        public void SetUp()
        {
            foreach (var door in DoorsList)
            {
                door.SetPrize(Prize.Goat);
            }
        }

        public void RandomlyPlaceGoat()
        {
            
        }
    }

    public enum Prize
    {
        Goat,
        Car
    }
}