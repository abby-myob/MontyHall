using MontyHallLibrary.Interfaces;

namespace MontyHallLibrary
{
    public class Door : IDoor
    {
        public Prize Prize { get; private set; }

        public void SetPrize(Prize prize)
        {
            Prize = prize;
        } 
    }
}