@echo off

for /r %%x in (ByteBee.*.nupkg) do (
    
	xcopy /y /b %%x D:\job\NuGetFeed\
)


rem xcopy /y /b .\ByteBee.Framework.Validating.Contract\bin\Release\ByteBee.Framework.*.nupkg ..\NuGetFeed\