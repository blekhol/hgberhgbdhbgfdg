using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Mozgatas(0);
            Mozgatas(1);
            Mozgatas(2);
		}

        void Mozgatas(int oszlop)
        {
            int[] oszlopMarginok = { 25, 285, 545 };

            Rectangle rect = new Rectangle();
            rect.Height = 150;
            rect.Width = 210;
            rect.Stroke = Brushes.Black;
            rect.Fill = new SolidColorBrush(Color.FromRgb(222, 222, 222));
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            rect.Margin = new Thickness(oszlopMarginok[oszlop], -400, 0, 0);
		}
    }
}