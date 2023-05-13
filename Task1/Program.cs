namespace Task1;

public class Program
{
    private const int PassengerCount = 10;
    private const int TramCapacity = 2;
    private const int StopsNumber = 10;
    private const int TramRouteCycles = 5;

    public static void Main(string[] args)
    {
        Console.WriteLine("\n---Tram process simulation using Monitor---\n");
        SimulateMonitorTramProcess();

        Console.WriteLine("\n---Tram process simulation using Semaphore---\n");
        SimulateSemaphoreTramProcess();
    }

    private static void SimulateMonitorTramProcess()
    {
        SimulateTramProcess(new TramMonitor(TramCapacity, StopsNumber));
    }

    private static void SimulateSemaphoreTramProcess()
    {
        SimulateTramProcess(new TramSemaphore(TramCapacity, StopsNumber));
    }

    private static void SimulateTramProcess(AbstractTram tram)
    {
        Random random = new();

        // Create and start passenger threads
        Task[] tasks = new Task[PassengerCount];
        for (int i = 0; i < PassengerCount; i++)
        {
            int startedStop = random.Next(0, StopsNumber);
            int targetStop;
            do
            {
                targetStop = random.Next(0, StopsNumber);
            } while (startedStop == targetStop);


            Passenger passenger = new($"Passenger{i + 1}", tram, startedStop, targetStop);
            tasks[i] = new Task(passenger.EnterTrain);
        }

        foreach (Task x in tasks.ToList())
        {
            x.Start();
        }

        // Simulate tram movement
        for (int i = 0; i < TramRouteCycles * StopsNumber; i++)
        {
            tram.MoveToNextStop();
            Thread.Sleep(1000);
        }
    }
}