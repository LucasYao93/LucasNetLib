using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasNetLib.Fundamental.Timer
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                // 永远执行不到这里
                Console.WriteLine("Exception!");
            }
        }

        static void Go() { throw null; }
    }
}
