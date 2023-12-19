
//// See https://aka.ms/new-console-template for more information
//using LucasNetLib.Fundamental.Threading;

//Console.WriteLine("Start program...");

//#region 简单创建线程和使用线程池
////SharedObject sharedObject = new SharedObject();

////Thread thread = new Thread(() =>
////{
////    while(true)
////    {
////        sharedObject.AddNumber();
////    }
////});

////thread.Name = $"New Thread";
////thread.Start(); //创建新的线程

////object shareObject = 0;

////ThreadPool.QueueUserWorkItem((shareObject) =>
////{
////    while (true)
////    {
////        sharedObject.AddNumber();
////    }
////});


////while(true)
////{
////    Console.WriteLine(sharedObject.Number);
////}

//#endregion

//#region AutoResetEvent 

//AutoResetEvent autoResetEvent = new AutoResetEvent(false); //一次指唤醒一个线程，
//ManualResetEvent manualResetEvent = new ManualResetEvent(false); //
//// 创建两个线程
//Thread thread1 = new Thread(Worker);
//Thread thread2 = new Thread(Worker);

//// 启动线程
//thread1.Start();
//thread2.Start();

//// 等待一段时间后，发送信号给一个线程
//Thread.Sleep(2000);
//autoResetEvent.Set();

//// 等待一段时间后，再次发送信号给另一个线程
//Thread.Sleep(2000);
//autoResetEvent.Set();

//// 等待线程执行完毕
//thread1.Join();
//thread2.Join();

//void Worker()
//{
//    Console.WriteLine("线程开始等待信号");
//    autoResetEvent.WaitOne();
//    Console.WriteLine("线程收到信号并执行工作");
//}
//#endregion

//Console.WriteLine("End program.");

//Console.ReadKey();


//DaysOfWeek daysOfWeek = DaysOfWeek.Monday;
//var t = daysOfWeek.ToString();

//int[] array = new int[1] { 1 };
//GC.Collect(0, GCCollectionMode.Forced);

int t = 10;

t.CompareTo(20);

Console.ReadKey();
