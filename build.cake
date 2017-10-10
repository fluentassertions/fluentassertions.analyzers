//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./artifacts") + Directory(configuration);
var solutionFile = File("./src/FluentAssertions.BestPractices.sln");
var testCsproj = File("./src/FluentAssertions.BestPractices.Tests/FluentAssertions.BestPractices.Tests.csproj");
var nuspecFile = File("./src/FluentAssertions.BestPractices/FluentAssertions.BestPractices.nuspec");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
	DotNetCoreRestore(solutionFile);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetCoreBuild(solutionFile, new DotNetCoreBuildSettings
	{
	  Configuration = configuration,
	  OutputDirectory = buildDir
	});
});

Task("Run-Unit-Tests")
	.IsDependentOn("Build")
    .Does(() =>
{
      DotNetCoreTest(testCsproj, new DotNetCoreTestSettings
	  {
	    Filter = "TestCategory=Completed",
		Configuration = configuration,
		NoBuild = true
	  });
});

Task("Pack")
    .Does(() => 
    {
	  var nuGetPackSettings = new NuGetPackSettings {
          OutputDirectory = buildDir
      };
      NuGetPack(nuspecFile, nuGetPackSettings);
    });

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Pack");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);