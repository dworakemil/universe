using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;  

namespace _2_calki
{
	class Rectangle
		{
			private double a;
			private double h;

			public Rectangle( double a, double h=0 )
			{
				this.a = a;
				this.h = h;
			}

			public double ReturnArea()
			{
				return (a*h);
			}
		}


	class Program
	{
		public static double ReturnHeight( double xMult, double xPosition, double yPosition )
		{
			double value = xMult * xPosition + yPosition;
			return value;
		}

		static void Main(string[] args)
		{
			bool goFurther = false; // if false - loop asking for function
			string x = "";
			string y = "";

			while( true )
			{
				
				while( !goFurther )
				{
					Console.WriteLine( "Wpisz funkcje zgodnie ze wzorem <liczba>x+<liczba> np 2x+1 lub 3x-2" );
					string operation = Console.ReadLine();
			
					string[] operands = Regex.Split( operation, @"\+|\-" );
					// if correct split was done
					if( operands.Length == 2 ){
						operands[0] = Regex.Replace( operands[0], "x", "" );

						Console.WriteLine( operands[1] );
						// var goFurther will let program get out of loop
						goFurther = true;
						x = operands[0];
						y = operands[1];
					}
				}

				Console.WriteLine( "Wpisz zakres calkowania" );
				Console.WriteLine( "Od " );
				string rangeFrom_ = Console.ReadLine();
				Console.WriteLine( "Do " );
				string rangeTo_ = Console.ReadLine();

				
				int rangeFrom = 0;
				int rangeTo = 3;
				int xMult = 0;
				int yValue = 0;
				try
				{
					rangeFrom = Convert.ToInt32( Regex.Match( rangeFrom_, @"\d+").Value );
					rangeTo = Convert.ToInt32( Regex.Match( rangeTo_, @"\d+").Value );

					
					xMult = Convert.ToInt32( Regex.Match( x, @"\d+").Value );
					yValue = Convert.ToInt32( Regex.Match( y, @"\d+").Value );
				}
				catch( FormatException ){};


				int accuracy = 10;
				double area = 0;

				Console.WriteLine( "liczymy y={0}x+{1}", xMult, yValue );
				Console.WriteLine( "przedzial {0} do {1}", rangeFrom, rangeTo );

			

				double rect_a = (double)(rangeTo - rangeFrom)/accuracy ;

			
				//Console.WriteLine( "{0} do {1}, dokladnosc {2}. Wynik {3}", rangeFrom, rangeTo, accuracy, rect_a );
			
				for( int i=0; i < accuracy; i++ )
				{
					double rect_center = Math.Round( (rect_a / 2 + i*rect_a ), 3 );
					Console.WriteLine( rect_center );
					double height = ReturnHeight( xMult, rect_center, yValue );
					Rectangle rect = new Rectangle( rect_a, height );

					area += rect.ReturnArea();

				}
			
				Console.WriteLine( area );
				goFurther = false;
				Console.WriteLine( "\n\nWcisnij dowolny klawisz by zaczac od nowa" );
				Console.ReadKey();
				Console.Clear();
				
			}
		}
	}
}
