namespace Task1;

public abstract class AbstractTram
{
    protected readonly int Capacity;
    protected readonly int StopsNumber;
    protected int CurrentStop;

    protected AbstractTram(int capacity, int stopsNumber)
    {
        Capacity = capacity;
        StopsNumber = stopsNumber;
    }

    public abstract void MoveToNextStop();
    public abstract void EnterTram(string passengerName, int startedStop, int targetStop);
}