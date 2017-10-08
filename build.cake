//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./Artifacts") + Directory(configuration);
var solutionFile = File("./src/FluentAssertions.BestPractices.sln");
var testCsproj = File("./src/FluentAssertions.BestPractices.Tests/FluentAssertions.BestPractices.Tests.csproj");
var analyzersCsproj = File("./src/FluentAssertions.BestPractices/FluentAssertions.BestPractices.csproj");

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
    .Does(() =>
{
      DotNetCoreTest(testCsproj, new DotNetCoreTestSettings
	  {
	    Filter = "TestCategory=Completed",
		Configuration = configuration
	  });
});

Task("Pack")
    .Does(() => 
    {
      DotNetCorePack(analyzersCsproj, new DotNetCorePackSettings
	  {
	    Configuration = configuration,
        OutputDirectory = buildDir
	  });
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