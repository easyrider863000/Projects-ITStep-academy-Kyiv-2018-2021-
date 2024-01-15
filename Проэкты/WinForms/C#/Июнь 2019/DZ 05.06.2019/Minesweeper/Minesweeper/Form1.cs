using Minesweeper.Common;
using Minesweeper.Data;
using Minesweeper.Prism;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _fieldGenerator = new Dictionary<CurrentMode, Func<ICellDataProvider>>
            {
                { CurrentMode.Beginner, () => CreateRandomizedField(9, 9, 10) },
                { CurrentMode.Intermediate, () => CreateRandomizedField(16, 16, 40) },
                { CurrentMode.Expert, () => CreateRandomizedField(30, 16, 90) }
            };
            Text = "Minesweeper";
            Icon = new Icon(new Uri(@"icon.ico", UriKind.Relative).ToString());
            _timer = new Timer();
            _timer.Start();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Сапер";
            menuStrip1.Visible = false;
            menuStrip2.Visible = true;
        }
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Text = "Minesweeper";
            menuStrip2.Visible = false;
            menuStrip1.Visible = true;
        }






        private readonly IDictionary<CurrentMode, Func<ICellDataProvider>> _fieldGenerator;

        private readonly Timer _timer;

        private ICellDataProvider _dataProvider;

        private CurrentMode _currentMode = CurrentMode.Beginner;

        private int _bombsLeft;

        private int _secondsGone;

        private EmotionType _currentEmotionType;
        private enum CurrentMode
        {
            Beginner,

            Intermediate,

            Expert
        }

        /// <summary>
        /// How many bombs left.
        /// </summary>
        public int BombsLeft
        {
            get
            {
                return _bombsLeft;
            }

            set
            {
                _bombsLeft = value;
            }
        }

        /// <summary>
        /// Seconds gone from begin.
        /// </summary>
        public int SecondsGone
        {
            get
            {
                return _secondsGone;
            }

            set
            {
                _secondsGone = value;
            }
        }

        /// <summary>
        /// New game command.
        /// </summary>
        public DelegateCommand NewGameCommand { get; private set; }

        /// <summary>
        /// New game beginner command.
        /// </summary>
        public DelegateCommand BeginnerCommand { get; private set; }

        /// <summary>
        /// New game intermediate command.
        /// </summary>
        public DelegateCommand IntermediateCommand { get; private set; }

        /// <summary>
        /// New game expert command.
        /// </summary>
        public DelegateCommand ExpertCommand { get; private set; }

        /// <summary>
        /// Exit command.
        /// </summary>
        public DelegateCommand ExitCommand { get; private set; }

        /// <summary>
        /// About command.
        /// </summary>
        public DelegateCommand AboutCommand { get; private set; }

        /// <summary>
        /// Current emotion type.
        /// </summary>
        public EmotionType CurrentEmotionType
        {
            get
            {
                return _currentEmotionType;
            }

            set
            {
                _currentEmotionType = value;
            }
        }

        /// <summary>
        /// Mines field data provider.
        /// </summary>
        public ICellDataProvider DataProvider
        {
            get
            {
                return _dataProvider;
            }

            private set
            {
                _dataProvider = value;
            }
        }

        private ICellDataProvider CreateRandomizedField(int width, int height, int bombs)
        {
            var random = new Random();
            var randomField = new bool[height, width];

            for (int i = 0; i < bombs; i++)
            {
                do
                {
                    int randomX = random.Next(0, width);
                    int randomY = random.Next(0, height);

                    if (!randomField[randomY, randomX])
                    {
                        randomField[randomY, randomX] = true;
                        break;
                    }
                } while (true);
            }

            var provider = new StandardCellDataProvider(randomField);
            provider.Gameover += OnGameover;
            return provider;
        }

        private void OnGameover(object sender, GameArgs gameArgs)
        {
            if (gameArgs.EndType == EndType.ButtonPressed)
            {
                BombsLeft = DataProvider.BombsCount - gameArgs.Flagged;

                if (!_timer.Enabled)
                {
                    _timer.Start();
                }
            }

            if (gameArgs.EndType == EndType.YouHaveWon)
            {
                _timer.Stop();
                CurrentEmotionType = EmotionType.Win;
            }
            else if (gameArgs.EndType == EndType.YouHaveLost)
            {
                _timer.Stop();
                CurrentEmotionType = EmotionType.Lose;
            }
        }

        private void NewGame(CurrentMode newMode)
        {
            _currentMode = newMode;
            NewGame();
        }

        private void NewGame()
        {
            if (DataProvider != null)
            {
                DataProvider.Gameover -= OnGameover;
            }

            CurrentEmotionType = EmotionType.Common;
            DataProvider = _fieldGenerator[_currentMode]();
            SecondsGone = 0;
            BombsLeft = DataProvider.BombsCount;
            _timer.Stop();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame(CurrentMode.Beginner);
        }
    }
}
