using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visualizer
{
    public struct FieldInfo
    {
        public bool[,] Grid;
        public int Width;
        public int Height;
    }

    public partial class GameForm : Form
    {
        public Graphics graphics;
        FieldInfo fieldInfo;
        private uint CurrentGeneration;

        public GameForm()
        {
            InitializeComponent();
        }

        private void Density_ValueChanged(object sender, EventArgs e)
        {

        }

        private void StartGame()
        {
            CurrentGeneration = 0;
            Text = $"Current generation {CurrentGeneration}";

            Density.Enabled = false;
            Zoom.Enabled = true;

            fieldInfo = new FieldInfo { Height = (int)(Field.Height / Convert.ToSingle(Zoom.Value)), Width = (int)(Field.Width / Convert.ToSingle(Zoom.Value)), Grid = new bool[Width, Height] };

            Random random = new Random();
            for (int x = 0; x < fieldInfo.Width; ++x)
            {
                for (int y = 0; y < fieldInfo.Height; ++y)
                {
                    fieldInfo.Grid[x, y] = (random.Next(Convert.ToInt32((int)Density.Value)) <= 1);
                }
            }

            Field.Image = new Bitmap(Field.Width, Field.Height);
            graphics = Graphics.FromImage(Field.Image);

            Timer.Start();
        }

        private short QuantityOfNeightbours(int x, int y)
        {
            short quantity = 0;
            bool IsAlive;

            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; j++)
                {
                    IsAlive = fieldInfo.Grid[(x + i + fieldInfo.Width) % fieldInfo.Width, (y + j + fieldInfo.Height) % fieldInfo.Height];

                    if (IsAlive && !(i == 0 && j == 0))
                        quantity++;
                }
            }

            return quantity;
        }
        private void EvaluateNextGeneration()
        {
            graphics.Clear(Color.Black);

            var newGrid = new bool[fieldInfo.Width, fieldInfo.Height];

            bool IsAlive;
            for (int x = 0; x < fieldInfo.Width; ++x)
            {
                for (int y = 0; y < fieldInfo.Height; ++y)
                {
                    IsAlive = fieldInfo.Grid[x, y];

                    if (!IsAlive && QuantityOfNeightbours(x, y) == 3)
                    {
                        newGrid[x, y] = true;
                    }
                    else if (IsAlive && (QuantityOfNeightbours(x, y) < 2 || QuantityOfNeightbours(x, y) > 3))
                    {
                        newGrid[x, y] = false;
                    }
                    else
                    {
                        newGrid[x, y] = fieldInfo.Grid[x, y];
                    }

                    if (IsAlive)
                    {
                        graphics.FillRectangle(Brushes.Crimson, x * Convert.ToSingle(Zoom.Value), y * Convert.ToSingle(Zoom.Value), Convert.ToSingle(Zoom.Value), Convert.ToSingle(Zoom.Value));
                    }
                }
            }

            fieldInfo.Grid = newGrid;
            Text = $"Current generation {++CurrentGeneration}";
            Field.Refresh();
        }

        private void PauseGame()
        {
            if (!Timer.Enabled)
            {
                Timer.Start();
                return;
            }

            Timer.Stop();
            Density.Enabled = true;
        }

        //TODO: Add slow
        private void TimerTick(object sender, EventArgs e)
        {
            EvaluateNextGeneration();
        }

        private void StartGameButton(object sender, EventArgs e)
        {
            if (GenerateButton.Text != "generate again")
                GenerateButton.Text = "generate again";

            if (Timer.Enabled)
            {
                graphics.Clear(Color.Black);
                Timer.Stop();
            }

            StartGame();
        }

        private void PauseGameButton(object sender, EventArgs e)
        {
            if (Timer.Enabled)
                PauseFrameButton.Text = "resume";
            else PauseFrameButton.Text = "pause frame";

            PauseGame();
        }

        private bool MouseInsideField(int x, int y)
        {
            return x >= 0 && y >= 0 && x < fieldInfo.Width && y < fieldInfo.Height;
        }
        private void InteractByMouse(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var x = e.X / Convert.ToSingle(Zoom.Value);
                var y = e.Y / Convert.ToSingle(Zoom.Value);

                if (MouseInsideField((int)x, (int)y))
                    fieldInfo.Grid[(int)x, (int)y] = true;
            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.X / Convert.ToSingle(Zoom.Value);
                var y = e.Y / Convert.ToSingle(Zoom.Value);

                if (MouseInsideField((int)x, (int)y))
                    fieldInfo.Grid[(int)x, (int)y] = false;
            }
        }
    }
}
