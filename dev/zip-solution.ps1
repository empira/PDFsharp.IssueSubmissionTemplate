#Requires -PSEdition Core
#Requires -Version 7.0

$root = "$PSScriptRoot\..\"
$archive = $root + "\Issue.zip"
$contents = $root + "\*"

Get-ChildItem $root -include bin,obj -Recurse | ForEach-Object ($_) { remove-item $_.fullname -Force -Recurse }

Remove-Item $archive -ErrorAction Ignore
# $files = Get-ChildItem -Path $contents -Exclude "compress.ps1"
Compress-Archive -Path $contents -DestinationPath $archive -CompressionLevel Optimal
