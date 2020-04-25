#(Get-Content .\AppMetaDataTemplate.cs).Replace('[PS_Stub_Date]', (Get-Date).ToString("yyyyMMdd")) | Set-Content .\AppMetaData.cs
#timeout /t 10
#(Get-Content .\AppMetaData.cs).Replace('[PS_Stub_Time]', (Get-Date).ToString("hhmmssfff")) | Set-Content .\AppMetaData.cs
#pause

param (
	[Parameter(Mandatory=$true)][string]$projectDir
)
$startTime=(Get-Date)
$templateFilePath = [System.IO.Path]::Combine($projectDir, ".\AppMetaData.cs.Template")
$targetFilePath = [System.IO.Path]::Combine($projectDir, ".\AppMetaData.cs")
$content = [System.IO.File]::ReadAllText($templateFilePath).Replace("[PS_Stub_Date]", (($startTime).ToString("yyMMdd"))).Replace("[PS_Stub_Time]", (($startTime).ToString("HHmmss"))).Replace("[PS_Stub_CopyRightYear]", (($startTime).ToString("yyyy")))
[System.IO.File]::WriteAllText($targetFilePath, $content)
pause