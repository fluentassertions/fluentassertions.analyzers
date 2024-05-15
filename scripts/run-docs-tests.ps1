param (
    [switch]$FormatAndExecuteTestsAgain
)

Push-Location src
Push-Location FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs
dotnet test
Pop-Location
Pop-Location

if ($FormatAndExecuteTestsAgain) {
    Push-Location src
    Push-Location FluentAssertions.Analyzers.FluentAssertionAnalyzerDocs

    $i = 1;
    do {
        Write-Host "formatting code... - Iteration $i"
        $out = dotnet format analyzers --diagnostics FAA0001 FAA0003 FAA0004 --severity info --verbosity normal

        Write-Host $out

        $i++
    } while ($out -cnotcontains "Unable to fix FAA0004. Code fix NunitCodeFixProvider didn't return a Fix All action")

    Pop-Location
    Pop-Location

    Push-Location src
    Push-Location FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator
    dotnet run verify
    Pop-Location
    Pop-Location
}
