﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysMath = System.Math;

namespace Descartes.MathEx.Statistics
{
	[TestClass]
	public class BaseStatisticsTest
	{
		[TestMethod]
		public void TestMedian()
		{
			Assert.AreEqual<double>(1.0, BaseStatistics.Median(new double[] { 1.0 }));

			Assert.AreEqual<double>(3.0, BaseStatistics.Median(new double[] { 2.0, 4.0 }));

			Assert.AreEqual<double>(5.0, BaseStatistics.Median(new double[] { 1.0, 5.0, 8.0 }));

			Assert.AreEqual<double>(7.0, BaseStatistics.Median(new double[] { 4.0, 8.0, 6.0, 12.0 }));
		}

		[TestMethod]
		public void TestMode()
		{
			var mode1 = BaseStatistics.Mode(new double[] { 2.0 });
			Assert.AreEqual<int>(1, mode1.Count());
			Assert.AreEqual<double>(2.0, mode1.ElementAt(0));

			var mode2 = BaseStatistics.Mode(new double[] { 1.0, 3.0, 3.0, 5.0, 7.0 });
			Assert.AreEqual<int>(1, mode2.Count());
			Assert.AreEqual<double>(3.0, mode2.ElementAt(0));

			var mode3 = BaseStatistics.Mode(new double[] { 1.2, 3.7, 3.7, 4.3, 7.8, 7.8, 8.2 });
			Assert.AreEqual<int>(2, mode3.Count());
			Assert.AreEqual<double>(3.7, mode3.ElementAt(0));
			Assert.AreEqual<double>(7.8, mode3.ElementAt(1));
		}

		[TestMethod]
		public void TestVariance()
		{
			var array1 = new double[] { 10, 13, 8, 15, 8 };
			var var1 = BaseStatistics.Variance(array1, VarianceType.Sample);
			var var2 = BaseStatistics.Variance(array1, VarianceType.Unbiased);

			Assert.AreEqual<double>(7.76, SysMath.Round(var1, 2));
			Assert.AreEqual<double>(9.70, SysMath.Round(var2, 2));
		}

		[TestMethod]
		public void TestStdDev()
		{
			var array1 = new double[] { 10, 13, 8, 15, 8 };
			var stdDev1 = BaseStatistics.StdDev(array1, VarianceType.Sample);
			var stdDev2 = BaseStatistics.StdDev(array1, VarianceType.Unbiased);

			Assert.AreEqual<double>(2.785678, SysMath.Round(stdDev1, 6));
			Assert.AreEqual<double>(3.114482, SysMath.Round(stdDev2, 6));
		}

		[TestMethod]
		public void TestStdScore()
		{
			var array1 = new double[] {
				13, 14, 7, 12, 10, 6, 8, 15, 4, 14,
				9, 6, 10, 12, 5, 12, 8, 8, 12, 15
			};
			var stdScore1 = BaseStatistics.StdScore(array1);

			stdScore1.ToList().ForEach(x => Console.WriteLine(SysMath.Round(x, 5).ToString("F5")));
		}

		[TestMethod]
		public void TestSkewness()
		{
			var data = new double[] { 1.89, 2.43, 2.37, 2.3, 1.74 };
			var skewness1 = BaseStatistics.Skewness(data, SkewnessType.Moment);
			var skewness2 = BaseStatistics.Skewness(data, SkewnessType.Fisher);

			Assert.AreEqual<double>(-0.3075402, Math.Round(skewness1, 7));
			Assert.AreEqual<double>(-0.3075402, Math.Round(skewness1, 7));
			Assert.AreEqual<double>(1.52567, Math.Round(skewness2, 5));
		}

		[TestMethod]
		public void TestKurtosis()
		{
			var data = new double[] { 1.89, 2.43, 2.37, 2.3, 1.74 };
			var kurtosis = BaseStatistics.Kurtosis(data);
			var kurtosis1 = BaseStatistics.Kurtosis(data, KurtosisType.Excess);
			var kurtosis2 = BaseStatistics.Kurtosis(data, KurtosisType.Moment);
			var kurtosis3 = BaseStatistics.Kurtosis(data, KurtosisType.Fisher);

			Assert.AreEqual<double>(-2.113382, Math.Round(kurtosis, 6));
			Assert.AreEqual<double>(-2.113382, Math.Round(kurtosis1, 6));
			Assert.AreEqual<double>(0.8866177, Math.Round(kurtosis2, 7));
			Assert.AreEqual<double>(-3.755223, Math.Round(kurtosis3, 6));
		}

		[TestMethod]
		public void TestCovariance()
		{
			var data1 = new double[] {
				6, 10, 6, 10, 5, 3, 5, 9, 3, 3,
				11, 6, 11, 9, 7, 5, 8, 7, 7, 9
			};
			var data2 = new double[] {
				10, 13, 8, 15, 8, 6, 9, 10, 7, 3,
				18, 14, 18, 11, 12, 5, 7, 12, 7, 7
			};

			var cov1 = BaseStatistics.Covariance(data1, data2, VarianceType.Sample);
			var cov2 = BaseStatistics.Covariance(data1, data2, VarianceType.Unbiased);

			Assert.AreEqual<double>(7.55, Math.Round(cov1, 2));
			Assert.AreEqual<double>(7.947368, Math.Round(cov2, 6));
		}

		[TestMethod]
		public void TestCorrelation()
		{
			var data1 = new double[] {
				6, 10, 6, 10, 5, 3, 5, 9, 3, 3,
				11, 6, 11, 9, 7, 5, 8, 7, 7, 9
			};
			var data2 = new double[] {
				10, 13, 8, 15, 8, 6, 9, 10, 7, 3,
				18, 14, 18, 11, 12, 5, 7, 12, 7, 7
			};

			var cor = BaseStatistics.Correlation(data1, data2);

			Assert.AreEqual<double>(0.749659, Math.Round(cor, 6));
		}

		[TestMethod]
		public void Test01()
		{
			var xvar = new double[] {
				107, 336, 233, 82, 61, 378, 129, 313, 142, 428
			};
			var yvar = new double[] {
				286, 851, 589, 389, 158, 1037, 463, 563, 372, 1020
			};

			Assert.AreEqual<double>(2209.0, xvar.Sum());
			var v = BaseStatistics.Variance(xvar);
			var cov = BaseStatistics.Covariance(xvar, yvar);
			var b = cov / v;
			var b2 = BaseStatistics.Correlation(xvar, yvar);
			Console.WriteLine(b2);

			var a_num =
				xvar.Select(x => x * x).Sum() * yvar.Sum() -
				xvar.Select((x, i) => x * yvar.ElementAt(i)).Sum() * xvar.Sum();
			var a_dnm =
				xvar.Count() * xvar.Select(x => x * x).Sum() -
				xvar.Sum() * xvar.Sum();
			var a = a_num / a_dnm;
			Console.WriteLine(a);
		}
	}
}
