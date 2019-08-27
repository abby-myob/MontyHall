using System;
using System.Collections.Generic;
using MontyHallLibrary.Interfaces;

namespace MontyHallLibrary
{
    public class Doors : IDoors
    {
        public List<IDoor> DoorsList { get; }
        public Doors(List<IDoor> doorsList)
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

        public void RandomlyPlaceCar()
        {
            var random = new Random();
            var index = random.Next(0, 3);
            DoorsList[index].SetPrize(Prize.Car);
        }
    }
}