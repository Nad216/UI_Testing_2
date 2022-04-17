using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Timers;

namespace UI_Testing_2
{
    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second updates
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public string Full
        {
            get { return DateTime.Now.ToString("F", DateTimeFormatInfo.InvariantInfo); }
        }
        public string Date
        {
            get { return DateTime.Now.ToString("D", DateTimeFormatInfo.InvariantInfo); }
        }

        public string Time
        {
            get { return DateTime.Now.ToString("T", DateTimeFormatInfo.InvariantInfo); }
        }


        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Now"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
