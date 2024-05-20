using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

public static class SolutionExtensions
{
    private static readonly string NugetPackagesPath = Environment.GetEnvironmentVariable("NUGET_PACKAGES")
        ?? (OperatingSystem.IsWindows() ? Environment.ExpandEnvironmentVariables("%userprofile%\\.nuget\\packages") : "~/.nuget/packages");

    private static readonly HttpClient HttpClient = new HttpClient();
    private static readonly Task SetupPackages = Task.WhenAll(PackageReference.AllDependencies.Select(p => DownloadPackageAsync(p.Name, p.Version)));

    public static Solution AddPackageReference(this Solution solution, ProjectId projectId, PackageReference package)
    {
        SetupPackages.GetAwaiter().GetResult();

        var packagePath = Path.Combine(NugetPackagesPath, package.Name, package.Version, package.Path);
        foreach (var dll in Directory.GetFiles(packagePath, "*.dll"))
        {
            solution = solution.AddMetadataReference(projectId, MetadataReference.CreateFromFile(dll));
        }

        return solution;
    }

    public static Solution AddTargetFrameworkReference(this Solution solution, ProjectId projectId, TargetFramework targetFramework)
    {
        return targetFramework switch
        {
            TargetFramework.NetStandard2_0 => solution.AddPackageReference(projectId, PackageReference.NETStandard2_0),
            TargetFramework.NetStandard2_1 => solution.AddPackageReference(projectId, PackageReference.NETStandard2_1),
            TargetFramework.Net6_0 => solution.AddPackageReference(projectId, PackageReference.DotNet6),
            TargetFramework.Net7_0 => solution.AddPackageReference(projectId, PackageReference.DotNet7),
            TargetFramework.Net8_0 => solution.AddPackageReference(projectId, PackageReference.DotNet8),
            _ => throw new ArgumentOutOfRangeException(nameof(targetFramework), targetFramework, "Unknown target framework"),
        };
    }

    private static async Task DownloadPackageAsync(string packageId, string version)
    {
        var packagePath = Path.Combine(NugetPackagesPath, packageId, version);
        if (Directory.Exists(packagePath))
        {
            return;
        }

        await using var stream = await HttpClient.GetStreamAsync(new Uri($"https://www.nuget.org/api/v2/package/{packageId}/{version}")).ConfigureAwait(false);
        using var zip = new ZipArchive(stream, ZipArchiveMode.Read);

        Directory.CreateDirectory(packagePath);
        zip.ExtractToDirectory(packagePath, overwriteFiles: true);
    }
}