using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace IReadOnlyListBenchmark
{
	[SimpleJob(launchCount: 1, warmupCount: 3, targetCount: 10, runtimeMoniker: RuntimeMoniker.Net60)]
	[SimpleJob(launchCount: 1, warmupCount: 3, targetCount: 10, runtimeMoniker: RuntimeMoniker.Net472)]
	[MarkdownExporterAttribute.GitHub]
	[MemoryDiagnoser]
	public class Benchmarks
	{
		private static readonly List<Guid> TestList;
		private static readonly Guid Splitter;
		private static readonly ImmutableArray<Guid> TestArray;
		private static readonly IReadOnlyList<Guid> TestIReadonlyList;
		private static readonly ImmutableList<Guid> TestImmutableList;


		static Benchmarks()
		{
			TestList = Enumerable.Range(0, 1_000_000).Select(_ => Guid.NewGuid()).ToList();
			TestIReadonlyList = TestList;
			TestArray = ImmutableArray.CreateRange(TestList);
			TestImmutableList = ImmutableList.CreateRange(TestList);
			Splitter = Guid.NewGuid();
		}


		[Benchmark]
		public void RunListForeach()
		{
			var resultList = new List<Guid>(TestList.Count / 2);
			foreach (var guid in TestList)
			{
				if (guid.CompareTo(Splitter) > 0)
				{
					resultList.Add(guid);
				}
			}

			var results = resultList;
		}


		[Benchmark]
		public void RunListFor()
		{
			var resultList = new List<Guid>(TestList.Count / 2);
			for (var i = 0; i < TestList.Count; i++)
			{
				var guid = TestList[i];
				if (guid.CompareTo(Splitter) > 0)
				{
					resultList.Add(guid);
				}
			}

			var results = resultList;
		}


		[Benchmark]
		public void RunIReadOnlyListForeach()
		{
			var resultList = new List<Guid>(TestIReadonlyList.Count / 2);
			foreach (var guid in TestIReadonlyList)
			{
				if (guid.CompareTo(Splitter) > 0)
				{
					resultList.Add(guid);
				}
			}

			var results = resultList;
		}


		[Benchmark]
		public void RunIReadOnlyListFor()
		{
			var resultList = new List<Guid>(TestIReadonlyList.Count / 2);
			for (var i = 0; i < TestIReadonlyList.Count; i++)
			{
				var guid = TestIReadonlyList[i];
				if (guid.CompareTo(Splitter) > 0)
				{
					resultList.Add(guid);
				}
			}

			var results = resultList;
		}


		[Benchmark]
		public void RunImmutableArrayForeach()
		{
			var resultList = new List<Guid>(TestArray.Length / 2);
			foreach (var guid in TestArray)
			{
				if (guid.CompareTo(Splitter) > 0)
				{
					resultList.Add(guid);
				}
			}

			var results = resultList;
		}


		[Benchmark]
		public void RunImmutableArrayFor()
		{
			var resultList = new List<Guid>(TestArray.Length / 2);
			for (var i = 0; i < TestArray.Length; i++)
			{
				var guid = TestArray[i];
				if (guid.CompareTo(Splitter) > 0)
				{
					resultList.Add(guid);
				}
			}

			var results = resultList;
		}


		[Benchmark]
		public void RunImmutableListForeach()
		{
			var resultList = new List<Guid>(TestImmutableList.Count / 2);
			foreach (var guid in TestImmutableList)
			{
				if (guid.CompareTo(Splitter) > 0)
				{
					resultList.Add(guid);
				}
			}

			var results = resultList;
		}


		[Benchmark]
		public void RunImmutableListFor()
		{
			var resultList = new List<Guid>(TestImmutableList.Count / 2);
			for (var i = 0; i < TestImmutableList.Count; i++)
			{
				var guid = TestImmutableList[i];
				if (guid.CompareTo(Splitter) > 0)
				{
					resultList.Add(guid);
				}
			}

			var results = resultList;
		}
	}
}