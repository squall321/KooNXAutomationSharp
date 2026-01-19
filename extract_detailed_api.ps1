[xml]$xml = Get-Content 'D:\Program Files\Siemens\NXStudentEdition2506\NXBIN\managed\NXOpen.xml' -Raw

$output = @()
$output += "# NXOpen API Detailed Reference"
$output += ""
$output += "This document contains detailed descriptions extracted from the official NXOpen XML documentation."
$output += ""

# Key classes to document
$keyTypes = @(
    'T:NXOpen.Session',
    'T:NXOpen.Part',
    'T:NXOpen.BasePart',
    'T:NXOpen.Body',
    'T:NXOpen.Face',
    'T:NXOpen.Edge',
    'T:NXOpen.Point',
    'T:NXOpen.Curve',
    'T:NXOpen.Line',
    'T:NXOpen.Arc',
    'T:NXOpen.Spline',
    'T:NXOpen.Expression',
    'T:NXOpen.NXObject',
    'T:NXOpen.Builder',
    'T:NXOpen.Features.Feature',
    'T:NXOpen.Features.FeatureCollection',
    'T:NXOpen.Features.ExtrudeBuilder',
    'T:NXOpen.Features.RevolveBuilder',
    'T:NXOpen.Features.BooleanBuilder',
    'T:NXOpen.Features.ChamferBuilder',
    'T:NXOpen.Features.EdgeBlendBuilder',
    'T:NXOpen.Features.HoleFeatureBuilder',
    'T:NXOpen.Features.BlockFeatureBuilder',
    'T:NXOpen.Features.CylinderBuilder',
    'T:NXOpen.Features.SphereBuilder',
    'T:NXOpen.Features.ConeBuilder',
    'T:NXOpen.Sketch',
    'T:NXOpen.SketchCollection'
)

foreach ($typeName in $keyTypes) {
    $typeDoc = $xml.doc.members.member | Where-Object { $_.name -eq $typeName }
    if ($typeDoc) {
        $shortName = $typeName -replace 'T:NXOpen\.', '' -replace 'T:NXOpen\.Features\.', 'Features.'
        $output += "## $shortName"

        if ($typeDoc.summary) {
            $summary = ($typeDoc.summary -replace '\s+', ' ').Trim()
            $output += ""
            $output += $summary
        }
        $output += ""

        # Get methods and properties for this type
        $prefix = $typeName -replace '^T:', ''
        $members = $xml.doc.members.member | Where-Object {
            ($_.name -like "M:$prefix.*" -or $_.name -like "P:$prefix.*") -and
            $_.name -notlike "*#*"
        } | Select-Object -First 30

        if ($members.Count -gt 0) {
            $output += "### Members"
            $output += ""
            foreach ($m in $members) {
                $memberName = $m.name -replace "^[MP]:$prefix\.", ''
                $memberType = if ($m.name -like "P:*") { "[Property]" } else { "[Method]" }
                $memberSummary = if ($m.summary) { ($m.summary -replace '\s+', ' ').Trim() } else { "" }

                if ($memberSummary) {
                    $output += "- **$memberName** $memberType"
                    $output += "  - $memberSummary"
                }
            }
            $output += ""
        }
    }
}

# Feature Builders with descriptions
$output += "---"
$output += ""
$output += "# Feature Builders Reference"
$output += ""

$builderTypes = @(
    'T:NXOpen.Features.ExtrudeBuilder',
    'T:NXOpen.Features.RevolveBuilder',
    'T:NXOpen.Features.SweepAlongGuideBuilder',
    'T:NXOpen.Features.ThroughCurvesBuilder',
    'T:NXOpen.Features.BooleanBuilder',
    'T:NXOpen.Features.TrimBodyBuilder',
    'T:NXOpen.Features.SplitBodyBuilder',
    'T:NXOpen.Features.ChamferBuilder',
    'T:NXOpen.Features.EdgeBlendBuilder',
    'T:NXOpen.Features.ShellBuilder',
    'T:NXOpen.Features.DraftBuilder',
    'T:NXOpen.Features.HoleFeatureBuilder',
    'T:NXOpen.Features.ThreadBuilder',
    'T:NXOpen.Features.PatternFeatureBuilder',
    'T:NXOpen.Features.MirrorFeatureBuilder',
    'T:NXOpen.Features.BlockFeatureBuilder',
    'T:NXOpen.Features.CylinderBuilder',
    'T:NXOpen.Features.SphereBuilder',
    'T:NXOpen.Features.ConeBuilder',
    'T:NXOpen.Features.TubeBuilder',
    'T:NXOpen.Features.OffsetSurfaceBuilder',
    'T:NXOpen.Features.ThickenBuilder',
    'T:NXOpen.Features.ProjectCurveBuilder',
    'T:NXOpen.Features.IntersectionCurveBuilder',
    'T:NXOpen.Features.BridgeCurveBuilder',
    'T:NXOpen.Features.CompositeCurveBuilder',
    'T:NXOpen.Features.DatumPlaneBuilder',
    'T:NXOpen.Features.DatumAxisBuilder',
    'T:NXOpen.Features.DatumCsysBuilder'
)

foreach ($typeName in $builderTypes) {
    $typeDoc = $xml.doc.members.member | Where-Object { $_.name -eq $typeName }
    if ($typeDoc) {
        $shortName = $typeName -replace 'T:NXOpen\.Features\.', ''
        $output += "## $shortName"

        if ($typeDoc.summary) {
            $summary = ($typeDoc.summary -replace '\s+', ' ').Trim()
            $output += ""
            $output += $summary
        }
        $output += ""

        # Get key properties
        $prefix = $typeName -replace '^T:', ''
        $props = $xml.doc.members.member | Where-Object {
            $_.name -like "P:$prefix.*" -and $_.name -notlike "*#*"
        } | Select-Object -First 20

        if ($props.Count -gt 0) {
            $output += "### Properties"
            $output += ""
            foreach ($p in $props) {
                $propName = $p.name -replace "^P:$prefix\.", ''
                $propSummary = if ($p.summary) { ($p.summary -replace '\s+', ' ').Trim() } else { "" }

                if ($propSummary) {
                    $output += "- **$propName**: $propSummary"
                }
            }
            $output += ""
        }
    }
}

$output | Out-File -FilePath 'd:\KooNXAutomationSharp\docs\NXOpen_API_Detailed.md' -Encoding UTF8

Write-Host "Done! Saved to docs/NXOpen_API_Detailed.md"
