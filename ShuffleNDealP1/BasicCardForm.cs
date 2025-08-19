//********************************************************
//Developed by UbGames, visit UbGames.com - ShuffleNDealP1
//********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

using System.Media;
using System.Threading.Tasks;
using System.Threading;

namespace ShuffleNDealP1
{
	public partial class BasicCardForm
	{
        //card backs Red_Back.png, aqua150.png, purple150.png

        private const double CARDDELAY = 2.0;

        //set value of animation interval, the lower the number the faster the dealing cards
        private int AnimationTimerInterval = 5;
        //how fast to deal cards default 75
        private int DealSpeed = 75;

        private const byte MAXCARDS = 52;
		private const byte MAXSUITS = 4;
		private const byte MAXRANKS = 13;
        //position indicating that no card has been selected yet
        private const byte NOCHOICE = 100;

        //number of vertical cards, 4
        private const int maxCardsHeight = 4;
        //number of horizontal cards, 13
        private const int maxCardsWidth = 13;

        bool TimerOn;

        //timer stopWatch
        Stopwatch stopWatch = new Stopwatch();

        public struct PlayingCard
		{
			public int rank;
            public int suit;            //face-up?
            public bool revealed;
			public Image face;
			public Image rear;

            public short FormIndex;     //hold location on form index
            public short CardIndex;     //hold location of card
            public string CardVal;      //hold card value
            public bool CardFlag;       //true id matched
        }

        //add dealer information
        //not used - DealerCard structure
        public struct DealerCard
        {
            public int rank;
            public int suit;
            public bool revealed;       //face-up?
            public Image face;
            public Image rear;

            public short FormIndex;     //hold location on form index
            public short CardIndex;     //hold location of card
            public string CardVal;      //hold card value
            public bool CardFlag;       //true id matched
        }

        //not used - get width and height of dealer card picture box
        private float dealercardWidth = Properties.Resources.aqua150.Width;
        private float dealercardHeight = Properties.Resources.aqua150.Height;

        //player information
        //each card is displayed in a picturebox
        private PictureBox[] cardButtons = new PictureBox[MAXCARDS];

        ////add the pictureBox Action>Click>Method (cardClick function) to the array
        ////cardButtons[i].Click += new System.EventHandler(cardClick);
        //cardButtons[i].Click += cardClick;

        //used to hold deck of cards for player
        private PlayingCard[] shuffled = new PlayingCard[MAXCARDS];
        private PlayingCard[] unshuffled = new PlayingCard[MAXCARDS];

        //dealer information
        //each card is displayed in a picturebox, not used at this time
        private PictureBox[] deckofcardsPB = new PictureBox[MAXCARDS];

        //used to hold deck of cards for dealer
        private PlayingCard[] shuffledDC = new PlayingCard[MAXCARDS];
        private PlayingCard[] unshuffledDC = new PlayingCard[MAXCARDS];

        private int centerDealerCardPB, bottomDealerCardPB;

        //Fields needed to control the player card dealing animation
        private Point _startPoint;
        private int _CardIndex;
        private int _a, _b;
        private int _x, _y;
        private int _Increment;

        private int intCardNum = 1;

        private int PlayerCardLocationX, PlayerCardLocationY;
        private int DealerCardLocationX, DealerCardLocationY;

        private int TempX, TempY;
        private int aflag = 1;
        private int bflag = 1;
        
        //set the size of cards
        private double CardPercent = 1;

        private bool ClearCardTable = false;
        //end add dealer information

        //number of piles currently face up
        private byte tabled = 0;
        //number of cards played - including those no longer visible
        private byte cardCount = 0;

		private string[] suits = {"clubs", "diamonds", "hearts", "spades"};
		private string[] ranks = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace"};

        //text in textbox
        private string[] suit = { "C", "D", "H", "S" };
        //text in textbox
        private string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        //red_back width = 495, height = 725
        //get width of card graphics, set to 350, 70.7%
        private float cardWidth = 350;          //Properties.Resources.Red_Back.Width;
        //get height of card graphics, set to 513
        private float cardHeight = 513;     // Properties.Resources.Red_Back.Height;

        //the on-screen width of each card sized to fit the window
        private float displayCardWidth = 0;
        //the on-screen height of each card sized to fit the window
        private float displayCardHeight = 0;

        //space between cards
        private float cardMargin = 2;
        //pair of cards selected
        private int[] choices = { NOCHOICE, NOCHOICE };

        private int nScreenWidth;
        private int nScreenHeight;

        //added
        private bool NewGameStarted;
        //when to redeal cards
        private bool MustReDeal;

        //turn sound on/off, 1,0, default off
        private short NSound = 0;
        //show/hide side panel, 1,0, default show
        private short NPanel = 1;

        //show/hide PanelCardsSelected, 1,0, default hide
        private short NCardsSelected = 0;
        //show/hide PanelCardsFound, 1,0, default hide
        private short NCardsFound = 0;

        private int SidePanelWidthSm = 2;
        private int SidePanelWidthLg = 115;

        private int tDelay;
        private bool IsGameReady = false;

        //when games is started
        private bool InPlay;
        //number of cards to hold in memeory
        private short MAXARRAY;

        //Object true to refresh new backs
        private bool NewCards;

        //set to true if play computer
        //bool PlayComputer = false;
        //set to true if to practice
        private bool Practice = true;
        //end added

        private bool AnimationDone = false;
        private bool IsCardFaceUp;

        /// <summary>
        /// Main constructor for the BasicCardForm.  Initializes components, loads the card skin images, and sets up the new game
        /// </summary>
        internal BasicCardForm()
        {
            //under BasicCardForm.Designer.cs
            InitializeComponent();
            SetUpNewGame();
        }

        /// <summary>
        /// Set up the UI for a new game
        /// </summary>
        private void SetUpNewGame()
        {

            //MessageBox.Show("SetUpNewGame", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //turn sound on/off, 1,0, default off
            SelectSoundOnOff(NSound);
            //show side panel show/hide, 1,0, default show
            SelectSidePanelShowHide(NPanel);
            //MessageBox.Show("NPanel1= " + NPanel.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //this.Panel2.BackColor = Color.SteelBlue;

            //show the show/hide panel buttons
            //PanelButtons.Location = new Point(100, 9);
            //PanelButtons.Size = new Size(250, 30);
            //PanelButtons.Visible = true;

            //show/hide PanelCardsSelected, 1,0, default show
            if (NCardsSelected == 1)
            {
                PanelCardsSelected.Visible = true;
            }
            else
            {
                PanelCardsSelected.Visible = false;
            }

            //show/hide PanelCardsFound, 1,0, default show
            if (NCardsFound == 1)
            {
                PanelCardsFound.Visible = true;
            }
            else
            {
                PanelCardsFound.Visible = false;
            }

            ////player1
            ////photoPictureBox.ImageLocation = Properties.Settings.Default.PlayerImage;
            //photoPictureBox.Image = Image.FromFile(Properties.Settings.Default.PlayerImage);
            //photoPictureBox.Visible = true;
            //playerNameLabel.Text = Properties.Settings.Default.PlayerName;

            ////player2   
            ////photo2PictureBox.ImageLocation = Properties.Settings.Default.DefaultImage2;
            //photo2PictureBox.Image = Image.FromFile(Properties.Settings.Default.DefaultImage2);
            //photo2PictureBox.Visible = true;
            //player2NameLabel.Text = Properties.Settings.Default.Player2Name;

            //dealButton.Enabled = true;
            //ShowHandsBtn.Enabled = false;
            //HideHandsBtn.Enabled = false;
            //clearTableButton.Enabled = false;

            //gameOverTextBox.Hide();

            //if (tShowHandTotals)
            //{
            //    //show or hide
            //    playerTotalLabel.Show();
            //    //show or hide
            //    dealerTotalLabel.Show();
            //}

            ////display the ShowHands Button
            //firstTurn = true;
            //ShowPlayersName();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //You can override OnFormClosing by doing the following. Just be careful you do not do anything unexpected, as clicking the 'X' to close is a well understood behavior.

            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to exit the game?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void BasicCardForm_Load(object sender, EventArgs e)
        {

            //MessageBox.Show("BasicCardForm_Load", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //if you do not want the cards dealt when form is loaded (start new game)
            //comment out the line below LoadDeckOfCards_Deal();

            try
            {

                DoubleBuffered = true;

                //set to max sreen size
                nScreenWidth = (System.Windows.Forms.Screen.GetBounds(this).Width);
                nScreenHeight = (System.Windows.Forms.Screen.GetBounds(this).Height);

                //nScreenWidth = 1150;
                //nScreenHeight = 650;

                this.Width = nScreenWidth;
                this.Height = nScreenHeight;

                //this.TopMost = true;  //set game to be on top
                this.WindowState = FormWindowState.Maximized;

                //center the Form on the screen
                this.SetBounds((System.Windows.Forms.Screen.GetBounds(this).Width / 2) - (this.Width / 2), (System.Windows.Forms.Screen.GetBounds(this).Height / 2) - (this.Height / 2), this.Width, this.Height, System.Windows.Forms.BoundsSpecified.Location);

                ClearTextBox();

                MustReDeal = true;
                InPlay = true; //false

                //set intermediate mode
                MAXARRAY = 10;

                InitDeck();

                //set timer interval and variables
                Timer1.Interval = 1000;
                NewGameStarted = false;

                AnimationTimer.Interval = AnimationTimerInterval;
                AnimationTimer.Tick += new EventHandler(AnimatePlayerCardTimer_Tick);

                //commented 03/23/2022 testing - form load
                DealerCardPB.Hide();
                PicBoxDealerCard1.Hide();

                //PicBoxDealerCard1.Visible = true;
                //DealerCardPB.Visible = true;
                //DealerCardPB.BackColor = Color.Gold;
                //PicBoxDealerCard1.BackColor = Color.Gold;

                //table is clear of cards
                ClearCardTable = true;

                //MessageBox.Show("Card width, height " + cardWidth + "," + cardHeight, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //if card is face-up, player cannot select card
                IsCardFaceUp = false;

                _Increment = 0;

                //added to start game when form is loaded
                //***** comment out the line if you do not want cards dealt at start if games
                //LoadDeckOfCards_Deal();

                //MessageBox.Show("IsCardFaceUp= " + IsCardFaceUp.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                //MessageBox.Show("File is missing or corrupted!", "Error1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ////exit game
                //Application.Exit();
            }
        }

        private void BasicCardForm_SizeChanged(object sender, EventArgs e)
        {

            //MessageBox.Show("BasicCardForm_SizeChanged", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //deal with a change in window size

            //using window height to guide card size - first calculate according to window height
            displayCardHeight = (this.Panel1.Height - maxCardsHeight * cardMargin) / maxCardsHeight;
            displayCardWidth = displayCardHeight * (cardWidth / cardHeight);

            //MessageBox.Show("NPanel2= " + NPanel.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //if NPanel = 1 then show side panel, if NPanel = 0 then hide side panel
            if (NPanel == 0)
            {
                //PanelButtons.Visible = true;
                this.Panel2.Width = SidePanelWidthSm;
                this.Panel2.Visible = false;

                if (displayCardWidth > (this.Panel1.Width - maxCardsWidth * cardMargin) / maxCardsWidth)
                {
                    // if too wide, recalculate according to window width
                    displayCardWidth = (this.Panel1.Width - maxCardsWidth * cardMargin) / maxCardsWidth;
                    displayCardHeight = displayCardWidth * (cardHeight / cardWidth);
                }

                //center DelarCardPB in Panel1
                centerDealerCardPB = (this.Panel1.Width) / 2;
                bottomDealerCardPB = (this.Panel1.Height - Convert.ToInt32(displayCardHeight * CardPercent));

                //MessageBox.Show("NPanel2a= " + NPanel.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //PanelButtons.Visible = true;
                this.Panel2.Width = SidePanelWidthLg;
                this.Panel2.Visible = true;

                if (displayCardWidth > ((this.Panel1.Width - this.Panel2.Width) - maxCardsWidth * cardMargin) / maxCardsWidth)
                {
                    //if too wide, recalculate according to window width
                    displayCardWidth = ((this.Panel1.Width - this.Panel2.Width) - maxCardsWidth * cardMargin) / maxCardsWidth;
                    displayCardHeight = displayCardWidth * (cardHeight / cardWidth);
                }

                //center DelarCardPB in Panel1
                centerDealerCardPB = (this.Panel1.Width - Panel2.Width) / 2;
                bottomDealerCardPB = (this.Panel1.Height - Convert.ToInt32(displayCardHeight * CardPercent));

                //MessageBox.Show("NPanel2b= " + NPanel.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            //MessageBox.Show("Card width, height " + cardWidth + "," + cardHeight, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //MessageBox.Show("centerDealerCardPB " + centerDealerCardPB, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //_x = DealerCardPB.Location.X;
            //_y = DealerCardPB.Location.Y;
            _x = centerDealerCardPB;
            _y = bottomDealerCardPB - 10;

            //MessageBox.Show("1 _x,_y,centerDealerCardPB " + _x + " " + _y + " " + centerDealerCardPB, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //MessageBox.Show("displayCardWidth,displayCardHeight " + displayCardWidth + " " + displayCardHeight, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //PicBoxDealerCard1.Visible = true;
            //DealerCardPB.Visible = true;
            //DealerCardPB.BackColor = Color.Gold;
            //PicBoxDealerCard1.BackColor = Color.Gold;

            DealerCardPB.Location = new Point(_x, _y);
            //DealerCardPB.Size = new Size(Convert.ToInt32(displayCardWidth), Convert.ToInt32(displayCardHeight));
            //using CardPercent
            DealerCardPB.Size = new Size(Convert.ToInt32(displayCardWidth * CardPercent), Convert.ToInt32(displayCardHeight * CardPercent));

            PicBoxDealerCard1.Location = new Point(_x, _y);
            //PicBoxDealerCard1.Size = new Size(Convert.ToInt32(displayCardWidth), Convert.ToInt32(displayCardHeight));
            //using CardPercent
            PicBoxDealerCard1.Size = new Size(Convert.ToInt32(displayCardWidth * CardPercent), Convert.ToInt32(displayCardHeight * CardPercent));

            //commented 03/23/2022 form size changed
            DealerCardPB.Hide();
            PicBoxDealerCard1.Hide();
            //end added

            //change all card button sizes
            UpdateCards();
        }

        private void UpdateCards()
        {
            //each time the window is resized, recalculate the new card sizes
            //horizontal space between cards
            float xoffset = cardMargin;
            //vertical space between cards
            float yoffset = cardMargin;
            byte i = 0;
            for (byte y = 0; y <= 3; y++)
            {
                for (byte x = 0; x <= 12; x++)
                {
                    if (cardButtons[i] != null)
                    {
                        //ignore this event when it fires during initial startup
                        cardButtons[i].Size = new Size(Convert.ToInt32(displayCardWidth), Convert.ToInt32(displayCardHeight));
                        cardButtons[i].Location = new Point(Convert.ToInt32(x * (displayCardWidth + cardMargin) + xoffset), Convert.ToInt32(y * (displayCardHeight + cardMargin) + yoffset));
                        cardButtons[i].BringToFront();
                    }
                    i += 1;
                }
            }
        }

        private PlayingCard[] InsideOutShuffle(PlayingCard[] deck)
		{
			//Fisher-Yates shuffle algorithm, shuffle the deck of cards
			int i = 0;
			int j = 0;
			PlayingCard[] newShuffled = new PlayingCard[MAXCARDS];
			newShuffled[0] = deck[0];
            Random sortRandom = new Random();
			for (i = 1; i < MAXCARDS; i++)
			{
                j = Convert.ToInt32(sortRandom.Next(0, i+1));
                newShuffled[i] = newShuffled[j];
				newShuffled[j] = deck[i];
			}
			return newShuffled;
		}

        private void InitDeck()
		{
			//open a new deck of cards, unshuffled
			int k = 0;
            for (int i = 0; i < MAXSUITS; i++)
			{
				for (int j = 0; j < MAXRANKS; j++)
				{
                    //assign its suit
                    unshuffled[k].suit = i;
                    //assign its rank
                    unshuffled[k].rank = j;
                    //face down
                    unshuffled[k].revealed = false;
                    unshuffled[k].face = (System.Drawing.Image) Properties.Resources.ResourceManager.GetObject("_" + ranks[j] + "_of_" + suits[i]);
                    unshuffled[k].rear = Properties.Resources.aqua150;
                    k += 1;
				}
			}
		}

        private void StartNewGame()
        {
            //start a new game, deal the cards
            if (!MustReDeal && NewGameStarted)
            {
                // Dialog box with two buttons: yes and no.
                DialogResult result1 = MessageBox.Show("Would you like to start a new game?", "Start New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //MessageBox.Show("result1 " + result1, "Results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (result1 == DialogResult.Yes)
                {
                    MustReDeal = true;
                    NewGameStarted = false;

                    ClearDeckOfCards_Deal();
                    //ClearCardTable = true;
                    LoadDeckOfCards_Deal();
                }
                else
                {
                    ClearCardTable = false;
                }
            }
            else
            {
                //MessageBox.Show("ClearCardTable, MustReDeal, NewGameStarted " + ClearCardTable + " " + Module1.MustReDeal + " " + NewGameStarted, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (ClearCardTable && MustReDeal && !NewGameStarted)
                {
                    MustReDeal = false;
                    LoadDeckOfCards_Deal();
                }
                else
                {
                    //MessageBox.Show("You must deal new cards!", "Select New Game", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void LoadDeckOfCards_Deal()
        {
            // IsGameReady = false;

            //load deck of cards
            InitDealerCard();

            DealerCardPB.Show();
            PicBoxDealerCard1.Show();

            //deck of cards is ready to start game, table will not be clear of cards
            ClearCardTable = false;

            //start new game
            NewGame();
        }

        private void InitDealerCard()
        {
            //initially face down artwork
            //DealerCardPB.BackgroundImage = Image.FromFile(Module1.strThemeDir + Module1.NCard + ".png");
            DealerCardPB.BackgroundImage = Properties.Resources.aqua150;
            DealerCardPB.BackgroundImageLayout = ImageLayout.Stretch;
            DealerCardPB.Show();
            DealerCardPB.BringToFront();

            //PicBoxDealerCard1.BackgroundImage = Image.FromFile(Module1.strThemeDir + Module1.NCard + ".png");
            PicBoxDealerCard1.BackgroundImage = Properties.Resources.aqua150;
            PicBoxDealerCard1.BackgroundImageLayout = ImageLayout.Stretch;
            PicBoxDealerCard1.Show();
            PicBoxDealerCard1.SendToBack();
        }

        private void NewGame()
        {
            //show existing cards on table, show all card faces
            OnShowCardsToolStripMenuItem.Checked = false;
            OffShowCardsToolStripMenuItem.Checked = true;

            //sound files in resources - card_drop, defeat, hooray, shuffling_cards
            //SoundPlayer player = new SoundPlayer(Properties.Resources.shuffling_cards);
            //player.Play();
            //player.Dispose();
            PlaySoundFiles("shuffling_cards");

            System.Threading.Thread.Sleep(500);

            //shuffle the deck
            shuffled = InsideOutShuffle(unshuffled);
            //add shuffled deck to dealer deck
            shuffledDC = shuffled;

            //to set deck to unshuffled deck to view cards
            //shuffled = unshuffled;

            //no face-up cards currently on table
            tabled = 0;
            //no cards yet played
            cardCount = 0;
            //no card selections made
            choices[0] = NOCHOICE;
            choices[1] = NOCHOICE;

            //reset timer
            ResetClockDisplay();
            ClearTextBox();

            //load cards to table, display cards
            InitTableau();

            TimerOn = false;

            MustReDeal = false;
            InPlay = false;
            NewGameStarted = true;
            //table is not clear of cards
            ClearCardTable = false;

            //added to start game when form is loaded
            InPlay = true;

            //start timer in seconds
            StartClockDisplay();

        }

        private void InitTableau()
        {
            //setup cards on table 4 rows (maxCardsHeight), 13 columns (maxCardsWidth), 52 cards

            IsGameReady = false;

            // Save the original location of the PicBoxDealerCard (card to animate)
            _startPoint = DealerCardPB.Location;

            //horizontal space between cards
            float xoffset = cardMargin;
            //vertical space between cards
            float yoffset = cardMargin;

            //create a pictureBox (button) for each card and place on table, each card is displayed in a picturebox, PictureBox[] cardButtons = new PictureBox[MAXCARDS];
            byte i = 0;
            for (byte y = 0; y <= (maxCardsHeight - 1); y++)
            {
                for (byte x = 0; x <= (maxCardsWidth - 1); x++)
                {
                    if (cardButtons[i] != null)
                    {
                        //erase previous game data
                        cardButtons[i].Visible = false;
                        //remove the pictureBox Action>Click>Method (cardClick function) from the array
                        cardButtons[i].Click -= cardClick;
                        this.Panel1.Controls.Remove(cardButtons[i]);
                        cardButtons[i].Dispose();
                    }
                    //create this games card picturebox
                    cardButtons[i] = new PictureBox();
                    cardButtons[i].Enabled = true;
                    cardButtons[i].Name = i.ToString();

                    //picturebox styles
                    cardButtons[i].BackColor = Color.SteelBlue;

                    //initially face down artwork
                    cardButtons[i].BackgroundImage = Properties.Resources.aqua150;
                    cardButtons[i].BackgroundImageLayout = ImageLayout.Stretch;
                    cardButtons[i].Size = new Size(Convert.ToInt32(displayCardWidth), Convert.ToInt32(displayCardHeight));
                    cardButtons[i].Location = new Point(Convert.ToInt32(x * (displayCardWidth + cardMargin) + xoffset), Convert.ToInt32(y * (displayCardHeight + cardMargin) + yoffset));

                    //initially, only the first card is visible, not used in this game
                    //if (i > 0){ cardButtons[i].Visible = false; } else { cardButtons[i].Visible = true; }

                    PicPlayerCard0.Visible = false;
                    //PicPlayerCard0.Location = cardButtons[i].Location;

                    //deal the card.................................animation
                    PlayerCardLocationX = cardButtons[i].Location.X;
                    PlayerCardLocationY = cardButtons[i].Location.Y;
                    //DealerCardPB
                    DealerCardLocationX = DealerCardPB.Location.X;
                    DealerCardLocationY = DealerCardPB.Location.Y;
                    //MessageBox.Show("PlayerCardLocationX, PlayerCardLocationY, DealerCardLocationX, DealerCardLocationY " + PlayerCardLocationX + " " + PlayerCardLocationY + " " + DealerCardLocationX + " " + DealerCardLocationY, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    AnimationDone = false;
                    AnimatePlayerCard();

                    //show all cards
                    cardButtons[i].Visible = true;
                    cardButtons[i].BringToFront();

                    this.Panel1.Controls.Add(cardButtons[i]);

                    //add the pictureBox Action>Click>Method (cardClick function) to the array
                    //cardButtons[i].Click += new System.EventHandler(cardClick);

                    cardButtons[i].Click += cardClick;

                    i += 1;
                }
            }

            //commented 03/23/2022 testing InitTableau
            DealerCardPB.Hide();
            PicBoxDealerCard1.Hide();

            PicPlayerCard0.Hide();

            //need to enable cards
            EnabeAllCards();
        }

        private void AnimatePlayerCard()
        {
            AnimationTimer.Enabled = true;
            while (AnimationTimer.Enabled == true)
            {
                // Wait for animation to finish
                Application.DoEvents();
                //Delay(25);
            }
        }

        private void AnimatePlayerCardTimer_Tick(object sender, EventArgs e)
        {
            //deal card to PicBoxPlayer1Card1
            if (intCardNum == 1)
            {
                if (_Increment <= 500)
                {
                    // Player is dealt the card, so use as endpoints player card locations.
                    _a = PlayerCardLocationX;
                    _b = PlayerCardLocationY;
                }
                _x = (_a - _startPoint.X) * _Increment / 500 + _startPoint.X;
                _y = (_b - _startPoint.Y) * _Increment / 500 + _startPoint.Y;

                //MessageBox.Show("_startPoint x and y " + _startPoint.X + " " + _startPoint.Y, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show("_x and _y and _Increment " + _x + " " + _y + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //if (_Increment == 0)
                //{
                //    MessageBox.Show("1_x and _y and _Increment " + _x + " " + _y + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //}

                DealerCardPB.Location = new Point(_x, _y);
                DealerCardPB.Show();
                DealerCardPB.BringToFront();

                if (PicPlayerCard0.Bounds.IntersectsWith(DealerCardPB.Bounds) && AnimationDone == false)
                {
                    //MessageBox.Show("_y and _b _Increment " + _y + " " + _b + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //tFlag = true;
                    //AnimationDone = true;
                }

                if (_y == (_b + 1) && AnimationDone == false)
                {
                    //end animation before top of card is reached, ShuffleNDealP1
                    AnimationDone = true;
                    //MessageBox.Show("_x and _a and _Increment " + _x + " " + _a + " " + _Increment, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (_Increment == 500)
                {
                    DealerCardPB.Location = _startPoint;
                }

                if (_Increment > 500 || AnimationDone == true)
                {
                    AnimationTimer.Enabled = false;
                    DealerCardPB.Location = _startPoint;
                    _Increment = 0;
                }

                //how fast to deal cards, 75
                _Increment += DealSpeed;
            }
        }

        private void cardClick(object sender, EventArgs e)
        {
            //pictureBox Action>Click>Method (cardClick function) for the array

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            //determine if we are revealing a face-down card or selecting a face-up card
            if (!shuffled[Convert.ToInt32(((PictureBox)sender).Name)].revealed && !IsCardFaceUp)
            {
                //we are selecting a face-down card
                if (choices[0] == NOCHOICE)
                {
                    //first card selected
                    //((PictureBox)sender).FlatAppearance.BorderColor = Color.Gold;
                    ((PictureBox)sender).BackColor = Color.Gold;
                    choices[0] = Convert.ToInt32(((PictureBox)sender).Name);

                    TextBox7.Text = rank[shuffled[Convert.ToInt32((choices[0]))].rank].ToString() + suit[shuffled[Convert.ToInt32((choices[0]))].suit].ToString();
                    TextBox8.Text = "";

                    shuffled[Convert.ToInt32(((PictureBox)sender).Name)].revealed = true;
                    //shows its face
                    cardButtons[Convert.ToInt32(((PictureBox)sender).Name)].BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("_" + ranks[shuffled[Convert.ToInt32(((PictureBox)sender).Name)].rank] + "_of_" + suits[shuffled[Convert.ToInt32(((PictureBox)sender).Name)].suit]);
                    //if face-down cards remain, display the face-down card at the end
                    cardButtons[Convert.ToInt32(((PictureBox)sender).Name)].Visible = true;
                    //disable card from user selecting it again
                    cardButtons[choices[0]].Enabled = false;
                }
                else if (choices[1] == NOCHOICE)
                {
                    //second card selected, do we have a match?
                    //((PictureBox)sender).FlatAppearance.BorderColor = Color.Gold;
                    ((PictureBox)sender).BackColor = Color.Gold;
                    choices[1] = Convert.ToInt32(((PictureBox)sender).Name);

                    TextBox8.Text = rank[shuffled[Convert.ToInt32((choices[1]))].rank].ToString() + suit[shuffled[Convert.ToInt32((choices[1]))].suit].ToString();

                    shuffled[Convert.ToInt32(((PictureBox)sender).Name)].revealed = true;
                    //shows its face
                    cardButtons[Convert.ToInt32(((PictureBox)sender).Name)].BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("_" + ranks[shuffled[Convert.ToInt32(((PictureBox)sender).Name)].rank] + "_of_" + suits[shuffled[Convert.ToInt32(((PictureBox)sender).Name)].suit]);
                    //if face-down cards remain, display the face-down card at the end
                    cardButtons[Convert.ToInt32(((PictureBox)sender).Name)].Visible = true;
                    //disable card from user selecting it again
                    cardButtons[choices[1]].Enabled = false;

                    //check for match
                    AssessAttempt();

                    //cardCount = MAXCARDS, end game
                    if (cardCount == MAXCARDS)
                    {
                        //sound files in resources - card_drop, defeat, hooray, shuffling_cards
                        SoundPlayer player = new SoundPlayer(Properties.Resources.hooray);
                        player.Play();
                        player.Dispose();

                        StopClockDisplay();
                        MessageBox.Show("You won!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                if (choices[0] == choices[1])
                {
                    //clicking on same card twice deselects
                    ((PictureBox)sender).BackColor = Color.SteelBlue;
                }
            }
            else
            {
                //card if face-up, IsCardFaceUp
                MessageBox.Show("Cannot select card, please hide cards!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            TextBox5.Text = cardCount.ToString();
            TextBox6.Text = (MAXCARDS - cardCount).ToString();
        }

        private void EnabeAllCards()
        {
            //enable cards on table
            byte i = 0;
            for (byte x = 0; x <= 51; x++)
            {
                if (cardButtons[i] != null)
                {
                    //erase previous game data
                    cardButtons[i].Enabled = true;
                }
                i += 1;
            }
            IsGameReady = true;
        }

        private void ClearCardsFromTable()
        {
            //clear existing cards from table

            //conditions to consider
            //ClearCardTable - true if table is empty, false if there is cards on table
            //Module1.MustReDeal = false and NewGameStarted = true; if game is started and cards on table, 
            //Module1.MustReDeal = true and NewGameStarted = false; if game is not started and cards are not on table,
            //ClearCardTable = true and Module1.MustReDeal = false and NewGameStarted = false, if table is clear and game is not started.
            //MessageBox.Show("1C ClearCardTable, MustReDeal, NewGameStarted " + ClearCardTable + " " + Module1.MustReDeal + " " + NewGameStarted, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if ((!ClearCardTable && MustReDeal && NewGameStarted) || (!ClearCardTable && !MustReDeal && NewGameStarted))
            {
                // Dialog box with two buttons: yes and no.
                DialogResult result1 = MessageBox.Show("Would you like to clear the cards from the table?", "Clear the table", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //MessageBox.Show("result1 " + result1, "Results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (result1 == DialogResult.Yes)
                {
                    MustReDeal = true;
                    NewGameStarted = false;

                    //clear the cards off the table
                    ClearDeckOfCards_Deal();

                    //reset timer
                    ResetClockDisplay();
                    ClearTextBox();
                }
                else
                {
                    ClearCardTable = false;
                }
            }
            else
            {
                //used for testing
                if (ClearCardTable && !MustReDeal && !NewGameStarted)
                {
                    //true, false, false
                    //table is clear, cards are not dealt, game is not started
                    //MessageBox.Show("1 ClearCardTable, MustReDeal, NewGameStarted " + ClearCardTable + " " + Module1.MustReDeal + " " + NewGameStarted, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //MessageBox.Show("You must deal new cards!", "Select New Game", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //true, true, false, table is clear, cards are dealt and must redeal, game is not started
                    //false, false, false, table is not clear, cards are not dealt, game is not started
                    //false, false, false, table is not clear, cards are not dealt, game is not started
                    //false, true, true, table is not clear, cards are dealt, game is started
                    //MessageBox.Show("2 ClearCardTable, MustReDeal, NewGameStarted " + ClearCardTable + " " + Module1.MustReDeal + " " + NewGameStarted, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //ClearCardTable = false;
            }
        }
        private void ClearDeckOfCards_Deal()
        {
            //clear the cards off the table
            //not used this.Panel1.Controls.Remove(cardButtons[i]); this.Panel1.Controls.Clear();

            byte i = 0;
            for (byte x = 0; x <= 51; x++)
            {
                if (cardButtons[i] != null)
                {
                    //erase previous game data
                    cardButtons[i].Visible = false;
                    //remove the pictureBox Action>Click>Method (cardClick function) from the array
                    cardButtons[i].Click -= cardClick;
                    this.Panel1.Controls.Remove(cardButtons[i]);
                    cardButtons[i].Dispose();
                }
                i += 1;
            }
            ClearCardTable = true;
        }

        private void ShowCardsOnTable()
        {
            //show existing cards on table, show all card faces

            short i;
            bool flg;

            if (!MustReDeal && NewGameStarted)
            {
                //search for card
                for (i = 0; i <= (MAXCARDS - 1); i++)
                {
                    flg = shuffled[i].revealed;
                    if (!flg)
                    {
                        cardButtons[Convert.ToInt32(cardButtons[i].Name)].BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("_" + ranks[shuffled[Convert.ToInt32(cardButtons[i].Name)].rank] + "_of_" + suits[shuffled[Convert.ToInt32(cardButtons[i].Name)].suit]);
                    }
                }
                IsCardFaceUp = true;
            }
            else
            {
                MessageBox.Show("You must deal new cards!", "Select New Game", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HideCardsOnTable()
        {
            //hide existing cards on table, hide all card faces, show backs

            short i;
            bool flg;

            if (!MustReDeal && NewGameStarted)
            {
                //search for card
                for (i = 0; i <= (MAXCARDS - 1); i++)
                {
                    flg = shuffled[i].revealed;
                    if (!flg)
                    {
                        //cardButtons[i].BackgroundImage = Image.FromFile(Module1.strThemeDir + Module1.NCard + ".png");
                        cardButtons[i].BackgroundImage = Properties.Resources.aqua150;
                    }
                }
                IsCardFaceUp = false;
            }
            else
            {
                MessageBox.Show("You must deal new cards!", "Select New Game", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Delay(int miliseconds_to_sleep)
        {
            //this procedure delays the given number of seconds, which can be fractional.
            //Thread.Sleep(1000); //sleep 1 second.
            Thread.Sleep(miliseconds_to_sleep);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            //Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            lblShowTime.Text = elapsedTime;
            lblShowTime.Refresh();

        }

        private void PlaySoundFiles(string tString)
        {
            //play sound files
            if (NSound == 1)
            {
                //sound files in resources - card_drop, defeat, hooray, shuffling_cards, SoundPlayer player = new SoundPlayer(Properties.Resources.hooray);
                switch (tString)
                {
                    case "card_drop":
                        SoundPlayer player1 = new SoundPlayer(Properties.Resources.card_drop);
                        player1.Play();
                        player1.Dispose();
                        break;
                    case "defeat":
                        SoundPlayer player2 = new SoundPlayer(Properties.Resources.defeat);
                        player2.Play();
                        player2.Dispose();
                        break;
                    case "hooray":
                        SoundPlayer player3 = new SoundPlayer(Properties.Resources.hooray);
                        player3.Play();
                        player3.Dispose();
                        break;
                    case "shuffling_cards":
                        SoundPlayer player4 = new SoundPlayer(Properties.Resources.shuffling_cards);
                        player4.Play();
                        player4.Dispose();
                        break;
                    default:
                        SoundPlayer player = new SoundPlayer(Properties.Resources.card_drop);
                        player.Play();
                        player.Dispose();
                        break;
                }   //end switch
            }   //end if NSound
        }   //end PlaySoundFiles

        private void SelectSoundOnOff(short NSound)
        {
            //turn sound on/off, 1 on, 0 off
            if (NSound == 1)
            {
                OnSoundToolStripMenuItem.Checked = true;
                OffSoundToolStripMenuItem.Checked = false;
            }
            else if (NSound == 0)
            {
                OnSoundToolStripMenuItem.Checked = false;
                OffSoundToolStripMenuItem.Checked = true;
            }
            else
            {
                NSound = 1;
                OnSoundToolStripMenuItem.Checked = true;
                OffSoundToolStripMenuItem.Checked = false;
            }

            //put ini file settings for sound, turn sound on/off, 1 on, 0 off
            //ini.PutIniFileSettings(ref NSound, "PlaySound");
        }

        private void SelectSidePanelShowHide(short NPanel)
        {
            //show side panel show/hide, 1,0, default show
            if (NPanel == 1)
            {
                OnSidePanelToolStripMenuItem.Checked = true;
                OffSideToolStripMenuItem.Checked = false;
            }
            else if (NPanel == 0)
            {
                OnSidePanelToolStripMenuItem.Checked = false;
                OffSideToolStripMenuItem.Checked = true;
            }
            else
            {
                NPanel = 1;
                OnSidePanelToolStripMenuItem.Checked = true;
                OffSideToolStripMenuItem.Checked = false;
            }

            //put ini file settings for side panel, panel show/hide, 1 show, 0 hide
            //ini.PutIniFileSettings(ref NPanel, "ShowPanel");
        }

        // StartClockDisplay
        public void StartClockDisplay()
        {
            //start timer
            if ((Practice) && InPlay && !TimerOn)
            {
                stopWatch.Start();
                Timer1.Enabled = true;
                TimerOn = true;
            }
        }

        // StopClockDisplay
        public void StopClockDisplay()
        {
            //stop timer
            if (InPlay && TimerOn)
            {
                stopWatch.Stop();
                Timer1.Enabled = false;
                TimerOn = false;
            }
        }

        // ResetClockDisplay
        public void ResetClockDisplay()
        {
            //reset timer to zero
            stopWatch.Reset();
            TimerOn = false;
        }

        private void AssessAttempt()
        {
            //check if the selected cards are a match
            if ((shuffled[choices[0]].rank == shuffled[choices[1]].rank))
            {
                //we have a match of 2 cards with same ranking
                cardCount += 2;

                //choices(0) and choices(1) are the location of the cards selected in the table
                textBox1.Text = choices[0].ToString() + ", " + choices[1].ToString();
                textBox2.Text = rank[shuffled[Convert.ToInt32((choices[0]))].rank].ToString() + suit[shuffled[Convert.ToInt32((choices[0]))].suit].ToString() + ", " + rank[shuffled[Convert.ToInt32((choices[1]))].rank].ToString() + suit[shuffled[Convert.ToInt32((choices[1]))].suit].ToString();

                textBox3.Text = ranks[shuffled[choices[0]].rank].ToString() + ", " + ranks[shuffled[choices[1]].rank].ToString();
                textBox4.Text = suits[shuffled[choices[0]].suit].ToString() + ", " + suits[shuffled[choices[1]].suit].ToString();

                //card delay of 1 sec
                Delay(1000);

                shuffled[choices[0]].revealed = true;
                //shows its face
                cardButtons[choices[0]].BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("_" + ranks[shuffled[choices[0]].rank] + "_of_" + suits[shuffled[choices[0]].suit]);
                //if cards match remove from this card from view on table
                cardButtons[choices[0]].Visible = false;

                shuffled[choices[1]].revealed = true;
                //shows its face
                cardButtons[choices[1]].BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("_" + ranks[shuffled[choices[1]].rank] + "_of_" + suits[shuffled[choices[1]].suit]);
                //if cards match remove from this card from view on table
                cardButtons[choices[1]].Visible = false;

                FlipCards();
            }
            else
            {
                //no match
                //card delay of 1.75 sec
                Delay(1750);

                shuffled[choices[0]].revealed = false;
                //initially face down artwork
                cardButtons[choices[0]].BackgroundImage = Properties.Resources.aqua150;
                //if cards do not match leave this card on table
                cardButtons[choices[0]].Visible = true;

                shuffled[choices[1]].revealed = false;
                //initially face down artwork
                cardButtons[choices[1]].BackgroundImage = Properties.Resources.aqua150;
                //if cards do not match leave this card on table
                cardButtons[choices[1]].Visible = true;

                cardButtons[choices[0]].BackColor = Color.SteelBlue;
                cardButtons[choices[1]].BackColor = Color.SteelBlue;
                //enable card to allow user to select it
                cardButtons[choices[0]].Enabled = true;
                //enable card to allow user to select it
                cardButtons[choices[1]].Enabled = true;

                //no piles should now be selected
                choices[0] = NOCHOICE;
                choices[1] = NOCHOICE;
            }
        }

        private void FlipCards()
        {
            //no cards should now be selected
            choices[0] = NOCHOICE;
            choices[1] = NOCHOICE;
            //sound files in resources - card_drop, defeat, hooray, shuffling_cards
            SoundPlayer player = new SoundPlayer(Properties.Resources.card_drop);
            player.Play();
            player.Dispose();
        }

        // ClearTextBox
        public void ClearTextBox()
        {
            //show cards positions
            textBox1.Text = "";
            //show cards rank/suite
            textBox2.Text = "";
            //show ranks of matching cards
            textBox3.Text = "";
            //show suits of matching cards
            textBox4.Text = "";
            //show cards found
            TextBox5.Text = "0";
            //show cards remaining
            TextBox6.Text = "0";
            //show which button was clicked
            TextBox7.Text = "";
            TextBox8.Text = "";
            //lbl_Match.Text = "";
            //TextBox10.Text = "";
            //lbl_Pot0.Text = "0";
            //lbl_Pot1.Text = "0";
            //lbl_GameMode.Text = "";
            //lbl_Level.Text = "";
        }

        //********** start menu strip info

        private void PlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //start a new game
            StartNewGame();
        }

        private void ClearCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear the cards from table
            ClearCardsFromTable();
        }

        private void OnSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //turn sound on
            NSound = 1;
            SelectSoundOnOff(NSound);
        }

        private void OffSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //turn sound off
            NSound = 0;
            SelectSoundOnOff(NSound);
        }

        private void OnShowCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show existing cards on table, show all card faces

            ShowCardsOnTable();
            if (!MustReDeal && NewGameStarted)
            {
                OnShowCardsToolStripMenuItem.Checked = true;
                OffShowCardsToolStripMenuItem.Checked = false;
            }
        }

        private void OffShowCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hide existing cards on table, hide all card faces, show backs

            HideCardsOnTable();
            if (!MustReDeal && NewGameStarted)
            {
                OnShowCardsToolStripMenuItem.Checked = false;
                OffShowCardsToolStripMenuItem.Checked = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit application
            Application.Exit();
        }

        private void HowToPlayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Memory Card game using one deck of playing cards. The object of the game is to match as many cards as you can by turning the cards face up in pairs of the same value." + Environment.NewLine + Environment.NewLine + "At the beginning of play turn two cards face up, one at a time. If they are a pair, such as 2 Aces or 2 Threes, you matched the two cards. See if you can turn up another pair. Keep on playing until you turn up all cards." + Environment.NewLine + Environment.NewLine + "As the game continues, you will be able to remember the positions and values of some of the cards that have been turned up. If your memory is good, you will be able to find the cards you need to make pairs." + Environment.NewLine + Environment.NewLine + "Test your skills against the clock!" + Environment.NewLine + Environment.NewLine + "The game ends when all the cards have been made into pairs.", "How To Play", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Memory Card Game by UbGames", "Single Player", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnSidePanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show side panel cards selected
            NPanel = 1;
            SelectSidePanelShowHide(NPanel);

            //OnSidePanelToolStripMenuItem.Checked = true;
            //OffSideToolStripMenuItem.Checked = false;

            //PanelButtons.Visible = true;
            this.Panel2.Width = SidePanelWidthLg;
            //this.Panel2.Visible = true;

            //change all card button sizes

            //using window height to guide card size - first calculate according to window height
            displayCardHeight = (this.Panel1.Height - maxCardsHeight * cardMargin) / maxCardsHeight;
            displayCardWidth = displayCardHeight * (cardWidth / cardHeight);

            //change all card button sizes
            if (displayCardWidth > ((this.Panel1.Width - this.Panel2.Width) - maxCardsWidth * cardMargin) / maxCardsWidth)
            {
                //if too wide, recalculate according to window width
                displayCardWidth = ((this.Panel1.Width - this.Panel2.Width) - maxCardsWidth * cardMargin) / maxCardsWidth;
                displayCardHeight = displayCardWidth * (cardHeight / cardWidth);
            }

            HideAllCardsOnTable();
            this.Panel2.Visible = true;
            UpdateCards();
        }

        private void OffSidePanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //hide side panel cards selected
            NPanel = 0;
            SelectSidePanelShowHide(NPanel);

            //OnSidePanelToolStripMenuItem.Checked = false;
            //OffSideToolStripMenuItem.Checked = true;

            //PanelButtons.Visible = false;
            this.Panel2.Width = SidePanelWidthSm;
            this.Panel2.Visible = false;

            //using window height to guide card size - first calculate according to window height
            displayCardHeight = (this.Panel1.Height - maxCardsHeight * cardMargin) / maxCardsHeight;
            displayCardWidth = displayCardHeight * (cardWidth / cardHeight);

            //change all card button sizes
            if (displayCardWidth > (this.Panel1.Width - maxCardsWidth * cardMargin) / maxCardsWidth)
            {
                // if too wide, recalculate according to window width
                displayCardWidth = (this.Panel1.Width - maxCardsWidth * cardMargin) / maxCardsWidth;
                displayCardHeight = displayCardWidth * (cardHeight / cardWidth);
            }

            HideAllCardsOnTable();
            UpdateCards();
        }

        private void HideAllCardsOnTable()
        {
            //hide existing cards on table, hide all card faces, show backs

            short i;
            bool flg;

            if (!MustReDeal && NewGameStarted)
            {
                //search for card
                for (i = 0; i <= (MAXCARDS - 1); i++)
                {
                    flg = shuffled[i].revealed;
                    if (!flg)
                    {
                        //cardButtons[i].BackgroundImage = Image.FromFile(Module1.strThemeDir + Module1.NCard + ".png");
                        cardButtons[i].BackgroundImage = Properties.Resources.aqua150;
                    }
                }
                IsCardFaceUp = false;
                OnShowCardsToolStripMenuItem.Checked = false;
                OffShowCardsToolStripMenuItem.Checked = true;
            }
            else
            {
                //MessageBox.Show("You must deal new cards!", "Select New Game", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void StartNewGame2()
        {
            //this function is not  used, see PlayToolStripMenuItem_Click to start new game

            //start a new game, deal the cards
            if ((ClearCardTable && !MustReDeal && NewGameStarted))
            {
                //MessageBox.Show("1D ClearCardTable, MustReDeal, NewGameStarted " + ClearCardTable + " " + MustReDeal + " " + NewGameStarted, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Dialog box with two buttons: yes and no.
                DialogResult result1 = MessageBox.Show("Would you like to start a new game?", "Start New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //MessageBox.Show("result1 " + result1, "Results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (result1 == DialogResult.Yes)
                {
                    MustReDeal = true;
                    NewGameStarted = false;

                    ClearDeckOfCards_Deal();
                    //ClearCardTable = true;
                    LoadDeckOfCards_Deal();
                }
                else
                {
                    ClearCardTable = false;
                }
            }
            else
            {
                //table is clear, cards are dealt and must redeal, game is not started
                if (ClearCardTable && MustReDeal && !NewGameStarted)
                {
                    //MessageBox.Show("1 ClearCardTable, MustReDeal, NewGameStarted " + ClearCardTable + " " + Module1.MustReDeal + " " + NewGameStarted, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MustReDeal = false;
                    ClearDeckOfCards_Deal();
                    LoadDeckOfCards_Deal();
                }
                else
                {
                    //MessageBox.Show("2 ClearCardTable, MustReDeal, NewGameStarted " + ClearCardTable + " " + Module1.MustReDeal + " " + NewGameStarted, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //false, false, true
                    if ((!ClearCardTable && !MustReDeal && NewGameStarted))
                    {
                        //MessageBox.Show("1D ClearCardTable, MustReDeal, NewGameStarted " + ClearCardTable + " " + Module1.MustReDeal + " " + NewGameStarted, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Dialog box with two buttons: yes and no.
                        DialogResult result1 = MessageBox.Show("Would you like to start a new game?", "Start New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //MessageBox.Show("result1 " + result1, "Results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        if (result1 == DialogResult.Yes)
                        {
                            MustReDeal = true;
                            NewGameStarted = false;

                            ClearDeckOfCards_Deal();
                            //ClearCardTable = true;
                            LoadDeckOfCards_Deal();
                        }
                        else
                        {
                            ClearCardTable = false;
                        }
                    }
                    //table is not clear, cards are not dealt, game is not started
                    //MessageBox.Show("You must clear the table!", "Clear Cards", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }// end StartNewGame2

    } //class BasicCardForm

} //namespace