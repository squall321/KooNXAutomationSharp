# Quick extraction using Select-String instead of XML parsing
$xmlPath = 'D:\Program Files\Siemens\NXStudentEdition2506\NXBIN\managed\NXOpen.xml'

$output = @()
$output += "# NXOpen API Detailed Reference"
$output += ""
$output += "Extracted from official NXOpen XML documentation."
$output += ""

# Key types to find
$keyTypes = @(
    'NXOpen.Session',
    'NXOpen.Part',
    'NXOpen.Body',
    'NXOpen.Face',
    'NXOpen.Edge',
    'NXOpen.Features.ExtrudeBuilder',
    'NXOpen.Features.RevolveBuilder',
    'NXOpen.Features.BooleanBuilder',
    'NXOpen.Features.EdgeBlendBuilder',
    'NXOpen.Features.ChamferBuilder'
)

# Read file content
$content = Get-Content $xmlPath -Raw

foreach ($typeName in $keyTypes) {
    $output += "## $($typeName -replace 'NXOpen\.', '')"
    $output += ""

    # Find type summary
    $pattern = "<member name=`"T:$typeName`">\s*<summary>\s*(.*?)\s*</summary>"
    if ($content -match $pattern) {
        $summary = $matches[1] -replace '\s+', ' '
        $output += $summary.Trim()
        $output += ""
    }

    # Find some methods
    $methodPattern = "<member name=`"M:$typeName\.(\w+).*?`">\s*<summary>\s*(.*?)\s*</summary>"
    $methodMatches = [regex]::Matches($content, $methodPattern) | Select-Object -First 10

    if ($methodMatches.Count -gt 0) {
        $output += "### Methods"
        foreach ($m in $methodMatches) {
            $methodName = $m.Groups[1].Value
            $methodSummary = ($m.Groups[2].Value -replace '\s+', ' ').Trim()
            $output += "- **$methodName**: $methodSummary"
        }
        $output += ""
    }

    # Find some properties
    $propPattern = "<member name=`"P:$typeName\.(\w+)`">\s*<summary>\s*(.*?)\s*</summary>"
    $propMatches = [regex]::Matches($content, $propPattern) | Select-Object -First 10

    if ($propMatches.Count -gt 0) {
        $output += "### Properties"
        foreach ($p in $propMatches) {
            $propName = $p.Groups[1].Value
            $propSummary = ($p.Groups[2].Value -replace '\s+', ' ').Trim()
            $output += "- **$propName**: $propSummary"
        }
        $output += ""
    }
}

$output | Out-File -FilePath 'd:\KooNXAutomationSharp\docs\NXOpen_API_Detailed.md' -Encoding UTF8
Write-Host "Done!"
