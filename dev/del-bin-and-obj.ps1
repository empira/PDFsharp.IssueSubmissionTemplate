#Requires -PSEdition Core
#Requires -Version 7.0

Get-ChildItem .\ -include bin,obj -Recurse | ForEach-Object ($_) { remove-item $_.fullname -Force -Recurse }
