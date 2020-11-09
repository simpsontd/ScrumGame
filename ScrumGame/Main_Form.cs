using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using System.Media;
using ScrumGame.Properties;
using NAudio.Wave;

namespace ScrumGame
{
    public partial class MainForm : Form
    {
        #region Properties

        

        //-----------------------------------------------------------Properties-------------------------------------------------------------------------------
        /// <summary>
        /// Number of players in the game
        /// </summary>
        public int NumPlayers { get; set; }

        /// <summary>
        /// the player that starts each phase for the round
        /// </summary>
        public Player StartPlayer { get; set; }

        /// <summary>
        /// Track the areas that each player have placed workers
        /// </summary>
        public List<List<Control>>  PlayerAreasUsed { get; set; }

        /// <summary>
        /// Control when players can move worker tokens
        /// </summary>
        public bool AllowDragWorker { get; set; }

        /// <summary>
        /// The current phase of the round
        /// </summary>
        public int CurrentPhase { get; set; }

        /// <summary>
        /// Make form 2 a global variable so the task list items persist closing
        /// </summary>
        public TaskForm frm2 = new TaskForm();

        /// <summary>
        /// Custom color progress bar for player1
        /// </summary>
        CustomProgressBar Player1PointProgressBar = new CustomProgressBar();

        /// <summary>
        /// Custom color progress bar for player2
        /// </summary>
        CustomProgressBar Player2PointProgressBar = new CustomProgressBar();

        /// <summary>
        /// Custom color progress bar for player3
        /// </summary>
        CustomProgressBar Player3PointProgressBar = new CustomProgressBar();

        /// <summary>
        /// Custom color progress bar for player4
        /// </summary>
        /// 
        CustomProgressBar Player4PointProgressBar = new CustomProgressBar();


        /// <summary>
        /// Player objects to keep track of points and resources
        /// </summary>
        public Player[] Players { get; set; }
        /// <summary>
        /// Vertical offset to account for border and menu bar
        /// </summary>
        private const int Y_OFFSET = 23;

        /// <summary>
        /// Horizontal offset between resource control and the first location to place a worker
        /// </summary>
        private const int RESOURCE_X_OFFSET = 10;

        /// <summary>
        /// Vertical offset between resource control and the first location to place a worker
        /// </summary>
        private const int RESOURCE_Y_OFFSET = 6;

        /// <summary>
        /// List of all workers in game
        /// </summary>
        private List<Worker> WorkersList { get; set; }

        /// <summary>
        /// List of all front-end developers in supply
        /// </summary>
        public List<Worker> FrontEndDeveloperSupplyList { get; set; }

        /// <summary>
        /// list of all back-end developers in supply
        /// </summary>
        public List<Worker> BackEndDeveloperSupplyList { get; set; }

        /// <summary>
        /// list of all full-stack developers in supply
        /// </summary>
        public List<Worker> FullStackDeveloperSupplyList { get; set; }

        /// <summary>
        /// list of all product owners in supply
        /// </summary>
        private List<Worker> ProductOwnerSupplyList { get; set; }

        /// <summary>
        /// list of all scrum masters in supply
        /// </summary>
        private List<Worker> ScrumMasterSupplyList { get; set; }

        /// <summary>
        /// list of all workers on Countract Out spot
        /// </summary>
        private List<Worker> ContractOutWorkersList { get; set; }

        /// <summary>
        /// list of all workers on Taskland
        /// </summary>
        private List<Worker> TaskWorkersList { get; set; }

        /// <summary>
        /// list of all workers on Storyland
        /// </summary>
        private List<Worker> StoryWorkersList { get; set; }

        /// <summary>
        /// list of all workers on Featureland
        /// </summary>
        private List<Worker> FeatureWorkersList { get; set; }

        /// <summary>
        /// list of all workers on Epicland
        /// </summary>
        private List<Worker> EpicWorkersList { get; set; }

        /// <summary>
        /// Worker on Google spot
        /// </summary>
        private Worker GoogleWorker { get; set; }

        /// <summary>
        /// Workers on Job fair spot
        /// </summary>
        private List<Worker> JobFairWorkersList { get; set; }

        /// <summary>
        /// Worker on BigWigs Spot
        /// </summary>
        private Worker BigWigsWorker { get; set; }

        /// <summary>
        /// The pointer is dragging a control if true.
        /// </summary>
        public bool IsDragging { get; set; }

        /// <summary>
        /// The point at which dragging began.
        /// </summary>
        public Point DragPoint { get; set; }

        /// <summary>
        /// Keep track of number of resources in supply for each resource
        /// </summary>
        public int[] ResourceSupply { get; set; }

        /// <summary>
        /// Group resource labels to access via index
        /// </summary>
        public Label[] ResourceLabels { get; set; }

        /// <summary>
        /// Keep track of cards in deck
        /// </summary>
        public Stack<TechnologyCard> TechnologyCardStack { get; set; }

        /// <summary>
        /// Deck of Client cards (should be empty after game is set up for 4 players)
        /// </summary>
        public Stack<ClientCard> ClientCardStack { get; set; }

        /// <summary>
        /// Keep track of cards in each client stack
        /// </summary>
        public Stack<ClientCard>[] ClientCardStacks { get; set; }

        /// <summary>
        /// Toal from last dice roll
        /// </summary>
        public int DiceTotal { get; set; }

        /// <summary>
        /// Whether or not the player is allowed to roll the dice
        /// </summary>
        public bool AllowDiceRoll { get; set; }

        /// <summary>
        /// Number of research tokens in supply
        /// </summary>
        private int ResearchSupply { get; set; }

        /// <summary>
        /// Array of all ClientCards
        /// </summary>
        public ClientCard[] ClientCardMasterArray { get; set; }

        /// <summary>
        /// Array of all Technology cards
        /// </summary>
        public TechnologyCard[] TechnologyCardMasterArray { get; set; }

        /// <summary>
        /// The player whose turn it is.
        /// </summary>
        public Player ActivePlayer { get; set; }

        /// <summary>
        /// Keep track Technology Cards currently in slots
        /// </summary>
        public TechnologyCard[] TechnologyCardSlots {get; set;}

        /// <summary>
        /// Group PictureBoxes for client cards to access via index
        /// </summary>
        public PictureBox[] ClientCardPictureBoxes { get; set; }

        /// <summary>
        /// Group picture boxes for technology cards to access via index
        /// </summary>
        public PictureBox[] TechnologyCardPictureBoxes { get; set; }

        /// <summary>
        /// Keep track of workers on the technology card slots
        /// </summary>
        public Worker[] TechnologyCardWorkerArray { get; set; }

        /// <summary>
        /// keep track of workers on the client card slots
        /// </summary>
        public Worker[] ClientCardWorkerArray { get; set; }
        
        /// <summary>
        /// Keep track of Types of resource bonuses
        /// </summary>
        public int[] ResourceTypes { get; set; }

        public Control AssignedControl { get; set; }

        public List<Label> ResourceTypeLabels { get; set; }
        #endregion
        //-----------------------------------------------------------------------Methods------------------------------------------------------------------------------------
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainForm(int numPlayers)
        {
            if (numPlayers > 4) { NumPlayers = 4; }
            else if (numPlayers < 2) { NumPlayers = 2; }
            else { NumPlayers = numPlayers; }
            InitializeComponent();
            InitializeCustomComponent();

        }

        /// <summary>
        /// Declare and Initialize Controls that can be customized by the developer
        /// </summary>
        private void InitializeCustomComponent()
        {
            DiceTotal = 0;
            AllowDiceRoll = true;

            ResourceTypes = new int[] { 0, 0, 0, 0 }; //set all resource types to none
            ResourceTypeLabels = new List<Label> { TaskTypeLabel, StoryTypeLabel, FeatureTypeLabel, EpicTypeLabel };
            CurrentPhase = -1;
            AllowDragWorker = false;

            //
            //Players
            //
            Players = new Player[4];
            Random r = new Random();
            for (int i = 1; i <= NumPlayers; i++)
            {
                Players[i - 1] = new Player("Player " + i, System.Drawing.Color.FromArgb(255, r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
                Players[i - 1].PlayerNumber = i;
                Players[i - 1].Money = 12;
            }
            SetActivePlayer(1);
            StartPlayer = ActivePlayer;

            PlayerAreasUsed = new List<List<Control>>();
            for (int i = 0; i < 4; i++)
            {
                PlayerAreasUsed.Add(new List<Control>());
            }

            // 
            // Player1PointProgressBar
            // 
            Player1PointProgressBar.ForeColor = Players[0].Color;
            Player1PointProgressBar.Location = new System.Drawing.Point(22, 7);
            Player1PointProgressBar.Name = "progressBar1";
            Player1PointProgressBar.Size = new System.Drawing.Size(700, 9);
            Player1PointProgressBar.TabIndex = 18;
            Player1PointProgressBar.MouseHover += ProgressBar1_MouseHover;
            this.GameBoardPanel.Controls.Add(Player1PointProgressBar);

            // 
            // Player2PointProgressBar
            // 
            Player2PointProgressBar.ForeColor = Players[1].Color;
            Player2PointProgressBar.Location = new System.Drawing.Point(22, 16);
            Player2PointProgressBar.Name = "progressBar1";
            Player2PointProgressBar.Size = new System.Drawing.Size(700, 9);
            Player2PointProgressBar.TabIndex = 18;
            Player2PointProgressBar.MouseHover += ProgressBar2_MouseHover;
            this.GameBoardPanel.Controls.Add(Player2PointProgressBar);

            // 
            // Player3PointProgressBar
            // 
            
            Player3PointProgressBar.Location = new System.Drawing.Point(22, 25);
            Player3PointProgressBar.Name = "progressBar1";
            Player3PointProgressBar.Size = new System.Drawing.Size(700, 9);
            Player3PointProgressBar.TabIndex = 18;
            Player3PointProgressBar.MouseHover += ProgressBar3_MouseHover;
            this.GameBoardPanel.Controls.Add(Player3PointProgressBar);
            if (NumPlayers < 3) { Player3PointProgressBar.Visible = false; }
            else { Player3PointProgressBar.ForeColor = Players[2].Color; }
            // 
            // Player4PointProgressBar
            // 
            Player4PointProgressBar.ForeColor = System.Drawing.Color.Blue;
            Player4PointProgressBar.Location = new System.Drawing.Point(22, 34);
            Player4PointProgressBar.Name = "progressBar1";
            Player4PointProgressBar.Size = new System.Drawing.Size(700, 9);
            Player4PointProgressBar.TabIndex = 18;
            Player4PointProgressBar.MouseHover += ProgressBar4_MouseHover;
            this.GameBoardPanel.Controls.Add(Player4PointProgressBar);
            if (NumPlayers < 4) { Player4PointProgressBar.Visible = false; }
            else { Player4PointProgressBar.ForeColor = Players[3].Color; }



            //
            //WorkersList(s)
            //
            WorkersList = new List<Worker>();
            ContractOutWorkersList = new List<Worker>();
            TaskWorkersList = new List<Worker>();
            StoryWorkersList = new List<Worker>();
            FeatureWorkersList = new List<Worker>();
            EpicWorkersList = new List<Worker>();
            JobFairWorkersList = new List<Worker>();
            GoogleWorker = null;
            BigWigsWorker = null;

            Point location;
            //
            //FrontEndDeveloper Tokens
            //
            FrontEndDeveloperSupplyList = new List<Worker>();
            for (int i = 0; i < 12; i++)
            {
                FrontEndDeveloperSupplyList.Add(new FrontEndDeveloper());
                location = new Point(this.CenterPanel.Location.X + FrontEndDeveloperSupplyPictureBox.Location.X, this.CenterPanel.Location.Y + FrontEndDeveloperSupplyPictureBox.Location.Y + Y_OFFSET);
                FrontEndDeveloperSupplyList[i].Control.Location = location;
                FrontEndDeveloperSupplyList[i].Control.Name = "FrontEndDeveloperPictureBox" + (i + 1);
                this.Controls.Add(FrontEndDeveloperSupplyList[i].Control);
                FrontEndDeveloperSupplyList[i].Control.BringToFront();
                FrontEndDeveloperSupplyLabel.Text = FrontEndDeveloperSupplyList.Count.ToString();
            }
            foreach (Worker w in FrontEndDeveloperSupplyList)
            {
                WorkersList.Add(w);
            }

            foreach (Worker w in FrontEndDeveloperSupplyList)
            {
                w.Control.MouseDown += new MouseEventHandler(GamePiecePictureBox_MouseDown);
                w.Control.MouseMove += new MouseEventHandler(GamePiecePictureBox_MouseMove);
                w.Control.MouseUp += new MouseEventHandler(GamePiecePictureBox_MouseUp);
                w.Control.MouseHover += new System.EventHandler(FrontEndDeveloper_MouseHover);

            }

            if (Players[0] != null)
            {
                location = new Point(this.Player1Panel.Location.X + Player1FrontEndDeveloperHomePictureBox.Location.X, this.Player1Panel.Location.Y + Player1FrontEndDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                FrontEndDeveloperSupplyList[0].Control.Location = location;
                FrontEndDeveloperSupplyList[0].Owner = Players[0];
                Players[0].WorkerList.Add(FrontEndDeveloperSupplyList[0]);
                Players[0].NumFrontEndDevelopersOnHome++;
                Player1FrontEndDevelopersLabel.Text = "1";
                FrontEndDeveloperSupplyList[0] = null;
            }
            if (Players[1] != null)
            {
                location = new Point(this.Player2Panel.Location.X + Player2FrontEndDeveloperHomePictureBox.Location.X, this.Player2Panel.Location.Y + Player2FrontEndDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                FrontEndDeveloperSupplyList[1].Control.Location = location;
                FrontEndDeveloperSupplyList[1].Owner = Players[1];
                Players[1].WorkerList.Add(FrontEndDeveloperSupplyList[1]);
                Players[1].NumFrontEndDevelopersOnHome++;
                Player2FrontEndDevelopersLabel.Text = "1";
                FrontEndDeveloperSupplyList[1] = null;
            }
            if (Players[2] != null)
            {
                location = new Point(this.Player3Panel.Location.X + Player3FrontEndDeveloperHomePictureBox.Location.X, this.Player3Panel.Location.Y + Player3FrontEndDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                FrontEndDeveloperSupplyList[2].Control.Location = location;
                FrontEndDeveloperSupplyList[2].Owner = Players[2];
                Players[2].WorkerList.Add(FrontEndDeveloperSupplyList[2]);
                Players[2].NumFrontEndDevelopersOnHome++;
                Player3FrontEndDevelopersLabel.Text = "1";
                FrontEndDeveloperSupplyList[2] = null;
            }
            if (Players[3] != null)
            {
                location = new Point(this.Player4Panel.Location.X + Player4FrontEndDeveloperHomePictureBox.Location.X, this.Player4Panel.Location.Y + Player4FrontEndDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                FrontEndDeveloperSupplyList[3].Control.Location = location;
                FrontEndDeveloperSupplyList[3].Owner = Players[3];
                Players[3].WorkerList.Add(FrontEndDeveloperSupplyList[3]);
                Players[3].NumFrontEndDevelopersOnHome++;
                Player4FrontEndDevelopersLabel.Text = "1";
                FrontEndDeveloperSupplyList[3] = null;
            }
            FrontEndDeveloperSupplyList.RemoveAll(item => item == null);
            FrontEndDeveloperSupplyLabel.Text = FrontEndDeveloperSupplyList.Count.ToString();

            //
            //BackEndDeveloper Tokens
            //
            BackEndDeveloperSupplyList = new List<Worker>();
            for (int i = 0; i < 12; i++)
            {
                BackEndDeveloperSupplyList.Add(new BackEndDeveloper());
                location = new Point(this.CenterPanel.Location.X + BackEndDeveloperSupplyPictureBox.Location.X, this.CenterPanel.Location.Y + BackEndDeveloperSupplyPictureBox.Location.Y + Y_OFFSET);
                BackEndDeveloperSupplyList[i].Control.Location = location;
                BackEndDeveloperSupplyList[i].Control.Name = "BackEndDeveloperPictureBox" + (i + 1);
                this.Controls.Add(BackEndDeveloperSupplyList[i].Control);
                BackEndDeveloperSupplyList[i].Control.BringToFront();
                BackEndDeveloperSupplyLabel.Text = BackEndDeveloperSupplyList.Count.ToString();
            }
            foreach (Worker w in BackEndDeveloperSupplyList)
            {
                WorkersList.Add(w);
            }

            foreach (Worker w in BackEndDeveloperSupplyList)
            {
                w.Control.MouseDown += new MouseEventHandler(GamePiecePictureBox_MouseDown);
                w.Control.MouseMove += new MouseEventHandler(GamePiecePictureBox_MouseMove);
                w.Control.MouseUp += new MouseEventHandler(GamePiecePictureBox_MouseUp);
                w.Control.MouseHover += new System.EventHandler(BackEndDeveloper_MouseHover);
            }

            if (Players[0] != null)
            {
                location = new Point(this.Player1Panel.Location.X + Player1BackEndDeveloperHomePictureBox.Location.X, this.Player1Panel.Location.Y + Player1BackEndDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                BackEndDeveloperSupplyList[0].Control.Location = location;
                BackEndDeveloperSupplyList[0].Owner = Players[0];
                Players[0].WorkerList.Add(BackEndDeveloperSupplyList[0]);
                Players[0].NumBackEndDevelopersOnHome++;
                Player1BackEndDevelopersLabel.Text = "1";
                BackEndDeveloperSupplyList[0] = null;
            }
            if (Players[1] != null)
            {
                location = new Point(this.Player2Panel.Location.X + Player2BackEndDeveloperHomePictureBox.Location.X, this.Player2Panel.Location.Y + Player2BackEndDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                BackEndDeveloperSupplyList[1].Control.Location = location;
                BackEndDeveloperSupplyList[1].Owner = Players[1];
                Players[1].WorkerList.Add(BackEndDeveloperSupplyList[1]);
                Players[1].NumBackEndDevelopersOnHome++;
                Player2BackEndDevelopersLabel.Text = "1";
                BackEndDeveloperSupplyList[1] = null;
            }
            if (Players[2] != null)
            {
                location = new Point(this.Player3Panel.Location.X + Player3BackEndDeveloperHomePictureBox.Location.X, this.Player3Panel.Location.Y + Player3BackEndDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                BackEndDeveloperSupplyList[2].Control.Location = location;
                BackEndDeveloperSupplyList[2].Owner = Players[2];
                Players[2].WorkerList.Add(BackEndDeveloperSupplyList[2]);
                Players[2].NumBackEndDevelopersOnHome++;
                Player3BackEndDevelopersLabel.Text = "1";
                BackEndDeveloperSupplyList[2] = null;
            }
            if (Players[3] != null)
            {
                location = new Point(this.Player4Panel.Location.X + Player4BackEndDeveloperHomePictureBox.Location.X, this.Player4Panel.Location.Y + Player4BackEndDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                BackEndDeveloperSupplyList[3].Control.Location = location;
                BackEndDeveloperSupplyList[3].Owner = Players[3];
                Players[3].WorkerList.Add(BackEndDeveloperSupplyList[3]);
                Players[3].NumBackEndDevelopersOnHome++;
                Player4BackEndDevelopersLabel.Text = "1";
                BackEndDeveloperSupplyList[3] = null;
            }
            BackEndDeveloperSupplyList.RemoveAll(item => item == null);
            BackEndDeveloperSupplyLabel.Text = BackEndDeveloperSupplyList.Count.ToString();


            //
            //FullStackDeveloper Tokens
            //
            FullStackDeveloperSupplyList = new List<Worker>();
            for (int i = 0; i < 12; i++)
            {
                FullStackDeveloperSupplyList.Add(new FullStackDeveloper());
                location = new Point(this.CenterPanel.Location.X + FullStackDeveloperSupplyPictureBox.Location.X, this.CenterPanel.Location.Y + FullStackDeveloperSupplyPictureBox.Location.Y + Y_OFFSET);
                FullStackDeveloperSupplyList[i].Control.Location = location;
                FullStackDeveloperSupplyList[i].Control.Name = "FullStackDeveloperPictureBox" + (i + 1);
                this.Controls.Add(FullStackDeveloperSupplyList[i].Control);
                FullStackDeveloperSupplyList[i].Control.BringToFront();
                FullStackDeveloperSupplyLabel.Text = FullStackDeveloperSupplyList.Count.ToString();
            }
            foreach (Worker w in FullStackDeveloperSupplyList)
            {
                WorkersList.Add(w);
            }

            foreach (Worker w in FullStackDeveloperSupplyList)
            {
                w.Control.MouseDown += new MouseEventHandler(GamePiecePictureBox_MouseDown);
                w.Control.MouseMove += new MouseEventHandler(GamePiecePictureBox_MouseMove);
                w.Control.MouseUp += new MouseEventHandler(GamePiecePictureBox_MouseUp);
                w.Control.MouseHover += new System.EventHandler(FullStackDeveloper_MouseHover);
            }

            if (Players[0] != null)
            {
                location = new Point(this.Player1Panel.Location.X + Player1FullStackDeveloperHomePictureBox.Location.X, this.Player1Panel.Location.Y + Player1FullStackDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                FullStackDeveloperSupplyList[0].Control.Location = location;
                FullStackDeveloperSupplyList[0].Owner = Players[0];
                Players[0].WorkerList.Add(FullStackDeveloperSupplyList[0]);
                Players[0].NumFullStackDevelopersOnHome++;
                Player1FullStackDevelopersLabel.Text = "1";
                FullStackDeveloperSupplyList[0] = null;
            }
            if (Players[1] != null)
            {
                location = new Point(this.Player2Panel.Location.X + Player2FullStackDeveloperHomePictureBox.Location.X, this.Player2Panel.Location.Y + Player2FullStackDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                FullStackDeveloperSupplyList[1].Control.Location = location;
                FullStackDeveloperSupplyList[1].Owner = Players[1];
                Players[1].WorkerList.Add(FullStackDeveloperSupplyList[1]);
                Players[1].NumFullStackDevelopersOnHome++;
                Player2FullStackDevelopersLabel.Text = "1";
                FullStackDeveloperSupplyList[1] = null;
            }
            if (Players[2] != null)
            {
                location = new Point(this.Player3Panel.Location.X + Player3FullStackDeveloperHomePictureBox.Location.X, this.Player3Panel.Location.Y + Player3FullStackDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                FullStackDeveloperSupplyList[2].Control.Location = location;
                FullStackDeveloperSupplyList[2].Owner = Players[2];
                Players[2].WorkerList.Add(FullStackDeveloperSupplyList[2]);
                Players[2].NumFullStackDevelopersOnHome++;
                Player3FullStackDevelopersLabel.Text = "1";
                FullStackDeveloperSupplyList[2] = null;
            }
            if (Players[3] != null)
            {
                location = new Point(this.Player4Panel.Location.X + Player4FullStackDeveloperHomePictureBox.Location.X, this.Player4Panel.Location.Y + Player4FullStackDeveloperHomePictureBox.Location.Y + Y_OFFSET);
                FullStackDeveloperSupplyList[3].Control.Location = location;
                FullStackDeveloperSupplyList[3].Owner = Players[3];
                Players[3].WorkerList.Add(FullStackDeveloperSupplyList[3]);
                Players[3].NumFullStackDevelopersOnHome++;
                Player4FullStackDevelopersLabel.Text = "1";
                FullStackDeveloperSupplyList[3] = null;
            }
            FullStackDeveloperSupplyList.RemoveAll(item => item == null);
            FullStackDeveloperSupplyLabel.Text = FullStackDeveloperSupplyList.Count.ToString();

            //
            //ProductOwner Tokens
            //
            ProductOwnerSupplyList = new List<Worker>();
            
            for (int i = 0; i < 4; i++)
            {
                ProductOwnerSupplyList.Add(new ProductOwner());
                location = new Point(this.CenterPanel.Location.X + ProductOwnerSupplyPictureBox.Location.X, this.CenterPanel.Location.Y + ProductOwnerSupplyPictureBox.Location.Y + Y_OFFSET);
                ProductOwnerSupplyList[i].Control.Location = location;
                ProductOwnerSupplyList[i].Control.Name = "ProductOwnerPictureBox" + (i + 1);
                this.Controls.Add(ProductOwnerSupplyList[i].Control);
                ProductOwnerSupplyList[i].Control.BringToFront();
                ProductOwnerSupplyLabel.Text = ProductOwnerSupplyList.Count.ToString();
            }
            foreach (Worker w in ProductOwnerSupplyList)
            {
                WorkersList.Add(w);
            }

            foreach (Worker w in ProductOwnerSupplyList)
            {
                w.Control.MouseDown += new MouseEventHandler(GamePiecePictureBox_MouseDown);
                w.Control.MouseMove += new MouseEventHandler(GamePiecePictureBox_MouseMove);
                w.Control.MouseUp += new MouseEventHandler(GamePiecePictureBox_MouseUp);
                w.Control.MouseHover += new System.EventHandler(ProductOwner_MouseHover);
            }

            if (Players[0] != null)
            {
                location = new Point(this.Player1Panel.Location.X + Player1ProductOwnerHomePictureBox.Location.X, this.Player1Panel.Location.Y + Player1ProductOwnerHomePictureBox.Location.Y + Y_OFFSET);
                ProductOwnerSupplyList[0].Control.Location = location;
                ProductOwnerSupplyList[0].Owner = Players[0];
                Players[0].WorkerList.Add(ProductOwnerSupplyList[0]);
                Players[0].NumProductOwnersOnHome++;
                Player1ProductOwnersLabel.Text = "1";
                ProductOwnerSupplyList[0] = null;
            }
            if (Players[1] != null)
            {
                location = new Point(this.Player2Panel.Location.X + Player2ProductOwnerHomePictureBox.Location.X, this.Player2Panel.Location.Y + Player2ProductOwnerHomePictureBox.Location.Y + Y_OFFSET);
                ProductOwnerSupplyList[1].Control.Location = location;
                ProductOwnerSupplyList[1].Owner = Players[1];
                Players[1].WorkerList.Add(ProductOwnerSupplyList[1]);
                Players[1].NumProductOwnersOnHome++;
                Player2ProductOwnersLabel.Text = "1";
                ProductOwnerSupplyList[1] = null;
            }
            if (Players[2] != null)
            {
                location = new Point(this.Player3Panel.Location.X + Player3ProductOwnerHomePictureBox.Location.X, this.Player3Panel.Location.Y + Player3ProductOwnerHomePictureBox.Location.Y + Y_OFFSET);
                ProductOwnerSupplyList[2].Control.Location = location;
                ProductOwnerSupplyList[2].Owner = Players[2];
                Players[2].WorkerList.Add(ProductOwnerSupplyList[2]);
                Players[2].NumProductOwnersOnHome++;
                Player3ProductOwnersLabel.Text = "1";
                ProductOwnerSupplyList[2] = null;
            }
            if (Players[3] != null)
            {
                location = new Point(this.Player4Panel.Location.X + Player4ProductOwnerHomePictureBox.Location.X, this.Player4Panel.Location.Y + Player4ProductOwnerHomePictureBox.Location.Y + Y_OFFSET);
                ProductOwnerSupplyList[3].Control.Location = location;
                ProductOwnerSupplyList[3].Owner = Players[3];
                Players[3].WorkerList.Add(ProductOwnerSupplyList[3]);
                Players[3].NumProductOwnersOnHome++;
                Player4ProductOwnersLabel.Text = "1";
                ProductOwnerSupplyList[3] = null;
            }
            ProductOwnerSupplyList.RemoveAll(item => item == null);
            ProductOwnerSupplyLabel.Text = ProductOwnerSupplyList.Count.ToString();
            
            



            //
            //ScrumMaster
            //
            ScrumMasterSupplyList = new List<Worker>();
            for (int i = 0; i < 4; i++)
            {
                ScrumMasterSupplyList.Add(new ScrumMaster());
                location = new Point(this.CenterPanel.Location.X + ScrumMasterSupplyPictureBox.Location.X, this.CenterPanel.Location.Y + ScrumMasterSupplyPictureBox.Location.Y + Y_OFFSET);
                ScrumMasterSupplyList[i].Control.Location = location;
                ScrumMasterSupplyList[i].Control.Name = "ScrumMasterPictureBox" + (i + 1);
                this.Controls.Add(ScrumMasterSupplyList[i].Control);
                ScrumMasterSupplyList[i].Control.BringToFront();
                ScrumMasterSupplyLabel.Text = ScrumMasterSupplyList.Count.ToString();
            }
            foreach (Worker w in ScrumMasterSupplyList)
            {
                WorkersList.Add(w);
            }

            foreach (Worker w in ScrumMasterSupplyList)
            {
                w.Control.MouseDown += new MouseEventHandler(GamePiecePictureBox_MouseDown);
                w.Control.MouseMove += new MouseEventHandler(GamePiecePictureBox_MouseMove);
                w.Control.MouseUp += new MouseEventHandler(GamePiecePictureBox_MouseUp);
                w.Control.MouseHover += new System.EventHandler(ScrumMaster_MouseHover);
            }

            if (Players[0] != null)
            {
                location = new Point(this.Player1Panel.Location.X + Player1ScrumMasterHomePictureBox.Location.X, this.Player1Panel.Location.Y + Player1ScrumMasterHomePictureBox.Location.Y + Y_OFFSET);
                ScrumMasterSupplyList[0].Control.Location = location;
                ScrumMasterSupplyList[0].Owner = Players[0];
                Players[0].WorkerList.Add(ScrumMasterSupplyList[0]);
                Players[0].NumScrumMastersOnHome++;
                Player1ScrumMastersLabel.Text = "1";
                ScrumMasterSupplyList[0] = null;
            }
            if (Players[1] != null)
            {
                location = new Point(this.Player2Panel.Location.X + Player2ScrumMasterHomePictureBox.Location.X, this.Player2Panel.Location.Y + Player2ScrumMasterHomePictureBox.Location.Y + Y_OFFSET);
                ScrumMasterSupplyList[1].Control.Location = location;
                ScrumMasterSupplyList[1].Owner = Players[1];
                Players[1].WorkerList.Add(ScrumMasterSupplyList[1]);
                Players[1].NumScrumMastersOnHome++;
                Player2ScrumMastersLabel.Text = "1";
                ScrumMasterSupplyList[1] = null;
            }
            if (Players[2] != null)
            {
                location = new Point(this.Player3Panel.Location.X + Player3ScrumMasterHomePictureBox.Location.X, this.Player3Panel.Location.Y + Player3ScrumMasterHomePictureBox.Location.Y + Y_OFFSET);
                ScrumMasterSupplyList[2].Control.Location = location;
                ScrumMasterSupplyList[2].Owner = Players[2];
                Players[2].WorkerList.Add(ScrumMasterSupplyList[2]);
                Players[2].NumScrumMastersOnHome++;
                Player3ScrumMastersLabel.Text = "1";
                ScrumMasterSupplyList[2] = null;
            }
            if (Players[3] != null)
            {
                location = new Point(this.Player4Panel.Location.X + Player4ScrumMasterHomePictureBox.Location.X, this.Player4Panel.Location.Y + Player4ScrumMasterHomePictureBox.Location.Y + Y_OFFSET);
                ScrumMasterSupplyList[3].Control.Location = location;
                ScrumMasterSupplyList[3].Owner = Players[3];
                Players[3].WorkerList.Add(ScrumMasterSupplyList[3]);
                Players[3].NumScrumMastersOnHome++;
                Player4ScrumMastersLabel.Text = "1";
                ScrumMasterSupplyList[3] = null;
            }
            ScrumMasterSupplyList.RemoveAll(item => item == null);
            ScrumMasterSupplyLabel.Text = ScrumMasterSupplyList.Count.ToString();


            
            
           

            //
            // Resources
            //
            ResourceSupply = new int[] { 20, 16, 12, 10 };
            ResourceLabels = new Label[] { TaskSupplyLabel, StorySupplyLabel, FeatureSupplyLabel, EpicSupplyLabel };
            for (int i = 0; i < 4; i++)
            {
                ResourceLabels[i].Text = ResourceSupply[i].ToString();
            }
            ResearchSupply = 90;

            //
            // Technology Cards
            //
            TechnologyCardStack = new Stack<TechnologyCard>();
            TechnologyCardMasterArray = new TechnologyCard[36];
            TechnologyCardPictureBoxes = new PictureBox[] { TechnologyCard1PictureBox, TechnologyCard2PictureBox, TechnologyCard3PictureBox, TechnologyCard4PictureBox };
            TechnologyCardWorkerArray = new Worker[4];

            TechnologyCardMasterArray[0] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard1)));
            TechnologyCardMasterArray[0].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[0]);
            TechnologyCardMasterArray[0].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[0], 1);

            TechnologyCardMasterArray[1] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard2)));
            TechnologyCardMasterArray[1].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[1]);
            TechnologyCardMasterArray[1].CardPoints = new ClientCardPoints(ref TechnologyCardMasterArray[1], 1);

            TechnologyCardMasterArray[2] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard3)));
            TechnologyCardMasterArray[2].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[2]);
            TechnologyCardMasterArray[2].CardPoints = new ClientCardPoints(ref TechnologyCardMasterArray[2], 2);

            TechnologyCardMasterArray[3] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard4)));
            TechnologyCardMasterArray[3].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[3]);
            TechnologyCardMasterArray[3].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[3], 2);

            TechnologyCardMasterArray[4] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard5)));
            TechnologyCardMasterArray[4].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[4]);
            TechnologyCardMasterArray[4].CardPoints = new ResearchTokenPoints(ref TechnologyCardMasterArray[4], 2);

            TechnologyCardMasterArray[5] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard6)));
            TechnologyCardMasterArray[5].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[5]);
            TechnologyCardMasterArray[5].CardPoints = new BudgetPoints(ref TechnologyCardMasterArray[5], 1);

            TechnologyCardMasterArray[6] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard7)));
            TechnologyCardMasterArray[6].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[6]);
            TechnologyCardMasterArray[6].CardPoints = new BudgetPoints(ref TechnologyCardMasterArray[6], 2);

            TechnologyCardMasterArray[7] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard8)));
            TechnologyCardMasterArray[7].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[7]);
            TechnologyCardMasterArray[7].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[7], 3);

            TechnologyCardMasterArray[8] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard9)));
            TechnologyCardMasterArray[8].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[8]);
            TechnologyCardMasterArray[8].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[8], 4);

            TechnologyCardMasterArray[9] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard10)));
            TechnologyCardMasterArray[9].CardEvent = new DiceEvent(ref TechnologyCardMasterArray[9]);
            TechnologyCardMasterArray[9].CardPoints = new ResearchTokenPoints(ref TechnologyCardMasterArray[9], 1);

            TechnologyCardMasterArray[10] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard11)));
            TechnologyCardMasterArray[10].CardEvent = new MoneyEvent(ref TechnologyCardMasterArray[10], 7);
            TechnologyCardMasterArray[10].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[10], 1);

            TechnologyCardMasterArray[11] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard12)));
            TechnologyCardMasterArray[11].CardEvent = new MoneyEvent(ref TechnologyCardMasterArray[11], 2);
            TechnologyCardMasterArray[11].CardPoints = new ClientCardPoints(ref TechnologyCardMasterArray[11], 2);

            TechnologyCardMasterArray[12] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard13)));
            TechnologyCardMasterArray[12].CardEvent = new MoneyEvent(ref TechnologyCardMasterArray[12], 4);
            TechnologyCardMasterArray[12].CardPoints = new ClientCardPoints(ref TechnologyCardMasterArray[12], 1);

            TechnologyCardMasterArray[13] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard14)));
            TechnologyCardMasterArray[13].CardEvent = new MoneyEvent(ref TechnologyCardMasterArray[13], 5);
            TechnologyCardMasterArray[13].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[13], 5);

            TechnologyCardMasterArray[14] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard15)));
            TechnologyCardMasterArray[14].CardEvent = new MoneyEvent(ref TechnologyCardMasterArray[14], 3);
            TechnologyCardMasterArray[14].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[14], 6);

            TechnologyCardMasterArray[15] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard16)));
            TechnologyCardMasterArray[15].CardEvent = new MoneyEvent(ref TechnologyCardMasterArray[15], 1);
            TechnologyCardMasterArray[15].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[15], 6);

            TechnologyCardMasterArray[16] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard17)));
            TechnologyCardMasterArray[16].CardEvent = new MoneyEvent(ref TechnologyCardMasterArray[16], 3);
            TechnologyCardMasterArray[16].CardPoints = new BudgetPoints(ref TechnologyCardMasterArray[16], 2);

            TechnologyCardMasterArray[17] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard18)));
            TechnologyCardMasterArray[17].CardEvent = new ResourceEvent(ref TechnologyCardMasterArray[17],0,0,1,0);
            TechnologyCardMasterArray[17].CardPoints = new BudgetPoints(ref TechnologyCardMasterArray[17], 1);

            TechnologyCardMasterArray[18] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard19)));
            TechnologyCardMasterArray[18].CardEvent = new ResourceEvent(ref TechnologyCardMasterArray[18],0,0,2,0);
            TechnologyCardMasterArray[18].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[18], 4);

            TechnologyCardMasterArray[19] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard20)));
            TechnologyCardMasterArray[19].CardEvent = new ResourceEvent(ref TechnologyCardMasterArray[19],0,0,1,0);
            TechnologyCardMasterArray[19].CardPoints = new WorkerPoints(ref TechnologyCardMasterArray[19], 1);

            TechnologyCardMasterArray[20] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard21)));
            TechnologyCardMasterArray[20].CardEvent = new ResourceEvent(ref TechnologyCardMasterArray[20],0,0,0,1);
            TechnologyCardMasterArray[20].CardPoints = new WorkerPoints(ref TechnologyCardMasterArray[20], 1);

            TechnologyCardMasterArray[21] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard22)));
            TechnologyCardMasterArray[21].CardEvent = new ResourceEvent(ref TechnologyCardMasterArray[21],0,1,0,0);
            TechnologyCardMasterArray[21].CardPoints = new WorkerPoints(ref TechnologyCardMasterArray[21], 2);

            TechnologyCardMasterArray[22] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard23)));
            TechnologyCardMasterArray[22].CardEvent = new DiceResourceEvent(ref TechnologyCardMasterArray[22], 3);
            TechnologyCardMasterArray[22].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[22], 7);

            TechnologyCardMasterArray[23] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard24)));
            TechnologyCardMasterArray[23].CardEvent = new DiceResourceEvent(ref TechnologyCardMasterArray[23], 0);
            TechnologyCardMasterArray[23].CardPoints = new WorkerPoints(ref TechnologyCardMasterArray[23], 2);

            TechnologyCardMasterArray[24] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard25)));
            TechnologyCardMasterArray[24].CardEvent = new DiceResourceEvent(ref TechnologyCardMasterArray[24], 2);
            TechnologyCardMasterArray[24].CardPoints = new WorkerPoints(ref TechnologyCardMasterArray[24], 1);

            TechnologyCardMasterArray[25] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard26)));
            TechnologyCardMasterArray[25].CardEvent = new PointsEvent(ref TechnologyCardMasterArray[25],3);
            TechnologyCardMasterArray[25].CardPoints = new ClientCardPoints(ref TechnologyCardMasterArray[25], 3);

            TechnologyCardMasterArray[26] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard27)));
            TechnologyCardMasterArray[26].CardEvent = new PointsEvent(ref TechnologyCardMasterArray[26],3);
            TechnologyCardMasterArray[26].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[26], 8);

            TechnologyCardMasterArray[27] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard28)));
            TechnologyCardMasterArray[27].CardEvent = new PointsEvent(ref TechnologyCardMasterArray[27],3);
            TechnologyCardMasterArray[27].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[27], 8);

            TechnologyCardMasterArray[28] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard29)));
            TechnologyCardMasterArray[28].CardEvent = new ResearchEvent(ref TechnologyCardMasterArray[28]);
            TechnologyCardMasterArray[28].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[28], 7);

            TechnologyCardMasterArray[29] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard30)));
            TechnologyCardMasterArray[29].CardEvent = new BudgetEvent(ref TechnologyCardMasterArray[29]);
            TechnologyCardMasterArray[29].CardPoints = new BudgetPoints(ref TechnologyCardMasterArray[29], 1);

            TechnologyCardMasterArray[30] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard31)));
            TechnologyCardMasterArray[30].CardEvent = new BudgetEvent(ref TechnologyCardMasterArray[30]);
            TechnologyCardMasterArray[30].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[30], 3);

            TechnologyCardMasterArray[31] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard32)));
            TechnologyCardMasterArray[31].CardEvent = new DrawCardEvent(ref TechnologyCardMasterArray[31]);
            TechnologyCardMasterArray[31].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[31], 2);

            TechnologyCardMasterArray[32] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard33)));
            TechnologyCardMasterArray[32].CardEvent = new TempResearchEvent(ref TechnologyCardMasterArray[32],4);
            TechnologyCardMasterArray[32].CardPoints = new ResearchTokenPoints(ref TechnologyCardMasterArray[32], 1);

            TechnologyCardMasterArray[33] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard34)));
            TechnologyCardMasterArray[33].CardEvent = new TempResearchEvent(ref TechnologyCardMasterArray[33],3);
            TechnologyCardMasterArray[33].CardPoints = new ResearchTokenPoints(ref TechnologyCardMasterArray[33], 1);

            TechnologyCardMasterArray[34] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard35)));
            TechnologyCardMasterArray[34].CardEvent = new TempResearchEvent(ref TechnologyCardMasterArray[34],2);
            TechnologyCardMasterArray[34].CardPoints = new ResearchTokenPoints(ref TechnologyCardMasterArray[34], 2);

            TechnologyCardMasterArray[35] = new TechnologyCard(((System.Drawing.Image)(ScrumGame.Properties.Resources.TechnologyCard36)));
            TechnologyCardMasterArray[35].CardEvent = new WildResourceEvent(ref TechnologyCardMasterArray[35]);
            TechnologyCardMasterArray[35].CardPoints = new GreenCardPoints(ref TechnologyCardMasterArray[35], 5);

            List<TechnologyCard> RandomBuffer = new List<TechnologyCard>(TechnologyCardMasterArray.ToList());
            Random rand = new Random();
            int index = 0;
            for (int i = 0; i < TechnologyCardMasterArray.Length; i++)
            {
                index = rand.Next(RandomBuffer.Count);
                TechnologyCardStack.Push(RandomBuffer[index]);
                RandomBuffer.RemoveAt(index);
            }
            TechnologyCardSlots = new TechnologyCard[4];
            FillTechnologyCardSlots();

            //
            // Client Cards
            //
            ClientCardMasterArray = new ClientCard[28];
            ClientCardPictureBoxes = new PictureBox[] { Client1PictureBox, Client2PictureBox, Client3PictureBox, Client4PictureBox };
            ClientCardWorkerArray = new Worker[4];
            ClientCardStack = new Stack<ClientCard>();
            ClientCardStacks = new Stack<ClientCard>[] { new Stack<ClientCard>(), new Stack<ClientCard>(), new Stack<ClientCard>(), new Stack<ClientCard>() };

            ClientCardMasterArray[0] = new NormalClientCard(0, 0, 1, 10);
            ClientCardMasterArray[0].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard1));

            ClientCardMasterArray[1] = new NormalClientCard(0, 0, 2, 11);
            ClientCardMasterArray[1].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard2));

            ClientCardMasterArray[2] = new NormalClientCard(0, 1, 1, 11);
            ClientCardMasterArray[2].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard3));

            ClientCardMasterArray[3] = new NormalClientCard(0, 0, 3, 12);
            ClientCardMasterArray[3].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard4));

            ClientCardMasterArray[4] = new NormalClientCard(0, 2, 2, 13);
            ClientCardMasterArray[4].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard5));

            ClientCardMasterArray[5] = new NormalClientCard(1, 1, 2, 13);
            ClientCardMasterArray[5].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard6));

            ClientCardMasterArray[6] = new NormalClientCard(1, 1, 3, 14);
            ClientCardMasterArray[6].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard7));

            ClientCardMasterArray[7] = new NormalClientCard(1, 2, 2, 14);
            ClientCardMasterArray[7].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard8));

            ClientCardMasterArray[8] = new NormalClientCard(2, 2, 3, 16);
            ClientCardMasterArray[8].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard9));

            ClientCardMasterArray[9] = new NormalClientCard(0, 1, 2, 12);
            ClientCardMasterArray[9].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard10));

            ClientCardMasterArray[10] = new NormalClientCard(0, 1, 2, 12);
            ClientCardMasterArray[10].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard11));

            ClientCardMasterArray[11] = new NormalClientCard(0, 1, 3, 13);
            ClientCardMasterArray[11].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard12));

            ClientCardMasterArray[12] = new NormalClientCard(0, 1, 3, 13);
            ClientCardMasterArray[12].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard13));

            ClientCardMasterArray[13] = new NormalClientCard(0, 2, 3, 14);
            ClientCardMasterArray[13].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard14));

            ClientCardMasterArray[14] = new NormalClientCard(0, 2, 3, 14);
            ClientCardMasterArray[14].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard15));

            ClientCardMasterArray[15] = new NormalClientCard(1, 2, 3, 15);
            ClientCardMasterArray[15].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard16));

            ClientCardMasterArray[16] = new NormalClientCard(1, 2, 3, 15);
            ClientCardMasterArray[16].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard17));

            ClientCardMasterArray[17] = new VarietyClientCard(4, 1);
            ClientCardMasterArray[17].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard18));

            ClientCardMasterArray[18] = new VarietyClientCard(4, 2);
            ClientCardMasterArray[18].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard19));

            ClientCardMasterArray[19] = new VarietyClientCard(4, 3);
            ClientCardMasterArray[19].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard20));

            ClientCardMasterArray[20] = new VarietyClientCard(4, 4);
            ClientCardMasterArray[20].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard21));

            ClientCardMasterArray[21] = new VarietyClientCard(5, 1);
            ClientCardMasterArray[21].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard22));

            ClientCardMasterArray[22] = new VarietyClientCard(5, 2);
            ClientCardMasterArray[22].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard23));

            ClientCardMasterArray[23] = new VarietyClientCard(5, 3);
            ClientCardMasterArray[23].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard24));

            ClientCardMasterArray[24] = new VarietyClientCard(5, 4);
            ClientCardMasterArray[24].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard25));

            ClientCardMasterArray[25] = new WildSevenClientCard();
            ClientCardMasterArray[25].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard26));

            ClientCardMasterArray[26] = new WildSevenClientCard();
            ClientCardMasterArray[26].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard27));

            ClientCardMasterArray[27] = new WildSevenClientCard();
            ClientCardMasterArray[27].Image = ((System.Drawing.Image)(ScrumGame.Properties.Resources.ClientCard28));

            List<ClientCard> ClientRandomBuffer = new List<ClientCard>(ClientCardMasterArray.ToList());
            index = 0;
            for (int i = 0; i < ClientCardMasterArray.Length; i++)
            {
                index = rand.Next(ClientRandomBuffer.Count);
                ClientCardStack.Push(ClientRandomBuffer[index]);
                ClientRandomBuffer.RemoveAt(index);
            }
            for (int i = 0; i < NumPlayers; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    ClientCardStacks[i].Push(ClientCardStack.Pop());
                }
            }
            Client1PictureBox.Image = ClientCardStacks[0].Peek().Image;
            Client2PictureBox.Image = ClientCardStacks[1].Peek().Image;
            if (NumPlayers > 2) { Client3PictureBox.Image = ClientCardStacks[2].Peek().Image; }
            if (NumPlayers > 3) { Client4PictureBox.Image = ClientCardStacks[3].Peek().Image; }

            UpdateLabels();
            UpdateColors();
            
        }
        /// <summary>
        /// Load empty technology card slots with the next technology card on the stack
        /// </summary>
        public void FillTechnologyCardSlots()
        {
            if (TechnologyCardStack.Count > 0)
            {
                if (TechnologyCardSlots[0] == null)
                {
                    TechnologyCardSlots[0] = TechnologyCardStack.Pop();
                    TechnologyCard1PictureBox.Image = TechnologyCardSlots[0].Image;
                }
                if (TechnologyCardSlots[1] == null)
                {
                    TechnologyCardSlots[1] = TechnologyCardStack.Pop();
                    TechnologyCard2PictureBox.Image = TechnologyCardSlots[1].Image;
                }
                if (TechnologyCardSlots[2] == null)
                {
                    TechnologyCardSlots[2] = TechnologyCardStack.Pop();
                    TechnologyCard3PictureBox.Image = TechnologyCardSlots[2].Image;
                }
                if (TechnologyCardSlots[3] == null)
                {
                    TechnologyCardSlots[3] = TechnologyCardStack.Pop();
                    TechnologyCard4PictureBox.Image = TechnologyCardSlots[3].Image;
                }
            }
            else
            {
                TechnologyCardSupplyPictureBox.Image = null;
                for (int i = 0; i < 4; i++)
                {
                    if (TechnologyCardSlots[i] == null)
                    {
                        TechnologyCardPictureBoxes[i].Image = null;
                    }
                }
            }
            
            

        }
        /// <summary>
        /// Update text of labels and progress bars with correct values
        /// </summary>
        public void UpdateLabels()
        {
            if (Players[0] != null)
            {
                Player1MoneyAmountLabel.Text = Players[0].Money.ToString();
                Player1ScoreAmountLabel.Text = Players[0].Points.ToString();
                Player1BudgetAmountLabel.Text = Players[0].Budget.ToString();
                Player1TaskAmountLabel.Text = Players[0].Resources[0].ToString();
                Player1StoryAmountLabel.Text = Players[0].Resources[1].ToString();
                Player1FeatureAmountLabel.Text = Players[0].Resources[2].ToString();
                Player1EpicAmountLabel.Text = Players[0].Resources[3].ToString();
                Player1Research1PictureBox.Image = Players[0].CurrentResearchImages[0];
                Player1Research2PictureBox.Image = Players[0].CurrentResearchImages[1];
                Player1Research3PictureBox.Image = Players[0].CurrentResearchImages[2];
                if (Players[0].Points > 100) { Player1PointProgressBar.Value = 100; } else { Player1PointProgressBar.Value = Players[0].Points; }
                Player1BudgetPictureBox.Location = new System.Drawing.Point(24, 501 - (Players[0].Budget * 40));
                Player1BudgetPictureBox.Height = 20 + (40 * Players[0].Budget);

            }
            if (Players[1] != null)
            {
                Player2MoneyAmountLabel.Text = Players[1].Money.ToString();
                Player2ScoreAmountLabel.Text = Players[1].Points.ToString();
                Player2BudgetAmountLabel.Text = Players[1].Budget.ToString();
                Player2TaskAmountLabel.Text = Players[1].Resources[0].ToString();
                Player2StoryAmountLabel.Text = Players[1].Resources[1].ToString();
                Player2FeatureAmountLabel.Text = Players[1].Resources[2].ToString();
                Player2EpicAmountLabel.Text = Players[1].Resources[3].ToString();
                Player2Research1PictureBox.Image = Players[1].CurrentResearchImages[0];
                Player2Research2PictureBox.Image = Players[1].CurrentResearchImages[1];
                Player2Research3PictureBox.Image = Players[1].CurrentResearchImages[2];
                if (Players[1].Points > 100) { Player2PointProgressBar.Value = 100; } else { Player2PointProgressBar.Value = Players[1].Points; }
                Player2BudgetPictureBox.Location = new System.Drawing.Point(32, 501 - (Players[1].Budget * 40));
                Player2BudgetPictureBox.Height = 20 + (40 * Players[1].Budget);
            }
            if (Players[2] != null)
            {
                Player3MoneyAmountLabel.Text = Players[2].Money.ToString();
                Player3ScoreAmountLabel.Text = Players[2].Points.ToString();
                Player3BudgetAmountLabel.Text = Players[2].Budget.ToString();
                Player3TaskAmountLabel.Text = Players[2].Resources[0].ToString();
                Player3StoryAmountLabel.Text = Players[2].Resources[1].ToString();
                Player3FeatureAmountLabel.Text = Players[2].Resources[2].ToString();
                Player3EpicAmountLabel.Text = Players[2].Resources[3].ToString();
                Player3Research1PictureBox.Image = Players[2].CurrentResearchImages[0];
                Player3Research2PictureBox.Image = Players[2].CurrentResearchImages[1];
                Player3Research3PictureBox.Image = Players[2].CurrentResearchImages[2];
                if (Players[2].Points > 100) { Player3PointProgressBar.Value = 100; } else { Player3PointProgressBar.Value = Players[2].Points; }
                Player3BudgetPictureBox.Location = new System.Drawing.Point(47, 501 - (Players[2].Budget * 40));
                Player3BudgetPictureBox.Height = 20 + (40 * Players[2].Budget);
            }
            if (Players[3] != null)
            {
                Player4MoneyAmountLabel.Text = Players[3].Money.ToString();
                Player4ScoreAmountLabel.Text = Players[3].Points.ToString();
                Player4BudgetAmountLabel.Text = Players[3].Budget.ToString();
                Player4TaskAmountLabel.Text = Players[3].Resources[0].ToString();
                Player4StoryAmountLabel.Text = Players[3].Resources[1].ToString();
                Player4FeatureAmountLabel.Text = Players[3].Resources[2].ToString();
                Player4EpicAmountLabel.Text = Players[3].Resources[3].ToString();
                Player4Research1PictureBox.Image = Players[3].CurrentResearchImages[0];
                Player4Research2PictureBox.Image = Players[3].CurrentResearchImages[1];
                Player4Research3PictureBox.Image = Players[3].CurrentResearchImages[2];
                if (Players[3].Points > 100) { Player4PointProgressBar.Value = 100; } else { Player4PointProgressBar.Value = Players[3].Points; }
                Player4BudgetPictureBox.Location = new System.Drawing.Point(55, 501 - (Players[3].Budget * 40));
                Player4BudgetPictureBox.Height = 20 + (40 * Players[3].Budget);
            }
            TaskSupplyLabel.Text = ResourceSupply[0].ToString();
            StorySupplyLabel.Text = ResourceSupply[1].ToString();
            FeatureSupplyLabel.Text = ResourceSupply[2].ToString();
            EpicSupplyLabel.Text = ResourceSupply[3].ToString();
            FrontEndDeveloperSupplyLabel.Text = FrontEndDeveloperSupplyList.Count.ToString();
            BackEndDeveloperSupplyLabel.Text = BackEndDeveloperSupplyList.Count.ToString();
            FullStackDeveloperSupplyLabel.Text = FullStackDeveloperSupplyList.Count.ToString();
            if (NumPlayers < 4) { Player4Panel.Visible = false; }
            if (NumPlayers < 3) { Player3Panel.Visible = false; }
            for (int i = 0; i < 4; i++)
            {
                switch (ResourceTypes[i])
                {
                    case 0:
                        ResourceTypeLabels[i].Text = "";
                        break;
                    case 1:
                        ResourceTypeLabels[i].Text = "FE";
                        break;
                    case 2:
                        ResourceTypeLabels[i].Text = "BE";
                        break;
                    case 3:
                        ResourceTypeLabels[i].Text = "FS";
                        break;
                    default :
                        ResourceTypeLabels[i].Text = "";
                        break;
                }
                
            }
            

        }

        
        /// <summary>
        /// Click event to roll dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRoll_Click(object sender, EventArgs e)
        {
            if (AllowDiceRoll)
            {
                RollDice();
            }
        }
        /// <summary>
        /// Roll the dice according to number in text box and prompt player to use research tokens
        /// </summary>
        public void RollDice()
        {
            Random r = new Random();
            int NumDiceAmount = 0;
            if (!string.IsNullOrWhiteSpace(DiceAmount.Text) && int.TryParse(DiceAmount.Text, out NumDiceAmount))
            {
                DiceTotal = 0;
                TextLabel.Text = "Number Of Dice To Roll";
                if (NumDiceAmount >= 8)
                {

                    for (int i = 0; i < NumDiceAmount - 7; i++)
                    {
                        DiceTotal += r.Next(1, 7);
                        TextLabel.Text = "(Extra dice not shown)";
                    }
                    NumDiceAmount = 7;
                }
                if (NumDiceAmount >= 1)
                {
                    
                    UseResearchForm ResearchForm = new UseResearchForm(ActivePlayer);
                    if (!ResearchForm.IsEmpty)
                    {
                        ResearchForm.ShowDialog();
                    }
                    //Creates a list for the diceImages and adds to list
                    List<PictureBox> diceImageList = new List<PictureBox>();
                    for (int i = 1; i < 7; i++)
                    {
                        diceImageList.Add((PictureBox)Controls.Find("diceImage" + i, true)[0]);
                    }

                    //Creates list of DiceBoxes and adds to list
                    List<PictureBox> DicePictureBoxList = new List<PictureBox>();
                    for (int i = 1; i <= 7; i++)
                    {
                        DicePictureBoxList.Add((PictureBox)Controls.Find("Dice" + i + "PictureBox", true)[0]);
                    }

                    //Creates a list of random numbers

                    List<int> RandomInts = new List<int>();
                    for (int i = 1; i <= 7; i++)
                    {
                        RandomInts.Add(r.Next(0, 6));
                    }

                    //Resets the images in dicepicturebox
                    Dice1PictureBox.Image = null;
                    Dice2PictureBox.Image = null;
                    Dice3PictureBox.Image = null;
                    Dice4PictureBox.Image = null;
                    Dice5PictureBox.Image = null;
                    Dice6PictureBox.Image = null;
                    Dice7PictureBox.Image = null;


                    //Places a random dice image into a dicebox 
                    for (int i = 0; i <= NumDiceAmount - 1; i++)
                    {
                        DicePictureBoxList[i].Image = diceImageList[RandomInts[i]].Image;
                        DiceTotal += RandomInts[i] + 1;
                    }
                }
                else
                {

                    TextLabel.Text = "Try a number greater than 0.";
                    return;
                }
            }
            //Checks if DiceAmount text is empty or not and is an integer number between 1 and 7
            
            
        }
        #region Dragging Events
        /// <summary>
        /// Changes the global IsDragging to true when a user clicks and holds on this control
        /// https://stackoverflow.com/questions/13245083/dragdrop-to-move-a-picture-box-at-run-time   Courtesy of Alan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GamePiecePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (GetWorker((PictureBox)sender).Owner == ActivePlayer && AllowDragWorker)
            {
                IsDragging = true;
                DragPoint = new Point(e.X, e.Y);
                ((PictureBox)sender).BringToFront();
                LeaveAreaEvent(GetWorker((PictureBox)sender));
            }

        }

        /// <summary>
        /// Updates the control's position when mouse is moving if being dragged.
        /// https://stackoverflow.com/questions/13245083/dragdrop-to-move-a-picture-box-at-run-time   Courtesy of Alan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GamePiecePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                int xOffset = ((PictureBox)sender).Location.X + e.X - DragPoint.X;
                int yOffset = ((PictureBox)sender).Location.Y + e.Y - DragPoint.Y;
                if (xOffset >= 0 && (xOffset + ((PictureBox)sender).Size.Width <= this.Size.Width)) //horizontal boundaries
                {
                    if (yOffset >= 0 && (yOffset + ((PictureBox)sender).Size.Height <= this.Size.Height - 30)) //vertical boundaries (offset by 30 pixels to account for title bar)
                    {
                        ((PictureBox)sender).Location = new Point(xOffset, yOffset);
                    }

                }


            }
        }
        /// <summary>
        /// Changes the global IsDragging to false when the mouse is unclicked while dragging
        /// https://stackoverflow.com/questions/13245083/dragdrop-to-move-a-picture-box-at-run-time   Courtest of Alan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GamePiecePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (GetWorker((PictureBox)sender).Owner == ActivePlayer && AllowDragWorker)
            {
                IsDragging = false;
                EnterAreaEvent(GetWorker((PictureBox)sender));
            }
            
            
        }
        #endregion
        #region Worker Enter/Leave Events ------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Searches for the area a gamepiece is in and performs an action based on the area. Use for leaving an area.
        /// </summary>
        /// <param name="input"></param>
        public void LeaveAreaEvent(Worker input)
        {
            if (IsInBoundaries(input.Control, Player1Panel))
            {
                if (input is FrontEndDeveloper && input.Owner == Players[0])
                {
                    
                    Players[0].NumFrontEndDevelopersOnHome--;
                    Player1FrontEndDevelopersLabel.Text = Players[0].NumFrontEndDevelopersOnHome.ToString();
                }
                else if (input is BackEndDeveloper && input.Owner == Players[0])
                {
                    Players[0].NumBackEndDevelopersOnHome--;
                    Player1BackEndDevelopersLabel.Text = Players[0].NumBackEndDevelopersOnHome.ToString();
                }
                else if (input is FullStackDeveloper && input.Owner == Players[0])
                {
                    Players[0].NumFullStackDevelopersOnHome--;
                    Player1FullStackDevelopersLabel.Text = Players[0].NumFullStackDevelopersOnHome.ToString();
                }
                else if (input is ProductOwner && input.Owner == Players[0])
                {
                    Players[0].NumProductOwnersOnHome--;
                    Player1ProductOwnersLabel.Text = Players[0].NumProductOwnersOnHome.ToString();
                }
                else if (input is ScrumMaster && input.Owner == Players[0])
                {
                    Players[0].NumScrumMastersOnHome--;
                    Player1ScrumMastersLabel.Text = Players[0].NumScrumMastersOnHome.ToString();
                }

            }
            else if (IsInBoundaries(input.Control, Player2Panel))
            {
                if (input is FrontEndDeveloper && input.Owner == Players[1])
                {

                    Players[1] .NumFrontEndDevelopersOnHome--;
                    Player2FrontEndDevelopersLabel.Text = Players[1] .NumFrontEndDevelopersOnHome.ToString();
                }
                else if (input is BackEndDeveloper && input.Owner == Players[1])
                {
                    Players[1] .NumBackEndDevelopersOnHome--;
                    Player2BackEndDevelopersLabel.Text = Players[1] .NumBackEndDevelopersOnHome.ToString();
                }
                else if (input is FullStackDeveloper && input.Owner == Players[1])
                {
                    Players[1] .NumFullStackDevelopersOnHome--;
                    Player2FullStackDevelopersLabel.Text = Players[1] .NumFullStackDevelopersOnHome.ToString();
                }
                else if (input is ProductOwner && input.Owner == Players[1])
                {
                    Players[1] .NumProductOwnersOnHome--;
                    Player2ProductOwnersLabel.Text = Players[1] .NumProductOwnersOnHome.ToString();
                }
                else if (input is ScrumMaster && input.Owner == Players[1])
                {
                    Players[1] .NumScrumMastersOnHome--;
                    Player2ScrumMastersLabel.Text = Players[1] .NumScrumMastersOnHome.ToString();
                }

            }
            else if (IsInBoundaries(input.Control, Player3Panel))
            {
                if (input is FrontEndDeveloper && input.Owner == Players[2])
                {

                    Players[2].NumFrontEndDevelopersOnHome--;
                    Player3FrontEndDevelopersLabel.Text = Players[2].NumFrontEndDevelopersOnHome.ToString();
                }
                else if (input is BackEndDeveloper && input.Owner == Players[2])
                {
                    Players[2].NumBackEndDevelopersOnHome--;
                    Player3BackEndDevelopersLabel.Text = Players[2].NumBackEndDevelopersOnHome.ToString();
                }
                else if (input is FullStackDeveloper && input.Owner == Players[2])
                {
                    Players[2].NumFullStackDevelopersOnHome--;
                    Player3FullStackDevelopersLabel.Text = Players[2].NumFullStackDevelopersOnHome.ToString();
                }
                else if (input is ProductOwner && input.Owner == Players[2])
                {
                    Players[2].NumProductOwnersOnHome--;
                    Player3ProductOwnersLabel.Text = Players[2].NumProductOwnersOnHome.ToString();
                }
                else if (input is ScrumMaster && input.Owner == Players[2])
                {
                    Players[2].NumScrumMastersOnHome--;
                    Player3ScrumMastersLabel.Text = Players[2].NumScrumMastersOnHome.ToString();
                }

            }
            else if (IsInBoundaries(input.Control, Player4Panel))
            {
                if (input is FrontEndDeveloper && input.Owner == Players[3])
                {

                    Players[3].NumFrontEndDevelopersOnHome--;
                    Player4FrontEndDevelopersLabel.Text = Players[3].NumFrontEndDevelopersOnHome.ToString();
                }
                else if (input is BackEndDeveloper && input.Owner == Players[3])
                {
                    Players[3].NumBackEndDevelopersOnHome--;
                    Player4BackEndDevelopersLabel.Text = Players[3].NumBackEndDevelopersOnHome.ToString();
                }
                else if (input is FullStackDeveloper && input.Owner == Players[3])
                {
                    Players[3].NumFullStackDevelopersOnHome--;
                    Player4FullStackDevelopersLabel.Text = Players[3].NumFullStackDevelopersOnHome.ToString();
                }
                else if (input is ProductOwner && input.Owner == Players[3])
                {
                    Players[3].NumProductOwnersOnHome--;
                    Player4ProductOwnersLabel.Text = Players[3].NumProductOwnersOnHome.ToString();
                }
                else if (input is ScrumMaster && input.Owner == Players[3])
                {
                    Players[3].NumScrumMastersOnHome--;
                    Player4ScrumMastersLabel.Text = Players[3].NumScrumMastersOnHome.ToString();
                }

            }
            else if (IsInBoundaries(input.Control, ContractOutPanel))
            {
                ContractOutWorkersList.Remove(input);
                UpdateContractOutWorkerLocations();
                if (!ContainsPlayerOwnedWorker(ContractOutWorkersList, input.Owner) && AssignedControl == ContractOutPanel)
                {
                    AssignedControl = null;
                }
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, TasklandPanel))
            {
                TaskWorkersList.Remove(input);
                Point startPoint = GetRawLocation(TasklandPanel);
                startPoint.X += RESOURCE_X_OFFSET;
                startPoint.Y += RESOURCE_Y_OFFSET;
                UpdateResourceWorkerLocations(TaskWorkersList, startPoint);
                if (!ContainsPlayerOwnedWorker(TaskWorkersList, input.Owner) && AssignedControl == TasklandPanel)
                {
                    AssignedControl = null;
                }
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, StorylandPanel))
            {
                StoryWorkersList.Remove(input);
                Point startPoint = GetRawLocation(StorylandPanel);
                startPoint.X += RESOURCE_X_OFFSET;
                startPoint.Y += RESOURCE_Y_OFFSET;
                UpdateResourceWorkerLocations(StoryWorkersList, startPoint);
                if (!ContainsPlayerOwnedWorker(StoryWorkersList, input.Owner) && AssignedControl == StorylandPanel)
                {
                    AssignedControl = null;
                }
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, FeaturelandPanel))
            {
                FeatureWorkersList.Remove(input);
                Point startPoint = GetRawLocation(FeaturelandPanel);
                startPoint.X += RESOURCE_X_OFFSET;
                startPoint.Y += RESOURCE_Y_OFFSET;
                UpdateResourceWorkerLocations(FeatureWorkersList, startPoint);
                if (!ContainsPlayerOwnedWorker(FeatureWorkersList, input.Owner) && AssignedControl == FeaturelandPanel)
                {
                    AssignedControl = null;
                }
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, EpiclandPanel))
            {
                EpicWorkersList.Remove(input);
                Point startPoint = GetRawLocation(EpiclandPanel);
                startPoint.X += RESOURCE_X_OFFSET;
                startPoint.Y += RESOURCE_Y_OFFSET;
                UpdateResourceWorkerLocations(EpicWorkersList, startPoint);
                if (!ContainsPlayerOwnedWorker(EpicWorkersList, input.Owner) && AssignedControl == EpiclandPanel)
                {
                    AssignedControl = null;
                }
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, GooglePanel))
            {
                if (AssignedControl == GooglePanel && input == GoogleWorker)
                {
                    AssignedControl = null;
                }
                GoogleWorker = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, JobFairPanel))
            {
                JobFairWorkersList.Remove(input);
                UpdateJobFairWorkerLocations();
                if (!ContainsPlayerOwnedWorker(JobFairWorkersList, input.Owner) && AssignedControl == JobFairPanel)
                {
                    AssignedControl = null;
                }
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, BigWigPanel))
            {
                if (AssignedControl == BigWigPanel && input == BigWigsWorker)
                {
                    AssignedControl = null;
                }
                BigWigsWorker = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, TechnologyCard1PictureBox))
            {
                if (AssignedControl == TechnologyCard1PictureBox && input == TechnologyCardWorkerArray[0])
                {
                    AssignedControl = null;
                }
                TechnologyCardWorkerArray[0] = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, TechnologyCard2PictureBox))
            {
                if (AssignedControl == TechnologyCard2PictureBox && input == TechnologyCardWorkerArray[1])
                {
                    AssignedControl = null;
                }
                TechnologyCardWorkerArray[1] = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, TechnologyCard3PictureBox))
            {
                if (AssignedControl == TechnologyCard3PictureBox && input == TechnologyCardWorkerArray[2])
                {
                    AssignedControl = null;
                }
                TechnologyCardWorkerArray[2] = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, TechnologyCard4PictureBox))
            {
                if (AssignedControl == TechnologyCard4PictureBox && input == TechnologyCardWorkerArray[3])
                {
                    AssignedControl = null;
                }
                TechnologyCardWorkerArray[3] = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, Client1PictureBox))
            {
                if (AssignedControl == Client1PictureBox && input == ClientCardWorkerArray[0])
                {
                    AssignedControl = null;
                }
                ClientCardWorkerArray[0] = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, Client2PictureBox))
            {
                if (AssignedControl == Client2PictureBox && input == ClientCardWorkerArray[1])
                {
                    AssignedControl = null;
                }
                ClientCardWorkerArray[1] = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, Client3PictureBox))
            {
                if (AssignedControl == Client3PictureBox && input == ClientCardWorkerArray[2])
                {
                    AssignedControl = null;
                }
                ClientCardWorkerArray[2] = null;
                input.IsAssigned = false;
            }
            else if (IsInBoundaries(input.Control, Client4PictureBox))
            {
                if (AssignedControl == Client4PictureBox && input == ClientCardWorkerArray[3])
                {
                    AssignedControl = null;
                }
                ClientCardWorkerArray[3] = null;
                input.IsAssigned = false;
            }

        }

        /// <summary>
        /// Searches for the area a gamepiece is in and performs an action based on the area. Use for entering an area.
        /// </summary>
        /// <param name="input"></param>
        public void EnterAreaEvent(Worker input)
        {
            if (IsInBoundaries(input.Control, Player1Panel))
            {
                if (input.Owner == null)
                {
                    input.Owner = Players[0];
                    Players[0].WorkerList.Add(input);
                }
                if (input is FrontEndDeveloper && input.Owner == Players[0])
                {
                    input.Control.Location = GetRawLocation(Player1FrontEndDeveloperHomePictureBox);
                    Players[0].NumFrontEndDevelopersOnHome++;
                    Player1FrontEndDevelopersLabel.Text = Players[0].NumFrontEndDevelopersOnHome.ToString();
                }
                else if (input is BackEndDeveloper && input.Owner == Players[0])
                {
                    input.Control.Location = GetRawLocation(Player1BackEndDeveloperHomePictureBox);
                    Players[0].NumBackEndDevelopersOnHome++;
                    Player1BackEndDevelopersLabel.Text = Players[0].NumBackEndDevelopersOnHome.ToString();
                }
                else if (input is FullStackDeveloper && input.Owner == Players[0])
                {
                    input.Control.Location = GetRawLocation(Player1FullStackDeveloperHomePictureBox);
                    Players[0].NumFullStackDevelopersOnHome++;
                    Player1FullStackDevelopersLabel.Text = Players[0].NumFullStackDevelopersOnHome.ToString();
                }
                else if (input is ProductOwner && input.Owner == Players[0])
                {
                    input.Control.Location = GetRawLocation(Player1ProductOwnerHomePictureBox);
                    Players[0].NumProductOwnersOnHome++;
                    Player1ProductOwnersLabel.Text = Players[0].NumProductOwnersOnHome.ToString();
                }
                else if (input is ScrumMaster && input.Owner == Players[0])
                {
                    input.Control.Location = GetRawLocation(Player1ScrumMasterHomePictureBox);
                    Players[0].NumScrumMastersOnHome++;
                    Player1ScrumMastersLabel.Text = Players[0].NumScrumMastersOnHome.ToString();
                }

            }
            else if (IsInBoundaries(input.Control, Player2Panel))
            {
                if (input.Owner == null)
                {
                    input.Owner = Players[1];
                    Players[1].WorkerList.Add(input);
                }
                if (input is FrontEndDeveloper && input.Owner == Players[1])
                {
                    input.Control.Location = GetRawLocation(Player2FrontEndDeveloperHomePictureBox);
                    Players[1].NumFrontEndDevelopersOnHome++;
                    Player2FrontEndDevelopersLabel.Text = Players[1].NumFrontEndDevelopersOnHome.ToString();
                }
                else if (input is BackEndDeveloper && input.Owner == Players[1])
                {
                    input.Control.Location = GetRawLocation(Player2BackEndDeveloperHomePictureBox);
                    Players[1].NumBackEndDevelopersOnHome++;
                    Player2BackEndDevelopersLabel.Text = Players[1].NumBackEndDevelopersOnHome.ToString();
                }
                else if (input is FullStackDeveloper && input.Owner == Players[1])
                {
                    input.Control.Location = GetRawLocation(Player2FullStackDeveloperHomePictureBox);
                    Players[1].NumFullStackDevelopersOnHome++;
                    Player2FullStackDevelopersLabel.Text = Players[1].NumFullStackDevelopersOnHome.ToString();
                }
                else if (input is ProductOwner && input.Owner == Players[1])
                {
                    input.Control.Location = GetRawLocation(Player2ProductOwnerHomePictureBox);
                    Players[1].NumProductOwnersOnHome++;
                    Player2ProductOwnersLabel.Text = Players[1].NumProductOwnersOnHome.ToString();
                }
                else if (input is ScrumMaster && input.Owner == Players[1])
                {
                    input.Control.Location = GetRawLocation(Player2ScrumMasterHomePictureBox);
                    Players[1].NumScrumMastersOnHome++;
                    Player2ScrumMastersLabel.Text = Players[1].NumScrumMastersOnHome.ToString();
                }

            }
            else if (IsInBoundaries(input.Control, Player3Panel))
            {
                if (input.Owner == null)
                {
                    input.Owner = Players[2];
                    Players[2].WorkerList.Add(input);
                }
                if (input is FrontEndDeveloper && input.Owner == Players[2])
                {
                    input.Control.Location = GetRawLocation(Player3FrontEndDeveloperHomePictureBox);
                    Players[2].NumFrontEndDevelopersOnHome++;
                    Player3FrontEndDevelopersLabel.Text = Players[2].NumFrontEndDevelopersOnHome.ToString();
                }
                else if (input is BackEndDeveloper && input.Owner == Players[2])
                {
                    input.Control.Location = GetRawLocation(Player3BackEndDeveloperHomePictureBox);
                    Players[2].NumBackEndDevelopersOnHome++;
                    Player3BackEndDevelopersLabel.Text = Players[2].NumBackEndDevelopersOnHome.ToString();
                }
                else if (input is FullStackDeveloper && input.Owner == Players[2])
                {
                    input.Control.Location = GetRawLocation(Player3FullStackDeveloperHomePictureBox);
                    Players[2].NumFullStackDevelopersOnHome++;
                    Player3FullStackDevelopersLabel.Text = Players[2].NumFullStackDevelopersOnHome.ToString();
                }
                else if (input is ProductOwner && input.Owner == Players[2])
                {
                    input.Control.Location = GetRawLocation(Player3ProductOwnerHomePictureBox);
                    Players[2].NumProductOwnersOnHome++;
                    Player3ProductOwnersLabel.Text = Players[2].NumProductOwnersOnHome.ToString();
                }
                else if (input is ScrumMaster && input.Owner == Players[2])
                {
                    input.Control.Location = GetRawLocation(Player3ScrumMasterHomePictureBox);
                    Players[2].NumScrumMastersOnHome++;
                    Player3ScrumMastersLabel.Text = Players[2].NumScrumMastersOnHome.ToString();
                }

            }
            else if (IsInBoundaries(input.Control, Player4Panel))
            {
                if (input.Owner == null)
                {
                    input.Owner = Players[3];
                    Players[3].WorkerList.Add(input);
                }
                if (input is FrontEndDeveloper && input.Owner == Players[3])
                {
                    input.Control.Location = GetRawLocation(Player4FrontEndDeveloperHomePictureBox);
                    Players[3].NumFrontEndDevelopersOnHome++;
                    Player4FrontEndDevelopersLabel.Text = Players[3].NumFrontEndDevelopersOnHome.ToString();
                }
                else if (input is BackEndDeveloper && input.Owner == Players[3])
                {
                    input.Control.Location = GetRawLocation(Player4BackEndDeveloperHomePictureBox);
                    Players[3].NumBackEndDevelopersOnHome++;
                    Player4BackEndDevelopersLabel.Text = Players[3].NumBackEndDevelopersOnHome.ToString();
                }
                else if (input is FullStackDeveloper && input.Owner == Players[3])
                {
                    input.Control.Location = GetRawLocation(Player4FullStackDeveloperHomePictureBox);
                    Players[3].NumFullStackDevelopersOnHome++;
                    Player4FullStackDevelopersLabel.Text = Players[3].NumFullStackDevelopersOnHome.ToString();
                }
                else if (input is ProductOwner && input.Owner == Players[3])
                {
                    input.Control.Location = GetRawLocation(Player4ProductOwnerHomePictureBox);
                    Players[3].NumProductOwnersOnHome++;
                    Player4ProductOwnersLabel.Text = Players[3].NumProductOwnersOnHome.ToString();
                }
                else if (input is ScrumMaster && input.Owner == Players[3])
                {
                    input.Control.Location = GetRawLocation(Player4ScrumMasterHomePictureBox);
                    Players[3].NumScrumMastersOnHome++;
                    Player4ScrumMastersLabel.Text = Players[3].NumScrumMastersOnHome.ToString();
                }
            }
            else if (IsInBoundaries(input.Control, ContractOutPanel))
            {
                if ((AssignedControl == null || AssignedControl == ContractOutPanel) && !PlayerAreasUsed[input.Owner.PlayerNumber - 1].Contains(ContractOutPanel))
                {
                    ContractOutWorkersList.Add(input);
                    UpdateContractOutWorkerLocations();
                    AssignedControl = ContractOutPanel;
                    input.IsAssigned = true;
                }

            }
            else if (IsInBoundaries(input.Control, TasklandPanel))
            {
                if ((!(input is ProductOwner) && TaskWorkersList.Count < 7 && input.Owner != null && (AssignedControl == null || AssignedControl == TasklandPanel)) && !PlayerAreasUsed[input.Owner.PlayerNumber - 1].Contains(TasklandPanel))
                {
                    TaskWorkersList.Add(input);
                    Point startPoint = GetRawLocation(TasklandPanel);
                    startPoint.X += RESOURCE_X_OFFSET;
                    startPoint.Y += RESOURCE_Y_OFFSET;
                    UpdateResourceWorkerLocations(TaskWorkersList, startPoint);
                    AssignedControl = TasklandPanel;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, StorylandPanel))
            {
                if ((!(input is ProductOwner) && StoryWorkersList.Count < 7 && input.Owner != null && (AssignedControl == null || AssignedControl == StorylandPanel)) && !PlayerAreasUsed[input.Owner.PlayerNumber - 1].Contains(StorylandPanel))
                {
                    StoryWorkersList.Add(input);
                    Point startPoint = GetRawLocation(StorylandPanel);
                    startPoint.X += RESOURCE_X_OFFSET;
                    startPoint.Y += RESOURCE_Y_OFFSET;
                    UpdateResourceWorkerLocations(StoryWorkersList, startPoint);
                    AssignedControl = StorylandPanel;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, FeaturelandPanel))
            {
                if ((!(input is ProductOwner) && FeatureWorkersList.Count < 7 && input.Owner != null && (AssignedControl == null || AssignedControl == FeaturelandPanel)) && !PlayerAreasUsed[input.Owner.PlayerNumber - 1].Contains(FeaturelandPanel))
                {
                    FeatureWorkersList.Add(input);
                    Point startPoint = GetRawLocation(FeaturelandPanel);
                    startPoint.X += RESOURCE_X_OFFSET;
                    startPoint.Y += RESOURCE_Y_OFFSET;
                    UpdateResourceWorkerLocations(FeatureWorkersList, startPoint);
                    AssignedControl = FeaturelandPanel;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, EpiclandPanel))
            {
                if ((!(input is ProductOwner) && EpicWorkersList.Count < 7 && input.Owner != null && (AssignedControl == null || AssignedControl == EpiclandPanel)) && !PlayerAreasUsed[input.Owner.PlayerNumber - 1].Contains(EpiclandPanel))
                {
                    EpicWorkersList.Add(input);
                    Point startPoint = GetRawLocation(EpiclandPanel);
                    startPoint.X += RESOURCE_X_OFFSET;
                    startPoint.Y += RESOURCE_Y_OFFSET;
                    UpdateResourceWorkerLocations(EpicWorkersList, startPoint);
                    AssignedControl = EpiclandPanel;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, GooglePanel))
            {
                if ((GoogleWorker == null && (input is ProductOwner || input is ScrumMaster) && input.Owner != null && AssignedControl == null) && !PlayerAreasUsed[input.Owner.PlayerNumber - 1].Contains(GooglePanel))
                {
                    GoogleWorker = input;
                    Point location = GetRawLocation(GooglePanel);
                    location.X += 31;
                    location.Y += 55;
                    input.Control.Location = location;
                    AssignedControl = GooglePanel;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, JobFairPanel) && (AssignedControl == null || AssignedControl == JobFairPanel))
            {
                if (JobFairWorkersList.Count < 2 && input.Owner != null)
                {
                    if (((JobFairWorkersList.Count == 1 && JobFairWorkersList[0].Owner == input.Owner) || JobFairWorkersList.Count == 0) && !PlayerAreasUsed[input.Owner.PlayerNumber - 1].Contains(JobFairPanel))
                    {
                        JobFairWorkersList.Add(input);
                        UpdateJobFairWorkerLocations();
                        AssignedControl = JobFairPanel;
                        input.IsAssigned = true;
                    }
                }
            }
            else if (IsInBoundaries(input.Control, BigWigPanel) && AssignedControl == null)
            {
                if ((BigWigsWorker == null && (input is ProductOwner || input is ScrumMaster) && input.Owner != null) && !PlayerAreasUsed[input.Owner.PlayerNumber - 1].Contains(BigWigPanel))
                {
                    BigWigsWorker = input;
                    Point location = GetRawLocation(BigWigPanel);
                    location.X += 29;
                    location.Y += 55;
                    input.Control.Location = location;
                    AssignedControl = BigWigPanel;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, TechnologyCard1PictureBox) && AssignedControl == null)
            {
                if (TechnologyCardWorkerArray[0] == null && input.Owner != null)
                {
                    TechnologyCardWorkerArray[0] = input;
                    Point location = GetRawLocation(TechnologyCard1PictureBox);
                    location.X += 20;
                    location.Y += 21;
                    input.Control.Location = location;
                    AssignedControl = TechnologyCard1PictureBox;
                    input.IsAssigned = true;
                }

            }
            else if (IsInBoundaries(input.Control, TechnologyCard2PictureBox) && AssignedControl == null)
            {
                if (TechnologyCardWorkerArray[1] == null && input.Owner != null)
                {
                    TechnologyCardWorkerArray[1] = input;
                    Point location = GetRawLocation(TechnologyCard2PictureBox);
                    location.X += 20;
                    location.Y += 21;
                    input.Control.Location = location;
                    AssignedControl = TechnologyCard2PictureBox;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, TechnologyCard3PictureBox) && AssignedControl == null)
            {
                if (TechnologyCardWorkerArray[2] == null && input.Owner != null)
                {
                    TechnologyCardWorkerArray[2] = input;
                    Point location = GetRawLocation(TechnologyCard3PictureBox);
                    location.X += 20;
                    location.Y += 21;
                    input.Control.Location = location;
                    AssignedControl = TechnologyCard3PictureBox;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, TechnologyCard4PictureBox) && AssignedControl == null)
            {
                if (TechnologyCardWorkerArray[3] == null && input.Owner != null)
                {
                    TechnologyCardWorkerArray[3] = input;
                    Point location = GetRawLocation(TechnologyCard4PictureBox);
                    location.X += 20;
                    location.Y += 21;
                    input.Control.Location = location;
                    AssignedControl = TechnologyCard4PictureBox;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, Client1PictureBox) && AssignedControl == null)
            {
                if (ClientCardWorkerArray[0] == null && input.Owner != null && input is ProductOwner)
                {
                    ClientCardWorkerArray[0] = input;
                    Point location = GetRawLocation(Client1PictureBox);
                    location.X += 10;
                    location.Y += 13;
                    input.Control.Location = location;
                    AssignedControl = Client1PictureBox;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, Client2PictureBox) && AssignedControl == null)
            {
                if (ClientCardWorkerArray[1] == null && input.Owner != null && input is ProductOwner)
                {
                    ClientCardWorkerArray[1] = input;
                    Point location = GetRawLocation(Client2PictureBox);
                    location.X += 10;
                    location.Y += 13;
                    input.Control.Location = location;
                    AssignedControl = Client2PictureBox;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, Client3PictureBox) && AssignedControl == null)
            {
                if (ClientCardWorkerArray[2] == null && input.Owner != null && input is ProductOwner && NumPlayers > 2)
                {
                    ClientCardWorkerArray[2] = input;
                    Point location = GetRawLocation(Client3PictureBox);
                    location.X += 10;
                    location.Y += 13;
                    input.Control.Location = location;
                    AssignedControl = Client3PictureBox;
                    input.IsAssigned = true;
                }
            }
            else if (IsInBoundaries(input.Control, Client4PictureBox) && AssignedControl == null)
            {
                if (ClientCardWorkerArray[3] == null && input.Owner != null && input is ProductOwner && NumPlayers > 3)
                {
                    ClientCardWorkerArray[3] = input;
                    Point location = GetRawLocation(Client4PictureBox);
                    location.X += 10;
                    location.Y += 13;
                    input.Control.Location = location;
                    AssignedControl = Client4PictureBox;
                    input.IsAssigned = true;
                }
            }

        }
        #endregion
        #region Helper Methods
        /// <summary>
        /// Check if the list contains a worker owned by the player
        /// </summary>
        /// <param name="WorkerList"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ContainsPlayerOwnedWorker(List<Worker> WorkerList, Player player)
        {
            bool output = false;
            foreach (Worker w in WorkerList)
            {
                if (w.Owner == player)
                {
                    output = true;
                    break;
                }
            }
            return output;
        }
        /// <summary>
        /// Test if a control 1 is within the area of control 2
        /// </summary>
        /// <param name="input"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        private bool IsInBoundaries(Control input, Control area)
        {
            bool output = false;
            Point areaPoint = GetRawLocation(area);
            if (input.Location.X < (areaPoint.X + area.Size.Width) && input.Location.X > areaPoint.X) //check if within horizontal boundaries
            {
                if (input.Location.Y < (areaPoint.Y + area.Size.Height) && input.Location.Y > areaPoint.Y)
                {
                    output = true;
                }
            }
            return output;
        }

        /// <summary>
        /// Get the worker object associated with the picturebox
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private Worker GetWorker(PictureBox input)
        {
            Worker output = null;
            foreach (Worker w in WorkersList)
            {
                if (w.Control == input)
                {
                    output = w;
                    break;
                }
            }
                    
            return output;
        }

        /// <summary>
        /// Get location of control based on main form.
        /// </summary>
        /// <param name="referenceControl"></param>
        /// <returns></returns>
        private Point GetRawLocation(Control referenceControl)
        {
            Point output = referenceControl.FindForm().PointToClient(referenceControl.Parent.PointToScreen(referenceControl.Location));

            return output;
        }

        /// <summary>
        /// Set locations of worker PictureBoxes on Contract Out spot. Spreads them evenly in a limited area.
        /// </summary>
        private void UpdateContractOutWorkerLocations()
        {
            if (ContractOutWorkersList.Count > 0)
            {
                int VerticalOffset = 71;
                int HorizontalOffset = 4;
                int Width = 110;
                int Spacing = Width / ContractOutWorkersList.Count;
                Point StartPoint = GetRawLocation(ContractOutPanel);
                StartPoint.X += HorizontalOffset;
                StartPoint.Y += VerticalOffset + Y_OFFSET;
                for (int i = 0; i < ContractOutWorkersList.Count; i++)
                {
                    ContractOutWorkersList[i].Control.Location = StartPoint;
                    StartPoint.X += Spacing;
                }
            }
        }

        /// <summary>
        /// Set locations of worker PictureBoxes on a resource.
        /// </summary>
        /// <param name="workerList"></param>
        /// <param name="referencePoint"></param>
        private void UpdateResourceWorkerLocations( List<Worker> workerList, Point referencePoint)
        {
            Point[] points = new Point[7];
            points[0] = new Point(0, 0);
            points[1] = new Point(46, 0);
            points[2] = new Point(92, 0);
            points[3] = new Point(92, 48);
            points[4] = new Point(92, 97);
            points[5] = new Point(46, 97);
            points[6] = new Point(0, 97);
            for (int i = 0; i < workerList.Count; i++)
            {
                workerList[i].Control.Location = new Point(points[i].X + referencePoint.X, points[i].Y + referencePoint.Y);
            }

        }

        /// <summary>
        /// Set locations of worker PictureBoxes on Job Fair spot.
        /// </summary>
        private void UpdateJobFairWorkerLocations()
        {
            Point[] points = new Point[2];
            points[0] = GetRawLocation(JobFairPanel);
            points[1] = GetRawLocation(JobFairPanel);
            points[0].X += 22;
            points[0].Y += 80;
            points[1].X += 68;
            points[1].Y += 80;
            for (int i = 0; i < JobFairWorkersList.Count; i++)
            {
                JobFairWorkersList[i].Control.Location = points[i];
            }
        }

        /// When user clicks the "Task List" button, the form for the list is triggered and displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            frm2.ShowDialog();
        }

        /// <summary>
        /// Update images for player research tokens
        /// </summary>
        /// <param name="playerNum"></param>
        private void UpdatePlayerResearch(int playerNum)
        {
            if (playerNum >= 0 && playerNum <= 3)
            {
                switch (playerNum)
                {
                    case 0:
                        if (Players[0].CurrentResearchImages[0] != null) { Player1Research1PictureBox.Image = Players[0].CurrentResearchImages[0]; }
                        if (Players[0].CurrentResearchImages[1] != null) { Player1Research2PictureBox.Image = Players[0].CurrentResearchImages[1]; }
                        if (Players[0].CurrentResearchImages[2] != null) { Player1Research3PictureBox.Image = Players[0].CurrentResearchImages[2]; }
                        break;
                    case 1:
                        if (Players[1].CurrentResearchImages[0] != null) { Player2Research1PictureBox.Image = Players[1].CurrentResearchImages[0]; }
                        if (Players[1].CurrentResearchImages[1] != null) { Player2Research2PictureBox.Image = Players[1].CurrentResearchImages[1]; }
                        if (Players[1].CurrentResearchImages[2] != null) { Player2Research3PictureBox.Image = Players[1].CurrentResearchImages[2]; }
                        break;
                    case 2:
                        if (Players[2].CurrentResearchImages[0] != null) { Player3Research1PictureBox.Image = Players[2].CurrentResearchImages[0]; }
                        if (Players[2].CurrentResearchImages[1] != null) { Player3Research2PictureBox.Image = Players[2].CurrentResearchImages[1]; }
                        if (Players[2].CurrentResearchImages[2] != null) { Player3Research3PictureBox.Image = Players[2].CurrentResearchImages[2]; }
                        break;
                    case 3:
                        if (Players[3].CurrentResearchImages[0] != null) { Player4Research1PictureBox.Image = Players[3].CurrentResearchImages[0]; }
                        if (Players[3].CurrentResearchImages[1] != null) { Player4Research2PictureBox.Image = Players[3].CurrentResearchImages[1]; }
                        if (Players[3].CurrentResearchImages[2] != null) { Player4Research3PictureBox.Image = Players[3].CurrentResearchImages[2]; }
                        break;
                }
                
            }
            
        }
        #endregion
        #region ToolTip Hover Events
        /// <summary>
        /// Show tooltip for ContractOutPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContractOutPanel_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Contract Out Area", ContractOutPanel);
        }

        /// <summary>
        /// Show ToolTip for Points Progressbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar1_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Player Points", Player1PointProgressBar);
        }

        /// <summary>
        /// Show ToolTip for Points Progressbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar2_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Player Points", Player2PointProgressBar);
        }

        /// <summary>
        /// Show ToolTip for Points Progressbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar3_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Player Points", Player3PointProgressBar);
        }

        /// <summary>
        /// Show ToolTip for Points Progressbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar4_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Player Points", Player4PointProgressBar);
        }

        /// <summary>
        /// Show ToolTip for Taskland
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TasklandPanel_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Taskland Resource Spot", TasklandPanel);
        }

        /// <summary>
        /// Show ToolTip for Storyland
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StorylandPanel_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Storyland Resource Spot", StorylandPanel);
        }

        /// <summary>
        /// Show ToolTip for Featureland
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeaturelandPanel_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Featureland Resource Spot", FeaturelandPanel);
        }

        /// <summary>
        /// Show ToolTip for Epicland
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EpiclandPanel_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Epicland Resource Spot", EpiclandPanel);
        }

        /// <summary>
        /// Show ToolTip for Google Spot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GooglePanel_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Google Research Spot", GooglePanel);
        }

        /// <summary>
        /// Show ToolTip for job Fair Spot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JobFairPanel_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Job Fair Hiring Spot", JobFairPanel);
        }

        /// <summary>
        /// Show ToolTip for Big Wigs Spot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BigWigPanel_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Big Wigs Budget Increase Spot", BigWigPanel);
        }

        /// <summary>
        /// Show ToolTip for Budget Bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BudgetStripPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Budget Bar", BudgetStripPictureBox);
        }


        /// <summary>
        /// Show ToolTip for Product Owner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductOwner_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Product Owner", (PictureBox)sender);
        }

        /// <summary>
        /// Show ToolTip for Scrum Master
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrumMaster_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Scrum Master", (PictureBox)sender);
        }

        /// <summary>
        /// Show ToolTip for Front End Developer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrontEndDeveloper_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Front End Developer", (PictureBox)sender);
        }

        /// <summary>
        /// Show ToolTip for Back End Developer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEndDeveloper_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Back End Developer", (PictureBox)sender);
        }

        /// <summary>
        /// Show ToolTip for Full Stack Developer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullStackDeveloper_MouseHover(object sender, EventArgs e)
        {
            ToolTip.Show("Full Stack Developer", (PictureBox)sender);
        }
        #endregion
        #region ResearchClickEvents



        /// <summary>
        /// Reset the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            Players[0].ResetResearchUsed();
            UpdatePlayerResearch(0);
        }


        #endregion




        /// <summary>
        /// Update player title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player1TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Players[0] != null)
            {
                Players[0].Name = Player1TitleTextBox.Text;
            }
        }

        /// <summary>
        /// update player title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player2TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Players[1] != null)
            {
                Players[1].Name = Player2TitleTextBox.Text;
            }
        }

        /// <summary>
        /// update player title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player3TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Players[2] != null)
            {
                Players[2].Name = Player3TitleTextBox.Text;
            }
        }

        /// <summary>
        /// update player title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player4TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Players[3] != null)
            {
                Players[3].Name = Player4TitleTextBox.Text;
            }
        }

        /// <summary>
        /// Open Technology Card inventory form for active player if player1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player1TechnologyCardHomePictureBox_Click(object sender, EventArgs e)
        {
            if (ActivePlayer == Players[0])
            {
                TechnologyCardInventoryForm form = new TechnologyCardInventoryForm(Players[0]);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Click event to reset form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioController.audio.Play();

            Application.Restart();
        }

        /// <summary>
        /// Click event to display rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioController.audio.Play();
            RulesForm form3 = new RulesForm();
            form3.Show();
        }



        /// <summary>
        /// Open Client Card Inventory form if active player is player1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player1ClientCardHomePictureBox_Click(object sender, EventArgs e)
        {
            if (Players[0] != null && ActivePlayer == Players[0])
            {
                ClientCardInventoryForm form = new ClientCardInventoryForm(ActivePlayer);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Open Client Card Inventory form if active player is player2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player2ClientCardHomePictureBox_Click(object sender, EventArgs e)
        {
            if (Players[1] != null && ActivePlayer == Players[1])
            {
                ClientCardInventoryForm form = new ClientCardInventoryForm(ActivePlayer);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Open Client Card Inventory form if active player is player3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player3ClientCardHomePictureBox_Click(object sender, EventArgs e)
        {
            if (Players[2] != null && ActivePlayer == Players[2])
            {
                ClientCardInventoryForm form = new ClientCardInventoryForm(ActivePlayer);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Open Client Card Inventory form if active player is player4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player4ClientCardHomePictureBox_Click(object sender, EventArgs e)
        {
            if (Players[3] != null && ActivePlayer == Players[3])
            {
                ClientCardInventoryForm form = new ClientCardInventoryForm(ActivePlayer);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Open Technology Card Inventory if active player is player2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player2TechnologyCardHomePictureBox_Click(object sender, EventArgs e)
        {
            if (ActivePlayer == Players[1])
            {
                TechnologyCardInventoryForm form = new TechnologyCardInventoryForm(Players[1]);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Open Technology Card Inventory if active player is player3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player3TechnologyCardHomePictureBox_Click(object sender, EventArgs e)
        {
            if (ActivePlayer == Players[2])
            {
                TechnologyCardInventoryForm form = new TechnologyCardInventoryForm(Players[2]);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Open Technology Card Inventory if active player is player4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player4TechnologyCardHomePictureBox_Click(object sender, EventArgs e)
        {
            if (ActivePlayer == Players[3])
            {
                TechnologyCardInventoryForm form = new TechnologyCardInventoryForm(Players[3]);
                form.ShowDialog();
            }
        }
        /// <summary>
        /// Set Active Player and update Player title box colors
        /// </summary>
        /// <param name="playerNum"></param>
        public void SetActivePlayer(int playerNum)
        {
            ActivePlayer = Players[playerNum - 1];
            Player1TitleTextBox.BackColor = Color.White;
            Player2TitleTextBox.BackColor = Color.White;
            Player3TitleTextBox.BackColor = Color.White;
            Player4TitleTextBox.BackColor = Color.White;

            switch (playerNum)
            {
                case 1:
                    Player1TitleTextBox.BackColor = Color.Green;
                    break;
                case 2:
                    Player2TitleTextBox.BackColor = Color.Green;
                    break;
                case 3:
                    Player3TitleTextBox.BackColor = Color.Green;
                    break;
                case 4:
                    Player4TitleTextBox.BackColor = Color.Green;
                    break;
            }
        }
        /// <summary>
        /// Start given phase by setting restrictions and displaying controls
        /// </summary>
        /// <param name="phase"></param>
        public void BeginPhase(int phase)
        {
            if (phase >= 0 && phase <= 3)
            {
                switch (phase)
                {
                    case 0:
                        for (int i = 0; i < NumPlayers; i++)
                        {
                            Players[i].ResetResearchUsed();
                        }
                        CurrentPhase = 0;
                        PhaseLabel.Text = "Phase 0 - Task Voting";
                        SetActivePlayer(StartPlayer.PlayerNumber);
                        VotingForm form = new VotingForm();
                        form.ShowDialog();
                        form.Close();
                        break;
                    case 1:
                        CurrentPhase = 1;
                        PhaseLabel.Text = "Phase 1 - Worker Assignment";
                        AllowDragWorker = true;
                        break;
                    case 2:
                        CurrentPhase = 2;
                        PhaseLabel.Text = "Phase 2 - Action Activation";
                        SetActivePlayer(StartPlayer.PlayerNumber);
                        AllowDragWorker = false;
                        DisplayActionButtons(ActivePlayer);
                        break;
                    case 3:
                        CurrentPhase = 3;
                        SetActivePlayer(StartPlayer.PlayerNumber);
                        PhaseLabel.Text = "Phase 3 - Pay Workers";
                        PlayerAreasUsed = new List<List<Control>> { new List<Control>(), new List<Control>(), new List<Control>(), new List<Control>()};
                        DisplayActionButtons(ActivePlayer);
                        for (int i = 0; i < NumPlayers; i++)
                        {
                            int WorkersOwned = 0;
                            Players[i].Money += Players[i].Budget;
                            foreach (Worker w in WorkersList)
                            {
                                if (w.Owner == Players[i]) { WorkersOwned++; }
                            }
                            if (Players[i].Money >= WorkersOwned)
                            {
                                Players[i].Money -= WorkersOwned;
                                MessageBox.Show(Players[i].Name + " gained $" + Players[i].Budget + " from their budget and payed $" + WorkersOwned + " for their workers.");
                                UpdateLabels();
                            }
                            else
                            {
                                Players[i].Money = 0;
                                int lostPoints = 10;
                                if (Players[i].Points < lostPoints)
                                {
                                    lostPoints = Players[i].Points;
                                }
                                MessageBox.Show(Players[i].Name + " gained $" + Players[i].Budget + " from their budget but failed to pay all workers. " + Players[i].Name + " loses " + lostPoints + " points.");
                                Players[i].Points -= lostPoints;
                                UpdateLabels();

                            }
                        }
                        PhaseButton.Text = "END ROUND";
                        break;
                }
            }
        }

        private void DisplayActionButtons (Player player)
        {
            int i = player.PlayerNumber - 1;
            GetContractOutButton.Visible = false;
            GetTasklandButton.Visible = false;
            GetStorylandButton.Visible = false;
            GetFeaturelandButton.Visible = false;
            GetEpiclandButton.Visible = false;
            GetGoogleButton.Visible = false;
            GetJobFairButton.Visible = false;
            GetBigWigsButton.Visible = false;
            BuyClientCard1Button.Visible = false;
            BuyClientCard2Button.Visible = false;
            BuyClientCard3Button.Visible = false;
            BuyClientCard4Button.Visible = false;
            BuyTechnologyCard1Button.Visible = false;
            BuyTechnologyCard2Button.Visible = false;
            BuyTechnologyCard3Button.Visible = false;
            BuyTechnologyCard4Button.Visible = false;
            if (PlayerAreasUsed[i].Contains(ContractOutPanel))
            {
                GetContractOutButton.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(TasklandPanel))
            {
                GetTasklandButton.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(StorylandPanel))
            {
                GetStorylandButton.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(FeaturelandPanel))
            {
                GetFeaturelandButton.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(EpiclandPanel))
            {
                GetEpiclandButton.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(GooglePanel))
            {
                GetGoogleButton.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(JobFairPanel))
            {
                GetJobFairButton.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(BigWigPanel))
            {
                GetBigWigsButton.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(Client1PictureBox))
            {
                BuyClientCard1Button.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(Client2PictureBox))
            {
                BuyClientCard2Button.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(Client3PictureBox))
            {
                BuyClientCard3Button.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(Client4PictureBox))
            {
                BuyClientCard4Button.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(TechnologyCard1PictureBox))
            {
                BuyTechnologyCard1Button.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(TechnologyCard2PictureBox))
            {
                BuyTechnologyCard2Button.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(TechnologyCard3PictureBox))
            {
                BuyTechnologyCard3Button.Visible = true;
            }
            if (PlayerAreasUsed[i].Contains(TechnologyCard4PictureBox))
            {
                BuyTechnologyCard4Button.Visible = true;
            }

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Return the next player
        /// </summary>
        /// <returns></returns>
        private Player NextPlayer()
        {
            Player output = null;
            if (ActivePlayer.PlayerNumber == 1)
            {
                output = Players[1];
            }
            else if (ActivePlayer.PlayerNumber == 2)
            {
                if (NumPlayers > 2) { output = Players[2]; }
                else { output = Players[0]; }
            }
            else if (ActivePlayer.PlayerNumber == 3)
            {
                if (NumPlayers > 3) { output = Players[3]; }
                else { output = Players[0]; }
            }
            else if (ActivePlayer.PlayerNumber == 4)
            {
                output = Players[0];
            }
            return output;
        }
        /// <summary>
        /// determine if there are any moves the player can make
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool WorkerAssignmentIsDone(Player player)
        {
            bool output = true;
            int numJobFairEligibleWorkers = 0;
            foreach (Worker w in WorkersList)
            {
                if (w.Owner == player && !w.IsAssigned)
                {
                    if (w is ProductOwner)
                    {
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(ContractOutPanel))
                        {
                            output = false;
                        }
                        if (GoogleWorker == null)
                        {
                            output = false;
                        }
                        if (BigWigsWorker == null)
                        {
                            output = false;
                        }
                        if (JobFairWorkersList.Count == 0)
                        {
                            numJobFairEligibleWorkers++;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (TechnologyCardWorkerArray[i] == null)
                            {
                                output = false;
                            }
                            if (ClientCardWorkerArray[i] == null)
                            {
                                output = false;
                            }
                        }

                    }
                    else if (w is ScrumMaster)
                    {
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(ContractOutPanel))
                        {
                            output = false;
                        }
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(TasklandPanel) && TaskWorkersList.Count < 7)
                        {
                            output = false;
                        }
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(StorylandPanel) && StoryWorkersList.Count < 7)
                        {
                            output = false;
                        }
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(FeaturelandPanel) && FeatureWorkersList.Count < 7)
                        {
                            output = false;
                        }
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(EpiclandPanel) && EpicWorkersList.Count < 7)
                        {
                            output = false;
                        }
                        if (GoogleWorker == null)
                        {
                            output = false;
                        }
                        if (BigWigsWorker == null)
                        {
                            output = false;
                        }
                        if (JobFairWorkersList.Count == 0)
                        {
                            numJobFairEligibleWorkers++;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (TechnologyCardWorkerArray[i] == null)
                            {
                                output = false;
                            }

                        }
                    }
                    else if (w is FrontEndDeveloper || w is BackEndDeveloper || w is FullStackDeveloper)
                    {
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(ContractOutPanel))
                        {
                            output = false;
                        }
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(TasklandPanel) && TaskWorkersList.Count < 7)
                        {
                            output = false;
                        }
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(StorylandPanel) && StoryWorkersList.Count < 7)
                        {
                            output = false;
                        }
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(FeaturelandPanel) && FeatureWorkersList.Count < 7)
                        {
                            output = false;
                        }
                        if (!PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(EpiclandPanel) && EpicWorkersList.Count < 7)
                        {
                            output = false;
                        }
                        if (JobFairWorkersList.Count == 0)
                        {
                            numJobFairEligibleWorkers++;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            if (TechnologyCardWorkerArray[i] == null)
                            {
                                output = false;
                            }

                        }
                    }

                }
            }
            if (numJobFairEligibleWorkers > 1)
            {
                output = false;
            }
            return output;
        }
        /// <summary>
        /// Update lists of controls used by player to be used when assigning workers
        /// </summary>
        private void UpdateAreasUsed()
        {
            for (int i = 0; i < 4; i++)
            {
                PlayerAreasUsed[i] = new List<Control>();
            }
            
            foreach (Worker w in WorkersList)
            {
                if (w.Owner != null)
                {
                    if (ContractOutWorkersList.Contains(w) && !PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(ContractOutPanel))
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(ContractOutPanel);
                    }
                    else if (TaskWorkersList.Contains(w) && !PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(TasklandPanel))
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(TasklandPanel);
                    }
                    else if (StoryWorkersList.Contains(w) && !PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(StorylandPanel))
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(StorylandPanel);
                    }
                    else if (FeatureWorkersList.Contains(w) && !PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(FeaturelandPanel))
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(FeaturelandPanel);
                    }
                    else if (EpicWorkersList.Contains(w) && !PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(EpiclandPanel))
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(EpiclandPanel);
                    }
                    else if (GoogleWorker == w )
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(GooglePanel);
                    }
                    else if (JobFairWorkersList.Contains(w) && !PlayerAreasUsed[w.Owner.PlayerNumber - 1].Contains(JobFairPanel))
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(JobFairPanel);
                    }
                    else if (BigWigsWorker == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(BigWigPanel);
                    }
                    else if (TechnologyCardWorkerArray[0] == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(TechnologyCard1PictureBox);
                    }
                    else if (TechnologyCardWorkerArray[1] == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(TechnologyCard2PictureBox);
                    }
                    else if (TechnologyCardWorkerArray[2] == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(TechnologyCard3PictureBox);
                    }
                    else if (TechnologyCardWorkerArray[3] == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(TechnologyCard4PictureBox);
                    }
                    else if (ClientCardWorkerArray[0] == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(Client1PictureBox);
                    }
                    else if (ClientCardWorkerArray[1] == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(Client2PictureBox);
                    }
                    else if (ClientCardWorkerArray[2] == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(Client3PictureBox);
                    }
                    else if (ClientCardWorkerArray[3] == w)
                    {
                        PlayerAreasUsed[w.Owner.PlayerNumber - 1].Add(Client4PictureBox);
                    }

                }
            }
        }

        private void PhaseButton_Click(object sender, EventArgs e)
        {
            if (CurrentPhase == -1)
            {
                BeginPhase(0);
                PhaseButton.Text = "End Turn";
            }
            else if (CurrentPhase == 1)
            {
                if (AssignedControl == null)
                {
                    MessageBox.Show("At least one worker must be placed to end your turn.");
                }
                else if (JobFairWorkersList.Count == 1)
                {
                    MessageBox.Show("At least two workers must be placed at the Job Fair");
                }
                else
                {
                    UpdateAreasUsed();
                    AssignedControl = null;
                    foreach (Worker w in WorkersList) //return all unassigned workers to players
                    {
                        if (w.Owner == null)
                        {
                            //do nothing
                        }
                        else if (w.Owner == Players[0])
                        {
                            if (!IsInBoundaries(w.Control, Player1Panel) && !w.IsAssigned)
                            {
                                w.Control.Location = GetRawLocation(Player1TitleTextBox);
                                EnterAreaEvent(w);
                            }
                        }
                        else if (w.Owner == Players[1])
                        {
                            if (!IsInBoundaries(w.Control, Player2Panel) && !w.IsAssigned)
                            {
                                w.Control.Location = GetRawLocation(Player2TitleTextBox);
                                EnterAreaEvent(w);
                            }
                        }
                        else if (NumPlayers > 2 && w.Owner == Players[2])
                        {
                            if (!IsInBoundaries(w.Control, Player3Panel) && !w.IsAssigned)
                            {
                                w.Control.Location = GetRawLocation(Player3TitleTextBox);
                                EnterAreaEvent(w);
                            }
                        }
                        else if (NumPlayers > 3 && w.Owner == Players[3])
                        {
                            if (!IsInBoundaries(w.Control, Player4Panel) && !w.IsAssigned)
                            {
                                w.Control.Location = GetRawLocation(Player4TitleTextBox);
                                EnterAreaEvent(w);
                            }
                        }

                    }
                    int FinishedPlayers = 0;
                    for (int i = 0; i < NumPlayers; i++)
                    {
                        if (WorkerAssignmentIsDone(NextPlayer()))
                        {
                            FinishedPlayers++;
                            SetActivePlayer(NextPlayer().PlayerNumber);
                        }
                        else
                        {
                            SetActivePlayer(NextPlayer().PlayerNumber);
                            break;
                        }
                    }
                    if (FinishedPlayers >= NumPlayers)
                    {
                        BeginPhase(2);
                    }
                }
            }
            else if (CurrentPhase == 2)
            {
                if (GetContractOutButton.Visible == false && GetTasklandButton.Visible == false && GetStorylandButton.Visible == false && GetFeaturelandButton.Visible == false && GetEpiclandButton.Visible == false && GetGoogleButton.Visible == false && GetJobFairButton.Visible == false && GetBigWigsButton.Visible == false)
                {
                    if (NextPlayer() == StartPlayer)
                    {
                        ReturnBuyingWorkers();
                        BeginPhase(3);
                    }
                    else
                    {
                        SetActivePlayer(NextPlayer().PlayerNumber);
                        DisplayActionButtons(ActivePlayer);
                    }
                }
            }
            else if (CurrentPhase == 3)
            {
                bool isEnd = false;
                for (int i = 0; i < NumPlayers; i++)
                {
                    if (ClientCardStacks[0].Count == 0)
                    {
                        isEnd = true;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (TechnologyCardSlots[i] == null)
                    {
                        isEnd = true;
                    }
                }
                if (isEnd)
                {
                    EndGame();
                }
                else
                {
                    PhaseButton.Text = "NEXT ROUND";
                    StartPlayer = NextPlayer();
                    CurrentPhase = -1;
                }
            }
        }
        /// <summary>
        /// Listener for Button to get money from Contract out spot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetContractOutButton_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            GetContractOut();
            
        }
        /// <summary>
        /// Roll dice and give money to player depending on roll and workers
        /// </summary>
        private void GetContractOut()
        {
            int numWorkers = 0;
            List<Worker> list = new List<Worker>(ContractOutWorkersList);
            foreach (Worker w in list)
            {
                if (w.Owner == ActivePlayer)
                {
                    numWorkers++;
                    ReturnWorker(w);
                    
                }
            }
            DiceAmount.Text = numWorkers.ToString();
            RollDice();
            ActivePlayer.Money += DiceTotal / 2;
            UpdateLabels();

        }
        /// <summary>
        /// return the worker to its owner's home box
        /// </summary>
        /// <param name="w"></param>
        public void ReturnWorker(Worker w)
        {
            LeaveAreaEvent(w);
            switch (w.Owner.PlayerNumber)
            {
                case 1:
                    w.Control.Location = GetRawLocation(Player1FrontEndDeveloperHomePictureBox);
                    break;
                case 2:
                    w.Control.Location = GetRawLocation(Player2FrontEndDeveloperHomePictureBox);
                    break;
                case 3:
                    w.Control.Location = GetRawLocation(Player3FrontEndDeveloperHomePictureBox);
                    break;
                case 4:
                    w.Control.Location = GetRawLocation(Player4FrontEndDeveloperHomePictureBox);
                    break;
            }
            EnterAreaEvent(w);
        }
        /// <summary>
        /// listener for getting resources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetTasklandButton_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            GetTaskResource();
        }

        private void GetTaskResource()
        {
            int numWorkers = 0;
            int typeMatches = 0;
            List<Worker> list = new List<Worker>(TaskWorkersList);
            foreach (Worker w in list)
            {
                if (w.Owner == ActivePlayer)
                {
                    numWorkers++;
                    if (w is FrontEndDeveloper && TaskTypeLabel.Text == "FE") { typeMatches++; }
                    if (w is BackEndDeveloper && TaskTypeLabel.Text == "BE") { typeMatches++; }
                    if (w is FullStackDeveloper && TaskTypeLabel.Text == "FS") { typeMatches++; }
                    ReturnWorker(w);
                }
            }
            DiceAmount.Text = numWorkers.ToString();
            RollDice();
            DiceTotal += typeMatches;
            int resourceNumber = DiceTotal / 3;
            if (resourceNumber > ResourceSupply[0])
            {
                resourceNumber = ResourceSupply[0];
            }
            ResourceSupply[0] -= resourceNumber;
            ActivePlayer.Resources[0] += resourceNumber;
            UpdateLabels();
        }
        /// <summary>
        /// listener for getting resources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetStorylandButton_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            GetStoryResource();
        }

        private void GetStoryResource()
        {
            int numWorkers = 0;
            int typeMatches = 0;
            List<Worker> list = new List<Worker>(StoryWorkersList);
            foreach (Worker w in list)
            {
                if (w.Owner == ActivePlayer)
                {
                    numWorkers++;
                    if (w is FrontEndDeveloper && StoryTypeLabel.Text == "FE") { typeMatches++; }
                    if (w is BackEndDeveloper && StoryTypeLabel.Text == "BE") { typeMatches++; }
                    if (w is FullStackDeveloper && StoryTypeLabel.Text == "FS") { typeMatches++; }
                    ReturnWorker(w);
                }
            }
            DiceAmount.Text = numWorkers.ToString();
            RollDice();
            DiceTotal += typeMatches;
            int resourceNumber = DiceTotal / 4;
            if (resourceNumber > ResourceSupply[1])
            {
                resourceNumber = ResourceSupply[1];
            }
            ResourceSupply[1] -= resourceNumber;
            ActivePlayer.Resources[1] += resourceNumber;
            UpdateLabels();
        }
        /// <summary>
        /// listener for getting resources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetFeatureLandButton_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            GetFeatureResource();
        }

        private void GetFeatureResource()
        {
            int numWorkers = 0;
            int typeMatches = 0;
            List<Worker> list = new List<Worker>(FeatureWorkersList);
            foreach (Worker w in list)
            {
                if (w.Owner == ActivePlayer)
                {
                    numWorkers++;
                    if (w is FrontEndDeveloper && FeatureTypeLabel.Text == "FE") { typeMatches++; }
                    if (w is BackEndDeveloper && FeatureTypeLabel.Text == "BE") { typeMatches++; }
                    if (w is FullStackDeveloper && FeatureTypeLabel.Text == "FS") { typeMatches++; }
                    ReturnWorker(w);
                }
            }
            DiceAmount.Text = numWorkers.ToString();
            RollDice();
            DiceTotal += typeMatches;
            int resourceNumber = DiceTotal / 5;
            if (resourceNumber > ResourceSupply[2])
            {
                resourceNumber = ResourceSupply[2];
            }
            ResourceSupply[2] -= resourceNumber;
            ActivePlayer.Resources[2] += resourceNumber;
            UpdateLabels();
        }

        /// <summary>
        /// listener for getting resources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetEpiclandButton_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            GetEpicResource();
        }

        private void GetEpicResource()
        {
            int numWorkers = 0;
            int typeMatches = 0;
            List<Worker> list = new List<Worker>(EpicWorkersList);
            foreach (Worker w in list)
            {
                if (w.Owner == ActivePlayer)
                {
                    numWorkers++;
                    if (w is FrontEndDeveloper && EpicTypeLabel.Text == "FE") { typeMatches++; }
                    if (w is BackEndDeveloper && EpicTypeLabel.Text == "BE") { typeMatches++; }
                    if (w is FullStackDeveloper && EpicTypeLabel.Text == "FS") { typeMatches++; }
                    ReturnWorker(w);
                }
            }
            DiceAmount.Text = numWorkers.ToString();
            RollDice();
            DiceTotal += typeMatches;
            int resourceNumber = DiceTotal / 6;
            if (resourceNumber > ResourceSupply[3])
            {
                resourceNumber = ResourceSupply[3];
            }
            ResourceSupply[3] -= resourceNumber;
            ActivePlayer.Resources[3] += resourceNumber;
            UpdateLabels();
        }

        private void GetGoogleButton_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            GetGoogleResearch();
        }

        private void GetGoogleResearch()
        {
            if (ResearchSupply > 0)
            {
                ActivePlayer.UpgradeResearch();
                ResearchSupply--;
                UpdateLabels();
            }
            ReturnWorker(GoogleWorker);
            
        }

        private void GetJobFairButton_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            GetJobFairWorker();
            UpdateLabels();
        }

        private void GetJobFairWorker()
        {
            JobFairSelectionForm form = new JobFairSelectionForm();
            form.ShowDialog();
            List<Worker> list = new List<Worker>(JobFairWorkersList);
            foreach (Worker w in list)
            {
                ReturnWorker(w);
            }
        }

        private void GetBigWigsButton_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            GetBigWigBudget();
        }

        private void GetBigWigBudget()
        {
            ActivePlayer.UpgradeBudget();
            ReturnWorker(BigWigsWorker);
            UpdateLabels();
        }

        private void BuyClientCard1Button_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            BuyClientCard(1);
        }

        private void BuyClientCard(int StackNumber)
        {
            if ( StackNumber > 0 && StackNumber < 5)
            {
                ClientCardStacks[StackNumber - 1].Peek().BuyCard(ActivePlayer);
                ReturnWorker(ClientCardWorkerArray[StackNumber - 1]);
                if (ClientCardStacks[StackNumber - 1].Peek().Owner != null)
                {
                    ActivePlayer.ClientCardList.Add(ClientCardStacks[StackNumber - 1].Pop());
                    if (ClientCardStacks[StackNumber - 1].Count > 0)
                    {
                        ClientCardPictureBoxes[StackNumber - 1].Image = ClientCardStacks[StackNumber - 1].Peek().Image;
                    }
                    else
                    {
                        ClientCardPictureBoxes[StackNumber - 1].Image = null;
                    }
                    UpdateLabels();
                }
                
            }
            else
            {
                MessageBox.Show("Error: Invalid client number entered for BuyClientCard() on Main_Form.CS");
            }
            
        }

        private void BuyClientCard2Button_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            BuyClientCard(2);
        }

        private void BuyClientCard3button_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            BuyClientCard(3);
        }

        private void BuyClientCard4Button_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            BuyClientCard(4);
        }

        private void BuyTechnologyCard1Button_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            BuyTechnologyCard(1);
        }

        private void BuyTechnologyCard2Button_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            BuyTechnologyCard(2);
        }

        private void BuyTechnologyCard3Button_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            BuyTechnologyCard(3);
        }

        private void BuyTechnologyCard4Button_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            BuyTechnologyCard(4);
        }
        
        public void BuyTechnologyCard(int SlotNumber)
        {
            BuyCardForm form = new BuyCardForm(ActivePlayer, 0, 0, 0, 0, 5 - SlotNumber, 5 - SlotNumber, 0, 4);
            form.ShowDialog();
            if (form.Bought)
            {
                ActivePlayer.TechnologyCardList.Add(TechnologyCardSlots[SlotNumber - 1]);
                TechnologyCardSlots[SlotNumber - 1].Owner = ActivePlayer;
                TechnologyCardSlots[SlotNumber - 1].GetEvent();
                TechnologyCardSlots[SlotNumber - 1] = null;
                FillTechnologyCardSlots();
                ReturnWorker(TechnologyCardWorkerArray[SlotNumber - 1]);
            }
        }

        private void ReturnBuyingWorkers()
        {
            foreach (Worker w in ClientCardWorkerArray)
            {
                if (w != null)
                {
                    ReturnWorker(w);
                }
            }
            foreach (Worker w in TechnologyCardWorkerArray)
            {
                if (w != null)
                {
                    ReturnWorker(w);
                }
            }
        }

        public void EndGame()
        {
            List<Player> maxScore = new List<Player> { Players[0] };
            List<Player> maxTokens = new List<Player>();
            for (int i = 1; i < NumPlayers; i++)
            {
                Players[i].GetEndPoints();
                if (Players[i].Points > maxScore[0].Points)
                {
                    maxScore = new List<Player> { Players[i]};
                }
                else if (Players[i].Points == maxScore[0].Points)
                {
                    maxScore.Add(Players[i]);
                }
            }
            if (maxScore.Count == 1)
            {
                MessageBox.Show("Congratulations!!! " + maxScore[0].Name + " wins!!!!");
            }
            else if (maxScore.Count > 1)
            {
                maxTokens = new List<Player> { maxScore[0] };
                for (int i = 1; i < maxScore.Count; i++)
                {
                    if ((maxScore[i].Budget + maxScore[i].Research.Sum() + maxScore[i].WorkerList.Count) > (maxTokens[0].Budget + maxTokens[0].Research.Sum() + maxTokens[0].WorkerList.Count))
                    {
                        maxTokens = new List<Player> { maxScore[i] };
                    }
                    else if ((maxScore[i].Budget + maxScore[i].Research.Sum() + maxScore[i].WorkerList.Count) == (maxTokens[0].Budget + maxTokens[0].Research.Sum() + maxTokens[0].WorkerList.Count))
                    {
                        maxTokens.Add(maxScore[i]);
                    }
                }
                if (maxTokens.Count == 1)
                {
                    MessageBox.Show("Congratulations!!! " + maxTokens[0].Name + " wins!!!!");
                }
                else if (maxTokens.Count > 1)
                {
                    String winners = "";
                    foreach (Player p in maxTokens)
                    {
                        winners += p.Name + "  ";
                    }
                    MessageBox.Show("It's a TIE!!! Congratulations winners: " + winners + "!!");
                }
            }
            UpdateLabels();
            PhaseButton.Enabled = false;
        }

        private void volumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioController audioUI = new AudioController();
            AudioController.audio.Play();

            audioUI.ShowDialog();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioController.audio.Play();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioController.audio.Play();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void UpdateColors()
        {
            foreach (Worker w in WorkersList)
            {
                if (w.Owner != null)
                {
                    w.Control.BackColor = w.Owner.Color;
                }
            }
            Player1Panel.BackColor = Players[0].Color;
            Player1BudgetPictureBox.BackColor = Players[0].Color;
            Player1PointProgressBar.ForeColor = Players[0].Color;
            Player1PointsFeedPictureBox.BackColor = Players[0].Color;
            Player2Panel.BackColor = Players[1].Color;
            Player2BudgetPictureBox.BackColor = Players[1].Color;
            Player2PointProgressBar.ForeColor = Players[1].Color;
            Player2PointsFeedPictureBox.BackColor = Players[1].Color;
            if (NumPlayers > 2)
            {
                Player3Panel.BackColor = Players[2].Color;
                Player3BudgetPictureBox.BackColor = Players[2].Color;
                Player3PointProgressBar.ForeColor = Players[2].Color;
                Player3PointsFeedPictureBox.BackColor = Players[2].Color;
            }
            if (NumPlayers > 3)
            {
                Player4Panel.BackColor = Players[3].Color;
                Player4BudgetPictureBox.BackColor = Players[3].Color;
                Player4PointProgressBar.ForeColor = Players[3].Color;
                Player4PointsFeedPictureBox.BackColor = Players[3].Color;
            }
        }

        private void Player1ColorWheelPictureBox_Click(object sender, EventArgs e)
        {
            Players[0].ChangeColor();
            UpdateColors();
        }

        private void Player2ColorWheelPictureBox_Click(object sender, EventArgs e)
        {
            Players[1].ChangeColor();
            UpdateColors();
        }

        private void Player4ColorWheelPictureBox_Click(object sender, EventArgs e)
        {
            Players[3].ChangeColor();
            UpdateColors();
        }

        private void Player3ColorWheelPictureBox_Click(object sender, EventArgs e)
        {
            Players[2].ChangeColor();
            UpdateColors();
        }
    }
}
