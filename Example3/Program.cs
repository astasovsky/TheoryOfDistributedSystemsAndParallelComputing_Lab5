for (int i = 1; i < 6; i++)
{
    Reader reader = new Reader(i);
}

class Reader
{
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;

    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Читач {i}";
        myThread.Start();
    }

    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} входить до бібліотеки");

            Console.WriteLine($"{Thread.CurrentThread.Name} читач");
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} залишає бібліотеку");

            sem.Release();

            count--;
            Thread.Sleep(1000);
        }
    }
}