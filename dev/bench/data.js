window.BENCHMARK_DATA = {
  "lastUpdate": 1704361265309,
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
      }
    ]
  }
}