@echo off
set BRANCH=%1
set REPO=%2

@REM cd ..
@REM echo Workspace? : %CD%

cd "Assets/Submodule/"
echo Root? : %CD%

cd "StudioCoreAssets"
echo StudioCoreAssets? : %CD%
set LOCAL_BRANCH=
for /f "tokens=*" %%i in ('git branch --list %BRANCH%') do set LOCAL_BRANCH=%%i
git ls-remote --exit-code --heads origin %BRANCH% >nul 2>nul
set EXIT_CODE=%errorlevel%

git reset --hard HEAD
if "%LOCAL_BRANCH%"=="" (
    git checkout -f %LOCAL_BRANCH%
) else if %EXIT_CODE%==0 (
    echo [ %REPO% ] Git branch '%BRANCH%' exists in the remote repository
    git checkout -f %BRANCH%
) else if %EXIT_CODE%==2 (
    echo [ %REPO% ] Git branch '%BRANCH%' does not exist in the remote repository
    git checkout -f develop
)
git pull
echo StudioCoreAssets Checkout :: %BRANCH%

cd "Submodules"
echo StudioCoreAssets/Submodules? : %CD%

cd "HoloStudioV2SDK"
echo StudioCoreAssets/Submodules/HoloStudioV2SDK? : %CD%
set LOCAL_BRANCH=
for /f "tokens=*" %%i in ('git branch --list %BRANCH%') do set LOCAL_BRANCH=%%i
git ls-remote --exit-code --heads origin %BRANCH% >nul 2>nul
set EXIT_CODE=%errorlevel%

git reset --hard HEAD
if "%LOCAL_BRANCH%"=="" (
    git checkout -f %LOCAL_BRANCH%
) else if %EXIT_CODE%==0 (
    echo [ %REPO% ] Git branch '%BRANCH%' exists in the remote repository
    git checkout -f %BRANCH%
) else if %EXIT_CODE%==2 (
    echo [ %REPO% ] Git branch '%BRANCH%' does not exist in the remote repository
    git checkout -f develop
)
git pull
echo StudioCoreAssets Checkout :: %BRANCH%
cd ..

cd "HoloMotionSDK"
echo StudioCoreAssets/Submodules/HoloMotionSDK? : %CD%
set LOCAL_BRANCH=
for /f "tokens=*" %%i in ('git branch --list %BRANCH%') do set LOCAL_BRANCH=%%i
git ls-remote --exit-code --heads origin %BRANCH% >nul 2>nul
set EXIT_CODE=%errorlevel%

git reset --hard HEAD
if "%LOCAL_BRANCH%"=="" (
    git checkout -f %LOCAL_BRANCH%
) else if %EXIT_CODE%==0 (
    echo [ %REPO% ] Git branch '%BRANCH%' exists in the remote repository
    git checkout -f %BRANCH%
) else if %EXIT_CODE%==2 (
    echo [ %REPO% ] Git branch '%BRANCH%' does not exist in the remote repository
    git checkout -f develop
)
git pull
echo HoloMotionSDK Checkout :: %BRANCH%
cd ..

cd "sdk"
echo StudioCoreAssets/Submodules/sdk? : %CD%
set LOCAL_BRANCH=
for /f "tokens=*" %%i in ('git branch --list %BRANCH%') do set LOCAL_BRANCH=%%i
git ls-remote --exit-code --heads origin %BRANCH% >nul 2>nul
set EXIT_CODE=%errorlevel%

git reset --hard HEAD
if "%LOCAL_BRANCH%"=="" (
    git checkout -f %LOCAL_BRANCH%
) else if %EXIT_CODE%==0 (
    echo [ %REPO% ] Git branch '%BRANCH%' exists in the remote repository
    git checkout -f %BRANCH%
) else if %EXIT_CODE%==2 (
    echo [ %REPO% ] Git branch '%BRANCH%' does not exist in the remote repository
    git checkout -f develop
)
git pull
echo sdk Checkout :: %BRANCH%

@REM cd ..\..\..\..\
cd ..\..\..\
exit /B

:CheckBranch

exit /B
