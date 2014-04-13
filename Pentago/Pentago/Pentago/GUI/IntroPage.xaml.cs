using Pentago.GUI.Classes;
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
using System.Windows.Shapes;
using Pentago.GUI;

namespace Pentago.GUI
{
    /// <summary>
    /// Interaction logic for CompanyIntro.xaml
    /// </summary>
    public partial class IntroPage : Page
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GoToNext();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void GoToNext()
        {
            MenuPage menu = new MenuPage();
            NavigationService.Navigate(menu);
        }


        private void video_MediaEnded(object sender, RoutedEventArgs e)
        {
            GoToNext();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            GoToNext();
        }
    }
}
