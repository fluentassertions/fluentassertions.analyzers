<a href="https://www.fluentassertions.com"><img src="assets/images/fluent_assertions_analyzers_large_horizontal.svg" style="width:400px"/></a>

***"With Fluent Assertions, the assertions look beautiful, natural and most importantly, extremely readable"*** -[_Girish_](https://twitter.com/girishracharya)

* Latest nuget [![NuGet Badge](https://buildstats.info/nuget/fluentassertions.analyzers?includePreReleases=true)](https://www.nuget.org/packages/fluentassertions.analyzers/)
* The build status is [![CI](https://github.com/fluentassertions/fluentassertions.analyzers/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/fluentassertions/fluentassertions.analyzers/actions/workflows/ci.yml)

A collection of Analyzers based on the best practices [tips](https://fluentassertions.com/tips/).

![Alt](https://repobeats.axiom.co/api/embed/92fd2e6496fc171c00616eaf672c3c757a1a29ac.svg "Repobeats analytics image")

## Analysis and Code Fix in Action

![Demo](assets/demo.gif)

## Install

using the latest stable version:

```powershell
Install-Package FluentAssertions.Analyzers
```

## Getting Started

### Build

```bash
dotnet build src
```

### Tests

```bash
dotnet test src --configuration Release  --filter 'TestCategory=Completed'
```

## Example Usages
- https://github.com/SonarSource/sonar-dotnet/pull/2072
