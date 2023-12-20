using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

public static class SolutionExtensions
{
    private static readonly string NugetPackagesPath = Environment.GetEnvironmentVariable("NUGET_PACKAGES")
        ?? (OperatingSystem.IsWindows() ? Environment.ExpandEnvironmentVariables("%userprofile%\\.nuget\\packages") : "~/.nuget/packages");

    private static readonly HttpClient HttpClient = new HttpClient();

    public static Solution AddPackageReference(this Solution solution, ProjectId projectId, PackageReference package)
    {
        DownloadPackageAsync(package.Name, package.Version).GetAwaiter().GetResult();

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
            TargetFramework.NetStandard2_0 => solution.AddPackageReference(projectId, new("NETStandard.Library", "2.0.3", "build/netstandard2.0/ref/")),
            TargetFramework.NetStandard2_1 => solution.AddPackageReference(projectId, new("NETStandard.Library.Ref", "2.1.0", "ref/netstandard2.1/ref/")),
            TargetFramework.Net6_0 => solution.AddPackageReference(projectId, new("Microsoft.NETCore.App.Ref", "6.0.25", "ref/net6.0/")),
            TargetFramework.Net7_0 => solution.AddPackageReference(projectId, new("Microsoft.NETCore.App.Ref", "7.0.14", "ref/net7.0/")),
            TargetFramework.Net8_0 => solution.AddPackageReference(projectId, new("Microsoft.NETCore.App.Ref", "8.0.0", "ref/net8.0/")),
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