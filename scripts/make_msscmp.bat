@echo off
setlocal
cd %~dp0/../res

echo Building msscmp.dll to res/msscmp.dll
tcc -Wall -shared msscmp.c -o msscmp.dll
echo done
del msscmp.def
copy msscmp.dll "%~dp0/../bin/Debug/msscmp.dll"
endlocal