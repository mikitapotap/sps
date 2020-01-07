using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace sps
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login_reg.Focus();
            Login_reg.SelectionStart = Login_reg.Text.Length;
            Login_reg.SelectAll();

            var timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0),
                IsEnabled = true
            };
            timer.Tick += (o, t) => { Label_info_time.Content = DateTime.Now.ToString("U"); };
            timer.Start();
        }

        private void Button_enter_Click(object sender, RoutedEventArgs e)
        {
            if (Login_reg.Text.Trim() == "polska_92" && Pass_reg.Password == "555")
            {
                //отрисовка контура и появление уровня досупа.
                Login_reg.BorderBrush = Brushes.GreenYellow;
                Login_reg.BorderThickness = new Thickness(3, 3, 3, 3);

                Pass_reg.BorderBrush = Brushes.GreenYellow;
                Pass_reg.BorderThickness = new Thickness(3, 3, 3, 3);

                Label_info.Content = "Доступ разрешён";
                Label_info.Foreground = Brushes.GreenYellow;

                MainForm forma_new = new MainForm();
                forma_new.ShowDialog();
            }
            else
            {
                //отрисовка контура и появление уровня досупа.
                Login_reg.BorderBrush = Brushes.Red;
                Login_reg.BorderThickness = new Thickness(3, 3, 3, 3);

                Pass_reg.BorderBrush = Brushes.Red;
                Pass_reg.BorderThickness = new Thickness(3, 3, 3, 3);

                Label_info.Content = "Ошибка идентификационных данных";
                Label_info.Foreground = Brushes.Red;

                Login_reg.SelectAll();
                Login_reg.Focus();
                Pass_reg.Clear();
            }
        }
        private void Login_reg_TextChanged(object sender, TextChangedEventArgs e)
        {
            //визуальное отображение подсказки.
            if (String.IsNullOrEmpty(Login_reg.Text.Trim()))
            {
                Login_reg.Text = "логин сотрудника";
                Login_reg.SelectionStart = Login_reg.Text.Length;
                Login_reg.FontSize = 19;
                Login_reg.SelectAll();
            }
        }
    }
}
