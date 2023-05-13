namespace Task1;

public class TramMonitor : AbstractTram
{
    private int _passengersCount;

    public TramMonitor(int capacity, int stopsNumber) : base(capacity, stopsNumber)
    {
    }

    public override void MoveToNextStop()
    {
        lock (this)
        {
            CurrentStop = (CurrentStop + 1) % StopsNumber;
            Console.WriteLine($"Tram moved to stop {CurrentStop}");
            Monitor.PulseAll(this);
        }
    }

    public override void EnterTram(string passengerName, int startedStop, int targetStop)
    {
        lock (this)
        {
            while (CurrentStop != startedStop || _passengersCount >= Capacity)
            {
                Monitor.Wait(this);
            }

            _passengersCount++;
            Console.WriteLine(
                $"{passengerName} entered the tram at stop {CurrentStop}. Total passengers: {_passengersCount}");
        }

        lock (this)
        {
            while (targetStop != CurrentStop)
            {
                Monitor.Wait(this);
            }

            _passengersCount--;
            Console.WriteLine(
                $"{passengerName} exited the tram at stop {CurrentStop}. Total passengers: {_passengersCount}");
            Monitor.PulseAll(this);
        }
    }
}