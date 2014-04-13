using Pentago.GUI.Classes;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pentago.GUI
{
    /// <summary>
    /// Interaction logic for GameIntro.xaml
    /// </summary>
    public partial class GameIntro : Page
    {
        double bigmove = 1.8;
        double Dragmove = .35;
        double DragDistance = 700;

        public GameIntro()
        {
            InitializeComponent();

            SoundManager.backgroundMusicPlayer.Open(new Uri("GUI/Sounds/Intro.mp3", UriKind.Relative));
            SoundManager.backgroundMusicPlayer.Play();

            BeginAnimations();
        }

        private void BeginAnimations()
        {
            AnimateViking();
        }

        private void AnimateViking()
        {
            TranslateTransform translate = new TranslateTransform();
            DoubleAnimation animate;
            Viking.RenderTransform = translate;

            animate = new DoubleAnimation(0, 600, TimeSpan.FromSeconds(bigmove));

            animate.Completed += new EventHandler(AnimateFrostGiant);

            translate.BeginAnimation(TranslateTransform.XProperty, animate);
        }

        private void AnimateVikingDragon0(object sender, EventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            DoubleAnimation animate;
            translate = new TranslateTransform();
            VikingDragonPup0.RenderTransform = translate;

            animate = new DoubleAnimation(0, DragDistance, TimeSpan.FromSeconds(Dragmove));

            animate.Completed += new EventHandler(AnimateFrsotGiantDragon0);

            translate.BeginAnimation(TranslateTransform.XProperty, animate);
        }

        private void AnimateFrsotGiantDragon0(object sender, EventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            DoubleAnimation animate;
            translate = new TranslateTransform();
            FrostGiantDragonPup0.RenderTransform = translate;

            animate = new DoubleAnimation(0, -DragDistance, TimeSpan.FromSeconds(Dragmove));

            animate.Completed += new EventHandler(AnimateVikingDragon1);

            translate.BeginAnimation(TranslateTransform.XProperty, animate);
        }

        private void AnimateVikingDragon1(object sender, EventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            DoubleAnimation animate;
            translate = new TranslateTransform();
            VikingDragonPup1.RenderTransform = translate;

            animate = new DoubleAnimation(0, DragDistance, TimeSpan.FromSeconds(Dragmove));

            animate.Completed += new EventHandler(AnimateFrsotGiantDragon1);

            translate.BeginAnimation(TranslateTransform.XProperty, animate);
        }

        private void AnimateFrsotGiantDragon1(object sender, EventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            DoubleAnimation animate;
            translate = new TranslateTransform();
            FrostGiantDragonPup1.RenderTransform = translate;

            animate = new DoubleAnimation(0, -DragDistance, TimeSpan.FromSeconds(Dragmove));

            animate.Completed += new EventHandler(AnimateVikingDragon2);

            translate.BeginAnimation(TranslateTransform.XProperty, animate);
        }

        private void AnimateVikingDragon2(object sender, EventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            DoubleAnimation animate;
            translate = new TranslateTransform();
            VikingDragonPup2.RenderTransform = translate;

            animate = new DoubleAnimation(0, DragDistance, TimeSpan.FromSeconds(Dragmove));

            animate.Completed += new EventHandler(AnimateFrsotGiantDragon2);

            translate.BeginAnimation(TranslateTransform.XProperty, animate);
        }

        private void AnimateFrsotGiantDragon2(object sender, EventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            DoubleAnimation animate;
            translate = new TranslateTransform();
            FrostGiantDragonPup2.RenderTransform = translate;

            animate = new DoubleAnimation(0, -DragDistance, TimeSpan.FromSeconds(Dragmove));

            animate.Completed += new EventHandler(GoToNext);

            translate.BeginAnimation(TranslateTransform.XProperty, animate);
        }

        private void AnimateFrostGiant(object sender, EventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            DoubleAnimation animate;
            FrostGiant.RenderTransform = translate;

            animate = new DoubleAnimation(0, -800, TimeSpan.FromSeconds(bigmove));

            animate.Completed += new EventHandler(AnimateVikingDragon0);

            translate.BeginAnimation(TranslateTransform.XProperty, animate);
        }

        private void GoToNext(object sender, EventArgs e)
        {
            try
            {
                MenuPage menu = new MenuPage();
                NavigationService.Navigate(menu);
            }
            catch (Exception err)
            {
            }
        }

        private void Page_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            GoToNext(sender, e);
        }

    }
}
