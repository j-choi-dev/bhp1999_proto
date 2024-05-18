#!/bin/sh
BRANCH=$1
git ls-remote --exit-code --heads origin $BRANCH >/dev/null 2>&1
EXIT_CODE=$?

function CheckBranch()
{
    local _branch=${1}
    local _repo=$2
    local _local_branch=$(git branch --list ${_branch})
    if [[ -z ${_local_branch} ]]; then
        git checkout -f $_local_branch
    elif [[ $EXIT_CODE == '0' ]]; then
        echo "[ "$_repo" ] Git branch '$_branch' exists in the remote repository"
        git checkout -f $_branch
    elif [[ $EXIT_CODE == '2' ]]; then
        echo "[ "$_repo" ] Git branch '$_branch' does not exist in the remote repository"
        git checkout -f $develop
    fi
    git pull
}

cd "Assets/Submodule/"
cd "StudioCoreAssets"
CheckBranch "$BRANCH" "StudioCoreAssets"
cd "Submodules"

cd HoloStudioV2SDK
CheckBranch "$BRANCH" "HoloStudioV2SDK"
cd ..

cd "HoloMotionSDK"
CheckBranch "$BRANCH" "HoloMotionSDK"
cd ..

cd "sdk"
CheckBranch "$BRANCH" "sdk"
cd ..

cd .. # return StudioCoreAssets
cd .. # return Assets/Submodule
cd .. # return Assets
cd .. # return HoloStudioCore