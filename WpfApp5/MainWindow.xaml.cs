using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{

    public partial class MainWindow : Window
    {
        Random rnd = new Random();

		public MainWindow()
        {
            InitializeComponent();

            TarcsakFeltolt();
		}

        void TarcsakFeltolt()
        {
            Uri[] fileok = [new Uri("./Images/goldgoldgold.png", UriKind.Relative), new Uri("./Images/dlore.png", UriKind.Relative), new Uri("./Images/mac10heat.png", UriKind.Relative), new Uri("./Images/nip.png", UriKind.Relative), new Uri("./Images/titanholo.png", UriKind.Relative), new Uri("./Images/unnamed.png", UriKind.Relative)];
            Image[] kepek = new Image[72];

            for (int i = 0; i < 24; i++)
            {
				kepek[i] = new Image();
				kepek[i].Width = 260;
				kepek[i].Height = 210;
				Canvas.SetTop(kepek[i], 210*i);
				kepek[i].Source = new BitmapImage(fileok[rnd.Next(0, 6)]);

				tarcsa1.Children.Add(kepek[i]);
            }
			for (int i = 24; i < 48; i++)
			{
				kepek[i] = new Image();
				kepek[i].Width = 260;
				kepek[i].Height = 210;
				Canvas.SetTop(kepek[i], 210 * (i-24));
				kepek[i].Source = new BitmapImage(fileok[rnd.Next(0, 6)]);

				tarcsa2.Children.Add(kepek[i]);
			}
			for (int i = 48; i < 72; i++)
			{
				kepek[i] = new Image();
				kepek[i].Width = 260;
				kepek[i].Height = 210;
				Canvas.SetTop(kepek[i], 210 * (i-48));
				kepek[i].Source = new BitmapImage(fileok[rnd.Next(0, 6)]);

				tarcsa3.Children.Add(kepek[i]);
			}
		}

		private void gold_Click(object sender, RoutedEventArgs e)
		{
			var mozgatasAnim = new DoubleAnimation();
			mozgatasAnim.From = 1.0;
			mozgatasAnim.To = 0.0;
		}
	}
}