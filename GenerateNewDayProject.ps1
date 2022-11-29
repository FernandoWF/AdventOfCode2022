$currentDay = Get-ChildItem -Directory |
    Where { $_.Name.StartsWith('Day') } |
    ForEach { [int]$_.Name.Substring(3) } |
    Sort |
    Select -Last 1

$currentDayFolderName = "Day$currentDay"
$nextDayFolderName = "Day$($currentDay + 1)"

New-Item -Path . -ItemType Directory -Name $nextDayFolderName > $null

Copy-Item "$currentDayFolderName\$currentDayFolderName.csproj" -Destination "$nextDayFolderName\$nextDayFolderName.csproj"

Copy-Item "$currentDayFolderName\Input.txt" -Destination "$nextDayFolderName\Input.txt"

(Get-Content "$currentDayFolderName\Part1.cs") -replace "namespace $currentDayFolderName", "namespace $nextDayFolderName" |
    Set-Content "$nextDayFolderName\Part1.cs"

(Get-Content "$currentDayFolderName\Part2.cs") -replace "namespace $currentDayFolderName", "namespace $nextDayFolderName" |
    Set-Content "$nextDayFolderName\Part2.cs"

(Get-Content "$currentDayFolderName\Program.cs") -replace "using $currentDayFolderName", "using $nextDayFolderName" |
    Set-Content "$nextDayFolderName\Program.cs"

& dotnet sln add $nextDayFolderName > $null
