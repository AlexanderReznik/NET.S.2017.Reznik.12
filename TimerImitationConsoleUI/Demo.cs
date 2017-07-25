using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerImitation;

namespace TimerImitationConsoleUI
{
    class Demo
    {
        static void Main(string[] args)
        {
            TimerClock timer = new TimerClock();
            ListenerOleg olezhka = new ListenerOleg();
            ListenerStas stasik = new ListenerStas();
            stasik.Register(timer);
            olezhka.Register(timer);
            Console.WriteLine("Starting timer for 2 listeners(5 seconds)");
            timer.StartTimer("Both will work", 5);

            stasik.Unregister(timer);
            Console.WriteLine("Starting timer for 1 listener(10 seconds)");
            timer.StartTimer("Now only Oleg will work", 5);

            Console.ReadKey();
        }
    }
}
