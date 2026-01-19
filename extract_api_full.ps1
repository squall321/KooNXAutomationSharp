$asm = [System.Reflection.Assembly]::LoadFrom('D:\Program Files\Siemens\NXStudentEdition2506\NXBIN\managed\NXOpen.dll')
$types = $asm.GetExportedTypes()

$output = @()

# Features builders
$output += "## Feature Builders (NXOpen.Features)"
$output += ""
$featureBuilders = $types | Where-Object { $_.Namespace -eq 'NXOpen.Features' -and $_.IsClass -and $_.Name -like '*Builder' } | Sort-Object Name
$output += "Total: $($featureBuilders.Count) builders"
$output += ""
foreach ($fb in $featureBuilders) {
    $output += "- $($fb.Name)"
}

# FeatureCollection methods
$output += ""
$output += "## FeatureCollection Methods"
$fc = $types | Where-Object { $_.Name -eq 'FeatureCollection' -and $_.Namespace -eq 'NXOpen.Features' }
if ($fc) {
    $methods = $fc.GetMethods() | Where-Object { $_.DeclaringType.Name -eq 'FeatureCollection' -and $_.Name -like 'Create*' } | Sort-Object Name
    foreach ($m in $methods) {
        $output += "- $($m.Name)"
    }
}

# CAM namespace
$output += ""
$output += "## CAM Classes (NXOpen.CAM)"
$output += ""
$camTypes = $types | Where-Object { $_.Namespace -eq 'NXOpen.CAM' -and $_.IsClass -and $_.Name -like '*Builder' } | Select-Object -First 50 Name
foreach ($ct in $camTypes) {
    $output += "- $($ct.Name)"
}

# Assemblies namespace
$output += ""
$output += "## Assemblies Classes (NXOpen.Assemblies)"
$output += ""
$asmTypes = $types | Where-Object { $_.Namespace -eq 'NXOpen.Assemblies' -and $_.IsClass } | Select-Object Name
foreach ($at in $asmTypes) {
    $output += "- $($at.Name)"
}

# GeometricUtilities
$output += ""
$output += "## GeometricUtilities Classes"
$output += ""
$geoTypes = $types | Where-Object { $_.Namespace -eq 'NXOpen.GeometricUtilities' -and $_.IsClass } | Select-Object -First 50 Name
foreach ($gt in $geoTypes) {
    $output += "- $($gt.Name)"
}

$output | Out-File -FilePath 'd:\KooNXAutomationSharp\docs\NXOpen_API_Extended.md' -Encoding UTF8

Write-Host "Done!"
