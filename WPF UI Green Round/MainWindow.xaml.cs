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

namespace WPF_UI_ROUND
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ctrlLheld;
        bool ctrlRheld;

        public MainWindow()
        {
            InitializeComponent();

            scrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
            this.KeyDown += MainWindow_KeyDown;
            this.KeyUp += MainWindow_KeyUp;
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
            {
                ctrlLheld = false;
            }
            if (e.Key == Key.RightCtrl)
            {
                ctrlRheld = false;
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.LeftCtrl)
            {
                ctrlLheld = true;
            }
            if (e.Key == Key.RightCtrl)
            {
                ctrlRheld = true;
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!ctrlLheld && !ctrlRheld)
                return;

            if (e.Delta > 0)
            {
                scaleTransform.ScaleX += 0.1;
                scaleTransform.ScaleY += 0.1;
            }
            if (e.Delta < 0)
            {
                scaleTransform.ScaleX -= 0.1;
                scaleTransform.ScaleY -= 0.1;
            }

            e.Handled = true;
        }
    }
}
