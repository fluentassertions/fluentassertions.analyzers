param (
    [switch]$FormatAndExecuteTestsAgain
)

function RunTestsAndValidate {
    param (
        [string]$project
    )

    Push-Location src
    Push-Location $project
    dotnet test
    Pop-Location
    Pop-Location

    if ($FormatAndExecuteTestsAgain) {
        Push-Location src
        Push-Location $project

        $i = 1;
        do {
            Write-Host "formatting code... - Iteration $i"
            $out = dotnet format analyzers --diagnostics FAA0001 FAA0003 FAA0004 --severity info --verbosity normal 2>&1 | Out-String | Join-String

            Write-Host "-------------$i-------------"
            Write-Host $out
            Write-Host "-------------$i-------------"
            Write-Host "output length: $($out.Length)"

            $i++
        } while ($out.Contains("Unable to fix FAA000"))

        Pop-Location
        Pop-Location

        Push-Location src
        Push-Location $project
        dotnet test
        Pop-Location
        Pop-Location
    }
}

RunTestsAndValidate -project FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs
RunTestsAndValidate -project FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs.Nunit4
RunTestsAndValidate -project FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs.Nunit3