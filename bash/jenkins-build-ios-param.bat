@echo off
set BRANCH=%1
set MODE=%2
set JOB=%3

@REM cd .. @REM Return to ROOT 
echo JOB = %JOB%

set PARENT_PATH=%CD%
set TARGET_FOLDER=Rom
set TARGET_METHOD=

echo before parent_path = $parent_path
set "curr_dir=%cd%"
if "%curr_dir:bash=%" neq "%curr_dir%" (
    echo Back to ROOT
    cd ..
    cd ..
    set "parent_path=%cd%"
    echo %parent_path%
    cd %parent_path%
    set "curr_dir=%cd%"
    echo %curr_dir%
)
echo after parent_path = %parent_path%

if "%MODE%" == "release" (
    set TARGET_METHOD=IOSReleaseBuildProcessByExternal
    echo Release :: "%TARGET_METHOD%"
) else (
    set TARGET_METHOD=IOSBuildProcessByExternal
    echo Not Release :: "%TARGET_METHOD%"
)
echo TARGET_METHOD :: "%TARGET_METHOD%"

set EDITOR_PATH=C:\Program Files\Unity\Hub\Editor\2022.3.22f1\Editor\Unity.exe
set UNITY_SUCCESS_MSG=Application will terminate with return code 0
set LOG_PATH=%PARENT_PATH%\Builds\Log\%TARGET_FOLDER%\%JOB%_log.txt

echo LOG_PATH = %LOG_PATH%
echo -e  "[ Rom Build ] Build start! %BRANCH% ... %MODE%\n"

"%EDITOR_PATH%" -projectPath "%PARENT_PATH%" -executeMethod GameSystemSDK.Editor.Build.View.RomBuildView.%TARGET_METHOD% -batchmode -quit -logFile "%LOG_PATH%" /root_path "%ROOT_PATH%" /build_version "%BUILD_VERSION%"
type "%LOG_PATH%"

findstr /C:"%UNITY_SUCCESS_MSG%" "%LOG_PATH%" >nul
if %errorlevel% equ 0 (
    echo [ Rom Build Main Process ] Success !!!
) else (
    echo [ Rom Build Main Process ] Fail !!!
)
echo -e  "[ Rom Build ] Build Finished!"

exit /B 0
