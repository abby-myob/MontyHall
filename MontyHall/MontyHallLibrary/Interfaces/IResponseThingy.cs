namespace MontyHallLibrary.Interfaces
{
    public interface IResponseThingy
    {
        int PickDoor();
        bool SwitchToOtherDoor();
        void ShowGoatDoor(int getOtherGoatDoor);
        void ShowWinOrLose(bool winOrLose);
    }
}