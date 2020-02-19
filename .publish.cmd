@echo off

mkdir .build
for /r %%x in (ByteBee.*.nupkg) do (
	xcopy /y /b %%x .build
)


rem xcopy /y /b .\ByteBee.Framework.Validating.Contract\bin\Release\ByteBee.Framework.*.nupkg ..\NuGetFeed\