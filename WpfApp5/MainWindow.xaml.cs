using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        int szimbolumSzam = 11;

        int kepEgyTarcsan = 45;

        int ImageWidth = 200;
        int ImageHeight = 150;
        int porgetesKoltseg = 10;
        int egyenleg = 100;

        
        int[] vegsoKepekInd = new int[3];

        
        Uri[] fileok = [
            new Uri("./Images/goldgoldgold.png", UriKind.Relative),
            new Uri("./Images/dlore.png", UriKind.Relative),
            new Uri("./Images/mac10heat.png", UriKind.Relative),
            new Uri("./Images/nip.png", UriKind.Relative),
            new Uri("./Images/titanholo.png", UriKind.Relative),
            new Uri("./Images/unnamed.png", UriKind.Relative),

            new Uri("./Images/bf_gamma.png", UriKind.Relative),
            new Uri("./Images/bowie_auto.png", UriKind.Relative),
            new Uri("./Images/karambit_ch.png", UriKind.Relative),
            new Uri("./Images/karambit_doppler.png", UriKind.Relative),
            new Uri("./Images/m9_fade.png", UriKind.Relative)
        ];

        public MainWindow()
        {
            InitializeComponent();
            txtEgyenleg.Text = $"Egyenleg: {egyenleg} kredit";
            TarcsakFeltolt();
        }

        void TarcsakFeltolt()
        {
            TarcsaKepek(tarcsa1, trans1, 0, 0);
            TarcsaKepek(tarcsa2, trans2, 0, 1);
            TarcsaKepek(tarcsa3, trans3, 0, 2);
        }

        private void gold_Click(object sender, RoutedEventArgs e)
        {
            if (egyenleg < porgetesKoltseg)
            {
                txtEredmeny.Text = "Nincs elég kredit";
                txtEredmeny.Foreground = Brushes.Red;
                return;
            }

            egyenleg -= porgetesKoltseg;
            txtEgyenleg.Text = $"Egyenleg: {egyenleg} kredit";
            txtEredmeny.Text = "Pörgetés...";
            txtEredmeny.Foreground = Brushes.White;
            gold.IsEnabled = false;

            // nyertes képek
            int target1 = rnd.Next(30, kepEgyTarcsan - 3);
            int target2 = rnd.Next(30, kepEgyTarcsan - 3);
            int target3 = rnd.Next(30, kepEgyTarcsan - 3);


            TarcsaKepek(tarcsa1, trans1, target1, 0);
            TarcsaKepek(tarcsa2, trans2, target2, 1);
            TarcsaKepek(tarcsa3, trans3, target3, 2);

            SpinReel(trans1, target1, 2.0, null);
            SpinReel(trans2, target2, 2.7, null);
            SpinReel(trans3, target3, 3.4, TarcsaMegallt_Completed);
        }

        private void TarcsaKepek(Canvas tarcsa, TranslateTransform transform, int targetIndex, int tarcsaIndex)
        {
            transform.BeginAnimation(TranslateTransform.YProperty, null);
            tarcsa.Children.Clear();

            for (int i = 0; i < kepEgyTarcsan; i++)
            {
                Image img = new Image();
                img.Width = ImageWidth;
                img.Height = ImageHeight;

                Canvas.SetTop(img, (1 - i) * ImageHeight);

                int file = rnd.Next(0, szimbolumSzam);
                img.Source = new BitmapImage(fileok[file]);

                if (i == targetIndex)
                {
                    vegsoKepekInd[tarcsaIndex] = file;
                }

                tarcsa.Children.Add(img);
            }

            transform.Y = 0;
        }

        private void SpinReel(TranslateTransform transform, int targetIndex, double ido, EventHandler animVege)
        {
            double celY = targetIndex * ImageHeight;

            DoubleAnimation spinAnim = new DoubleAnimation();
            spinAnim.From = 0;
            spinAnim.To = celY;
            spinAnim.Duration = new Duration(TimeSpan.FromSeconds(ido));

            spinAnim.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut };

            if (animVege != null)
            {
                spinAnim.Completed += animVege;
            }

            transform.BeginAnimation(TranslateTransform.YProperty, spinAnim);
        }

        private void TarcsaMegallt_Completed(object sender, EventArgs e)
        {
            gold.IsEnabled = true;

            int kep1 = vegsoKepekInd[0];
            int kep2 = vegsoKepekInd[1];
            int kep3 = vegsoKepekInd[2];

            if (kep1 == kep2 && kep2 == kep3)
            {
                egyenleg += 50;
                txtEredmeny.Text = "MAX WIN (+50)";
                txtEredmeny.Foreground = Brushes.Gold;
            }
            else if (kep1 == kep2 || kep2 == kep3 || kep1 == kep3)
            {
                egyenleg += 20;
                txtEredmeny.Text = "Kis nyeremény (+20)";
                txtEredmeny.Foreground = Brushes.LightGreen;
            }
            else
            {
                txtEredmeny.Text = "Nem nyert.";
                txtEredmeny.Foreground = Brushes.OrangeRed;
            }

            txtEgyenleg.Text = $"Egyenleg: {egyenleg} kredit";
        }
    }
}