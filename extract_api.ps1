$asm = [System.Reflection.Assembly]::LoadFrom('D:\Program Files\Siemens\NXStudentEdition2506\NXBIN\managed\NXOpen.dll')
$types = $asm.GetExportedTypes()

$output = @()
$output += "# NXOpen API Reference"
$output += "Total Types: $($types.Count)"
$output += ""

# Namespaces
$namespaces = $types | ForEach-Object { $_.Namespace } | Sort-Object -Unique
$output += "## Namespaces ($($namespaces.Count))"
foreach ($ns in $namespaces) {
    $count = ($types | Where-Object { $_.Namespace -eq $ns }).Count
    $output += "- $ns ($count types)"
}

$output += ""
$output += "## Core Classes (NXOpen namespace)"
$output += ""

# Key classes to document
$keyClasses = @('Session', 'Part', 'BasePart', 'Body', 'Face', 'Edge', 'Point', 'Curve', 'Line', 'Arc', 'Spline', 'NXObject', 'TaggedObject', 'Builder', 'Expression', 'CoordinateSystem', 'CartesianCoordinateSystem', 'Matrix3x3', 'Point3d', 'Vector3d')

foreach ($className in $keyClasses) {
    $type = $types | Where-Object { $_.Name -eq $className -and $_.Namespace -eq 'NXOpen' } | Select-Object -First 1
    if ($type) {
        $output += "### $className"
        if ($type.BaseType) {
            $output += "Base: $($type.BaseType.Name)"
        }

        # Properties
        $props = $type.GetProperties([System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::DeclaredOnly)
        if ($props.Count -gt 0) {
            $output += "**Properties:**"
            foreach ($prop in ($props | Select-Object -First 20)) {
                $output += "- $($prop.Name): $($prop.PropertyType.Name)"
            }
        }

        # Methods
        $methods = $type.GetMethods([System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::DeclaredOnly) | Where-Object { -not $_.IsSpecialName }
        if ($methods.Count -gt 0) {
            $output += "**Methods:**"
            foreach ($method in ($methods | Select-Object -First 20)) {
                $params = $method.GetParameters() | ForEach-Object { "$($_.ParameterType.Name) $($_.Name)" }
                $paramStr = $params -join ", "
                $output += "- $($method.Name)($paramStr): $($method.ReturnType.Name)"
            }
        }
        $output += ""
    }
}

# Features namespace
$output += "## Features (NXOpen.Features)"
$output += ""
$featureTypes = $types | Where-Object { $_.Namespace -eq 'NXOpen.Features' -and $_.IsClass -and $_.Name -like '*Builder' } | Select-Object -First 30 Name
foreach ($ft in $featureTypes) {
    $output += "- $($ft.Name)"
}

$output | Out-File -FilePath 'd:\KooNXAutomationSharp\docs\NXOpen_API_Reference.md' -Encoding UTF8

Write-Host "Done! Output saved to docs/NXOpen_API_Reference.md"
