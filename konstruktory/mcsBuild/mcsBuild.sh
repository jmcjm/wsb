mcs -out:inputLibrary.dll -target:library ../dlls/inputLibrary.cs
mcs -out:carAnimation.dll -target:library ../dlls/carAnimation.cs
mcs -out:program.exe -r:carAnimation.dll -r:inputLibrary.dll ../Program.cs
