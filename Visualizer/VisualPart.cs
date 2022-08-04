using System;
using System.Drawing;
using System.Windows.Forms;
using Engine;

namespace Visualizer
{
    public partial class GameForm : Form
    {
        public Graphics graphics;
        private GameOfLife game;
        private const uint RESTRICTION = 400;

        public GameForm()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            Density.Enabled = false;
            Zoom.Enabled = true;

            game = new GameOfLife
            (
                height: (int)(Field.Height / Convert.ToSingle(Zoom.Value)),
                width: (int)(Field.Width / Convert.ToSingle(Zoom.Value)),
                populationDensity: (uint)Density.Value
            );


            

            Text = $"Current generation {game.CurrentGeneration}";

            Field.Image = new Bitmap(Field.Width, Field.Height);
            graphics = Graphics.FromImage(Field.Image);

            Timer.Start();
        }

        private void DrawNextGeneration()
        {
            graphics.Clear(Color.Black);

            var CurrentField = game.GetCurrentFieldState();
            game.EvaluateNextGeneration();


            for (int x = 0; x < CurrentField.GetLength(0); ++x)
            {
                for (int y = 0; y < CurrentField.GetLength(1); ++y)
                {
                    bool IsAlive = CurrentField[x, y];
                    if (IsAlive)
                    {
                        graphics.FillRectangle(Brushes.Crimson, x * Convert.ToSingle(Zoom.Value), y * Convert.ToSingle(Zoom.Value), Convert.ToSingle(Zoom.Value) - 1, Convert.ToSingle(Zoom.Value) - 1);
                    }
                }
            }

            Text = $"Current generation {game.CurrentGeneration}";
            Field.Refresh();
        }

        private void PauseGame()
        {
            if (!Timer.Enabled)
            {
                Timer.Start();
                Density.Enabled = false;
                return;
            }

            Density.Enabled = true;

            Timer.Stop();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Timer.Interval = (int)(RESTRICTION / Speed.Value);
            DrawNextGeneration();
        }

        private void StartGameButton(object sender, EventArgs e)
        {
            GenerateButton.Text = "generate again";
            PauseFrameButton.Text = "pause frame";

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

        private void DrawtByMouse(object sender, MouseEventArgs mouse)
        {
            var x = mouse.X / Convert.ToSingle(Zoom.Value);
            var y = mouse.Y / Convert.ToSingle(Zoom.Value);

            if (mouse.Button == MouseButtons.Left)
            {
                game.AddCell((int)x, (int)y);
            }

            if (mouse.Button == MouseButtons.Right)
            {
                game.EraseCell((int)x, (int)y);
            }
        }
    }
}
