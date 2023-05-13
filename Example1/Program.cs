namespace Example1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n---Fuel station simulation using Monitor---\n");
        SimulateMonitorFuelStation();

        Console.WriteLine("\n---Fuel station simulation using Semaphore---\n");
        SimulateSemaphoreFuelStation();
    }

    private static void SimulateFuelStation(AbstractFuelStation fuelStation)
    {
        int carCount = 5;

        Random random = new Random();
        Console.WriteLine("\tGO!!!");
        var tasks = new Task[carCount];
        for (int i = 0; i < carCount; i++)
        {
            var car = new Car($"car {i + 1}", fuelStation, 100, random.Next(1, 5));
            tasks[i] = new Task(car.Run);
        }

        tasks.ToList().ForEach(x => x.Start());
        Thread.Sleep(30000);
        fuelStation.Fill(2000);
        Task.WaitAll(tasks);
        Console.WriteLine("\tFINISH!!!");
    }

    private static void SimulateMonitorFuelStation()
    {
        SimulateFuelStation(new FuelStationMonitor(2, 300));
    }

    private static void SimulateSemaphoreFuelStation()
    {
        SimulateFuelStation(new FuelStationSemaphore(2, 300));
    }
}