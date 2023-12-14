using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasNetLib.Fundamental.Threading
{
    public class SharedObject
    {
        private object _sync = new object(); 
        public int Number { get; private set; }

        public void AddNumber()
        {
            //lock (_sync)
            //{
            //    Number++;
            //}

            Number++;
        }
    }
}
