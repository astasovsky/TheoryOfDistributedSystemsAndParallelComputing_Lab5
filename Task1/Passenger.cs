namespace Task1;

public class Passenger
{
    private readonly string _name;
    private readonly AbstractTram _tram;
    private readonly int _startedStop;
    private readonly int _targetStop;

    public Passenger(string name, AbstractTram tram, int startedStop, int targetStop)
    {
        _name = name;
        _tram = tram;
        _startedStop = startedStop;
        _targetStop = targetStop;
    }

    public void EnterTrain()
    {
        Console.WriteLine($"{_name} STARTED; started stop is {_startedStop}, target stop is {_targetStop}");
        _tram.EnterTram(_name, _startedStop, _targetStop);
    }
}