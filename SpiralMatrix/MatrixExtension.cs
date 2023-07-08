using System;

namespace SpiralMatrix
{
    /// <summary>
    /// Matrix manipulation.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Fills the matrix with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix size.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when matrix size less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size cannot be less or equal zero");
            }

            int[,] matrix = new int[size, size];

            int num = 1;
            int rowStart = 0;
            int rowEnd = size - 1;
            int colStart = 0;
            int colEnd = size - 1;

            while (num <= size * size)
            {
                for (int i = colStart; i <= colEnd; i++)
                {
                    matrix[rowStart, i] = num;
                    num++;
                }

                rowStart++;

                for (int i = rowStart; i <= rowEnd; i++)
                {
                    matrix[i, colEnd] = num;
                    num++;
                }

                colEnd--;

                for (int i = colEnd; i >= colStart; i--)
                {
                    matrix[rowEnd, i] = num;
                    num++;
                }

                rowEnd--;
                for (int i = rowEnd; i >= rowStart; i--)
                {
                    matrix[i, colStart] = num;
                    num++;
                }

                colStart++;
            }

            return matrix;
        }
    }
}
