window.BENCHMARK_DATA = {
  "lastUpdate": 1715751081309,
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
          "id": "aae551eb77202c6389f99b923aafd4793b6f9d66",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/aae551eb77202c6389f99b923aafd4793b6f9d66"
        },
        "date": 1702185287083,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2539.7385234832764,
            "unit": "ns",
            "range": "± 39.64576972864553"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2374.5675155639647,
            "unit": "ns",
            "range": "± 9.408408823044855"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8964.607944781963,
            "unit": "ns",
            "range": "± 34.542929901177686"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8802.939758300781,
            "unit": "ns",
            "range": "± 62.36470241237086"
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
          "id": "d69900882f7b32bb6a1958a4e82d75004b99e34e",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/d69900882f7b32bb6a1958a4e82d75004b99e34e"
        },
        "date": 1702185360016,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2433.4287766676684,
            "unit": "ns",
            "range": "± 14.123916101200264"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2297.9098065694175,
            "unit": "ns",
            "range": "± 2.557013360666926"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9456.97709437779,
            "unit": "ns",
            "range": "± 11.732811755449044"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8117.465515136719,
            "unit": "ns",
            "range": "± 33.62042951060611"
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
          "id": "b94d586990ea4a5a64eb5fad9574689ff593690a",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/b94d586990ea4a5a64eb5fad9574689ff593690a"
        },
        "date": 1702186590885,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2405.330012981708,
            "unit": "ns",
            "range": "± 15.87659792498857"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2266.43930943807,
            "unit": "ns",
            "range": "± 15.839067453275751"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8704.296216837565,
            "unit": "ns",
            "range": "± 33.845061624971635"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8117.248678843181,
            "unit": "ns",
            "range": "± 21.64668320545194"
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
          "id": "653d4b003a456b1f937a32f01e9ce765d42b9a9e",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/653d4b003a456b1f937a32f01e9ce765d42b9a9e"
        },
        "date": 1702186687730,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2322.0136868403506,
            "unit": "ns",
            "range": "± 14.335859646686941"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2214.102061051589,
            "unit": "ns",
            "range": "± 5.500173144484237"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8626.475448608398,
            "unit": "ns",
            "range": "± 54.463496042970164"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8461.706831614176,
            "unit": "ns",
            "range": "± 17.569468579392908"
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
          "id": "1eb392a5096d0ab016d7be895fe7891a3593dd41",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/1eb392a5096d0ab016d7be895fe7891a3593dd41"
        },
        "date": 1702187035234,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2563.6474964435283,
            "unit": "ns",
            "range": "± 26.283430797998793"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2237.2454223632812,
            "unit": "ns",
            "range": "± 14.17941378967504"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8927.013430786134,
            "unit": "ns",
            "range": "± 60.04064807180795"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8423.397113506611,
            "unit": "ns",
            "range": "± 23.800065452593447"
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
          "id": "c2c45092fc28e82b8b9f83a03d026e831d9185fc",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/c2c45092fc28e82b8b9f83a03d026e831d9185fc"
        },
        "date": 1702187651884,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2345.05824807974,
            "unit": "ns",
            "range": "± 19.362545335411582"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2230.091217549642,
            "unit": "ns",
            "range": "± 18.27276117296772"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8545.116630045573,
            "unit": "ns",
            "range": "± 65.85263446500369"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7897.921704101563,
            "unit": "ns",
            "range": "± 63.65035744914327"
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
          "id": "fde81f125241e6ebda8fb1d1cf301858607b7208",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/fde81f125241e6ebda8fb1d1cf301858607b7208"
        },
        "date": 1702188210393,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2315.0783136807954,
            "unit": "ns",
            "range": "± 34.320935708354796"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2251.2767378000112,
            "unit": "ns",
            "range": "± 3.911802596411647"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9017.246697998047,
            "unit": "ns",
            "range": "± 65.77341453637783"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8468.917352294922,
            "unit": "ns",
            "range": "± 62.82924089623958"
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
          "id": "ec4b5b4288632b5a88ca390192e16c4a2720fbd0",
          "message": "introduce single CollectionAnalyzer for collection assertions",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/251/commits/ec4b5b4288632b5a88ca390192e16c4a2720fbd0"
        },
        "date": 1702232700522,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2418.238319651286,
            "unit": "ns",
            "range": "± 36.32308209383352"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2209.0089510599773,
            "unit": "ns",
            "range": "± 13.676159391911444"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8575.755012003581,
            "unit": "ns",
            "range": "± 62.48677900016816"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8389.183068847657,
            "unit": "ns",
            "range": "± 21.593005513844464"
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
          "id": "3fb5207940b978418020292d1b1de75ef28c645d",
          "message": "250 use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/3fb5207940b978418020292d1b1de75ef28c645d"
        },
        "date": 1702357180429,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2297.6151390075684,
            "unit": "ns",
            "range": "± 13.045973117083644"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2252.9456758499146,
            "unit": "ns",
            "range": "± 4.761403421325802"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9221.128402709961,
            "unit": "ns",
            "range": "± 68.75611649352187"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8515.279646737235,
            "unit": "ns",
            "range": "± 58.42088272358465"
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
          "id": "7b28549fe88a223a7a91c36eb8afbcbe4f02b377",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/7b28549fe88a223a7a91c36eb8afbcbe4f02b377"
        },
        "date": 1702361371609,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2336.232214518956,
            "unit": "ns",
            "range": "± 30.89409364713268"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2268.938804880778,
            "unit": "ns",
            "range": "± 15.115837059214437"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8824.809182739258,
            "unit": "ns",
            "range": "± 66.70570231006138"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8503.377904619489,
            "unit": "ns",
            "range": "± 12.96276393075602"
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
          "id": "4df8a0e5fd4bddda03a7f404f4247e5fdbfb290a",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/4df8a0e5fd4bddda03a7f404f4247e5fdbfb290a"
        },
        "date": 1702362679658,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2277.664328061617,
            "unit": "ns",
            "range": "± 12.952970219074604"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2189.868552207947,
            "unit": "ns",
            "range": "± 5.429745258522042"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8781.350456237793,
            "unit": "ns",
            "range": "± 28.654924855771057"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8601.45209757487,
            "unit": "ns",
            "range": "± 8.86575602521542"
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
          "id": "dcb70bc07eaaca09a28088660a593d9892d9eabb",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/dcb70bc07eaaca09a28088660a593d9892d9eabb"
        },
        "date": 1702362756396,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2416.207248687744,
            "unit": "ns",
            "range": "± 11.145763103216964"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2215.6974884668984,
            "unit": "ns",
            "range": "± 2.559779474082245"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9225.581467764718,
            "unit": "ns",
            "range": "± 35.97208478658675"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8538.60294189453,
            "unit": "ns",
            "range": "± 60.12864690956487"
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
          "id": "838dde94dfebf1d13e205d39fbb71f20447ca781",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/838dde94dfebf1d13e205d39fbb71f20447ca781"
        },
        "date": 1702362889850,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2353.885212824895,
            "unit": "ns",
            "range": "± 10.92399483084828"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2198.1307482038223,
            "unit": "ns",
            "range": "± 7.421248373116297"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8799.109817504883,
            "unit": "ns",
            "range": "± 23.986264894936763"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8537.841876220704,
            "unit": "ns",
            "range": "± 58.019276068067434"
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
          "id": "9b593fe0a3c6464d35487897fbd1b0e26aa7a925",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/9b593fe0a3c6464d35487897fbd1b0e26aa7a925"
        },
        "date": 1702368852641,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2301.9055361066544,
            "unit": "ns",
            "range": "± 18.970114712894254"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2212.734337439904,
            "unit": "ns",
            "range": "± 4.898066472923591"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8864.28312479655,
            "unit": "ns",
            "range": "± 67.97945273751641"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8761.724053955078,
            "unit": "ns",
            "range": "± 58.96390640208716"
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
          "id": "c6e73fb788b0b4d7005c97d4d9f6e8295dc5573a",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/c6e73fb788b0b4d7005c97d4d9f6e8295dc5573a"
        },
        "date": 1702458415622,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2389.394884109497,
            "unit": "ns",
            "range": "± 13.178402803513746"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2268.551579284668,
            "unit": "ns",
            "range": "± 16.459684337492963"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8769.296860758464,
            "unit": "ns",
            "range": "± 63.410519723033154"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8508.032796223959,
            "unit": "ns",
            "range": "± 14.51901325565751"
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
          "id": "6c412806462648b41016c528f03f79e5e4a940ba",
          "message": "better visibility for mstest discovery",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/253/commits/6c412806462648b41016c528f03f79e5e4a940ba"
        },
        "date": 1702459456573,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2429.465788269043,
            "unit": "ns",
            "range": "± 43.70201984367215"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2294.2673853556316,
            "unit": "ns",
            "range": "± 15.145796632987622"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8966.203701019287,
            "unit": "ns",
            "range": "± 15.521769417086547"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8453.882658822196,
            "unit": "ns",
            "range": "± 39.78517751756337"
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
          "id": "26e3ebc670e535f8454dbf35e28dd4ca70726548",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/26e3ebc670e535f8454dbf35e28dd4ca70726548"
        },
        "date": 1702459991546,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2331.472250529698,
            "unit": "ns",
            "range": "± 23.76327290430182"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2292.9902267456055,
            "unit": "ns",
            "range": "± 17.247076459516634"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9246.295627848307,
            "unit": "ns",
            "range": "± 117.05259666327761"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7967.220368605394,
            "unit": "ns",
            "range": "± 12.27232722062187"
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
          "id": "4d91d2c77876e20d5eb5747c057f908cef87ce57",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/4d91d2c77876e20d5eb5747c057f908cef87ce57"
        },
        "date": 1702460287068,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2457.3885304377627,
            "unit": "ns",
            "range": "± 17.19737262293526"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2227.745776249812,
            "unit": "ns",
            "range": "± 3.9596313274784087"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8762.59186299642,
            "unit": "ns",
            "range": "± 18.605378294310597"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7949.242888132731,
            "unit": "ns",
            "range": "± 14.274890165687596"
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
          "id": "54832b8081d7e19698870f4555d8b1740139c82e",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/54832b8081d7e19698870f4555d8b1740139c82e"
        },
        "date": 1702463865277,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2384.928123474121,
            "unit": "ns",
            "range": "± 36.723990313720364"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2220.408935546875,
            "unit": "ns",
            "range": "± 15.104075398356272"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9265.390298461914,
            "unit": "ns",
            "range": "± 61.53976473385819"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8172.769759114583,
            "unit": "ns",
            "range": "± 67.71165208968894"
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
          "id": "a8a491c2146edb80db7622306a1d47aedf8ac17b",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/a8a491c2146edb80db7622306a1d47aedf8ac17b"
        },
        "date": 1702464294621,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2427.9201425824845,
            "unit": "ns",
            "range": "± 49.98708427482083"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2213.652898243495,
            "unit": "ns",
            "range": "± 3.807497262356304"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8863.997492109027,
            "unit": "ns",
            "range": "± 37.586225934113315"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8142.933284214565,
            "unit": "ns",
            "range": "± 28.274441451255424"
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
          "id": "b8902029d7f37ebbd9fdff9d6c1d173f4938c720",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/b8902029d7f37ebbd9fdff9d6c1d173f4938c720"
        },
        "date": 1702466998632,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2380.7652975383558,
            "unit": "ns",
            "range": "± 51.392729015227474"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2275.7005694707236,
            "unit": "ns",
            "range": "± 5.120760006188996"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9106.695062909808,
            "unit": "ns",
            "range": "± 36.6847967921616"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8000.195697239467,
            "unit": "ns",
            "range": "± 50.437794075945504"
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
          "id": "4ea659f18930524e418dd0e552d0c5ed48ea2044",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/4ea659f18930524e418dd0e552d0c5ed48ea2044"
        },
        "date": 1702473880792,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2376.4128262446475,
            "unit": "ns",
            "range": "± 18.489851390523263"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2248.9242856343585,
            "unit": "ns",
            "range": "± 13.569018556755678"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8622.498329671223,
            "unit": "ns",
            "range": "± 54.56586214064616"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8505.525805664063,
            "unit": "ns",
            "range": "± 70.48989795979621"
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
          "id": "5acc9d72f8518ab567d5fbf92b6169bf4580d924",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/5acc9d72f8518ab567d5fbf92b6169bf4580d924"
        },
        "date": 1702480830262,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2274.8842552730016,
            "unit": "ns",
            "range": "± 15.901793685655786"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2212.4509239196777,
            "unit": "ns",
            "range": "± 5.843226726726049"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8525.977824619838,
            "unit": "ns",
            "range": "± 10.28612720959514"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7903.59069925944,
            "unit": "ns",
            "range": "± 65.1238494751987"
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
          "id": "b0b49f2a3da4fb1fdd5828bd95902e41c287f3e1",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/b0b49f2a3da4fb1fdd5828bd95902e41c287f3e1"
        },
        "date": 1702483097578,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2302.1807289123535,
            "unit": "ns",
            "range": "± 7.489112800292914"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2193.8831810584434,
            "unit": "ns",
            "range": "± 5.608812320578085"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8869.017450968424,
            "unit": "ns",
            "range": "± 16.42162944895904"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8832.012319946289,
            "unit": "ns",
            "range": "± 12.736467653925827"
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
          "id": "54bba06d9c48d3fbd050f6c8a061991057fec6d3",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/54bba06d9c48d3fbd050f6c8a061991057fec6d3"
        },
        "date": 1702483153232,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2397.0231778462726,
            "unit": "ns",
            "range": "± 39.76825624863672"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2244.550934927804,
            "unit": "ns",
            "range": "± 12.99568636133682"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8941.062725067139,
            "unit": "ns",
            "range": "± 16.193132391987852"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7763.00780359904,
            "unit": "ns",
            "range": "± 5.689151009319529"
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
          "id": "8776b189f8be0fd1158da4e06ddc26943e5d72a0",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/8776b189f8be0fd1158da4e06ddc26943e5d72a0"
        },
        "date": 1702483388479,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2331.0532629830495,
            "unit": "ns",
            "range": "± 28.998295244050215"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2172.2917922973634,
            "unit": "ns",
            "range": "± 16.12317912390301"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 9119.16069539388,
            "unit": "ns",
            "range": "± 60.814304808764184"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7795.364473978679,
            "unit": "ns",
            "range": "± 12.008867465983844"
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
          "id": "f58271a0ae7b989d7c03dad24fbd40209694cc1d",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/f58271a0ae7b989d7c03dad24fbd40209694cc1d"
        },
        "date": 1702483446587,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2252.4537118765024,
            "unit": "ns",
            "range": "± 15.19407360181664"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2194.7094347817556,
            "unit": "ns",
            "range": "± 3.222975195003306"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8864.20558420817,
            "unit": "ns",
            "range": "± 15.99370951696083"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8330.799846942607,
            "unit": "ns",
            "range": "± 14.692145939406862"
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
          "id": "9ea898af0406b0144629e2c882ca76af30815bed",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/9ea898af0406b0144629e2c882ca76af30815bed"
        },
        "date": 1702489036686,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2285.660134379069,
            "unit": "ns",
            "range": "± 12.868746069561197"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2301.409734285795,
            "unit": "ns",
            "range": "± 22.58850023803092"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8831.345645359585,
            "unit": "ns",
            "range": "± 43.58250901671128"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7907.450140816824,
            "unit": "ns",
            "range": "± 65.36318603189072"
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
          "id": "e8d05d133e69341e18b7114802c3e987ccbd7118",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/e8d05d133e69341e18b7114802c3e987ccbd7118"
        },
        "date": 1702490623079,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2425.5437046686807,
            "unit": "ns",
            "range": "± 15.320014618751209"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2250.540009053548,
            "unit": "ns",
            "range": "± 20.682024925553772"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8728.443337758383,
            "unit": "ns",
            "range": "± 16.235422393402427"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7771.091327921549,
            "unit": "ns",
            "range": "± 62.8809579054182"
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
          "id": "2bba82a2e0644eefd08fefa797303acb3ec2e0e3",
          "message": "use single analyzer for fluentassertions tips - collections",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/252/commits/2bba82a2e0644eefd08fefa797303acb3ec2e0e3"
        },
        "date": 1702491282179,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2300.5275934659517,
            "unit": "ns",
            "range": "± 18.51265207019118"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2191.928186416626,
            "unit": "ns",
            "range": "± 15.11358394744566"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8730.426052386943,
            "unit": "ns",
            "range": "± 23.715613222787315"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8196.559748331705,
            "unit": "ns",
            "range": "± 56.2529016824748"
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
          "id": "54c0c44d2945b63a77e7a2cea8c477d147606958",
          "message": "add more test cases for collection types",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/254/commits/54c0c44d2945b63a77e7a2cea8c477d147606958"
        },
        "date": 1702535120292,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2222.298542567662,
            "unit": "ns",
            "range": "± 11.274095427491407"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2185.895982615153,
            "unit": "ns",
            "range": "± 15.101808558514533"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8246.806396484375,
            "unit": "ns",
            "range": "± 19.952675039250543"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7714.998162587483,
            "unit": "ns",
            "range": "± 8.642020507763533"
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
          "id": "de348c01ed576abef0bb78c68174ceaaeb1d958d",
          "message": "Remove collections dead code",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/255/commits/de348c01ed576abef0bb78c68174ceaaeb1d958d"
        },
        "date": 1702535634569,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2267.78002841656,
            "unit": "ns",
            "range": "± 20.495031529561892"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2157.8786784580775,
            "unit": "ns",
            "range": "± 11.46400136030741"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8772.245696004231,
            "unit": "ns",
            "range": "± 70.01715537062506"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7694.300001780192,
            "unit": "ns",
            "range": "± 8.430492469490273"
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
          "id": "da520a3f4436a33ded439cd8be7bf79a23263921",
          "message": "Use specific message for code fixes",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/256/commits/da520a3f4436a33ded439cd8be7bf79a23263921"
        },
        "date": 1702589050516,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2366.3059616088867,
            "unit": "ns",
            "range": "± 12.883863723953253"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2554.46567586263,
            "unit": "ns",
            "range": "± 12.882700686259492"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8278.68323810284,
            "unit": "ns",
            "range": "± 49.14452400414012"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8786.329677327474,
            "unit": "ns",
            "range": "± 77.51048407174636"
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
          "id": "bfa168c396015d4ccc362f523f62ee554832c9ba",
          "message": "Use specific message for code fixes",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/256/commits/bfa168c396015d4ccc362f523f62ee554832c9ba"
        },
        "date": 1702626700123,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2509.629727681478,
            "unit": "ns",
            "range": "± 11.113429595180882"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2170.057949701945,
            "unit": "ns",
            "range": "± 2.3419516689135635"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8912.30296122233,
            "unit": "ns",
            "range": "± 59.46722729146358"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8169.960355486189,
            "unit": "ns",
            "range": "± 9.017171948767512"
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
          "id": "62a876dbdcc6d52502696b85163269054c1014ea",
          "message": "cleanup FluentAssertionsOperationAnalyzer",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/257/commits/62a876dbdcc6d52502696b85163269054c1014ea"
        },
        "date": 1702633067309,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2223.7154532212476,
            "unit": "ns",
            "range": "± 18.847871690044524"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2143.2629400889077,
            "unit": "ns",
            "range": "± 3.771711742319965"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 10095.533250935872,
            "unit": "ns",
            "range": "± 72.05412824362129"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7679.153382364909,
            "unit": "ns",
            "range": "± 66.71223934310399"
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
          "id": "0a83dd02300f4fc8c8882d21ef7af9c265978e11",
          "message": "fix NumericShouldBeInRange CodeFix",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/258/commits/0a83dd02300f4fc8c8882d21ef7af9c265978e11"
        },
        "date": 1702639233349,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2314.203120640346,
            "unit": "ns",
            "range": "± 22.829072746274274"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2204.40620803833,
            "unit": "ns",
            "range": "± 15.612888536387112"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8275.4855275472,
            "unit": "ns",
            "range": "± 58.51667980749509"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7693.312128339495,
            "unit": "ns",
            "range": "± 7.6157182149981395"
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
          "id": "e834dc2aa92e5d3199c8c57d294a0356c77d09c0",
          "message": "feat: Migrate numerics to IOperation",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/259/commits/e834dc2aa92e5d3199c8c57d294a0356c77d09c0"
        },
        "date": 1702639521109,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2224.8156741460166,
            "unit": "ns",
            "range": "± 9.710544091059255"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2033.4730205535889,
            "unit": "ns",
            "range": "± 7.326504369182557"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8192.648977426383,
            "unit": "ns",
            "range": "± 28.230518104036793"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8082.658171081543,
            "unit": "ns",
            "range": "± 61.92143159858841"
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
          "id": "d86fc7bd5e4d0a27c1adda1ba780ac251894959f",
          "message": "Migrate String to IOperation",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/260/commits/d86fc7bd5e4d0a27c1adda1ba780ac251894959f"
        },
        "date": 1702745287191,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2040.46432358878,
            "unit": "ns",
            "range": "± 25.161245163253064"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1923.9939531179575,
            "unit": "ns",
            "range": "± 4.871858037424681"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7283.088627115885,
            "unit": "ns",
            "range": "± 27.2937177724648"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6978.559045410157,
            "unit": "ns",
            "range": "± 37.28735238755638"
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
          "id": "704d18dfbeeab5ebfc7c6b44470636ac8182085a",
          "message": "Migrate String to IOperation",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/260/commits/704d18dfbeeab5ebfc7c6b44470636ac8182085a"
        },
        "date": 1702745814481,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2093.003311246984,
            "unit": "ns",
            "range": "± 113.05700833544844"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1877.002797762553,
            "unit": "ns",
            "range": "± 27.49885231888134"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 8226.3433096367,
            "unit": "ns",
            "range": "± 356.46616588537955"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7376.299605069095,
            "unit": "ns",
            "range": "± 366.7421239897923"
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
          "id": "b3230f911ec441395369ee81de960db1d391ffc0",
          "message": "Cleanup FluentAssertionsCodeFix",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/261/commits/b3230f911ec441395369ee81de960db1d391ffc0"
        },
        "date": 1702748829952,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1897.4608893761267,
            "unit": "ns",
            "range": "± 12.30707759419769"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1850.4289354960124,
            "unit": "ns",
            "range": "± 7.484505396052239"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6922.838150024414,
            "unit": "ns",
            "range": "± 36.08596464053586"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6945.263539995466,
            "unit": "ns",
            "range": "± 17.15741186687247"
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
          "id": "d961df9a16d9150b8b7cdc45bfcfd7745b1766cd",
          "message": "Devops/ci caching",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/262/commits/d961df9a16d9150b8b7cdc45bfcfd7745b1766cd"
        },
        "date": 1702749935285,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1893.6890610286168,
            "unit": "ns",
            "range": "± 23.195890333514566"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1878.031622341701,
            "unit": "ns",
            "range": "± 11.004900378696494"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7251.5336336408345,
            "unit": "ns",
            "range": "± 7.981691367328894"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6994.293945821127,
            "unit": "ns",
            "range": "± 36.11622798658052"
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
          "id": "4bea6785676d25b5ec4826b0e0a8a17da15447a5",
          "message": "Devops/ci caching",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/262/commits/4bea6785676d25b5ec4826b0e0a8a17da15447a5"
        },
        "date": 1702750565299,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1919.8915585109166,
            "unit": "ns",
            "range": "± 33.217472276370756"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2094.507744598389,
            "unit": "ns",
            "range": "± 12.069498460306212"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6943.808852640787,
            "unit": "ns",
            "range": "± 34.08119401961471"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6589.130489095052,
            "unit": "ns",
            "range": "± 39.82880531647962"
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
          "id": "df8f50c6d938022f8515d4b3443587127ac93191",
          "message": "Devops/ci caching",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/262/commits/df8f50c6d938022f8515d4b3443587127ac93191"
        },
        "date": 1702757223777,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1944.9518264134724,
            "unit": "ns",
            "range": "± 3.9794069913526986"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1920.9850187301636,
            "unit": "ns",
            "range": "± 4.442165007947478"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7302.301832580566,
            "unit": "ns",
            "range": "± 40.88582357805394"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6586.5056889851885,
            "unit": "ns",
            "range": "± 37.86194279820837"
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
          "id": "df8f50c6d938022f8515d4b3443587127ac93191",
          "message": "Devops/ci caching",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/262/commits/df8f50c6d938022f8515d4b3443587127ac93191"
        },
        "date": 1702759470829,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 2025.1846155439105,
            "unit": "ns",
            "range": "± 12.390241633953872"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1926.6332532246909,
            "unit": "ns",
            "range": "± 16.388648552031526"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 7312.954411315918,
            "unit": "ns",
            "range": "± 41.62118218630323"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6958.3409679957795,
            "unit": "ns",
            "range": "± 23.789297668542645"
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
          "id": "950f8e3bd92b45344a8a9bd79e67965843a0116f",
          "message": "feat: Migrate dictionary to IOperation",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/263/commits/950f8e3bd92b45344a8a9bd79e67965843a0116f"
        },
        "date": 1702798839490,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1837.609140141805,
            "unit": "ns",
            "range": "± 19.500859256797327"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1712.574543271746,
            "unit": "ns",
            "range": "± 3.42719814784935"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6295.704075622559,
            "unit": "ns",
            "range": "± 27.616315512887926"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 5909.435714134803,
            "unit": "ns",
            "range": "± 4.581159201012502"
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
          "id": "68d25de5e085ce9ae347e78833fc9cb7ad7efbc2",
          "message": "feat: Migrate dictionary to IOperation",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/263/commits/68d25de5e085ce9ae347e78833fc9cb7ad7efbc2"
        },
        "date": 1702799957918,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1798.796778678894,
            "unit": "ns",
            "range": "± 9.588193153132462"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1707.8982489267985,
            "unit": "ns",
            "range": "± 15.505435692496532"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6629.54322458903,
            "unit": "ns",
            "range": "± 38.87320274424204"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6335.829008483886,
            "unit": "ns",
            "range": "± 44.54164545624401"
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
          "id": "2fdf6fa05a82a250565273892714ec28549af1de",
          "message": "feat: Migrate dictionary to IOperation",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/263/commits/2fdf6fa05a82a250565273892714ec28549af1de"
        },
        "date": 1702800296164,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1790.6598219190325,
            "unit": "ns",
            "range": "± 19.651280564034654"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1690.9572793415614,
            "unit": "ns",
            "range": "± 6.90787551122333"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6238.380728040423,
            "unit": "ns",
            "range": "± 29.42646791027932"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6042.6581627982005,
            "unit": "ns",
            "range": "± 25.298003961423003"
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
          "id": "eb5f1e91b394f8abb4cc114032c0d287f7959776",
          "message": "feat: Migrate dictionary to IOperation",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/263/commits/eb5f1e91b394f8abb4cc114032c0d287f7959776"
        },
        "date": 1702800602425,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1768.5623915536064,
            "unit": "ns",
            "range": "± 24.530182451416447"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1831.0359121958415,
            "unit": "ns",
            "range": "± 7.470562575568381"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6258.283530171712,
            "unit": "ns",
            "range": "± 35.994172562581774"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 5947.6112632751465,
            "unit": "ns",
            "range": "± 37.09246004964853"
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
          "id": "9349fc57634daa1283f2a6fd2d23bcc22cce3f6c",
          "message": "feat: migrate exceptions to IOperation",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/264/commits/9349fc57634daa1283f2a6fd2d23bcc22cce3f6c"
        },
        "date": 1702877425610,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1814.3675188337054,
            "unit": "ns",
            "range": "± 22.506931639499815"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1659.2757241566976,
            "unit": "ns",
            "range": "± 9.777222960538408"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6408.410837809245,
            "unit": "ns",
            "range": "± 38.926466770568545"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6014.7503169133115,
            "unit": "ns",
            "range": "± 10.330677324268477"
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
          "id": "91a189bfc5a579b4795515a040304fee77735434",
          "message": "chore: analyzer cleanups",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/265/commits/91a189bfc5a579b4795515a040304fee77735434"
        },
        "date": 1702879983879,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1743.6490129324106,
            "unit": "ns",
            "range": "± 16.692780854040706"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1697.3107091585796,
            "unit": "ns",
            "range": "± 2.670303415392862"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6402.10075378418,
            "unit": "ns",
            "range": "± 34.10742239410995"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6121.724740600586,
            "unit": "ns",
            "range": "± 34.438654614575476"
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
          "id": "ef4397a7a8768951aff77b12d7fd2f4a5d68d5e8",
          "message": "tests: generate test project as DynamicallyLinkedLibrary",
          "timestamp": "2023-12-08T08:19:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/266/commits/ef4397a7a8768951aff77b12d7fd2f4a5d68d5e8"
        },
        "date": 1702966358691,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1772.5716090202332,
            "unit": "ns",
            "range": "± 11.229851694177365"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1727.1437390645344,
            "unit": "ns",
            "range": "± 8.044013103398978"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6092.316492353167,
            "unit": "ns",
            "range": "± 33.368647510017894"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6179.713834635417,
            "unit": "ns",
            "range": "± 32.341723064617284"
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
          "id": "38bffd77dc7256749b53ac1b3206fd1683c5790d",
          "message": "tests: introduce API for creating complex test projects",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/267/commits/38bffd77dc7256749b53ac1b3206fd1683c5790d"
        },
        "date": 1703066012499,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1865.1333005269369,
            "unit": "ns",
            "range": "± 24.853898174784234"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1646.3029199600219,
            "unit": "ns",
            "range": "± 9.862582220171992"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6075.7271405733545,
            "unit": "ns",
            "range": "± 8.940362087955046"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 1016.6429967146653,
            "unit": "ns",
            "range": "± 1.5671702206683145"
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
          "id": "b20ba7c7047517d02bdd0eed26f1585e1b45070c",
          "message": "chore: Cleanup unused Constants",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/268/commits/b20ba7c7047517d02bdd0eed26f1585e1b45070c"
        },
        "date": 1703068329316,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1814.0672766367595,
            "unit": "ns",
            "range": "± 28.61986350973253"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1762.836054288424,
            "unit": "ns",
            "range": "± 4.915126762816792"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 6420.453242962177,
            "unit": "ns",
            "range": "± 3.980744704428725"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 1075.3744797706604,
            "unit": "ns",
            "range": "± 2.090890476698078"
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
          "id": "db98175c4a95e02eec9c8c7f1632d2c1d5debfd7",
          "message": "feat: Migrate MsTest to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/269/commits/db98175c4a95e02eec9c8c7f1632d2c1d5debfd7"
        },
        "date": 1703165105889,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1414.0006715456645,
            "unit": "ns",
            "range": "± 11.082016711064643"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1386.225154069754,
            "unit": "ns",
            "range": "± 1.9711169338734282"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 5338.680629185268,
            "unit": "ns",
            "range": "± 10.100583902312618"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 903.4766637361967,
            "unit": "ns",
            "range": "± 2.297117108554026"
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
          "id": "2028e6bebdeef25e491988c4ecc2f1f69da4ab51",
          "message": "feat: Migrate MsTest to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/269/commits/2028e6bebdeef25e491988c4ecc2f1f69da4ab51"
        },
        "date": 1703172298043,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1398.6607032922598,
            "unit": "ns",
            "range": "± 11.073639684932353"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1401.8295764923096,
            "unit": "ns",
            "range": "± 9.658486869355274"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 4985.367088953654,
            "unit": "ns",
            "range": "± 5.949831382504738"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 889.0374745686848,
            "unit": "ns",
            "range": "± 4.2511351591058135"
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
          "id": "aea9a27bc8e8013f524747721065a01f7feb53fb",
          "message": "feat: Migrate MsTest to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/269/commits/aea9a27bc8e8013f524747721065a01f7feb53fb"
        },
        "date": 1703175299193,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1518.0227946043015,
            "unit": "ns",
            "range": "± 28.633378950331114"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1352.1133651733398,
            "unit": "ns",
            "range": "± 4.249440311776767"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 5228.666276550293,
            "unit": "ns",
            "range": "± 50.07929876905351"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 863.2713618278503,
            "unit": "ns",
            "range": "± 2.2066828525742324"
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
          "id": "aac3354685e43b96990043eb3840e878f05ade53",
          "message": "feat: Migrate MsTest to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/269/commits/aac3354685e43b96990043eb3840e878f05ade53"
        },
        "date": 1703199069293,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1455.2670667966206,
            "unit": "ns",
            "range": "± 9.147957049104706"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1376.611595026652,
            "unit": "ns",
            "range": "± 2.3497358684374623"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 4980.7367418729345,
            "unit": "ns",
            "range": "± 20.68823150975235"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 853.6565300396511,
            "unit": "ns",
            "range": "± 2.4745225165053877"
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
          "id": "4d4aa3ef7e7a90100f1d3b03d5f90ede59efd328",
          "message": "feat: Migrate MsTest to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/269/commits/4d4aa3ef7e7a90100f1d3b03d5f90ede59efd328"
        },
        "date": 1703232681746,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1590.5065010615758,
            "unit": "ns",
            "range": "± 7.715911948897217"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1385.7957946232386,
            "unit": "ns",
            "range": "± 1.953111344848768"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 5192.919651794434,
            "unit": "ns",
            "range": "± 34.637608178869655"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 850.8287988026937,
            "unit": "ns",
            "range": "± 3.6259991822074555"
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
          "id": "248da85d48c4cbdcd213b0a2ab12450099f08d4a",
          "message": "feat: Migrate MsTest to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/269/commits/248da85d48c4cbdcd213b0a2ab12450099f08d4a"
        },
        "date": 1703234901764,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1296.1444372449603,
            "unit": "ns",
            "range": "± 15.982652096955642"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1286.7755107879639,
            "unit": "ns",
            "range": "± 1.6827124378046954"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 4467.643540064494,
            "unit": "ns",
            "range": "± 11.008639027929572"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 784.4667890071869,
            "unit": "ns",
            "range": "± 1.4891941783246696"
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
          "id": "23feb20987fd1dbceb79e6ea34f1fc70389aeb5c",
          "message": "feat: Migrate MsTest to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/269/commits/23feb20987fd1dbceb79e6ea34f1fc70389aeb5c"
        },
        "date": 1703237030785,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 1026.2420073917933,
            "unit": "ns",
            "range": "± 17.2268172920532"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 989.4558373769124,
            "unit": "ns",
            "range": "± 8.793831516753253"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 3432.1535135904946,
            "unit": "ns",
            "range": "± 22.821127889027828"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 624.4500049908955,
            "unit": "ns",
            "range": "± 3.4617009064268087"
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
          "id": "b40ae3ab07eecc266d1110c1d28d0d3c8d23ac18",
          "message": "feat: Migrate xunit to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/270/commits/b40ae3ab07eecc266d1110c1d28d0d3c8d23ac18"
        },
        "date": 1703489488320,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 428.81530098120373,
            "unit": "ns",
            "range": "± 0.3968464098946078"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 417.4876962389265,
            "unit": "ns",
            "range": "± 1.063103758037222"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 984.4594475672795,
            "unit": "ns",
            "range": "± 2.193386483052329"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 286.3844975508176,
            "unit": "ns",
            "range": "± 1.2942524795535135"
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
          "id": "464262b10feb5d75e45dad6f7c1ebff84c5c8df8",
          "message": "chore: cleanup dead code",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/271/commits/464262b10feb5d75e45dad6f7c1ebff84c5c8df8"
        },
        "date": 1703490206912,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 454.6350525856018,
            "unit": "ns",
            "range": "± 5.561789699087129"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 407.8870310386022,
            "unit": "ns",
            "range": "± 0.6695703233051987"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 972.1911536852518,
            "unit": "ns",
            "range": "± 1.9430974246410448"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 276.50288312775746,
            "unit": "ns",
            "range": "± 0.9069556568702273"
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
          "id": "35ebe3fa53ce28d574e1c64806826cf659616fe9",
          "message": "feat: Migrate equals to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/272/commits/35ebe3fa53ce28d574e1c64806826cf659616fe9"
        },
        "date": 1703526947193,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 433.00693298067364,
            "unit": "ns",
            "range": "± 14.074772573844585"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 276.49225011238684,
            "unit": "ns",
            "range": "± 7.5399623520312185"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 898.3076877593994,
            "unit": "ns",
            "range": "± 13.445697771741175"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 286.04533636569977,
            "unit": "ns",
            "range": "± 6.357281259279716"
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
          "id": "4dc517428f85706225ffe7901c0d9127c5ad2eae",
          "message": "chore: cleanup dead code",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/273/commits/4dc517428f85706225ffe7901c0d9127c5ad2eae"
        },
        "date": 1703527993180,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 392.04603044192,
            "unit": "ns",
            "range": "± 9.756063466945516"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 276.7167443888528,
            "unit": "ns",
            "range": "± 4.737600443904034"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 881.779438316822,
            "unit": "ns",
            "range": "± 16.795383972994767"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 255.92363612992423,
            "unit": "ns",
            "range": "± 4.298307844838778"
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
          "id": "7fbf426ae75338db761e746f05de24b79f93e30c",
          "message": "feature: improve numeric assertions",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/275/commits/7fbf426ae75338db761e746f05de24b79f93e30c"
        },
        "date": 1703675772283,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 425.9219905989511,
            "unit": "ns",
            "range": "± 2.256845904605313"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 267.0543375015259,
            "unit": "ns",
            "range": "± 1.8690453636302384"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 888.8361847559611,
            "unit": "ns",
            "range": "± 4.779555047554202"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.5516639096396,
            "unit": "ns",
            "range": "± 1.1727600540146919"
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
          "id": "34602b335c7d6742e84a038f28de1bdf5afa3007",
          "message": "feature: improve numeric assertions",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/275/commits/34602b335c7d6742e84a038f28de1bdf5afa3007"
        },
        "date": 1703676085978,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 394.22283816337585,
            "unit": "ns",
            "range": "± 5.250189002594743"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 268.16726282664706,
            "unit": "ns",
            "range": "± 1.0160224088073346"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 878.1452271597726,
            "unit": "ns",
            "range": "± 3.6427794226929"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 262.7677855858436,
            "unit": "ns",
            "range": "± 0.7209715792491743"
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
          "id": "32a722380610448121860d78736fb6e30952a215",
          "message": "tests: reproduce issue #276",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/277/commits/32a722380610448121860d78736fb6e30952a215"
        },
        "date": 1703839455092,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 395.3017535026257,
            "unit": "ns",
            "range": "± 4.1971683460098825"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 268.6480459485735,
            "unit": "ns",
            "range": "± 1.5487447677379407"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 885.7182949611118,
            "unit": "ns",
            "range": "± 3.26871168599326"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 268.32562414805096,
            "unit": "ns",
            "range": "± 0.5159801895752593"
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
          "id": "0b252efd238040f4cff97dd04af25beb62a18521",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/0b252efd238040f4cff97dd04af25beb62a18521"
        },
        "date": 1703845181130,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 399.0926513671875,
            "unit": "ns",
            "range": "± 4.6273822769979835"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 268.4091284091656,
            "unit": "ns",
            "range": "± 0.7216889872057485"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 894.5159208433969,
            "unit": "ns",
            "range": "± 3.730599552935798"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 268.38781048456826,
            "unit": "ns",
            "range": "± 2.512812616575223"
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
          "id": "9b5c6e56481f12299da7098c67afcef9ea4e6fe2",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/9b5c6e56481f12299da7098c67afcef9ea4e6fe2"
        },
        "date": 1703850918621,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 413.7195130586624,
            "unit": "ns",
            "range": "± 1.4673219685795371"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 271.72791655858356,
            "unit": "ns",
            "range": "± 1.6364075182414035"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 897.1605747858683,
            "unit": "ns",
            "range": "± 5.876305796791541"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 298.4271592458089,
            "unit": "ns",
            "range": "± 2.2161168479629874"
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
          "id": "0058d0900605824f6313ff29714561c3e66794fe",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/0058d0900605824f6313ff29714561c3e66794fe"
        },
        "date": 1704276092221,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 427.18740150133766,
            "unit": "ns",
            "range": "± 6.24353816851598"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 263.8827345212301,
            "unit": "ns",
            "range": "± 1.6435973541271391"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 867.324328358968,
            "unit": "ns",
            "range": "± 5.007480109485336"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 266.98624005317686,
            "unit": "ns",
            "range": "± 2.456238011951101"
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
          "id": "dea7d4e31b87ea9cce70663310ba061d172be9a6",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/dea7d4e31b87ea9cce70663310ba061d172be9a6"
        },
        "date": 1704278249111,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 383.2395926438845,
            "unit": "ns",
            "range": "± 2.469662654454604"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 267.00528752009075,
            "unit": "ns",
            "range": "± 2.0160451225962355"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 885.2981469971793,
            "unit": "ns",
            "range": "± 3.9254730878069823"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.76845254216875,
            "unit": "ns",
            "range": "± 2.1321742070157415"
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
          "id": "40b8fac89301b6df248240ae40745adbf2a47154",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/40b8fac89301b6df248240ae40745adbf2a47154"
        },
        "date": 1704307448054,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 414.40685875075206,
            "unit": "ns",
            "range": "± 5.0045641668329015"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 270.5553331034524,
            "unit": "ns",
            "range": "± 0.5088116382646007"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 860.9201166788737,
            "unit": "ns",
            "range": "± 7.139969814402042"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 284.6272518818195,
            "unit": "ns",
            "range": "± 2.355301874136275"
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
          "id": "b5b487995f486dec07eb846df05ff0d391411fc7",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/b5b487995f486dec07eb846df05ff0d391411fc7"
        },
        "date": 1704309444278,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 400.6831217606862,
            "unit": "ns",
            "range": "± 2.290354460528831"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 272.2438371522086,
            "unit": "ns",
            "range": "± 1.761185216492564"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 908.5927710533142,
            "unit": "ns",
            "range": "± 6.136261379362907"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.7616019884745,
            "unit": "ns",
            "range": "± 1.1431587742229186"
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
          "id": "b2933a95a869b7a8c1a67f3126cc8f9551a70870",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/b2933a95a869b7a8c1a67f3126cc8f9551a70870"
        },
        "date": 1704346576839,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 398.2073345184326,
            "unit": "ns",
            "range": "± 2.1156032432019685"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 266.5550123964037,
            "unit": "ns",
            "range": "± 0.9370238498411105"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 874.3328492824847,
            "unit": "ns",
            "range": "± 1.603970061185656"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 273.9769460201263,
            "unit": "ns",
            "range": "± 2.1816275080642353"
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
          "id": "6c9a7690a569be915a8b19436f1cbdb2c7f2d730",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/6c9a7690a569be915a8b19436f1cbdb2c7f2d730"
        },
        "date": 1704347421820,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 397.20104281107587,
            "unit": "ns",
            "range": "± 2.3062801192402267"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 274.757809809276,
            "unit": "ns",
            "range": "± 0.6846587351805805"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 874.3084973335266,
            "unit": "ns",
            "range": "± 4.046303261982487"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 277.7113805611928,
            "unit": "ns",
            "range": "± 1.262732067481708"
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
          "id": "4b5599ab19cd370c8b288314aee79db32cf60f10",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/4b5599ab19cd370c8b288314aee79db32cf60f10"
        },
        "date": 1704355660929,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 426.5929996626718,
            "unit": "ns",
            "range": "± 1.677260631303379"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 266.0315886815389,
            "unit": "ns",
            "range": "± 1.958911859463713"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 902.8076956612723,
            "unit": "ns",
            "range": "± 4.482691573971333"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 288.5483062426249,
            "unit": "ns",
            "range": "± 2.0063177533653613"
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
          "id": "2f0733b52d788ab01653eaf11d0ac3b1f759b13b",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/2f0733b52d788ab01653eaf11d0ac3b1f759b13b"
        },
        "date": 1704359378458,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 393.03839201927184,
            "unit": "ns",
            "range": "± 6.2045254589412755"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 269.7977760859898,
            "unit": "ns",
            "range": "± 0.8643043158099198"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 875.3991619110108,
            "unit": "ns",
            "range": "± 3.7783806433907356"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 268.82119683424634,
            "unit": "ns",
            "range": "± 0.6758443128784345"
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
          "id": "214b4fe87533870d77a893c9e585131f7ad66374",
          "message": "feat: Migrate fluent assertions code-fixers to levarage IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/278/commits/214b4fe87533870d77a893c9e585131f7ad66374"
        },
        "date": 1704361264189,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 423.54882375399274,
            "unit": "ns",
            "range": "± 1.897504255712796"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 267.72490879467557,
            "unit": "ns",
            "range": "± 0.4436918639564636"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 912.4084138189044,
            "unit": "ns",
            "range": "± 4.905450491889147"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 282.0862787882487,
            "unit": "ns",
            "range": "± 1.7941711267627904"
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
          "id": "dec27b9837c456fbe361edec9dcd4819546d8dd1",
          "message": "bugfix: Do not report fluentassertion diagnostic when there is a condition expression before the Should invocation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/279/commits/dec27b9837c456fbe361edec9dcd4819546d8dd1"
        },
        "date": 1704363211557,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 400.80467480879565,
            "unit": "ns",
            "range": "± 2.6011961774060057"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 267.60925500209515,
            "unit": "ns",
            "range": "± 0.9116525220236792"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 919.601917775472,
            "unit": "ns",
            "range": "± 3.898686651714937"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.8121746948787,
            "unit": "ns",
            "range": "± 1.5779107321023267"
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
          "id": "09574a0be4d42d12d5e2eefbb884f42d997fd6dc",
          "message": "feat: Migrate NullConditionalAssertion to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/280/commits/09574a0be4d42d12d5e2eefbb884f42d997fd6dc"
        },
        "date": 1704365614283,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 383.4670766081129,
            "unit": "ns",
            "range": "± 3.624644041460688"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 267.30237671307157,
            "unit": "ns",
            "range": "± 1.630069128832412"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 810.7915512493679,
            "unit": "ns",
            "range": "± 8.376720043084923"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 263.8648712793986,
            "unit": "ns",
            "range": "± 2.594429405162514"
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
          "id": "ea4c5974b81cce8290ea966d451b9777a33d9e9c",
          "message": "feat: Migrate NullConditionalAssertion to IOperation",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/280/commits/ea4c5974b81cce8290ea966d451b9777a33d9e9c"
        },
        "date": 1704365737504,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 357.7270212173462,
            "unit": "ns",
            "range": "± 1.7570159568538213"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 257.820791165034,
            "unit": "ns",
            "range": "± 1.6236009179365711"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 864.5569018046061,
            "unit": "ns",
            "range": "± 3.5704304635874506"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 263.6104600429535,
            "unit": "ns",
            "range": "± 0.7217071171588284"
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
          "id": "ac6cfe5610eb406395e7d4eedd73b8071331c96d",
          "message": "feat: add xunit Assert.InRange",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/281/commits/ac6cfe5610eb406395e7d4eedd73b8071331c96d"
        },
        "date": 1704568664232,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 356.49103804997037,
            "unit": "ns",
            "range": "± 4.715003857552481"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 249.8821053845542,
            "unit": "ns",
            "range": "± 1.1702987643783258"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 769.8975039800008,
            "unit": "ns",
            "range": "± 4.16956847023199"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 248.07981899579366,
            "unit": "ns",
            "range": "± 2.4235552851692783"
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
          "id": "ae6037eb4aa796d6d8a25e12cb790f790bc7ec9c",
          "message": "feat: add xunit Assert.Equivalent",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/282/commits/ae6037eb4aa796d6d8a25e12cb790f790bc7ec9c"
        },
        "date": 1704571498371,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 369.2180550439017,
            "unit": "ns",
            "range": "± 2.182918512527945"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.7085111141205,
            "unit": "ns",
            "range": "± 0.9935438502848432"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 787.2232040405273,
            "unit": "ns",
            "range": "± 4.883806994574052"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 264.19442758560183,
            "unit": "ns",
            "range": "± 1.7901380646848615"
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
          "id": "180c01eb25874402d09f2e587f1ec62ce2cdfc90",
          "message": "cleanup: simplify the edit-action API",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/283/commits/180c01eb25874402d09f2e587f1ec62ce2cdfc90"
        },
        "date": 1704695270694,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 369.33462045742914,
            "unit": "ns",
            "range": "± 3.453211956359353"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 260.03428756395977,
            "unit": "ns",
            "range": "± 1.5497455015921862"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 789.6139307975769,
            "unit": "ns",
            "range": "± 5.521718626380911"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 247.27674472332,
            "unit": "ns",
            "range": "± 0.7666363097554381"
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
          "id": "34ac524f564a2d71674c9c1fa475323d3011f493",
          "message": "137 xunit define codefixes for exceptionasserts assert.throws",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/284/commits/34ac524f564a2d71674c9c1fa475323d3011f493"
        },
        "date": 1704739133079,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 368.7355338505336,
            "unit": "ns",
            "range": "± 4.061228742447958"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 261.2614386240641,
            "unit": "ns",
            "range": "± 1.999085107504111"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 787.142684173584,
            "unit": "ns",
            "range": "± 3.927596366473502"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.060591173172,
            "unit": "ns",
            "range": "± 1.5937111958846903"
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
          "id": "124a098ee19a8c6b23c50ed10434c45ae0a0ef44",
          "message": "feat: Add Using directive for FluentAssertion if missing",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/285/commits/124a098ee19a8c6b23c50ed10434c45ae0a0ef44"
        },
        "date": 1704745177534,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 372.8021180947622,
            "unit": "ns",
            "range": "± 2.863083139520522"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 258.4114945118244,
            "unit": "ns",
            "range": "± 0.6013450887974875"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 766.8433252743313,
            "unit": "ns",
            "range": "± 4.003030632600677"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 252.24937908466046,
            "unit": "ns",
            "range": "± 0.6866078800253568"
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
          "id": "04276772570d635b7bfe74e97ae2fa99c637c977",
          "message": "chore: update benchmark pipeline",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/288/commits/04276772570d635b7bfe74e97ae2fa99c637c977"
        },
        "date": 1704882499175,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 369.6910263470241,
            "unit": "ns",
            "range": "± 2.4726566649829596"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.5057272275289,
            "unit": "ns",
            "range": "± 1.7413173066573226"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 790.0065416922936,
            "unit": "ns",
            "range": "± 3.8756658372722086"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 254.50722393989562,
            "unit": "ns",
            "range": "± 2.1328790377377613"
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
          "id": "a8979d87b20763bd127f110ae97b06dd5b8f2f43",
          "message": "bugfix: and test for #96",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/289/commits/a8979d87b20763bd127f110ae97b06dd5b8f2f43"
        },
        "date": 1704889617653,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 360.42131549971447,
            "unit": "ns",
            "range": "± 3.1909616228584206"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.50996651649476,
            "unit": "ns",
            "range": "± 1.5378002391131684"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 771.5797550837199,
            "unit": "ns",
            "range": "± 6.61760700800461"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 264.2946896076202,
            "unit": "ns",
            "range": "± 3.173159350107307"
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
          "id": "20da3738a9df7f043f728a4b0ab388c1e3fe2755",
          "message": "bugfix: and test for #96",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/289/commits/20da3738a9df7f043f728a4b0ab388c1e3fe2755"
        },
        "date": 1704889945755,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 370.8239290373666,
            "unit": "ns",
            "range": "± 2.565550639247242"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.1736012788919,
            "unit": "ns",
            "range": "± 0.5951485881829021"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 784.3500156084697,
            "unit": "ns",
            "range": "± 5.980750424322119"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 260.8655739564162,
            "unit": "ns",
            "range": "± 0.24160663731005658"
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
          "id": "14ce0fdaa4bf9c6717ee314793f522f376da9a24",
          "message": "feat: add nunit boolean assertions",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/291/commits/14ce0fdaa4bf9c6717ee314793f522f376da9a24"
        },
        "date": 1705255353294,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 388.1261967695676,
            "unit": "ns",
            "range": "± 3.0311524317557126"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 244.996452242136,
            "unit": "ns",
            "range": "± 4.6738229296363105"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 752.8765154520671,
            "unit": "ns",
            "range": "± 6.471372736835135"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 249.51373837788898,
            "unit": "ns",
            "range": "± 3.8024024117100774"
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
          "id": "a391d11444c4bbc6d3eedf2a1845a8c3231f083e",
          "message": "bugfix: fix issue 290",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/292/commits/a391d11444c4bbc6d3eedf2a1845a8c3231f083e"
        },
        "date": 1705303326903,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 338.3564592520396,
            "unit": "ns",
            "range": "± 4.256918563408674"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 265.53044710159304,
            "unit": "ns",
            "range": "± 2.250898652196832"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 755.0769647598266,
            "unit": "ns",
            "range": "± 13.527921254424573"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 237.3045029481252,
            "unit": "ns",
            "range": "± 2.8790094491277585"
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
          "id": "2eee45ff4fbc68f76151fba8cef7761896869467",
          "message": "bugfix: fix issue 290",
          "timestamp": "2023-12-19T22:08:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/292/commits/2eee45ff4fbc68f76151fba8cef7761896869467"
        },
        "date": 1705490429839,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 361.1164214452108,
            "unit": "ns",
            "range": "± 1.8486867678233767"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.2812260309855,
            "unit": "ns",
            "range": "± 1.892394917500865"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 759.5301597277323,
            "unit": "ns",
            "range": "± 5.258206953942461"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.0469344774882,
            "unit": "ns",
            "range": "± 2.0952559996389866"
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
          "id": "e314c64ed08ffe49258688c3ee3889a9c34ef062",
          "message": "bugfix: fix issue 290",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/292/commits/e314c64ed08ffe49258688c3ee3889a9c34ef062"
        },
        "date": 1705491090325,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 358.011177778244,
            "unit": "ns",
            "range": "± 1.394208890645702"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.24368555205209,
            "unit": "ns",
            "range": "± 0.8542299597821146"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 760.7716878255209,
            "unit": "ns",
            "range": "± 4.251546224308459"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 259.1267749150594,
            "unit": "ns",
            "range": "± 1.6800548990922297"
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
          "id": "7d4efb60ce209cce15a70a4a6af2a8ecf3284c61",
          "message": "feat: nunit null assertions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/293/commits/7d4efb60ce209cce15a70a4a6af2a8ecf3284c61"
        },
        "date": 1705492948133,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 387.84471158981324,
            "unit": "ns",
            "range": "± 4.55465827325409"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.0876805782318,
            "unit": "ns",
            "range": "± 1.1067438934105078"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 763.7708488873074,
            "unit": "ns",
            "range": "± 3.13516632847036"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 254.07086389859518,
            "unit": "ns",
            "range": "± 1.6202577758073156"
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
          "id": "bdcf74e6da5fd888bb93be17818d289a43bbd608",
          "message": "feat: nunit null assertions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/293/commits/bdcf74e6da5fd888bb93be17818d289a43bbd608"
        },
        "date": 1705493655024,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 387.78495370424713,
            "unit": "ns",
            "range": "± 1.410451376865929"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 257.44652036520154,
            "unit": "ns",
            "range": "± 0.992041495681069"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 773.0783857198862,
            "unit": "ns",
            "range": "± 1.3893320795655908"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 258.75806857989386,
            "unit": "ns",
            "range": "± 1.6714724792907487"
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
          "id": "ab45ee7207416d0e9a7c7e1f9b1a04837557a445",
          "message": "feat: nunit numeric assertions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/294/commits/ab45ee7207416d0e9a7c7e1f9b1a04837557a445"
        },
        "date": 1705495645096,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 368.8864757674081,
            "unit": "ns",
            "range": "± 4.803884787263906"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 316.879024880273,
            "unit": "ns",
            "range": "± 0.6245686992775517"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 779.2642962591989,
            "unit": "ns",
            "range": "± 2.708842514984434"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 254.36283472379048,
            "unit": "ns",
            "range": "± 1.6744489924083585"
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
          "id": "78ea5e07966d1cfaef9ba67f895245d52277ea57",
          "message": "feat: add nunit equality assertions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/295/commits/78ea5e07966d1cfaef9ba67f895245d52277ea57"
        },
        "date": 1705506500645,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 366.6601959375235,
            "unit": "ns",
            "range": "± 4.484092878910128"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 257.5549411932627,
            "unit": "ns",
            "range": "± 0.7699889684004512"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 760.8240818659465,
            "unit": "ns",
            "range": "± 4.9759100638529"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 272.71807742118835,
            "unit": "ns",
            "range": "± 0.7735076800612793"
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
          "id": "eda4645c67b9de81aa2009350aee7ec83fb8b495",
          "message": "feat: add nunit types assertions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/296/commits/eda4645c67b9de81aa2009350aee7ec83fb8b495"
        },
        "date": 1705521165126,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 368.6764414127056,
            "unit": "ns",
            "range": "± 3.9105976941532155"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.361202606788,
            "unit": "ns",
            "range": "± 0.7647252676930985"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 780.1092261314392,
            "unit": "ns",
            "range": "± 4.471314374403833"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 255.35882804943964,
            "unit": "ns",
            "range": "± 0.9512756031732404"
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
          "id": "d9170bb3ae5d591bbf28fe8d221c018869ba3a29",
          "message": "feat: add nunit contains assertions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/297/commits/d9170bb3ae5d591bbf28fe8d221c018869ba3a29"
        },
        "date": 1705906348734,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 369.51170901151806,
            "unit": "ns",
            "range": "± 3.5305137703922482"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.15800380706787,
            "unit": "ns",
            "range": "± 1.1507447784374476"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 780.5259405771891,
            "unit": "ns",
            "range": "± 4.11339970869796"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.6349929173787,
            "unit": "ns",
            "range": "± 2.1968795798858998"
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
          "id": "d97590e6f209adf8e3e20b378f5751f35d9dc86e",
          "message": "feat: add nunit Assert.Conditions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/298/commits/d97590e6f209adf8e3e20b378f5751f35d9dc86e"
        },
        "date": 1705954358028,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 367.17096014022826,
            "unit": "ns",
            "range": "± 3.8570142899605973"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 257.17589111328124,
            "unit": "ns",
            "range": "± 1.8042499997585533"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 769.7437702325674,
            "unit": "ns",
            "range": "± 6.476505791958955"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 258.62685353415355,
            "unit": "ns",
            "range": "± 1.8789309869237663"
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
          "id": "d0784cfd7236c7abe9a10024513725299e371a32",
          "message": "feat: add nunit Assert.Conditions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/298/commits/d0784cfd7236c7abe9a10024513725299e371a32"
        },
        "date": 1705954424610,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 367.96944801012677,
            "unit": "ns",
            "range": "± 4.730297758177905"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 268.3407826423645,
            "unit": "ns",
            "range": "± 1.4090260741105372"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 751.4305455344064,
            "unit": "ns",
            "range": "± 2.9381711106619894"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.84128413881575,
            "unit": "ns",
            "range": "± 1.6092011729732805"
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
          "id": "fdfe1916e38837c74d89a4219dccd620f0a4c2c8",
          "message": "feat: add nunit Assert.Conditions",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/298/commits/fdfe1916e38837c74d89a4219dccd620f0a4c2c8"
        },
        "date": 1706087314409,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 373.4012280977689,
            "unit": "ns",
            "range": "± 3.9947255012680465"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.4633421216692,
            "unit": "ns",
            "range": "± 1.7828800749046814"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 796.9022432735989,
            "unit": "ns",
            "range": "± 1.3414694749944216"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 275.14645191339343,
            "unit": "ns",
            "range": "± 0.857601250830786"
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
          "id": "93abee4bef267b8bc3abbcd9656d58b228e37caf",
          "message": "bugfix: fix docs for issue #301",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/302/commits/93abee4bef267b8bc3abbcd9656d58b228e37caf"
        },
        "date": 1706091222271,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 376.6868130793938,
            "unit": "ns",
            "range": "± 2.2199738311407375"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.97195525964102,
            "unit": "ns",
            "range": "± 0.46126947634325877"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 764.274038696289,
            "unit": "ns",
            "range": "± 4.787911837762046"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 262.7269193013509,
            "unit": "ns",
            "range": "± 1.9627469792488743"
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
          "id": "252275290157eb8ec348e954819c5136c8f2b59e",
          "message": "bugfix: fix analyzer for issue #300",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/303/commits/252275290157eb8ec348e954819c5136c8f2b59e"
        },
        "date": 1706092072145,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 364.18509417772293,
            "unit": "ns",
            "range": "± 6.608994367272664"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 261.16895287831625,
            "unit": "ns",
            "range": "± 1.828070202957662"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 769.1184577260699,
            "unit": "ns",
            "range": "± 4.5029434596172955"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.9152950922648,
            "unit": "ns",
            "range": "± 1.7576115819554525"
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
          "id": "47b3ff18af175d95d5a0d84cd181a2dc0d77dc32",
          "message": "bugfix: fix analyzer for issue #300 and #299",
          "timestamp": "2024-01-17T11:25:05Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/303/commits/47b3ff18af175d95d5a0d84cd181a2dc0d77dc32"
        },
        "date": 1706094239322,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 357.0311754703522,
            "unit": "ns",
            "range": "± 4.438556290785524"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 248.23882875075708,
            "unit": "ns",
            "range": "± 1.2645022810586424"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 774.2334366525922,
            "unit": "ns",
            "range": "± 1.739586559018439"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 255.87367691312517,
            "unit": "ns",
            "range": "± 1.546088699587617"
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
          "id": "ced0809c5301a2b8fa8e458ca334fdf02ae132c0",
          "message": "docs: add test project for FluentAssertionsAnalyzer",
          "timestamp": "2024-01-26T05:24:40Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/304/commits/ced0809c5301a2b8fa8e458ca334fdf02ae132c0"
        },
        "date": 1706259724325,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 360.31425446730395,
            "unit": "ns",
            "range": "± 4.104260773161513"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.1777084271113,
            "unit": "ns",
            "range": "± 0.6387617361784665"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 770.0320234298706,
            "unit": "ns",
            "range": "± 1.1015823663838822"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.5232316766466,
            "unit": "ns",
            "range": "± 1.2382581003349866"
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
          "id": "f80f6e34bc64614ca3b2f0d605d6223b39e6ab4e",
          "message": "docs: add test project for FluentAssertionsAnalyzer",
          "timestamp": "2024-02-17T19:16:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/304/commits/f80f6e34bc64614ca3b2f0d605d6223b39e6ab4e"
        },
        "date": 1708333808415,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 378.50687520844593,
            "unit": "ns",
            "range": "± 1.9214302120394948"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 253.86367321014404,
            "unit": "ns",
            "range": "± 0.693230262110815"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 762.4194423130581,
            "unit": "ns",
            "range": "± 0.8499308146293668"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.8479189139146,
            "unit": "ns",
            "range": "± 0.8994111745783651"
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
          "id": "015a3ae35b6032e60f60ef945a17f815b8ba0264",
          "message": "docs: add test project for FluentAssertionsAnalyzer",
          "timestamp": "2024-02-17T19:16:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/304/commits/015a3ae35b6032e60f60ef945a17f815b8ba0264"
        },
        "date": 1708333833951,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 370.7604605810983,
            "unit": "ns",
            "range": "± 2.8988602308201585"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.94486316045123,
            "unit": "ns",
            "range": "± 0.7316537938764386"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 769.5110952854156,
            "unit": "ns",
            "range": "± 1.422402090552537"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 252.86627281506856,
            "unit": "ns",
            "range": "± 2.4396919951044014"
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
          "id": "2de3448028c7b3011711f20384ec8702d201276b",
          "message": "docs: add test project for FluentAssertionsAnalyzer",
          "timestamp": "2024-02-17T19:16:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/304/commits/2de3448028c7b3011711f20384ec8702d201276b"
        },
        "date": 1708333889795,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 397.9119813992427,
            "unit": "ns",
            "range": "± 3.9018884620895324"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 261.3349380493164,
            "unit": "ns",
            "range": "± 1.4496577914042486"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 799.2857370694478,
            "unit": "ns",
            "range": "± 4.74289862437487"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 259.98809100786843,
            "unit": "ns",
            "range": "± 2.2905628222210854"
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
          "id": "c3868a5527f3f626c114082076023b69f21e59b3",
          "message": "docs: add test project for FluentAssertionsAnalyzer",
          "timestamp": "2024-02-17T19:16:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/304/commits/c3868a5527f3f626c114082076023b69f21e59b3"
        },
        "date": 1708335283984,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 364.6223726613181,
            "unit": "ns",
            "range": "± 4.403266727749299"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 253.4121915743901,
            "unit": "ns",
            "range": "± 0.9118594484212796"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 772.6651909901545,
            "unit": "ns",
            "range": "± 0.6801485612432471"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 262.41172250111896,
            "unit": "ns",
            "range": "± 0.9277099202903131"
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
          "id": "8f02edfa095ff8a2f418216e988398bc1a47d169",
          "message": "docs: add test project for FluentAssertionsAnalyzer",
          "timestamp": "2024-02-17T19:16:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/304/commits/8f02edfa095ff8a2f418216e988398bc1a47d169"
        },
        "date": 1708335895796,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 376.9464768996605,
            "unit": "ns",
            "range": "± 3.2083152666799792"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.07728396143233,
            "unit": "ns",
            "range": "± 3.0855380649580497"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 776.6302598953247,
            "unit": "ns",
            "range": "± 4.430571827457805"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.6465102036794,
            "unit": "ns",
            "range": "± 2.0599275791869736"
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
          "id": "29567e669068fbe2f332e6465548d70a7b2a312b",
          "message": "docs: generate documentation",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/307/commits/29567e669068fbe2f332e6465548d70a7b2a312b"
        },
        "date": 1708889252609,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 382.0549417459048,
            "unit": "ns",
            "range": "± 2.959479745801209"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.87867199457608,
            "unit": "ns",
            "range": "± 0.6149087105315427"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 777.2115523020426,
            "unit": "ns",
            "range": "± 5.036314520132995"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 262.206081755956,
            "unit": "ns",
            "range": "± 2.258940015051993"
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
          "id": "8abccaf3c7e1e273436e9f4eaebb220b1fca4a9c",
          "message": "chore: Cleanup solution structure",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/308/commits/8abccaf3c7e1e273436e9f4eaebb220b1fca4a9c"
        },
        "date": 1708960061057,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 374.2720189571381,
            "unit": "ns",
            "range": "± 2.6386567720034644"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 252.14041180610656,
            "unit": "ns",
            "range": "± 1.2308075615042509"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 771.1624913215637,
            "unit": "ns",
            "range": "± 0.9723405169427657"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 271.61909257570903,
            "unit": "ns",
            "range": "± 2.024524726725974"
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
          "id": "0fb61f65d8d2ba565eafd0ebad4b456a4d7ad472",
          "message": "docs: generate documentation",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/307/commits/0fb61f65d8d2ba565eafd0ebad4b456a4d7ad472"
        },
        "date": 1708961319302,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 369.1740360443409,
            "unit": "ns",
            "range": "± 2.2265249889296084"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 266.1034522737776,
            "unit": "ns",
            "range": "± 0.5012030978945906"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 801.332454749516,
            "unit": "ns",
            "range": "± 4.413406618878941"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 254.66475197247095,
            "unit": "ns",
            "range": "± 0.6130516883193136"
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
          "id": "0900b655eccf9aeb88acfc22a4da7bb6a992c165",
          "message": "docs: generate documentation",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/307/commits/0900b655eccf9aeb88acfc22a4da7bb6a992c165"
        },
        "date": 1709057802043,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 363.9903039591653,
            "unit": "ns",
            "range": "± 2.4374128759726643"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 266.13665494918826,
            "unit": "ns",
            "range": "± 2.0524284482090223"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 798.4385252634685,
            "unit": "ns",
            "range": "± 6.91157474549382"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 253.66293363571168,
            "unit": "ns",
            "range": "± 1.7035901996237715"
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
          "id": "60c53c9c486a96ea0d74d0c5b4e09fd5b9b26290",
          "message": "bugfix: limit CollectionShouldHaveCount_LengthShouldBe to one dimension arrays only ",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/310/commits/60c53c9c486a96ea0d74d0c5b4e09fd5b9b26290"
        },
        "date": 1709235874315,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 378.51552285466875,
            "unit": "ns",
            "range": "± 2.5247529746213604"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.6686015764872,
            "unit": "ns",
            "range": "± 2.0893535781598396"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 779.9760247548421,
            "unit": "ns",
            "range": "± 3.953780120562014"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 260.21839582920074,
            "unit": "ns",
            "range": "± 0.6234907546930173"
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
          "id": "a0dba8f58a8fee7d5ff8ffa90604135cf9ef81f2",
          "message": "docs: generate documentation",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/307/commits/a0dba8f58a8fee7d5ff8ffa90604135cf9ef81f2"
        },
        "date": 1709236433064,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 377.25540719713484,
            "unit": "ns",
            "range": "± 4.420140744172239"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.8861339886983,
            "unit": "ns",
            "range": "± 2.008988115593172"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 778.4529573440552,
            "unit": "ns",
            "range": "± 4.198095904136985"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.6543745358785,
            "unit": "ns",
            "range": "± 0.7700243294481405"
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
          "id": "f129a9f31bb4963b65d7d39aeb93c37cc3d4f6f9",
          "message": "Bugfix/309 more than one dimension array",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/311/commits/f129a9f31bb4963b65d7d39aeb93c37cc3d4f6f9"
        },
        "date": 1709236561357,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 375.8128743355091,
            "unit": "ns",
            "range": "± 2.381638652198415"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 261.7328599966489,
            "unit": "ns",
            "range": "± 0.8237557995973771"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 774.0913852964129,
            "unit": "ns",
            "range": "± 1.4095986448767959"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 262.03344690004985,
            "unit": "ns",
            "range": "± 2.44544034809904"
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
          "id": "1526ba5a8dd78b261410f054235213de84315031",
          "message": "docs: generate documentation",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/307/commits/1526ba5a8dd78b261410f054235213de84315031"
        },
        "date": 1709237504406,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 404.5386139324733,
            "unit": "ns",
            "range": "± 4.737494360598523"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.6356997807821,
            "unit": "ns",
            "range": "± 0.9396254917496036"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 800.7076037724813,
            "unit": "ns",
            "range": "± 6.775134678890846"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 254.50515314248892,
            "unit": "ns",
            "range": "± 1.2629864518151543"
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
          "id": "c4dfeda42708066f687b0f3d801937c10fed7227",
          "message": "docs: generate documentation",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/307/commits/c4dfeda42708066f687b0f3d801937c10fed7227"
        },
        "date": 1709533569479,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 371.73831864992775,
            "unit": "ns",
            "range": "± 5.867471191676723"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 253.95048144658406,
            "unit": "ns",
            "range": "± 2.1644364238212055"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 764.4815447671073,
            "unit": "ns",
            "range": "± 1.9552390543218503"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.7785007613046,
            "unit": "ns",
            "range": "± 0.6329375626474829"
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
          "id": "8a7006d46e98a6bb04e702bb29e8d1fe6b9c88df",
          "message": "docs: generate documentation",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/307/commits/8a7006d46e98a6bb04e702bb29e8d1fe6b9c88df"
        },
        "date": 1709533777680,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 380.63562637216904,
            "unit": "ns",
            "range": "± 7.322231788708912"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 249.0222752571106,
            "unit": "ns",
            "range": "± 1.4438631129533845"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 758.2082975827731,
            "unit": "ns",
            "range": "± 1.4547410511470487"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.5888778062967,
            "unit": "ns",
            "range": "± 0.7897011512315822"
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
          "id": "026649bfe61e7bb53f60f2ff90a36bf2350479a3",
          "message": "docs: generator - enforce generated docs to by in-sync with docs tests",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/312/commits/026649bfe61e7bb53f60f2ff90a36bf2350479a3"
        },
        "date": 1709542281384,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 411.6958329677582,
            "unit": "ns",
            "range": "± 4.82458494221214"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.04186466534935,
            "unit": "ns",
            "range": "± 1.6064412726625792"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 787.462151663644,
            "unit": "ns",
            "range": "± 3.985212795666311"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 249.08567993981498,
            "unit": "ns",
            "range": "± 0.6297669604861603"
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
          "id": "c58181fe51e83032e19e928a0da6d5147afb5829",
          "message": "docs: generator - enforce generated docs to by in-sync with docs tests",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/312/commits/c58181fe51e83032e19e928a0da6d5147afb5829"
        },
        "date": 1709542775842,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 366.68932342529297,
            "unit": "ns",
            "range": "± 2.5973668306910374"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 261.7586009979248,
            "unit": "ns",
            "range": "± 1.1216727513263491"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 771.3811590330941,
            "unit": "ns",
            "range": "± 3.534175204897438"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 270.6506968339284,
            "unit": "ns",
            "range": "± 0.5449086479500551"
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
          "id": "cb97b9d887185ca3d275696168104c2f6deaabd1",
          "message": "docs: generator - enforce generated docs to by in-sync with docs tests",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/312/commits/cb97b9d887185ca3d275696168104c2f6deaabd1"
        },
        "date": 1709543175010,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 367.7501461689289,
            "unit": "ns",
            "range": "± 4.0959035598216875"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 251.8543870051702,
            "unit": "ns",
            "range": "± 0.40417955079241924"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 794.5544191996256,
            "unit": "ns",
            "range": "± 4.676660941217664"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.4906256198883,
            "unit": "ns",
            "range": "± 1.3801521580550145"
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
          "id": "2281ce6dcc2610ef4474a7778564b526e8500a3b",
          "message": "docs: generator - enforce generated docs to by in-sync with docs tests",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/312/commits/2281ce6dcc2610ef4474a7778564b526e8500a3b"
        },
        "date": 1709549041954,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 392.7967689377921,
            "unit": "ns",
            "range": "± 2.42234237605911"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 257.7809240659078,
            "unit": "ns",
            "range": "± 0.8358726782966738"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 776.2794106165568,
            "unit": "ns",
            "range": "± 4.0375438425729815"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 261.71720831210797,
            "unit": "ns",
            "range": "± 0.5026698014331675"
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
          "id": "acb026801bf817cc80892c3e3c4a2b5016ba21e1",
          "message": "docs: generator - enforce generated docs to by in-sync with docs tests",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/312/commits/acb026801bf817cc80892c3e3c4a2b5016ba21e1"
        },
        "date": 1709549239813,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 373.47792700131737,
            "unit": "ns",
            "range": "± 2.7951987748582576"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.37571103756244,
            "unit": "ns",
            "range": "± 0.9014852581023551"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 776.3798073359898,
            "unit": "ns",
            "range": "± 5.7401208048482095"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.6654824843773,
            "unit": "ns",
            "range": "± 0.9319810242214928"
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
          "id": "b3775b3e44c8045c2158575e6581324963db342b",
          "message": "docs: add TOC",
          "timestamp": "2024-02-25T02:25:19Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/313/commits/b3775b3e44c8045c2158575e6581324963db342b"
        },
        "date": 1709551412409,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 354.16370432193463,
            "unit": "ns",
            "range": "± 3.1011782554687684"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.89590686162313,
            "unit": "ns",
            "range": "± 2.757499797208947"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 799.7392292703901,
            "unit": "ns",
            "range": "± 5.0833481941653424"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 248.6747969309489,
            "unit": "ns",
            "range": "± 3.3704783236606537"
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
          "id": "ea4d3cbb062cc6cbdcf80655906576a7c0b9c7ef",
          "message": "feat: support List<>.Count.Should scenario",
          "timestamp": "2024-03-04T13:06:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/314/commits/ea4d3cbb062cc6cbdcf80655906576a7c0b9c7ef"
        },
        "date": 1709832812409,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 372.6816722665514,
            "unit": "ns",
            "range": "± 2.3810920540177176"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.69943574496676,
            "unit": "ns",
            "range": "± 1.3137452520573705"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 763.0736998778123,
            "unit": "ns",
            "range": "± 1.3330463999079234"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 264.9197649161021,
            "unit": "ns",
            "range": "± 0.501242916588542"
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
          "id": "f7d4924d7cb9eda55ad307309101760ded0e211c",
          "message": "feat: support List<>.Count.Should scenario",
          "timestamp": "2024-03-04T13:06:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/314/commits/f7d4924d7cb9eda55ad307309101760ded0e211c"
        },
        "date": 1709833681446,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 360.8571077187856,
            "unit": "ns",
            "range": "± 1.4680702568652026"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 264.81299427577426,
            "unit": "ns",
            "range": "± 0.8266926963776189"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 771.3705722173055,
            "unit": "ns",
            "range": "± 2.824245565172848"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.984715291432,
            "unit": "ns",
            "range": "± 1.574685384405196"
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
          "id": "9d6c5c0a9ed4402cf3e13f2748c848f907151a67",
          "message": "feat: support List<>.Count.Should scenario",
          "timestamp": "2024-03-04T13:06:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/314/commits/9d6c5c0a9ed4402cf3e13f2748c848f907151a67"
        },
        "date": 1709833927664,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 373.365177154541,
            "unit": "ns",
            "range": "± 2.192628957385475"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 251.21181619962056,
            "unit": "ns",
            "range": "± 1.4720302798469986"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 766.1398493693425,
            "unit": "ns",
            "range": "± 1.0904674125586336"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 261.825036350886,
            "unit": "ns",
            "range": "± 1.9444218150839792"
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
          "id": "2a6c4f217ba79a75bbba291b78fe523fc1bbb430",
          "message": "feat: support List<>.Count.Should scenario",
          "timestamp": "2024-03-04T13:06:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/314/commits/2a6c4f217ba79a75bbba291b78fe523fc1bbb430"
        },
        "date": 1709833970485,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 377.68544394629345,
            "unit": "ns",
            "range": "± 2.3689135541783126"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 251.76049963633218,
            "unit": "ns",
            "range": "± 2.0765880907325966"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 775.4613246917725,
            "unit": "ns",
            "range": "± 1.8516425013268007"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 261.2376867703029,
            "unit": "ns",
            "range": "± 0.6565228037595612"
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
          "id": "97f1a8067f90ac6c6a7c29fc91a7f2c69125fa7c",
          "message": "chore: create script files for CI tasks for local usage",
          "timestamp": "2024-03-04T13:06:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/315/commits/97f1a8067f90ac6c6a7c29fc91a7f2c69125fa7c"
        },
        "date": 1709835793929,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 367.0974428653717,
            "unit": "ns",
            "range": "± 1.5727403910521325"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.6086523135503,
            "unit": "ns",
            "range": "± 0.4346642062186538"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 772.7406499726432,
            "unit": "ns",
            "range": "± 1.4405120997900078"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 260.32783273550183,
            "unit": "ns",
            "range": "± 1.1112398159680528"
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
          "id": "0b374b23ab8fb22ff5ea495ba6008807d2362660",
          "message": "docs: add docs verifier",
          "timestamp": "2024-03-04T13:06:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/316/commits/0b374b23ab8fb22ff5ea495ba6008807d2362660"
        },
        "date": 1709886950681,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 362.64436145623523,
            "unit": "ns",
            "range": "± 2.3146051756346426"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 260.88910589899336,
            "unit": "ns",
            "range": "± 0.7464756513077017"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 770.4431551615397,
            "unit": "ns",
            "range": "± 3.576692312357203"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 253.01665588787623,
            "unit": "ns",
            "range": "± 1.3214267032557063"
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
          "id": "30cd52fb2a9c1f4191205475fdff823057f10473",
          "message": "docs: add docs verifier",
          "timestamp": "2024-03-04T13:06:14Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/316/commits/30cd52fb2a9c1f4191205475fdff823057f10473"
        },
        "date": 1709887685890,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 368.6470273733139,
            "unit": "ns",
            "range": "± 3.024591022164104"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 253.59509437424796,
            "unit": "ns",
            "range": "± 0.7164501100000407"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 775.5284199078877,
            "unit": "ns",
            "range": "± 5.487731218961942"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 253.10222361882526,
            "unit": "ns",
            "range": "± 1.7077950756660447"
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
          "id": "764d8b2d6113c19583d4296f2135182ead423385",
          "message": "docs: add errors for old and new assertions",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/317/commits/764d8b2d6113c19583d4296f2135182ead423385"
        },
        "date": 1713035281170,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 371.2579458310054,
            "unit": "ns",
            "range": "± 2.137034678436515"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 251.69582522710164,
            "unit": "ns",
            "range": "± 2.2759233769104967"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 756.9357299804688,
            "unit": "ns",
            "range": "± 0.8170250704350336"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 254.0200351201571,
            "unit": "ns",
            "range": "± 1.2270419548928737"
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
          "id": "ebe6b30a9df3ec5832c03616236f93fe04e317d8",
          "message": "docs: add errors for old and new assertions",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/317/commits/ebe6b30a9df3ec5832c03616236f93fe04e317d8"
        },
        "date": 1713035560083,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 377.9485118048532,
            "unit": "ns",
            "range": "± 3.9790473870194867"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.18867543765478,
            "unit": "ns",
            "range": "± 1.515011992014904"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 775.1317044666836,
            "unit": "ns",
            "range": "± 4.031233944198692"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 261.08154762585957,
            "unit": "ns",
            "range": "± 1.0086681843903795"
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
          "id": "e948f5914ba2739bcf804fe67117f5dee489bf9a",
          "message": "docs: add errors for old and new assertions",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/317/commits/e948f5914ba2739bcf804fe67117f5dee489bf9a"
        },
        "date": 1713038512724,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 366.1428831020991,
            "unit": "ns",
            "range": "± 1.716255611375292"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 258.3988185112293,
            "unit": "ns",
            "range": "± 1.5668389153925817"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 762.018369547526,
            "unit": "ns",
            "range": "± 3.885543996738047"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.90303771836415,
            "unit": "ns",
            "range": "± 1.0980724873373688"
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
          "id": "a7b8b96a523c214ca5f4c468b0726db49c39888b",
          "message": "docs: add errors for old and new assertions",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/317/commits/a7b8b96a523c214ca5f4c468b0726db49c39888b"
        },
        "date": 1713038713669,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 352.82053875923157,
            "unit": "ns",
            "range": "± 4.088886837371926"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.88340929349263,
            "unit": "ns",
            "range": "± 0.5234778683971011"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 778.6197945049831,
            "unit": "ns",
            "range": "± 4.294047656054999"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.3831795624324,
            "unit": "ns",
            "range": "± 0.7865593602221178"
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
          "id": "766d1a4ea9108523d71700c23832ee7be89f18bf",
          "message": "docs: add errors for old and new assertions (p2)",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/318/commits/766d1a4ea9108523d71700c23832ee7be89f18bf"
        },
        "date": 1713039178290,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 365.73747989109586,
            "unit": "ns",
            "range": "± 4.042211471908621"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 257.8600770632426,
            "unit": "ns",
            "range": "± 2.315587386412741"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 777.8413682301839,
            "unit": "ns",
            "range": "± 4.732445681175326"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 250.7045461177826,
            "unit": "ns",
            "range": "± 0.7657420868637209"
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
          "id": "20767d05f1c430fa25c6402d8f0ad90b64212148",
          "message": "docs: add dictionary tests",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/319/commits/20767d05f1c430fa25c6402d8f0ad90b64212148"
        },
        "date": 1713105193088,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 364.77261124338423,
            "unit": "ns",
            "range": "± 2.503189868064308"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.49317701046283,
            "unit": "ns",
            "range": "± 0.5489358394644028"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 786.4299898147583,
            "unit": "ns",
            "range": "± 6.5980131528757875"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 266.6694564478738,
            "unit": "ns",
            "range": "± 1.358598145749367"
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
          "id": "efb7a8a1ac6d1f34e2c50325f27c3c1fc7691548",
          "message": "docs: exception tests docs",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/320/commits/efb7a8a1ac6d1f34e2c50325f27c3c1fc7691548"
        },
        "date": 1713158029389,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 395.8928047588893,
            "unit": "ns",
            "range": "± 3.9036807422173534"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 261.62067289352416,
            "unit": "ns",
            "range": "± 1.775283372767155"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 766.4858542283376,
            "unit": "ns",
            "range": "± 0.8176703477743962"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 260.13056459793677,
            "unit": "ns",
            "range": "± 1.0030009962859663"
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
          "id": "a3bd9d73fd4660c4c64838cd865e8a44237f934b",
          "message": "chore: add generated comment to docs",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/321/commits/a3bd9d73fd4660c4c64838cd865e8a44237f934b"
        },
        "date": 1713160591325,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 361.2815605958303,
            "unit": "ns",
            "range": "± 3.91457329431473"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 261.96666332880653,
            "unit": "ns",
            "range": "± 0.5783349677619167"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 766.4509666987827,
            "unit": "ns",
            "range": "± 2.1008217615645006"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.9793990770976,
            "unit": "ns",
            "range": "± 1.9714918159455772"
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
          "id": "53bb0220c4919c833a39c6ee7e4c0b7e3f90b336",
          "message": "docs: better link names",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/322/commits/53bb0220c4919c833a39c6ee7e4c0b7e3f90b336"
        },
        "date": 1713194411876,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 358.8088682798239,
            "unit": "ns",
            "range": "± 1.539401474476325"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.79377600124906,
            "unit": "ns",
            "range": "± 0.5567100170718682"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 793.1787060419719,
            "unit": "ns",
            "range": "± 4.371142987684898"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 259.3664361000061,
            "unit": "ns",
            "range": "± 2.462915359174024"
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
          "id": "fabec722f9d4f1b919be91f8a399ef6f589fbd7b",
          "message": "docs: add mstest docs",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/323/commits/fabec722f9d4f1b919be91f8a399ef6f589fbd7b"
        },
        "date": 1713244211748,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 378.3039781888326,
            "unit": "ns",
            "range": "± 4.77197577857202"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 262.64446318944294,
            "unit": "ns",
            "range": "± 1.9886680727020254"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 805.889064025879,
            "unit": "ns",
            "range": "± 2.7940950228349286"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 262.9577917685875,
            "unit": "ns",
            "range": "± 1.2582508046738454"
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
          "id": "ac9c2c973dedaf4b776c8827f4771295673c28c9",
          "message": "docs: add mstest docs",
          "timestamp": "2024-04-11T16:16:09Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/323/commits/ac9c2c973dedaf4b776c8827f4771295673c28c9"
        },
        "date": 1713244666774,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 373.5985290663583,
            "unit": "ns",
            "range": "± 5.847932511456433"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 252.98163998126984,
            "unit": "ns",
            "range": "± 0.567414593536223"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 799.9137940088908,
            "unit": "ns",
            "range": "± 6.674811668852844"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 270.3981976509094,
            "unit": "ns",
            "range": "± 1.035136140303885"
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
          "id": "726023484697b5b70b16aa729cf442a2ad471b3b",
          "message": "docs: add mstest docs",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/323/commits/726023484697b5b70b16aa729cf442a2ad471b3b"
        },
        "date": 1713268839179,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 383.650981426239,
            "unit": "ns",
            "range": "± 3.5571881695523486"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.38849207560222,
            "unit": "ns",
            "range": "± 1.9248407062874549"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 759.7804038365682,
            "unit": "ns",
            "range": "± 6.571094937010197"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.7431677409581,
            "unit": "ns",
            "range": "± 1.2099315645754032"
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
          "id": "2bde7366bde51b92b80876d9b7a2a0d7f4024441",
          "message": "docs: add mstest docs",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/323/commits/2bde7366bde51b92b80876d9b7a2a0d7f4024441"
        },
        "date": 1713269445235,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 375.83579768453325,
            "unit": "ns",
            "range": "± 5.378292065613082"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 251.89159005482992,
            "unit": "ns",
            "range": "± 2.2444941204945876"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 777.2418487548828,
            "unit": "ns",
            "range": "± 4.953372462455461"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 249.69587542460516,
            "unit": "ns",
            "range": "± 0.6825468316715355"
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
          "id": "622c55f6a94f1ed31f8e046dc32f2f239e7d1bed",
          "message": "docs: add mstest docs",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/323/commits/622c55f6a94f1ed31f8e046dc32f2f239e7d1bed"
        },
        "date": 1713269841449,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 367.2854266166687,
            "unit": "ns",
            "range": "± 3.7815612927179547"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 251.35309343338014,
            "unit": "ns",
            "range": "± 1.6622028984603237"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 767.9376483281453,
            "unit": "ns",
            "range": "± 4.593733160838896"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 255.8648954119001,
            "unit": "ns",
            "range": "± 1.89614984921889"
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
          "id": "5232445fdf8fdf9a7c585fb43bc2793a2e5aab9a",
          "message": "chore: generator cleanups",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/324/commits/5232445fdf8fdf9a7c585fb43bc2793a2e5aab9a"
        },
        "date": 1713270539377,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 364.03618918146407,
            "unit": "ns",
            "range": "± 1.9916580392789835"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 251.5583426768963,
            "unit": "ns",
            "range": "± 0.9992760857636331"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 772.4146928787231,
            "unit": "ns",
            "range": "± 2.9133225019247724"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 261.2042223044804,
            "unit": "ns",
            "range": "± 0.8194203160613861"
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
          "id": "4fafffca943fa083c072c2daadf5f525336586e5",
          "message": "docs: mstest support for IsNull, IsNotNull, IsInstanceOfType, IsNotInstanceOfType",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/325/commits/4fafffca943fa083c072c2daadf5f525336586e5"
        },
        "date": 1713356079845,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 380.91940313975016,
            "unit": "ns",
            "range": "± 6.473856850842774"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 264.82778517405194,
            "unit": "ns",
            "range": "± 1.8676242217938064"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 777.960627760206,
            "unit": "ns",
            "range": "± 3.37345832148628"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.95859725134716,
            "unit": "ns",
            "range": "± 1.876272719375591"
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
          "id": "5c03efdf4fe15dae664931dc5b6f38b436c28fab",
          "message": "docs: mstest support for IsNull, IsNotNull, IsInstanceOfType, IsNotInstanceOfType",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/325/commits/5c03efdf4fe15dae664931dc5b6f38b436c28fab"
        },
        "date": 1713356442440,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 368.12428054442773,
            "unit": "ns",
            "range": "± 1.245973572336511"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 267.81320548057556,
            "unit": "ns",
            "range": "± 0.5462630868106964"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 782.1814365069072,
            "unit": "ns",
            "range": "± 3.843506720150279"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.7686905494103,
            "unit": "ns",
            "range": "± 0.6450411347825189"
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
          "id": "b97d7f2864e022ea353014963642bf67934cb00c",
          "message": "docs: mstest support for AreEqual, AreNotEqual",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/326/commits/b97d7f2864e022ea353014963642bf67934cb00c"
        },
        "date": 1713427542917,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 373.891756772995,
            "unit": "ns",
            "range": "± 3.0963250274722047"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.6915333112081,
            "unit": "ns",
            "range": "± 1.9300893336548848"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 770.6322536468506,
            "unit": "ns",
            "range": "± 4.789263805965139"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 263.2924753938402,
            "unit": "ns",
            "range": "± 1.2174583516575164"
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
          "id": "9e4b3961b292b09af13d65bd26658aadb3d3ce1e",
          "message": "docs: mstest support for AreEqual, AreNotEqual",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/326/commits/9e4b3961b292b09af13d65bd26658aadb3d3ce1e"
        },
        "date": 1713428109629,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 373.2043784300486,
            "unit": "ns",
            "range": "± 4.792809642949441"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 265.16224455833435,
            "unit": "ns",
            "range": "± 0.8750662533920498"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 776.26942553887,
            "unit": "ns",
            "range": "± 2.315039429456285"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 261.31585981051126,
            "unit": "ns",
            "range": "± 1.7812337920631274"
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
          "id": "e0c4f422f2802d931bcbb187d51e9e534739a3d5",
          "message": "docs: mstest support for AreEqual, AreNotEqual",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/326/commits/e0c4f422f2802d931bcbb187d51e9e534739a3d5"
        },
        "date": 1713453793386,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 377.27826340381915,
            "unit": "ns",
            "range": "± 4.426342904172593"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 271.43669370015465,
            "unit": "ns",
            "range": "± 2.311075536369532"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 774.6730561256409,
            "unit": "ns",
            "range": "± 4.124926385596759"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 255.8701895933885,
            "unit": "ns",
            "range": "± 1.0621242503378598"
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
          "id": "b767dd66bafed3d7f7f7c1c2705d3bd02dcebb65",
          "message": "bugfix: adding-using-stops-additional-refactorings",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/327/commits/b767dd66bafed3d7f7f7c1c2705d3bd02dcebb65"
        },
        "date": 1713454533451,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 369.86839371461133,
            "unit": "ns",
            "range": "± 4.313850782324005"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.92049639565604,
            "unit": "ns",
            "range": "± 1.1062802558605527"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 764.7254316466195,
            "unit": "ns",
            "range": "± 4.53765107327098"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 253.4464447816213,
            "unit": "ns",
            "range": "± 1.7669289157433403"
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
          "id": "1b3cdd4bd5ad7c8aadfd2c58eef7f1c443f3ae3f",
          "message": "docs: mstest support for AreSame, AreNotSame",
          "timestamp": "2024-04-16T10:02:24Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/328/commits/1b3cdd4bd5ad7c8aadfd2c58eef7f1c443f3ae3f"
        },
        "date": 1713791622830,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 364.1244090965816,
            "unit": "ns",
            "range": "± 4.883436611739316"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 267.1649221640367,
            "unit": "ns",
            "range": "± 0.9185168068404806"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 801.8316497802734,
            "unit": "ns",
            "range": "± 4.680735043909604"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 258.6576362337385,
            "unit": "ns",
            "range": "± 0.9130840763436612"
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
          "id": "3b5ed04f79f05a48679445f311bba7d14ea1ec6c",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/3b5ed04f79f05a48679445f311bba7d14ea1ec6c"
        },
        "date": 1713973383879,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 371.7951811041151,
            "unit": "ns",
            "range": "± 6.302946385496252"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 253.4174859183175,
            "unit": "ns",
            "range": "± 0.9974285412696073"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 769.2207430521647,
            "unit": "ns",
            "range": "± 5.2743856439843695"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 262.11517786979675,
            "unit": "ns",
            "range": "± 1.0596516869295072"
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
          "id": "2e0640fc55f7ef1023e0c1ef3bc3ab7302bd63bd",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/2e0640fc55f7ef1023e0c1ef3bc3ab7302bd63bd"
        },
        "date": 1714026115125,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 380.31933721899986,
            "unit": "ns",
            "range": "± 7.15606085677032"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 257.468049287796,
            "unit": "ns",
            "range": "± 1.381069014356969"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 822.6919888087681,
            "unit": "ns",
            "range": "± 3.7333574772618174"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.3205993016561,
            "unit": "ns",
            "range": "± 1.0556380494358208"
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
          "id": "4c82975c8af0e14988e8da262439aad20cca9fba",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/4c82975c8af0e14988e8da262439aad20cca9fba"
        },
        "date": 1714028185533,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 374.1099443435669,
            "unit": "ns",
            "range": "± 2.808159824419934"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.6492931683858,
            "unit": "ns",
            "range": "± 2.01305102443001"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 769.6574171066284,
            "unit": "ns",
            "range": "± 5.178635551276195"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 258.1584698970501,
            "unit": "ns",
            "range": "± 0.5491927451952037"
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
          "id": "205573fb94d376170c51cf74879f8f900d0ff89b",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/205573fb94d376170c51cf74879f8f900d0ff89b"
        },
        "date": 1714028931381,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 369.3320554494858,
            "unit": "ns",
            "range": "± 2.290017804961551"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.8210926691691,
            "unit": "ns",
            "range": "± 1.8342678973930193"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 775.9975414276123,
            "unit": "ns",
            "range": "± 3.9679752056991275"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 248.99042661373431,
            "unit": "ns",
            "range": "± 1.1224716333032267"
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
          "id": "f4866b6194010442bf7f9b271d28e3a0c278d214",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/f4866b6194010442bf7f9b271d28e3a0c278d214"
        },
        "date": 1714029164970,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 376.7072657426198,
            "unit": "ns",
            "range": "± 6.9837102295612405"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.7824015276773,
            "unit": "ns",
            "range": "± 0.9666771653891862"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 779.0604748090108,
            "unit": "ns",
            "range": "± 5.593889049196714"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 259.5864050204937,
            "unit": "ns",
            "range": "± 0.8670418127837055"
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
          "id": "08a1a0c25ed703c032d5396dfcc0109e36278f5a",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/08a1a0c25ed703c032d5396dfcc0109e36278f5a"
        },
        "date": 1714029334001,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 362.8059885104497,
            "unit": "ns",
            "range": "± 1.5531289039489324"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.1596833229065,
            "unit": "ns",
            "range": "± 2.084599255844637"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 774.3017832438151,
            "unit": "ns",
            "range": "± 6.25351314608036"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 252.52313769658406,
            "unit": "ns",
            "range": "± 1.9765944647744396"
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
          "id": "b6a38345eb11ae83e6e4393de542afbc4e7cb40c",
          "message": "feat: add mstest collection docs",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/330/commits/b6a38345eb11ae83e6e4393de542afbc4e7cb40c"
        },
        "date": 1715351315921,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 373.17168299968426,
            "unit": "ns",
            "range": "± 2.1183472049842074"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 258.78302250589644,
            "unit": "ns",
            "range": "± 3.1177415392498267"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 763.0981665452322,
            "unit": "ns",
            "range": "± 1.0467010271556938"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.5124083042145,
            "unit": "ns",
            "range": "± 1.124722196997478"
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
          "id": "39f2fab9e2e7f6c2d87b30ee68a3234573f92775",
          "message": "feat: add mstest collection docs",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/330/commits/39f2fab9e2e7f6c2d87b30ee68a3234573f92775"
        },
        "date": 1715575663876,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 355.8690410852432,
            "unit": "ns",
            "range": "± 3.0975855970150064"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.53271927833558,
            "unit": "ns",
            "range": "± 2.7123059010364723"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 726.7123649303729,
            "unit": "ns",
            "range": "± 2.750101179715667"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 240.60254062016804,
            "unit": "ns",
            "range": "± 2.1365749141119195"
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
          "id": "b6a38345eb11ae83e6e4393de542afbc4e7cb40c",
          "message": "feat: add mstest collection docs",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/330/commits/b6a38345eb11ae83e6e4393de542afbc4e7cb40c"
        },
        "date": 1715576707385,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 379.7645430905478,
            "unit": "ns",
            "range": "± 2.0399834933176573"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 281.51362821034024,
            "unit": "ns",
            "range": "± 2.0768227324493904"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 808.5134053230286,
            "unit": "ns",
            "range": "± 4.859088869451949"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.6727460225423,
            "unit": "ns",
            "range": "± 1.893397730435525"
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
          "id": "4b541b0ab4b40672cc93bd72ea7cd0d79e9f52e9",
          "message": "feat: add mstest collection docs",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/330/commits/4b541b0ab4b40672cc93bd72ea7cd0d79e9f52e9"
        },
        "date": 1715578777524,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 372.588177839915,
            "unit": "ns",
            "range": "± 1.9286166676953558"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 258.35795469284056,
            "unit": "ns",
            "range": "± 2.678052202159911"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 786.3426337242126,
            "unit": "ns",
            "range": "± 4.40350304890022"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 260.33814832369484,
            "unit": "ns",
            "range": "± 2.173357666654442"
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
          "id": "b6a38345eb11ae83e6e4393de542afbc4e7cb40c",
          "message": "feat: add mstest collection docs",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/330/commits/b6a38345eb11ae83e6e4393de542afbc4e7cb40c"
        },
        "date": 1715579160602,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 360.2187804579735,
            "unit": "ns",
            "range": "± 6.857069243628282"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.55006504058838,
            "unit": "ns",
            "range": "± 1.04155905260129"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 773.8509502410889,
            "unit": "ns",
            "range": "± 7.1127203756111355"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 252.5772719016442,
            "unit": "ns",
            "range": "± 1.0829757583695028"
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
          "id": "a350690f51ff969dce1bf908e43c5c548c3fa712",
          "message": "feat: add mstest collection docs",
          "timestamp": "2024-04-22T13:34:55Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/330/commits/a350690f51ff969dce1bf908e43c5c548c3fa712"
        },
        "date": 1715579586230,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 371.4399582147598,
            "unit": "ns",
            "range": "± 0.5934600294334269"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.93296225865683,
            "unit": "ns",
            "range": "± 0.7645240410568562"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 762.8967537879944,
            "unit": "ns",
            "range": "± 0.8937813878106308"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.66632083484103,
            "unit": "ns",
            "range": "± 2.2758198726565344"
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
          "id": "01bcebf85a56c89d06b96239b55b7f0dd364ba57",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-05-13T05:57:44Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/01bcebf85a56c89d06b96239b55b7f0dd364ba57"
        },
        "date": 1715580142765,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 376.9229148546855,
            "unit": "ns",
            "range": "± 5.335547607775262"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.7730630636215,
            "unit": "ns",
            "range": "± 0.42522119811384856"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 783.3367258480617,
            "unit": "ns",
            "range": "± 4.312272363125571"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 260.46633268992105,
            "unit": "ns",
            "range": "± 2.302091996424705"
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
          "id": "2b12867e444987caf809c50c3436579ceda685c9",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-05-13T05:57:44Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/2b12867e444987caf809c50c3436579ceda685c9"
        },
        "date": 1715580179005,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 399.07817132132396,
            "unit": "ns",
            "range": "± 5.411217962791571"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 268.4087797678434,
            "unit": "ns",
            "range": "± 1.3392767838063309"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 768.4679322242737,
            "unit": "ns",
            "range": "± 2.46778711316331"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 269.77320539156597,
            "unit": "ns",
            "range": "± 1.8913935271107232"
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
          "id": "2f751704688f06f82597f63f1508c6b80052d741",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-05-13T05:57:44Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/2f751704688f06f82597f63f1508c6b80052d741"
        },
        "date": 1715580304425,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 368.52174802621204,
            "unit": "ns",
            "range": "± 2.725229137514668"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 258.5764089993068,
            "unit": "ns",
            "range": "± 1.2514059671573412"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 792.3550016696637,
            "unit": "ns",
            "range": "± 3.9140926932855677"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 276.62863003412883,
            "unit": "ns",
            "range": "± 2.799281709956925"
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
          "id": "15539b3a35da193fa4d1a144f872b8c8c9005ba8",
          "message": "docs: mstest support for ThrowsException/Async",
          "timestamp": "2024-05-13T05:57:44Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/329/commits/15539b3a35da193fa4d1a144f872b8c8c9005ba8"
        },
        "date": 1715580516394,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 388.0147976691906,
            "unit": "ns",
            "range": "± 2.8778295786328543"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 255.62763718196325,
            "unit": "ns",
            "range": "± 1.712811343600217"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 816.9608014424642,
            "unit": "ns",
            "range": "± 5.980512187457057"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 269.44915114130293,
            "unit": "ns",
            "range": "± 1.1688534966724036"
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
          "id": "4ec3fd68b95f6d7d6f9aef30d54744143de0d802",
          "message": "feat: add mstest string-assert migration docs",
          "timestamp": "2024-05-13T06:29:02Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/331/commits/4ec3fd68b95f6d7d6f9aef30d54744143de0d802"
        },
        "date": 1715582360256,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 369.36984554926556,
            "unit": "ns",
            "range": "± 5.949282201832534"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.56468967029028,
            "unit": "ns",
            "range": "± 1.5086858405371733"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 765.2535060882568,
            "unit": "ns",
            "range": "± 3.9373221872077266"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 252.99269620577493,
            "unit": "ns",
            "range": "± 1.8672460190536642"
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
          "id": "34980e2a6713128edc65a5baaa2e639cf9753eae",
          "message": "feat: add initial nunit migration docs",
          "timestamp": "2024-05-13T06:50:53Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/332/commits/34980e2a6713128edc65a5baaa2e639cf9753eae"
        },
        "date": 1715591209004,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 376.13991435368854,
            "unit": "ns",
            "range": "± 2.184640590678245"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 262.8577758715703,
            "unit": "ns",
            "range": "± 0.8986576129838354"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 772.2416193644206,
            "unit": "ns",
            "range": "± 4.771295161883979"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 301.8617821931839,
            "unit": "ns",
            "range": "± 1.7168326966951688"
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
          "id": "195aa89410493695678fe9e681cf1401fe1e6424",
          "message": "feat: add initial nunit migration docs",
          "timestamp": "2024-05-13T06:50:53Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/332/commits/195aa89410493695678fe9e681cf1401fe1e6424"
        },
        "date": 1715591526661,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 376.3218713402748,
            "unit": "ns",
            "range": "± 6.91009694029052"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 262.67992036683216,
            "unit": "ns",
            "range": "± 2.6556813888759367"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 826.0007332393101,
            "unit": "ns",
            "range": "± 4.25600620647293"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 260.7395898929009,
            "unit": "ns",
            "range": "± 0.7078347935438063"
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
          "id": "4d9ef730ad368814c7950cf5defcc3284db7b9ed",
          "message": "feat: add nunit null asserts migration docs",
          "timestamp": "2024-05-13T09:20:04Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/333/commits/4d9ef730ad368814c7950cf5defcc3284db7b9ed"
        },
        "date": 1715592520698,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 374.69700797398883,
            "unit": "ns",
            "range": "± 2.0451988319539356"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 256.249498907725,
            "unit": "ns",
            "range": "± 1.5987912591147455"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 779.160268942515,
            "unit": "ns",
            "range": "± 1.2115570795145254"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 265.73673462867737,
            "unit": "ns",
            "range": "± 1.0991404301572443"
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
          "id": "a6effbc694a44efeaa688ec8a924cbc444fc123d",
          "message": "feat: add nunit IsEmpty asserts migration docs",
          "timestamp": "2024-05-13T09:35:23Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/334/commits/a6effbc694a44efeaa688ec8a924cbc444fc123d"
        },
        "date": 1715593603574,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 366.9116940131554,
            "unit": "ns",
            "range": "± 2.438366499968417"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 254.85316387812296,
            "unit": "ns",
            "range": "± 2.6231215970006083"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 771.4869242986043,
            "unit": "ns",
            "range": "± 5.768964885259408"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.8076237610408,
            "unit": "ns",
            "range": "± 1.2265053559783738"
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
          "id": "577d47e50ada2ea4bc93e4c2f697edd989b2cb74",
          "message": "feat: support nunit assert.that migration",
          "timestamp": "2024-05-13T10:04:00Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/335/commits/577d47e50ada2ea4bc93e4c2f697edd989b2cb74"
        },
        "date": 1715714735349,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 366.9907334327698,
            "unit": "ns",
            "range": "± 6.740891834170127"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 258.4140989303589,
            "unit": "ns",
            "range": "± 0.9242640908864198"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 784.4989744504293,
            "unit": "ns",
            "range": "± 4.3698211311181065"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 257.3307830651601,
            "unit": "ns",
            "range": "± 1.5868785855287943"
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
          "id": "0a57aaddbf1b1340b3eeda1b84449fb777eeee00",
          "message": "chore: diagnostic logs for dotnet format",
          "timestamp": "2024-05-14T20:09:58Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/336/commits/0a57aaddbf1b1340b3eeda1b84449fb777eeee00"
        },
        "date": 1715749028851,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 402.22994723686804,
            "unit": "ns",
            "range": "± 4.265011847341135"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 247.91398712793986,
            "unit": "ns",
            "range": "± 2.057568032868997"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 790.4135604222615,
            "unit": "ns",
            "range": "± 4.876347486311556"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 256.2609277321742,
            "unit": "ns",
            "range": "± 0.7432609583877648"
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
          "id": "a367c3a98cdfb842c4efa4e5c728571ca9b93d3b",
          "message": "chore: diagnostic logs for dotnet format",
          "timestamp": "2024-05-14T20:09:58Z",
          "url": "https://github.com/fluentassertions/fluentassertions.analyzers/pull/336/commits/a367c3a98cdfb842c4efa4e5c728571ca9b93d3b"
        },
        "date": 1715751080801,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 367.15644983450574,
            "unit": "ns",
            "range": "± 2.158956809526704"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.MinimalCompilation_SingleSource_ObjectStatement_Analyzing",
            "value": 259.99497698148093,
            "unit": "ns",
            "range": "± 0.5160912376030059"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 784.9463763970596,
            "unit": "ns",
            "range": "± 1.937837873256811"
          },
          {
            "name": "FluentAssertions.Analyzers.BenchmarkTests.FluentAssertionsBenchmarks.SmallCompilation_MultipleSources_StringAssertions_Analyzing",
            "value": 268.2280689239502,
            "unit": "ns",
            "range": "± 2.456999839755343"
          }
        ]
      }
    ]
  }
}