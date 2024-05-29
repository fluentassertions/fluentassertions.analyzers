using System.Collections.Generic;

public class PackageReference
{
    private static readonly List<PackageReference> _allDependencies = new();

    public string Name { get; }
    public string Version { get; }
    public string Path { get; }


    private PackageReference(string name, string version, string path)
    {
        Name = name;
        Version = version;
        Path = path;

        _allDependencies.Add(this);
    }

    public static PackageReference FluentAssertions_6_12_0 { get; } = new("FluentAssertions", "6.12.0", "lib/netstandard2.0/");
    public static PackageReference MSTestTestFramework_3_1_1 { get; } = new("MSTest.TestFramework", "3.1.1", "lib/netstandard2.0/");
    public static PackageReference XunitAssert_2_5_1 { get; } = new("xunit.assert", "2.5.1", "lib/netstandard1.1/");
    public static PackageReference Nunit_3_14_0 { get; } = new("NUnit", "3.14.0", "lib/netstandard2.0/");
    public static PackageReference Nunit_4_0_1 { get; } = new("NUnit", "4.0.1", "lib/net6.0/");

    internal static PackageReference NETStandard2_0 = new("NETStandard.Library", "2.0.3", "build/netstandard2.0/ref/");
    internal static PackageReference NETStandard2_1 = new("NETStandard.Library.Ref", "2.1.0", "ref/netstandard2.1/ref/");
    internal static PackageReference DotNet6 = new("Microsoft.NETCore.App.Ref", "6.0.31", "ref/net6.0/");
    internal static PackageReference DotNet7 = new("Microsoft.NETCore.App.Ref", "7.0.20", "ref/net7.0/");
    internal static PackageReference DotNet8 = new("Microsoft.NETCore.App.Ref", "8.0.6", "ref/net8.0/");

    internal static IEnumerable<PackageReference> AllDependencies => _allDependencies;
}
