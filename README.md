# [FluentAssertions](http://fluentassertions.com/) Analyzers

<img src="./assets/FluentAssertions.png" width="400">

***"With Fluent Assertions, the assertions look beautiful, natural and most importantly, extremely readable"*** -[_Girish_](https://twitter.com/girishracharya)

* Latest stable nuget [![NuGet Badge](https://buildstats.info/nuget/fluentassertions.analyzers)](https://www.nuget.org/packages/fluentassertions.analyzers/)
* Latest nuget [![NuGet Badge](https://buildstats.info/nuget/fluentassertions.analyzers?includePreReleases=true)](https://www.nuget.org/packages/fluentassertions.analyzers/)
* The build status is [![CI](https://github.com/fluentassertions/fluentassertions.analyzers/actions/workflows/ci.yml/badge.svg)](https://github.com/fluentassertions/fluentassertions.analyzers/actions/workflows/ci.yml)

A collection of Analyzers based on the best practices [tips](https://fluentassertions.com/tips/).

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
