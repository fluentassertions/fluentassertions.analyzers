window.BENCHMARK_DATA = {
  "lastUpdate": 1702159359212,
  "repoUrl": "https://github.com/fluentassertions/fluentassertions.analyzers",
  "entries": {
    "FluentAssertions.Analyzers Benchmark": [
      {
        "commit": {
          "author": {
            "name": "fluentassertions",
            "username": "fluentassertions"
          },
          "committer": {
            "name": "fluentassertions",
            "username": "fluentassertions"
          },
          "id": "dc5d8c62f2cb761c0ff0eb11832188bcb25921b1",
          "message": "bench: add more analyze benchmarks",
          "timestamp": "2023-11-05T21:55:49Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/247/commits/dc5d8c62f2cb761c0ff0eb11832188bcb25921b1"
        },
        "date": 1699476761904,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 3093.4755442301434,
            "unit": "ns",
            "range": "± 44.321047052345925"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2897.398562367757,
            "unit": "ns",
            "range": "± 14.81274459953059"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 11471.094288752629,
            "unit": "ns",
            "range": "± 44.529944590631736"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 10634.555742703951,
            "unit": "ns",
            "range": "± 55.28531400214883"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "name": "fluentassertions",
            "username": "fluentassertions"
          },
          "committer": {
            "name": "fluentassertions",
            "username": "fluentassertions"
          },
          "id": "e3df7b7b4dfad207f8904921ddbe73219afe462b",
          "message": "run benchmark only for source repo",
          "timestamp": "2023-12-07T07:56:42Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/249/commits/e3df7b7b4dfad207f8904921ddbe73219afe462b"
        },
        "date": 1702023452025,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2931.4739061243395,
            "unit": "ns",
            "range": "± 49.18237193310831"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2872.9732472101846,
            "unit": "ns",
            "range": "± 4.194207522848932"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 11446.865768432617,
            "unit": "ns",
            "range": "± 41.84034147606641"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 10371.388119037334,
            "unit": "ns",
            "range": "± 18.02950010955623"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "name": "fluentassertions",
            "username": "fluentassertions"
          },
          "committer": {
            "name": "fluentassertions",
            "username": "fluentassertions"
          },
          "id": "60b1dda8a98014d6b47053fb07ddb52a04c8b0fa",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/60b1dda8a98014d6b47053fb07ddb52a04c8b0fa"
        },
        "date": 1702159358479,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2442.2640062059677,
            "unit": "ns",
            "range": "± 26.42815945766063"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2288.212234242757,
            "unit": "ns",
            "range": "± 16.362857579320277"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9372.039095365084,
            "unit": "ns",
            "range": "± 34.899287598511485"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8303.02335917155,
            "unit": "ns",
            "range": "± 76.39288084607477"
          }
        ]
      }
    ]
  }
}