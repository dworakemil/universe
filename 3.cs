using System;
using System.IO;

namespace ConsoleApp
{
    
    class Matrix 
    {
        public int[,] matrix;
        public Matrix( int[,] matrix )
        {
            this.matrix = matrix; // set matrix
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(1); i++) { // for every vertical line
                for (int j = 0; j < matrix.GetLength(0); j++) { // and for every horizontal line
                    Console.Write(matrix[j, i]); // print proper value
                    Console.Write(' '); // print some spaces to make things look better
                }
                Console.WriteLine(' '); // add newline
            }
        }
    }

    class Program 
    {
        static void Main(string[] args) {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //get desktop path
            string matrixFileName = "matrix.txt"; // name of file containing matrix
            string matrixPath = desktopPath + '\\' + matrixFileName; // final path of file with matrix
            string[] lines = System.IO.File.ReadAllLines( matrixPath ); // all lines from matrix file
            string[] line = lines[0].Split( ' ' ); // line for counting x size of matrix

            int x = line.Length; // x - horizontal
            int y = lines.Length; // y - vertical
            int[,] tempMatrix = new int[ x, y ]; // start matrix, to make things easier
            for( int i = 0; i < y; i++ ) // for every vertical line
            {
                string[] lineHelper = lines[i].Split(' '); // do a split at space char

                for( int j = 0; j < x; j++ ) // for every horizontal char
                {
                    tempMatrix[ j, i ] = int.Parse( lineHelper[j] ); // set proper value in tempMatrix corresponding to value from lineHelper
                }
            }
            Matrix matrix = new Matrix(tempMatrix); // object magic. Create new matrix from tempMatrix
            matrix.PrintMatrix();


        }
    }
}
