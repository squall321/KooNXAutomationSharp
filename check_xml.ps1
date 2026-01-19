[xml]$xml = Get-Content 'D:\Program Files\Siemens\NXStudentEdition2506\NXBIN\managed\NXOpen.xml' -Raw
$members = $xml.doc.members.member | Select-Object -First 30

foreach ($m in $members) {
    Write-Host "==="
    Write-Host "Name: $($m.name)"
    if ($m.summary) {
        $summary = $m.summary -replace '\s+', ' '
        Write-Host "Summary: $summary"
    }
}
