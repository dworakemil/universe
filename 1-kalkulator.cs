using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Text.RegularExpressions;  

namespace Calculator
{
	class Calc
	{
		//variables
		public int a;
		public int b;


		// methods
		public void Add()
		{
			int res = a + b;
			Console.WriteLine( res );
		}
		public void Sub()
		{
			int res = a - b;
			Console.WriteLine( res );
		}
		public void Mul()
		{
			int res = 0;
			// make every number absolute and then insert proper symbol to final result
			int absa = Math.Abs(a);
			int absb = Math.Abs(b);
			bool negSym = true;
			int min = absb;
			int sec = absa; 
			if( absa < absb ){ min = absa; sec = absb; }
			
			if( (absa - a == 0 && absb - b == 0) || (absa - a != 0 && absb - b != 0) ){
				negSym = false;
			}

			for( int i = 0; i < min; i++ )
			{
				res += sec;
			}
			if( negSym ){ res = -res; } // inserting proper symbol
			Console.Write( res );
		}
		public void Div()
		{
			int absa = Math.Abs(a);
			int absb = Math.Abs(b);
			bool aNeg = false;
			bool bNeg = false;
			if( absa-a != 0 ){ aNeg = true; }
			if( absb-b != 0 ){ bNeg = true; }
			bool negSym = true;
			int res = 0;
			int rest = 0;
			while( absa >= absb )
			{
				absa -= absb;
				res++;
			}
			if( (aNeg && bNeg) || !aNeg && !bNeg ){
				negSym = false;
			}
			rest = absa;
			if( negSym ){ res = -res; }
			Console.Write( "{0}, reszta {1}", res, rest );
			
		}
		public void Sqrt()
		{
			int absa = Math.Abs(a);
			int absb = Math.Abs(b);
			bool negSym = false;
			int res = 1;
			int smallRes = 0;
			int inc = absa;
			if( absb > 1 ){
				for( int i = 1; i < absb; i++ )
				{
				
					for( int j = 0; j < inc; j++ )
					{
						smallRes += absa;
					}
					inc = smallRes;
					res = smallRes;
					smallRes = 0;
				}
			}
			else{
				res = a;
			}
			if( absb % 2 == 0 && absa-a!=0 ){ negSym = true; }
			if( negSym ){ res = -res; }
			Console.WriteLine( res );
			
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			while( true )
			{
				bool goFurther = false;
				int a = 0;
				int b = 0;
				char symbol = '.';

				Console.WriteLine( "Witaj podróżniku!" );
				Console.WriteLine( "Zapewne zmęczyłeś się już liczeniem wszystkiego w pamięci." );
				Console.WriteLine( "Pomogę Ci." );
				Console.WriteLine( "Mówią na mnie Kalkulator. Spełniam pragnienia liczb całkowitych (śmiertelnicy mówią na to \"liczenie liczb całkowitych\")" );
				Console.WriteLine( "Potrafie dodawac, odejmowac, mnozyc, dzielic oraz potegowac" );
				Console.WriteLine( "\nWpisz to, czego pragniesz, a ja powiem Ci jaka jest prawda." );
			

				// while user did not give proper data
				while( !goFurther ){
					Console.WriteLine( "poprawna forma zapisu pragnień: <liczba><znak><liczba> np 2+1 ; 2-1 ; 2*1 ; 2/1 ; 2^1");
					Console.WriteLine( "liczby ujemne można zapisać jako m<liczba> np m1 oznacza -1");
					// string given by user
					string operation = Console.ReadLine(); 
	// Converting (splitting) the string to numbers and symbol
					// split on any of these symbols +-/*^
					string[] operands = Regex.Split( operation, @"\+|\-|\/|\*|\^" );
					// if correct split was done
					if( operands.Length == 2 ){
						// var goFurther will let program get out of loop
						goFurther = true;
						// try and catch - avoid breaking program when converting string is invalid
						try
						{
							// first check if "m" appears in string, then 
							// convert to int everything that match regex with proper negative symbol
							if( Regex.Match( operands[0], @"m\d+").Length > 0 )
							{
								a = -Convert.ToInt32( Regex.Match( operands[0], @"\d+").Value );
							}
							else
							{
								a = Convert.ToInt32( Regex.Match( operands[0], @"\d+").Value );
							}
							if( Regex.Match( operands[01], @"m\d+").Length > 0 )
							{
								b = -Convert.ToInt32( Regex.Match( operands[1], @"\d+").Value );
							}
							else
							{
								b = Convert.ToInt32( Regex.Match( operands[1], @"\d+").Value );
							}

							// symbol is at position of (length of first operand)
							symbol = operation[ operands[0].Length ];
						}
						catch( FormatException ){};
					}
	// END OF converting
				
					Console.WriteLine();
					Console.Write( a );
					Console.Write( symbol );
					if( symbol == '^' ){b = Math.Abs(b); }
					Console.Write( b );
					Console.Write( " = " );
				
				}

				Calc calc = new Calc();
				calc.a = a;
				calc.b = b;
				switch( symbol )
				{
					case '+':
						calc.Add();
					break;
					case '-':
						calc.Sub();
					break;
					case '*':
						calc.Mul();
					break;
					case '/':
						calc.Div();
					break;
					case '^':
						calc.Sqrt();
					break;
				}
				Console.WriteLine( "\n\nWcisnij dowolny klawisz by zaczac od nowa" );
				Console.ReadKey();
				Console.Clear();
			}
		}
	}
}
