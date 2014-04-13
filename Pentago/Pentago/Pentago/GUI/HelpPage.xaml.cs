using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pentago.GameCore;
using Pentago.GUI.Classes;

namespace Pentago.GUI
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class HelpPage : Page
    {
        public HelpPage()
        {
            InitializeComponent();
            SoundManager.backgroundMusicPlayer.Open(new Uri("GUI/Sounds/14.mp3", UriKind.Relative));
            SoundManager.backgroundMusicPlayer.Play();
            quotes = new Quotes();
            helpImageChange = 1;
            HelpTextBlock.Text = quotes.Elder;
        }

        Quotes quotes;
        private int helpImagecounter;
        private int helpImageChange
        {
            get
            {
                return helpImagecounter;
            }
            set
            {
                helpImagecounter = value; 
                quotes.speechCounter = value - 1;
            }
        }

        private void HelpRight_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.playSFX(SoundManager.SoundType.Click);
            helpImageChange++;
            HelpImage.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(new System.Drawing.Bitmap("GUI/Images/Help" + helpImageChange + ".png").GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight((int)HelpImage.Width, (int)HelpImage.Height));
            HelpTextBlock.Text = quotes.Elder;
            if (helpImageChange > 6)
            {
                HelpRight.Visibility = Visibility.Hidden;
            }
            HelpLeft.Visibility = Visibility.Visible;
        }

        private void HelpLeft_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.playSFX(SoundManager.SoundType.Click);
            helpImageChange--;
            HelpImage.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(new System.Drawing.Bitmap("GUI/Images/Help" + helpImageChange + ".png").GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight((int)HelpImage.Width, (int)HelpImage.Height));
            HelpTextBlock.Text = quotes.Elder;            
            if (helpImageChange < 2)
            {
                HelpLeft.Visibility = Visibility.Hidden;
            }
            HelpRight.Visibility = Visibility.Visible;
            //HelpImage.Source = "Help" + helpImageChange + ".png";
        }

        private void ExitHelp_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            SoundManager.playSFX(SoundManager.SoundType.Click);
            MenuPage menu = new MenuPage();
            NavigationService.Navigate(menu);
        }

        private void ExitHelp_MouseEnter(object sender, MouseEventArgs e)
        {
            SoundManager.playSFX(SoundManager.SoundType.MouseOver);
        }

        private void HelpRight_MouseEnter(object sender, MouseEventArgs e)
        {
            SoundManager.playSFX(SoundManager.SoundType.MouseOver);
        }

        private void HelpLeft_MouseEnter(object sender, MouseEventArgs e)
        {
            SoundManager.playSFX(SoundManager.SoundType.MouseOver);
        }
    }
}
