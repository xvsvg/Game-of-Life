using System;

namespace Engine
{
    public struct FieldInfo
    {
        public bool[,] Grid;
        public readonly int Width;
        public readonly int Height;

        public FieldInfo(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new bool[width, height];
        }
    }

    class GameOfLife
    {
        private FieldInfo fieldInfo;
        public uint CurrentGeneration { get; private set; }

        public uint PopulationDensity { get; private set; }

        private const uint CHANCE_OF_BEARING = 1;

        public GameOfLife(int width, int height, uint populationDensity)
        {
            fieldInfo = new FieldInfo(width, height);
            PopulationDensity = populationDensity;
            CurrentGeneration = 0;

            Random random = new Random();
            for (int x = 0; x < fieldInfo.Width; ++x)
            {
                for (int y = 0; y < fieldInfo.Height; ++y)
                {
                    fieldInfo.Grid[x, y] = (random.Next((int)populationDensity) <= CHANCE_OF_BEARING);
                }
            }
        }

        public bool[,] GetCurrentFieldState()
        {
            var support = new bool[fieldInfo.Width, fieldInfo.Height];

            for (int i = 0; i < fieldInfo.Grid.GetLength(0); ++i)
            {
                for (int j = 0; j < fieldInfo.Grid.GetLength(1); ++j)
                {
                    support[i, j] = fieldInfo.Grid[i, j];
                }
            }

            return support;
        }

        /// <summary>
        /// Using Moores neighborhood
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method uses standard game rules, declared on official web-page
        /// </summary>
        public void EvaluateNextGeneration()
        {

            var newGrid = new bool[fieldInfo.Width, fieldInfo.Height];

            for (int x = 0; x < fieldInfo.Width; ++x)
            {
                for (int y = 0; y < fieldInfo.Height; ++y)
                {
                    bool IsAlive = fieldInfo.Grid[x, y];

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
                }
            }

            fieldInfo.Grid = newGrid;
            CurrentGeneration++;
        }

        private bool PointInsideField(int x, int y)
        {
            return x >= 0 && y >= 0 && x < fieldInfo.Width && y < fieldInfo.Height;
        }

        private void UpdateCell(int x, int y, bool state)
        {
            if (PointInsideField(x, y))
            {
                fieldInfo.Grid[x, y] = state;
            }
        }

        public void AddCell(int x, int y)
        {
            UpdateCell(x, y, state: true);
        }

        public void EraseCell(int x, int y)
        {
            UpdateCell(x, y, state: false);
        }

    }
}
