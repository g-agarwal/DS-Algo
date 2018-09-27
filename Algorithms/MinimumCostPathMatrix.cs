using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparation
{
    class Driver
    {
        // Driver Program
        public static void Main()
        {
            MinimumCostPathMatrix matrix = new MinimumCostPathMatrix(3, 3);

            int minimumCost = matrix.MinimumCost(2, 2);
            Console.WriteLine("Minimum Cost = " + minimumCost);
            Console.Read();
        }
    }

    class MinimumCostPathMatrix
    {
        int Rows;
        int Columns;

        int[,] matrix;

        public MinimumCostPathMatrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            matrix = new int[Rows, Columns];

            // Initialize the Matrix with some random values
            Random rand = new Random();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    matrix[i, j] = rand.Next(1, Rows * columns);
                    Console.Write(matrix[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }


        public int MinimumCost(int row, int column)
        {
            if (row < 0 || column < 0)
            {
                return int.MaxValue;
            }

            if (row == 0 && row == 0)
            {
                return matrix[row, row];
            }

            return matrix[row, column] + Math.Min(MinimumCost(row, column - 1), MinimumCost(row - 1, column));
        }
    }
}
