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
    dotnet format analyzers --diagnostics FAA0001 --severity info --verbosity normal
    Pop-Location
    Pop-Location
}

if ($ValidateNoChanges) {
    $output = git status --porcelain=v1 -- docs
    if ($output) {
        git diff -- docs
        throw "The docs generator has made changes to the docs folder. Please commit these changes and push them to the repository."
    }
}