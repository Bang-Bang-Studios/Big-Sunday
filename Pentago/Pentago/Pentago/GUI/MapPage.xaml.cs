using Pentago.AI;
using Pentago.GameCore;
using Pentago.GUI.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pentago.GUI
{
    /// <summary>
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapPage : Page
    {
        ProfileManager profileManager = null;

        public int unMuteMusicVol = 6;
        public int currentMusicVol = 6;
        public int unMuteSoundVol = 6;
        public int currentSoundVol = 6;

        private BitmapImage lockImage = new BitmapImage(new Uri("pack://application:,,,/GUI/images/lock.png", UriKind.Absolute));
        private string profileName;
        public MapPage(GameOptions options)
        {
            InitializeComponent();
            profileManager = ProfileManager.InstanceCreator();
            InitializeProfileOnGUI(options._Player1);
            SetUpCampaignProgress(options._Player1.Name);
            profileName = options._Player1.Name;
            SoundManager.sfxVolume = Properties.Settings.Default.SFXVolume;
            SoundManager.musicVolume = Properties.Settings.Default.MusicVolume;
            unMuteMusicVol = SoundManager.musicVolume / 16;
            unMuteSoundVol = SoundManager.sfxVolume / 16;
            currentMusicVol = SoundManager.musicVolume / 16;
            currentSoundVol = SoundManager.sfxVolume / 16;
            SoundManager.backgroundMusicPlayer.Open(new Uri("GUI/Sounds/24.mp3", UriKind.Relative));
            SoundManager.backgroundMusicPlayer.Play();
        }

        private void SetUpCampaignProgress(string profileName)
        {
            Pentago.GameCore.ProfileManager.Profile playerProfile = profileManager.SearchProfile(profileName);
            int campaignLevel = playerProfile.CampaignProgress;
            switch (campaignLevel)
            {
                case 0:
                    Boat1.Source = lockImage;
                    Cottages.Source = lockImage;
                    Boat2.Source = lockImage;
                    Castle.Source = lockImage;
                    break;
                case 1:
                    Cottages.Source = lockImage;
                    Boat2.Source = lockImage;
                    Castle.Source = lockImage;
                    break;
                case 2:
                    Boat2.Source = lockImage;
                    Castle.Source = lockImage;
                    break;
                case 3:
                    Castle.Source = lockImage;
                    break;
                case 4:
                    break;
                default:
                    Boat1.Source = lockImage;
                    Cottages.Source = lockImage;
                    Boat2.Source = lockImage;
                    Castle.Source = lockImage;
                    break;
            }
        }

        private void InitializeProfileOnGUI(Player profilePlayer)
        {
            if (File.Exists(@"GUI\Images\CustomVikings\" + profilePlayer.Name + ".png"))
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(@"GUI\Images\CustomVikings\" + profilePlayer.Name + ".png");
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                BitmapSource bmpSrc = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(),
                    IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                bmp.Dispose();
                VikingImage.Source = bmpSrc;
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menu = new MenuPage();
            NavigationService.Navigate(menu);
        }

        private void GoBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SoundManager.playSFX(SoundManager.SoundType.MouseOver);
        }

        private void Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Home.Source != lockImage)
            {
                computerAI.Difficulty difficulty = computerAI.Difficulty.Beginner;
                InitializeCampaignGame(difficulty, 0);
            }
        }

        private void InitializeCampaignGame(computerAI.Difficulty difficultyLevel, int levelBeingPlay)
        {
            Pentago.GameCore.ProfileManager.Profile playerProfile = profileManager.SearchProfile(profileName);
            string player1Name = playerProfile.ProfileName;

            bool isPlayer1Active = true;

            ImageBrush player1Image = new ImageBrush();
            player1Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/GUI/images/RedPup.png", UriKind.Absolute));
            ImageBrush player1ImageHover = new ImageBrush();
            player1ImageHover.ImageSource = new BitmapImage(new Uri("pack://application:,,,/GUI/images/RedPupHover.png", UriKind.Absolute));

            string computerPlayerName = "Computer";
            ImageBrush computerPlayerImage = new ImageBrush();
            computerPlayerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/GUI/images/BluePup.png", UriKind.Absolute));

            ImageBrush computerPlayerImageHover = new ImageBrush();
            computerPlayerImageHover.ImageSource = new BitmapImage(new Uri("pack://application:,,,/GUI/images/BluePupHover.png", UriKind.Absolute));

            computerAI.Difficulty difficulty = difficultyLevel;

            Player player1 = new Player(player1Name.Trim(), isPlayer1Active, player1Image, player1ImageHover);
            computerAI computerPlayer = new computerAI(computerPlayerName.Trim(), !isPlayer1Active, computerPlayerImage, computerPlayerImageHover, difficulty);

            GameOptions gameOptions = new GameOptions(GameOptions.TypeOfGame.Campaign, player1, computerPlayer, levelBeingPlay);

            GamePage game = new GamePage(gameOptions);
            NavigationService.Navigate(game);
        }

        private void Boat1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Boat1.Source != lockImage)
            {
                computerAI.Difficulty difficulty = computerAI.Difficulty.Easy;
                InitializeCampaignGame(difficulty, 1);
            }
        }

        private void Cottages_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Cottages.Source != lockImage)
            {
                computerAI.Difficulty difficulty = computerAI.Difficulty.Medium;
                InitializeCampaignGame(difficulty, 2);
            }
        }

        private void Boat2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Boat2.Source != lockImage)
            {
                computerAI.Difficulty difficulty = computerAI.Difficulty.Medium;
                InitializeCampaignGame(difficulty, 3);
            }
        }

        private void Castle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Castle.Source != lockImage)
            {
                computerAI.Difficulty difficulty = computerAI.Difficulty.Hard;
                InitializeCampaignGame(difficulty, 4);
            }
        }
    }
}

