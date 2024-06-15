using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RacingHorses
{
    /// <summary>
    /// Логика взаимодействия для HorseUserControl.xaml
    /// </summary>
    public partial class HorseUserControl : UserControl
    {
        private DispatcherTimer _timer;
        private Random random;
       // Horse horse;
        public static Point startPoint, endPoint;
        public Point Position { get; set; }
        public double Speed { get; set; }

        public HorseUserControl()
        {
            InitializeComponent();            
            random = new Random();
            // horse = new Horse();
            
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Position = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
            MessageBox.Show($"Позиция лошади: {Position}", "Информация о позиции");
        }

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        { 
           
            MessageBox.Show($"Скорость лошади: {Speed}", "Информация о скорости");
        }

        public void Move(HorseUserControl userControl)
        {
            double x1 = startPoint.X, y1 = startPoint.Y; // начальные координаты
            double x2 = endPoint.X, y2 = endPoint.Y; // конечные координаты
            double speed = random.Next(1, 10); // общее время движения
            Speed = speed;

            // Анимация по X координате
            DoubleAnimationUsingKeyFrames xAnimation = new DoubleAnimationUsingKeyFrames();
            xAnimation.Duration = TimeSpan.FromSeconds(speed);

            // Добавляем ключевые кадры для изменения скорости
            xAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(x1, KeyTime.FromPercent(0.0)));
            xAnimation.KeyFrames.Add(new LinearDoubleKeyFrame((x1 + x2) / 2, KeyTime.FromPercent(0.5))); // замедление в середине пути
            xAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(x2, KeyTime.FromPercent(1.0)));

            // Анимация по Y координате
            DoubleAnimationUsingKeyFrames yAnimation = new DoubleAnimationUsingKeyFrames();
            yAnimation.Duration = TimeSpan.FromSeconds(speed);
            
            // Добавляем ключевые кадры для изменения скорости
            yAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(y1, KeyTime.FromPercent(0.0)));
            yAnimation.KeyFrames.Add(new LinearDoubleKeyFrame((y1 + y2) / 2, KeyTime.FromPercent(0.5)));
            yAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(y2, KeyTime.FromPercent(1.0)));

            // Применяем анимации к элементу
            userControl.BeginAnimation(Canvas.LeftProperty, xAnimation);
            userControl.BeginAnimation(Canvas.TopProperty, yAnimation);
        }
    }
}
