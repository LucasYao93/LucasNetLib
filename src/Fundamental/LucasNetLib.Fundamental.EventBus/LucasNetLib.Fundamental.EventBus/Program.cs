//using System;
//using System.Threading;
//using Rebus.Activation;
//using Rebus.Bus;
//using Rebus.Config;
//using Rebus.Handlers;
//using Rebus.Logging;
//using Rebus.Routing.TypeBased;
//using Rebus.Transport.InMem;

//public class Program
//{
//    private static IBus _bus;

//    public static void Main()
//    {
//        // 使用In-Memory传输创建Rebus实例
//        using var activator = new BuiltinHandlerActivator();
//        var rebusConfigurer = Configure.With(activator)
//            .Logging(l => l.ColoredConsole(LogLevel.Info))
//            .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "your_queue"))
//            .Routing(r => r.TypeBased().Map<YourMessageType>("your_queue"));

//        _bus = rebusConfigurer.Start();

//        //// 启动接收消息的线程
//        var thread = new Thread(MessageReceiver);
//        thread.Start();

//        //// 发送消息到另一个线程
//        Thread.Sleep(TimeSpan.FromSeconds(10));
//        _bus.Send(new YourMessageType { Message = "Hello, Rebus!" }).Wait();

//        //// 等待一段时间，确保消息被处理
//        Thread.Sleep(TimeSpan.FromSeconds(2));

//        // 停止Rebus实例
//        Console.WriteLine("Press enter to quit");
//        Console.ReadLine();
//        _bus.Dispose();
//    }

//    private static void MessageReceiver()
//    {
//        // 注册消息处理器
//        _bus.Subscribe<YourMessageType>().Wait();

//        Console.WriteLine("Recive message");
//        //// 接收并处理消息
//        //_bus.Advanced.SyncBus.Subscribe<YourMessageType>(async message =>
//        //{
//        //    Console.WriteLine($"Received message: {message.Message}");

//        //    // 在这里处理消息
//        //    // ...
//        //});
//    }
//}

//public class YourMessageType
//{
//    public string Message { get; set; }
//}

using Rebus.Activation;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Transport.InMem;

using var activator = new BuiltinHandlerActivator();

activator.Register(() => new PrintDateTime());

var timer = new System.Timers.Timer();
timer.Elapsed += delegate { activator.Bus.SendLocal(DateTime.Now).Wait(); };
timer.Interval = 1000;
timer.Start();

Configure.With(activator)
    .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "inputqueue"))
    .Start();

Console.WriteLine("Press enter to quit");
Console.ReadLine();



public class PrintDateTime : IHandleMessages<DateTime>
{

    public async Task Handle(DateTime currentDateTime)
    {
        Console.WriteLine("The time is {0}", currentDateTime);
    }
}