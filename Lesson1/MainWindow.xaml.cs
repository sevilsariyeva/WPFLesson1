using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static SolidColorBrush CreateColor()
        {
            var random = new Random();

            var r = Convert.ToByte(random.Next(0, 255));
            var g = Convert.ToByte(random.Next(0, 255));
            var b = Convert.ToByte(random.Next(0, 255));

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void firstBtn_Click(object sender, RoutedEventArgs e)
        {
           
            if(sender is Button btn)
            {
                btn.Background = CreateColor();
                MessageBox.Show($"I am {btn.Name}");
            }
        }

        private void firstBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) {
                if (sender is Button btn)
                {
                    btn.Background = CreateColor();
                    MessageBox.Show($"I am {btn.Name}");
                }
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                if(sender is Button btn)
                {
                    foreach (var item in mainPanel.Children)
                    {
                        if(item is StackPanel st)
                        {
                            st.Children.Remove(btn);
                            this.Title = $"{btn.Name} is removed";
                        }
                    }
                }
            }
        }
    }
}
