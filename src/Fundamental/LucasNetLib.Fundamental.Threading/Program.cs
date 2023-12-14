// See https://aka.ms/new-console-template for more information
using LucasNetLib.Fundamental.Threading;

Console.WriteLine("Start program...");

SharedObject sharedObject = new SharedObject();

Thread thread = new Thread(() =>
{
    while(true)
    {
        sharedObject.AddNumber();
    }
});

thread.Name = $"New Thread";
thread.Start(); //创建新的线程

object shareObject = 0;

ThreadPool.QueueUserWorkItem((shareObject) =>
{
    while (true)
    {
        sharedObject.AddNumber();
    }
});


while(true)
{
    Console.WriteLine(sharedObject.Number);
}

Console.WriteLine("End program.");

Console.ReadKey();