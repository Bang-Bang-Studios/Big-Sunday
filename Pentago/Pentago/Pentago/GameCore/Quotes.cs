using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pentago.GUI;

namespace Pentago.GameCore
{
    class Quotes
    {
        public Quotes()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {

            LoadingQuotes = new List<string>();
            VikingQuotes = new List<string>();
            VikingNames = new List<string>();
            ElderQuotes = new List<string>();
            IceGiantQuotes = new List<string>();

            Create();
        }

        private void Create()
        {
            CreateVikingQuotes();
            CreateLoadingQuotes();
            CreateVikingNames();
            CreateElderQuotes();
            CreateIceGiantQuotes();
        }

        public string Viking
        {
            get
            {
                Random rand = new Random();
                return VikingQuotes[rand.Next(VikingQuotes.Count - 1)];
            }
        }

        public string LoadingScreen
        {
            get
            {
                Random rand = new Random();
                return LoadingQuotes[rand.Next(LoadingQuotes.Count() - 1)];
            }
        }

        public string Names
        {
            get
            {
                Random rand = new Random();
                return VikingNames[rand.Next(VikingNames.Count() - 1)];
            }
        }

        public string Elder
        {
            get
            {
                return ElderQuotes[speechCounter];
            }
        }

        public string IceGiant
        {
            get
            {
                Random rand = new Random();
                return IceGiantQuotes[rand.Next(IceGiantQuotes.Count - 1)];
            }
        }

        public int speechCounter { get; set; }

        private void CreateVikingQuotes()
        {
            //VikingQuotes.Add("horgis borgis njord");
            VikingQuotes.Add("Ice giants are nothing to dragon fire");
            VikingQuotes.Add("What are your orders Warlord?");
            VikingQuotes.Add("Your dragons are restless");
            VikingQuotes.Add("CHARRRGGGEE!!!!");
            VikingQuotes.Add("The ice giants will stop at nothing to freeze this world");
            VikingQuotes.Add("I hope my wife isn't cooking freijord gopher again. YUCK!");
            VikingQuotes.Add("That's an...interesting strategy my Lord");
            VikingQuotes.Add("Stop poking me ya over sized chipmunk");
            VikingQuotes.Add("The ice giants can't handle your attack keep it up!");
            VikingQuotes.Add("Sometime's I wear my wife's clothing when she isn't home");
            VikingQuotes.Add("It is a great honor to defend the world from a icy death");
            VikingQuotes.Add("Ice giant heart's are as cold as they are dark");
            VikingQuotes.Add("I once defeated 3 ice giants using only my dagger and an ill tempered bunny");
            VikingQuotes.Add("You truly are our greatest strategist!");
            VikingQuotes.Add("I'm going to poke you back with my sword if you don't stop that");
            VikingQuotes.Add("YOLO. Yodeling on Large Oxen");
            VikingQuotes.Add("SWAG...Sword, War Axe, Grunting");
        }

        private void CreateLoadingQuotes()
        {
            LoadingQuotes.Add("Vikings are Ferocious warriors of Northern Europe");
        }

        private void CreateVikingNames()
        {
            VikingNames.Add("Godfrid Blackeye");
            VikingNames.Add("Bor Laughingsong");
            VikingNames.Add("Thiodarr Rockfist");
            VikingNames.Add("Haraldr Deathblade");
            VikingNames.Add("Steinmir Wolfbasher");
            VikingNames.Add("Roduulf Ragescream");
            VikingNames.Add("Bjorn Stronghand");
            VikingNames.Add("DeathLord Jeffery");
        }

        private void CreateElderQuotes()
        {
            ElderQuotes.Add("Hi! I am the village elder and I can help you fight the ice giants. Your turn has two parts, placing a dragon and using an arrow to rotate a part of the battlefield.");
            ElderQuotes.Add("Then your opponent will do the same. The Battlefield is split into four parts. The goal of the game is to get five dragons in a row to over power your opponent.");
            ElderQuotes.Add("Diagonal moves can be very strong attacks but the viking was too obvious here and was blocked by the ice giant. No matter how that quadrant is rotated that move is blocked.");
            ElderQuotes.Add("A few moves later the ice giant has set up a sneaky attack but spins the battlefield too soon giving the viking a chance to defend the final attack.");
            ElderQuotes.Add("A few moves later the ice giant has set up a sneaky attack but spins the battlefield too soon giving the viking a chance to defend the final attack.");
            ElderQuotes.Add("It looks like the ice giant has block another attack from the viking but he forgot about battlefield rotations! the viking can rotate the bottom right board to unblock a victorious attack.");
            ElderQuotes.Add("Our viking friend has won! Remember to always look at the battlefield rotations or this might happen to you.");
        }

        private void CreateIceGiantQuotes()
        {
            IceGiantQuotes.Add("Zasmvar kardu sagas");
            IceGiantQuotes.Add("Oromuragus mukzurri");
            IceGiantQuotes.Add("Ollaus zornurzal hoggosh tonmok");
            IceGiantQuotes.Add("Kelgurvar BOLVAR!!!");
            IceGiantQuotes.Add("Thrudurl....");
            IceGiantQuotes.Add("Is that the dreaded bunny weilding viking!?!?");
            IceGiantQuotes.Add("Hurgurzul rukgurolek mahlstan Zustar'Geld");
            IceGiantQuotes.Add("I don't even like ice...");
        }

        private List<string> LoadingQuotes;
        private List<string> VikingQuotes;
        private List<string> VikingNames;
        private List<string> ElderQuotes;
        private List<string> IceGiantQuotes;
    }
}
