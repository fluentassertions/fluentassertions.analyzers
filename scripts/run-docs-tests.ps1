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
        $out = dotnet format analyzers --diagnostics FAA0001 FAA0003 FAA0004 --severity info --verbosity normal 2>&1 | Out-String | Join-String

        Write-Host "-------------$i-------------"
        Write-Host $out
        Write-Host "-------------$i-------------"
        Write-Host "output length: $($out.Length)"

        $i++
    } while (($out -ccontains "Unable to fix FAA0004. Code fix NunitCodeFixProvider didn't return a Fix All action") -or ($out -ccontains "Unable to fix FAA0003. Code fix MsTestCodeFixProvider didn't return a Fix All action"))

    Pop-Location
    Pop-Location

    Push-Location src
    Push-Location FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator
    dotnet run verify
    Pop-Location
    Pop-Location
}
