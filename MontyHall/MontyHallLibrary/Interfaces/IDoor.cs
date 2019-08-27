namespace MontyHallLibrary.Interfaces
{
    public interface IDoor
    {
        Prize Prize { get; }
        void SetPrize(Prize prize);
    }
}