@echo off
setlocal

set PROJECT_DIR=%~dp0
set OUTPUT_DIR=%PROJECT_DIR%KooNXAutomationSharp\bin\Debug
set BIN_DIR=%PROJECT_DIR%bin
set MSBUILD=D:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe

echo ============================================
echo   KooNXAutomationSharp Debug Build
echo ============================================
echo.

echo [1/2] Building project (Debug)...
"%MSBUILD%" "%PROJECT_DIR%KooNXAutomationSharp.sln" /p:Configuration=Debug /p:Platform="Any CPU" /v:q /nologo
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
copy /y "%OUTPUT_DIR%\KooNXAutomationSharp.pdb" "%BIN_DIR%\" > nul 2>&1
echo       Copied to: %BIN_DIR%\
echo.

echo ============================================
echo   Debug Build Complete!
echo ============================================
echo.
echo DLL: %BIN_DIR%\KooNXAutomationSharp.dll
echo.
pause
