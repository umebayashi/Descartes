using System;
using System.Collections.Generic;
using System.Linq;

namespace Descartes.MathEx
{
	public static class MathExtension
	{
		public static int Factorial(this int n)
		{
			if (n == 1)
			{
				return 1;
			}
			else
			{
				return n * Factorial(n - 1);
			}
		}

		public static long Factorial(this long n)
		{
			if (n == 1)
			{
				return 1;
			}
			else
			{
				return n * Factorial(n - 1);
			}
		}
	}
}
