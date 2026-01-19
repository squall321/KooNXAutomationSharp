@echo off
setlocal

set PROJECT_DIR=%~dp0
set MSBUILD="D:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
set OUTPUT_DIR=%PROJECT_DIR%KooNXAutomationSharp\bin\Release
set BIN_DIR=%PROJECT_DIR%bin

echo ============================================
echo   KooNXAutomationSharp Build Script
echo ============================================
echo.

echo [1/2] Building project (Release)...
%MSBUILD% "%PROJECT_DIR%KooNXAutomationSharp\KooNXAutomationSharp.csproj" /p:Configuration=Release /p:Platform=x64 /v:q /nologo
if errorlevel 1 (
    echo.
    echo [ERROR] Build failed!
    pause
    exit /b 1
)
echo       Build successful!
echo.

echo [2/2] Copying to bin folder...
if not exist "%BIN_DIR%" mkdir "%BIN_DIR%"
copy /y "%OUTPUT_DIR%\KooNXAutomationSharp.dll" "%BIN_DIR%\" > nul
echo       Copied to: %BIN_DIR%\KooNXAutomationSharp.dll
echo.

echo ============================================
echo   Build Complete!
echo ============================================
echo.
echo DLL: %BIN_DIR%\KooNXAutomationSharp.dll
echo.
pause
