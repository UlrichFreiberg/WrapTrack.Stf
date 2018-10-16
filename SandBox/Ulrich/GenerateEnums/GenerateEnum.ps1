param ($inputfile, $enumName)

$content = get-content $inputfile

function HandleOneEnumMember($line) {
  $enumMemberName = (Get-Culture).TextInfo.ToTitleCase($line.ToLower()) -replace "[^a-zA-Z0-9]", ""
  Write-Output ""
  
  Write-Output "   /// <summary>"
  Write-Output "   /// $line"
  Write-Output "   /// </summary>"
  Write-Output "   [Display(Name = @""$line"")]"
  Write-Output "   $enumMemberName," 
}

Write-Output "using System.ComponentModel.DataAnnotations;"
Write-Output ""
Write-Output "public enum $enumName" 
Write-Output "{" 

HandleOneEnumMember "Unknown";

foreach ($line in $content) {
   HandleOneEnumMember $line.Trim();
}
  
Write-Output "}" 
