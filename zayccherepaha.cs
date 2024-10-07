using System;
using System.Threading;

class AnimalThread
{
    private readonly string name;
    private int kol;
    private readonly Random random;

    public AnimalThread(string name)
    {
        this.name = name;
        this.kol = 0;
        this.random = new Random();
    }

    public void run()
    {
        while (kol < 100)
        {
            int step = random.Next(1, 10); // шаг от 1 до 9 метров
            kol += step;

            Console.WriteLine($"{name} пробежал {kol} м");

            // Изменение приоритета, если отстал
            priori();

            Thread.Sleep(100); // задержка для имитации времени на преодоление расстояния
        }

        Console.WriteLine($"{name} достиг 100 м");
    }

    private void priori()
    {
        if (kol < 50)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest; // Увеличить приоритет
        }
        else
        {
            Thread.CurrentThread.Priority = ThreadPriority.Normal; // Снизить приоритет
        }
    }
}

class RabbitAndTurtle
{
    public static void Main()
    {
        AnimalThread rabbit = new AnimalThread("кролик");
        AnimalThread turtle = new AnimalThread("ччерепаха");

        // Запуск потоков
        Thread rabbitThread = new Thread(rabbit.run);
        Thread turtleThread = new Thread(turtle.run);

        rabbitThread.Start();
        turtleThread.Start();

        // Ожидание завершения потоков
        rabbitThread.Join();
        turtleThread.Join();
    }
}

