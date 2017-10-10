#tool "nuget:?package=GitVersion.CommandLine"

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
var version = GetCurrentVersion(Context);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("GitVersion")
    .WithCriteria(AppVeyor.IsRunningOnAppVeyor)
    .Does(() =>
    {
        var gitVersion = GitVersion();
		version += $"-preview{gitVersion.BuildMetaData}";

		Information($"Version: {version}");
    });

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
            Configuration = configuration
        });
    });

Task("Pack")
    .Does(() =>
    {
        var nuGetPackSettings = new NuGetPackSettings
        {
            OutputDirectory = buildDir,
            Version = version
        };
        NuGetPack(nuspecFile, nuGetPackSettings);
    });

Task("Publish-Nuget")
	.WithCriteria(AppVeyor.IsRunningOnAppVeyor)
    .Does(() =>
	{
		var apiKey = EnvironmentVariable("NUGET_API_KEY");
        if(string.IsNullOrEmpty(apiKey))
		{
            throw new InvalidOperationException("Could not resolve NuGet API key.");
        }	    
        var apiUrl = EnvironmentVariable("NUGET_API_URL");
        if(string.IsNullOrEmpty(apiUrl))
		{
            throw new InvalidOperationException("Could not resolve NuGet API url.");
        }

		var nupkgFile = File($"{buildDir}/FluentAssertions.BestPractices/FluentAssertions.BestPractices.{version}.nupkg");
		Information($"Publishing nupkg file '{nupkgFile}'...");

		NuGetPush(nupkgFile, new NuGetPushSettings
		{
            ApiKey = apiKey,
            Source = apiUrl
        });
	});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("GitVersion")
    .IsDependentOn("Build")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Pack")
	.IsDependentOn("Publish-Nuget");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);

string GetCurrentVersion(ICakeContext context)
{
	return context.XmlPeek(nuspecFile, "nu:package/nu:metadata/nu:version", new XmlPeekSettings
	{
	    Namespaces = new Dictionary<string, string>
		{
			["nu"] = "http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd"
		}
	});
}