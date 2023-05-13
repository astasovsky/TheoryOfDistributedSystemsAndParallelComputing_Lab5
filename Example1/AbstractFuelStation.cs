namespace Example1;

public abstract class AbstractFuelStation
{
    public int Reserve { get; protected set; }
    public int Capacity { get; } = 1000;
    public int ColumnCount { get; }

    public AbstractFuelStation(int columnCount, int reserve = 1000)
    {
        if (columnCount <= 0) throw new Exception("Invalid column count");
        if (reserve > Capacity || reserve < 0) throw new Exception("Invalid reserve");
        ColumnCount = columnCount;
        Reserve = reserve;
    }

    public abstract void Fill(int amount);
    public abstract bool TryRefuel(Car car, int volume);
}