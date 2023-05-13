namespace Example1;

public class Car
{
    private static Random random = new Random();
    public string Name { get; set; }
    public int TankVolume { get; }
    public AbstractFuelStation Station { get; }
    public int RefuelCount { get; }

    public Car(string name, AbstractFuelStation station, int tankVolume, int refuelCount)
    {
        Name = name;
        TankVolume = tankVolume;
        Station = station;
        RefuelCount = refuelCount;
    }

    public void Run()
    {
        Console.WriteLine($"{Name} STARTED; refuel count is {RefuelCount}");
        for (int i = 0; i < RefuelCount; i++)
        {
            var volume = random.Next(TankVolume) + 1;
            Console.WriteLine($"{Name} tries to get {volume} lit. for {i + 1} times");
            while (!Station.TryRefuel(this, volume))
            {
                Console.WriteLine($"{Name} is waiting");
                Thread.Sleep(random.Next(1, 5) * 1000);
            }

            Thread.Sleep(random.Next(1, 3) * 1000);
            Console.WriteLine($"{Name} left the station for {i + 1} times");
        }

        Console.WriteLine($"{Name} SAID GOOD-BYE");
    }
}