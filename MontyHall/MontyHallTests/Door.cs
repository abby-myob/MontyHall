namespace MontyHallTests
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