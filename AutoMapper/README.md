// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-3520M CPU 2.90GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


|           Method |        Mean |     Error |    StdDev |
|----------------- |------------:|----------:|----------:|
|    RunAutomapper | 4,454.59 us | 72.015 us | 56.225 us |
| RunMapsterMapper |    47.48 us |  0.805 us |  0.714 us |
|    RunJsonMapper | 4,111.28 us | 48.395 us | 42.901 us |

// * Hints *
Outliers
  BenchMarkAuto.RunAutomapper: Default    -> 3 outliers were removed (4.80 ms..5.29 ms)
  BenchMarkAuto.RunMapsterMapper: Default -> 1 outlier  was  removed (52.34 us)
  BenchMarkAuto.RunJsonMapper: Default    -> 1 outlier  was  removed (4.59 ms)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  1 us   : 1 Microsecond (0.000001 sec)

// ***** BenchmarkRunner: End *****
// ** Remained 0 benchmark(s) to run **
Run time: 00:01:03 (63.13 sec), executed benchmarks: 3

Global total time: 00:01:09 (69.9 sec), executed benchmarks: 3
// * Artifacts cleanup *
BenchmarkDotNet.Reports.Summary
END


BEGIN

- Input 1 - Manual Benchmark
- Input 2 - Summary by Benchmark
- Input 3 - Manual Benchmark JsonSerializeDeserialize
- Your choice:
