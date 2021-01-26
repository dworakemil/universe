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

        public static int[,] operator + ( Matrix m1, Matrix m2 )
        {
            int[,] m3 = new int[m1.GetLength(0), m1.GetLength(1)];
            return  m3;
        }

        public int GetLength( int slot ) 
        {
            return matrix.GetLength( slot );
        }

        public void PrintMatrix() {
            Console.WriteLine(' '); // add newline
            Console.WriteLine("Oryginalna macierz");
            for (int i = 0; i < matrix.GetLength(1); i++) { // for every vertical line
                for (int j = 0; j < matrix.GetLength(0); j++) { // and for every horizontal line
                    Console.Write(matrix[j, i]); // print proper value
                    Console.Write(' '); // print some spaces to make things look better
                }
                Console.WriteLine(' '); // add newline
            }
            Console.WriteLine(' '); // add newline
        }
        public void PrintTransposedMatrix() {
            Console.WriteLine(' '); // add newline
            Console.WriteLine("Transponowana macierz");
            for (int i = 0; i < matrix.GetLength(0); i++) { // for every vertical line
                for (int j = 0; j < matrix.GetLength(1); j++) { // and for every horizontal line
                    Console.Write(matrix[i, j]); // print proper value
                    Console.Write(' '); // print some spaces to make things look better
                }
                Console.WriteLine(' '); // add newline
            }
            Console.WriteLine(' '); // add newline
        }
    }

    class Program 
    {
        static void Main(string[] args) {
            while( true )
            {
                string menuSelection = "n";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //get desktop path
                string matrixFileName = "matrix/1.txt"; // name of file containing matrix
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


            /* MENU */
                Console.WriteLine( "Wcisnij klawisz odpowiadajacy odpowiedniej funkcji menu" );
                Console.WriteLine( "o - Wyswietl oryginalna macierz" );
                Console.WriteLine( "t - Wyswietl transponowana macierz" );
                Console.WriteLine( "a - Dodaj macierze" );
                Console.WriteLine( "c - Wyczysc konsole" );
                Console.WriteLine( "x - Wyjdz z programu" );

                Console.Write("Wybor: " );
                menuSelection = Console.ReadKey().Key.ToString();
                Console.WriteLine(' '); // add newline

                switch ( menuSelection ) {
                    case "O":
                        matrix.PrintMatrix();
                        break;
                    case "T":
                        matrix.PrintTransposedMatrix();
                        break;
                    case "A":
                        matrix.PrintTransposedMatrix();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        System.Environment.Exit(1) ;
                        break;
                    default:
                        Console.WriteLine( "Nie wybrano poprawnej opcji. \nWcisnij klawisz na klawiaturze odpowiadajacy literze poprzedzajacej znak \"-\" w menu powyzej" );
                        break;
                }
            /* END OF MENU */


                Console.WriteLine("\n\nWcisnij dowolny klawisz by zaczac od nowa");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
