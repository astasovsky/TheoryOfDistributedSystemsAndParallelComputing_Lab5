namespace Task1
{
    public class TramSemaphore : AbstractTram
    {
        private readonly Mutex _mutex = new();
        private readonly SemaphoreSlim _semaphore;

        public TramSemaphore(int capacity, int stopsNumber) : base(capacity, stopsNumber)
        {
            _semaphore = new SemaphoreSlim(capacity, capacity);
        }

        public override void MoveToNextStop()
        {
            _mutex.WaitOne();
            CurrentStop = (CurrentStop + 1) % StopsNumber;
            Console.WriteLine($"Tram moved to stop {CurrentStop}");
            _mutex.ReleaseMutex();
        }

        public override void EnterTram(string passengerName, int startedStop, int targetStop)
        {
            while (CurrentStop != startedStop)
            {
                _mutex.WaitOne();
            }

            _semaphore.Wait();
            Console.WriteLine(
                $"{passengerName} entered the tram at stop {CurrentStop}.");

            while (targetStop != CurrentStop)
            {
                _mutex.WaitOne();
            }

            Console.WriteLine(
                $"{passengerName} exited the tram at stop {CurrentStop}.");
            _mutex.ReleaseMutex();
            _semaphore.Release();
        }
    }
}