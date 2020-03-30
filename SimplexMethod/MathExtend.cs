using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class MathExtend
    {
        public static double Nod(double a, double b)
        {
            if (b < 0)
                b = -b;
            if (a < 0)
                a = -a;
            while (b > 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static double Nok(double a, double b)
        {
            return Math.Abs(a * b) / MathExtend.Nod(a, b);
        }

        public static void MultipleMatrixRow(ref double[,] matrix, double k, int rowNum)
        {
            for (int i = 0; i <= matrix.GetUpperBound(1); i++)
            {
                matrix[rowNum, i] = matrix[rowNum, i] * k;
            }
            
        }

        public static void SumMatrixRows(ref double[,] matrix, int resourseRow, int targetRow)
        {
            for (int i = 0; i <= matrix.GetUpperBound(1); i++)
            {
                matrix[targetRow, i] += matrix[resourseRow, i];
            }
        }

        public static void Jordan(ref double[,] matrix, int resourseRow, int resourseColumn)
        {
            double solvingElem = matrix[resourseRow, resourseColumn];

            for(int i = 1; i < matrix.GetUpperBound(1); i++)
            {
                matrix[resourseRow, i] = matrix[resourseRow, i] / solvingElem;
            }

            MultipleMatrixRow(ref matrix, -1, resourseRow);

            for (int i = 0; i < matrix.GetUpperBound(0); i++)
            {
                if (i == resourseRow) continue;

                double k = matrix[i, resourseColumn];
                if (k == 0) continue;

                MultipleMatrixRow(ref matrix, k, resourseRow);
                SumMatrixRows(ref matrix, resourseRow, i);
                MultipleMatrixRow(ref matrix, 1/k, resourseRow);
            }

            MultipleMatrixRow(ref matrix, -1, resourseRow);
        }

        public static T[,] Copy<T>(T[,] array)
        {
            T[,] newArray = new T[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    newArray[i, j] = array[i, j];
            return newArray;
        }

        public static T[,] ListTo2DArr<T>(List<T[]> list)
        {
            int dimension = list[0].Length;
            T[,] arr = new T[list.Count, dimension];
            int i = 0;
            foreach(T[] row in list)
            {
                if (row.Length > dimension)
                    throw new ArgumentOutOfRangeException("Вы подали список не представимый в виде матрицы");

                int j = 0;
                foreach(T elem in row)
                {
                    arr[i, j] = elem;
                    j++;
                }
                i++;
            }

            return arr;
        }
    }
}
