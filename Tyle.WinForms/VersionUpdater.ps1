param (
	[Parameter(Mandatory=$true)][string]$projectDir
)

$startTime=(Get-Date).ToUniversalTime()

$templateFilePath = [System.IO.Path]::Combine($projectDir, ".\AppMetaData.cs.Template")
$targetFilePath = [System.IO.Path]::Combine($projectDir, ".\AppMetaData.cs")

Write-Host "Template   :  $templateFilePath"
Write-Host "Target     :  $targetFilePath"

$minorVer  = $startTime.ToString("yyMM")
$buildVer  = $startTime.ToString("dd")
$revision  = $startTime.ToString("HHmm")
$timeStamp = $startTime.ToString("yyyy-MM-dd  HH:mm:ss") + " UTC"

Write-Host "Minor      :  $minorVer"
Write-Host "Build      :  $buildVer"
Write-Host "Revision   :  $revision"

$repoBranch= & git rev-parse --abbrev-ref HEAD
$commitHash= & git rev-parse HEAD

Write-Host "RepoBranch :  $repoBranch"
Write-Host "CommitHash :  $commitHash"

$content = [System.IO.File]::ReadAllText($templateFilePath)
$content = $content.Replace("[PS_Stub_Minor]", $minorVer).Replace("[PS_Stub_Build]", $buildVer).Replace("[PS_Stub_Revision]", $revision)
$content = $content.Replace("[PS_Stub_CopyRightYear]", $startTime.ToString("yyyy"))
$content = $content.Replace("[PS_Stub_RepoBranch]", $repoBranch).Replace("[PS_Stub_CommitHash]", $commitHash)
$content = $content.Replace("[PS_Stub_BuildTimeStamp]", $timeStamp)

Write-Host "Content    :"
Write-Host $content
Write-Host

[System.IO.File]::WriteAllText($targetFilePath, $content)
