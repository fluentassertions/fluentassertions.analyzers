
param (
    [switch]$ValidateNoChanges
)

Push-Location src
Push-Location FluentAssertions.Analyzers.FluentAssertionAnalyzerDocsGenerator
dotnet run generate
Pop-Location
Pop-Location

if ($ValidateNoChanges) {
    $output = git status --porcelain=v1 -- docs
    if ($output) {
        $diff = git diff -- docs # HACK to ignore crlf changes 
        if ($diff) {
            git diff -- docs 
            throw "The docs generator has made changes to the docs folder. Please commit these changes and push them to the repository."
        }
    }
}