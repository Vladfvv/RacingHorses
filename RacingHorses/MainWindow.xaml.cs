using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace RacingHorses
{

    public partial class MainWindow : Window
    {

        private Point startPoint = new Point(0, 0);
        private Point endPoint = new Point(0, 0);
        private List<HorseUserControl> listHorseUserControls = new List<HorseUserControl>();
        private HorseUserControl userControl = null;
        bool isdrawing = false;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (listHorseUserControls != null)
            {

                foreach (HorseUserControl u in listHorseUserControls)
                    userControl.Move(userControl);

            }
            else
            {
                MessageBox.Show("Ups...");

            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            listHorseUserControls.Clear();
            myCanvas.Children.Clear();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Point currentPoint = e.GetPosition(myCanvas);
            if(isdrawing) MessageBox.Show("Жмите кнопку старт");
            isdrawing = false;
            if (startPoint.X == 0 && startPoint.Y == 0)
            {
                
                startPoint = currentPoint;// Начальная точка
                HorseUserControl.startPoint = startPoint;

                userControl = new HorseUserControl();// Новый объект HorseUserControl и добавление его на Canvas

                Canvas.SetLeft(userControl, startPoint.X);// Координаты для нового элемента
                Canvas.SetTop(userControl, startPoint.Y);
               // MessageBox.Show("Поставьте вторую точку");
                myCanvas.Children.Add(userControl);
            }
            else//или установить конечную точку
            {
                endPoint = currentPoint;
                HorseUserControl.endPoint = endPoint;

                listHorseUserControls.Add(userControl);// Добавление текущего HorseUserControl в список
               
                // Обнуляю начальную и конечную точки
                startPoint = new Point(0, 0);
                endPoint = new Point(0, 0);
                isdrawing = true;
                // Создаю новый объект HorseUserControl
                userControl = new HorseUserControl();
            }
        }

    }
}
