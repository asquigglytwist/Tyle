param (
	[Parameter(Mandatory=$true)][string]$solutionDir,
	[Parameter(Mandatory=$true)][string]$buildMode
)

$startTimeLocal=(Get-Date)
$startTimeUTC=$startTimeLocal.ToUniversalTime()

$corePath = [System.IO.Path]::Combine($solutionDir, "Src\Core")
$templateFilePath = [System.IO.Path]::Combine($corePath, "AppMetaData.cs.Template")
$targetFilePath = [System.IO.Path]::Combine($corePath, "AppMetaData.cs")

Write-Host "Template   :  $templateFilePath"
Write-Host "Target     :  $targetFilePath"

$minorVer  = $startTimeUTC.ToString("yyMM")
$buildVer  = $startTimeUTC.ToString("dd")
$revision  = $startTimeUTC.ToString("HHmm")
$timeStamp = $startTimeUTC.ToString("yyyy-MM-dd  HH:mm:ss") + " UTC"

Write-Host "Minor      :  $minorVer"
Write-Host "Build      :  $buildVer"
Write-Host "Revision   :  $revision"

$repoBranch= & git rev-parse --abbrev-ref HEAD
$commitHash= & git rev-parse HEAD

Write-Host "RepoBranch :  $repoBranch"
Write-Host "CommitHash :  $commitHash"

$content = [System.IO.File]::ReadAllText($templateFilePath)
$content = $content.Replace("[PS_Stub_Minor]", $minorVer).Replace("[PS_Stub_Build]", $buildVer).Replace("[PS_Stub_Revision]", $revision)
$content = $content.Replace("[PS_Stub_CopyRightYear]", $startTimeUTC.ToString("yyyy"))
$content = $content.Replace("[PS_Stub_RepoBranch]", $repoBranch).Replace("[PS_Stub_CommitHash]", $commitHash)
$content = $content.Replace("[PS_Stub_BuildTimeStamp]", $timeStamp)

Write-Host "Content    :"
Write-Host $content
Write-Host

[System.IO.File]::WriteAllText($targetFilePath, $content)
