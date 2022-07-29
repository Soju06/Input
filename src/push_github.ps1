$ver_value = Read-Host "Version"
$path = "./Input/bin/Release/Input." + $ver_value + ".nupkg"

[void][System.Console]::WriteLine()
[void][System.Console]::WriteLine($path)
[void][System.Console]::WriteLine("Press any key to continue...")
[void][System.Console]::ReadKey($true)

[void][System.Console]::WriteLine("Pushing to github.com...")
nuget push $path -source https://nuget.pkg.github.com/soju06/index.json 

[void][System.Console]::WriteLine()
[void][System.Console]::WriteLine("Press any key to continue...")
[void][System.Console]::ReadKey($true)