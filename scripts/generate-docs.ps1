
param (
    [switch]$ValidateNoChanges
)

Push-Location src
Push-Location FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator
dotnet run
Pop-Location
Pop-Location

if ($ValidateNoChanges) {
    $output = git status --porcelain=v1 -- docs
    if ($output) {
        git diff -- docs
        throw "The docs generator has made changes to the docs folder. Please commit these changes and push them to the repository."
    }
}