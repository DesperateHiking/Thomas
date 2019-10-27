using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TridiagonalMatrixAlgorithm
{
    class Program
    {
        static void ThomasMethod(double[,] mat)
        {
            var rows = mat.GetLength(0);
            var uArr = new double[rows + 1];
            var vArr = new double[rows + 1];
            var solution = new double[rows + 2];

            for (var i = 0; i < rows; i++)
            {
                uArr[i + 1] = GetU(uArr[i], mat[i, 0], mat[i, 1], mat[i, 2]);
                vArr[i + 1] = GetV(uArr[i], vArr[i], mat[i, 0], mat[i, 1], mat[i, 2], mat[i, 3]);
            }

            for (var i = rows; i >= 0; i--)
            {
                solution[i] = uArr[i] * solution[i + 1] + vArr[i];
            }

            for (var i = 1; i < solution.Length - 1; i++)
            {
                Console.WriteLine("X{0} = {1}", i, solution[i]);
            }
        }

        static double GetU(double U0, double a, double b, double c)
        {
            return -(c / (a * U0 + b));
        }

        static double GetV(double U0, double V0, double a, double b, double c, double d)
        {
            return (d - a * V0) / (a * U0 + b);
        }

        static void Main(string[] args)
        {
            var inputMatrix = new double[,] { { 0, -7, 2, 5 }, { 1, -12, -4, -8 }, { -1, 6, -1, -2 }, { 3, 5, 0, 4 } };
            ThomasMethod(inputMatrix);
        }
    }
}
