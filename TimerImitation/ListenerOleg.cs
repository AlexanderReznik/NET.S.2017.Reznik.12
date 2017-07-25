using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerImitation
{
    public class ListenerOleg
    {
        public void Register(TimerClock tc)
        {
            if(tc == null) throw new ArgumentNullException();
            tc.Timer += DoWork;
        }

        public void Unregister(TimerClock tc)
        {
            if (tc == null) throw new ArgumentNullException();
            tc.Timer -= DoWork;
        }

        private void DoWork(object sender, TimerEventsArgs e)
        {
            Console.WriteLine($"My mame is Oleg. Timer had elapsed after {e.Time}.");
            Console.WriteLine($"Someone said {e.Message}. But I yastnye days ostavljayu sebe");
        }
    }
}
