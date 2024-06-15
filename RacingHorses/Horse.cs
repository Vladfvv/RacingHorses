using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace RacingHorses
{
    public class Horse : INotifyPropertyChanged
    {
        // private DispatcherTimer _timer;
        // private Random _random;

        //private Point startPoint;
        //  private Point endPoint;
        private double x;
        private double y;
        private double speed;

        //public Point StartPoint
        //{
        //    get { return startPoint; }
        //    set
        //    {
        //        if (startPoint != value)
        //        {
        //            startPoint = value;
        //            OnPropertyChanged("StartPoint");
        //        }
        //    }
        //}
        //public Point EndPoint
        //{
        //    get { return endPoint; }
        //    set
        //    {
        //        if (endPoint != value)
        //        {
        //            endPoint = value;
        //            OnPropertyChanged("EndPoint");
        //        }
        //    }
        //}

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public double Speed
        {
            get { return speed; }
            set
            {
                if (speed != value)
                {
                    speed = value;
                    OnPropertyChanged("Speed");
                }
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
