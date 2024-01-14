public class PackageReference
{
    public string Name { get; }
    public string Version { get; }
    public string Path { get; }

    public PackageReference(string name, string version, string path) => (Name, Version, Path) = (name, version, path);

    public static PackageReference FluentAssertions_6_12_0 { get; } = FluentAssertions("6.12.0");

    public static PackageReference MSTestTestFramework_3_1_1 { get; } = new("MSTest.TestFramework", "3.1.1", "lib/netstandard2.0/");
    public static PackageReference XunitAssert_2_5_1 { get; } = new("xunit.assert", "2.5.1", "lib/netstandard1.1/");
    public static PackageReference Nunit_3_14_0 { get; } = new("NUnit", "3.14.0", "lib/netstandard2.0/");
    public static PackageReference Nunit_4_0_1 { get; } = new("NUnit", "4.0.1", "lib/net6.0/");

    public static PackageReference FluentAssertions(string version) => new("FluentAssertions", version, "lib/netstandard2.0/");
}
