# Benchmarking some collections

tl;dr: avoid IReadOnlyList and ImmutableList. For-cycle is about equal for List and ImmutableArray, but the second has added benefit of being thread-safe.


``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  Job-XTRMDK : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT

IterationCount=10  LaunchCount=1  WarmupCount=3

```
|                   Method |        Job |              Runtime |       Mean |      Error |    StdDev |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------------------- |----------- |--------------------- |-----------:|-----------:|----------:|---------:|---------:|---------:|----------:|
|           RunListForeach | Job-XTRMDK | .NET Framework 4.7.2 |  22.561 ms |  6.6281 ms | 4.3841 ms | 156.2500 | 156.2500 | 156.2500 |     23 MB |
|               RunListFor | Job-XTRMDK | .NET Framework 4.7.2 |   7.665 ms |  2.7401 ms | 1.8124 ms |  62.5000 |  62.5000 |  62.5000 |      8 MB |
|  RunIReadOnlyListForeach | Job-XTRMDK | .NET Framework 4.7.2 |  17.593 ms |  1.4622 ms | 0.9671 ms | 109.3750 | 109.3750 | 109.3750 |      8 MB |
|      RunIReadOnlyListFor | Job-XTRMDK | .NET Framework 4.7.2 |  13.063 ms |  2.3708 ms | 1.5681 ms |  93.7500 |  93.7500 |  93.7500 |      8 MB |
| RunImmutableArrayForeach | Job-XTRMDK | .NET Framework 4.7.2 |  13.586 ms |  4.2779 ms | 2.8295 ms |  93.7500 |  93.7500 |  93.7500 |      8 MB |
|     RunImmutableArrayFor | Job-XTRMDK | .NET Framework 4.7.2 |   8.890 ms |  0.2734 ms | 0.1808 ms |  46.8750 |  46.8750 |  46.8750 |      8 MB |
|  RunImmutableListForeach | Job-XTRMDK | .NET Framework 4.7.2 | 108.771 ms |  3.0354 ms | 1.5876 ms |        - |        - |        - |     23 MB |
|      RunImmutableListFor | Job-XTRMDK | .NET Framework 4.7.2 |  71.068 ms |  1.3921 ms | 0.8284 ms |        - |        - |        - |     23 MB |
