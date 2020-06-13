$files = Get-ChildItem *.txt

foreach($file in $files) {
  $enum = $file.BaseName
  write-output $enum
  .\generateEnum.ps1 -inputfile $file -enumName $enum > ".\$enum.cs"
}