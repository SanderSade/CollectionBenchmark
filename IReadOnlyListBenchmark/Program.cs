using System;
using System.Linq;
using BenchmarkDotNet.Running;

namespace IReadOnlyListBenchmark // Note: actual namespace depends on the project name.
{
	public class Program
	{
		public static void Main(string[] args)
		{
			
			var summary = BenchmarkRunner.Run<Benchmarks>();

			Console.WriteLine(summary.AllRuntimes);
			Console.ReadKey();
		}
	}
}