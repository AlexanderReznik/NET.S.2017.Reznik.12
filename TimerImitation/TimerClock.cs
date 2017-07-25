using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerImitation
{
    /// <summary>
    /// Something like timer for Oleg, Stas and others
    /// </summary>
    public sealed class TimerClock
    {
        public event EventHandler<TimerEventsArgs> Timer = delegate { };

        private void OnTimer(TimerEventsArgs e)
        {
            EventHandler<TimerEventsArgs> temp = Timer;
            Thread.Sleep(e.Time);
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Method for starting timer
        /// </summary>
        /// <param name="message">Anything you want to say</param>
        /// <param name="time">Time for timer to work</param>
        public void StartTimer(string message, TimeSpan time)
        {
            if(message == null) throw new ArgumentNullException();
            OnTimer(new TimerEventsArgs(message, time));
        }

        /// <summary>
        /// Method for starting timer
        /// </summary>
        /// <param name="message">Anything you want to say</param>
        /// <param name="seconds">Time for timer to work in seconds</param>
        public void StartTimer(string message, int seconds)
        {
            StartTimer(message, new TimeSpan(0, 0, seconds));
        }
    }

    public class TimerEventsArgs : EventArgs
    {
        #region properties

        /// <summary>
        /// Any message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Time of timer
        /// </summary>
        public TimeSpan Time { get; }

        #endregion

        #region c-tor

        public TimerEventsArgs(string message, TimeSpan time)
        {
            if(message == null) throw new ArgumentNullException();
            Message = message;
            Time = time;
        }

        #endregion
    }
}
