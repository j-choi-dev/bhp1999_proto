#!/bin/sh
BRANCH=$1
MODE=$2
root_path=$3
build_version=$4

curr_time=$(date +"%Y%m%d_%H%M")
curr_dir=$(pwd)
parent_path=$(dirname $(cd $(dirname $0); pwd))

if [[ $BRANCH == "" ]]; then
    BRANCH="develop"
fi
echo BRANCH = $BRANCH

echo before parent_path = $parent_path
if [[ $curr_dir == *"bash"* ]]; then
    echo "Back to ROOT"
    parent_path=$(dirname $(cd $(dirname $0); pwd))
    cd $parent_path
    curr_dir=$(pwd) 
    echo $curr_dir
fi
echo after parent_path = $parent_path

target_folder="Rom"
target_method=""
editor_path_win_root="C:\Program Files\Unity\Hub\Editor\2019.4.40f1\Editor\Unity.exe"
unity_successed_msg="Application will terminate with return code 0"
log_path=$parent_path"/Builds/Log/"$target_folder"/"$curr_time"_log.txt"

function CheckBranch()
{
    local _branch=${1}
    local _repo=$2
    local _local_branch=$(git branch --list ${_branch})
    git ls-remote --exit-code --heads origin $BRANCH >/dev/null 2>&1
    EXIT_CODE=$?

    git reset --hard HEAD
    if [[ -z ${_local_branch} ]]; then
        git checkout -f $_local_branch
    elif [[ $EXIT_CODE == '0' ]]; then
        echo "[ "$_repo" ] Git branch '$_branch' exists in the remote repository"
        git checkout -f $_branch
    elif [[ $EXIT_CODE == '2' ]]; then
        echo "[ "$_repo" ] Git branch '$_branch' does not exist in the remote repository"
        git checkout -f $develop
    fi
    echo "$_repo :: $_branch"
    git pull
}

if [[ $MODE == *"release"* ]]; then
  target_method="ReleaseBuildProcessByExternal"
  echo Release :: "$target_method"
else
  target_method="BuildProcessByExternal"
  echo Not Release :: "$target_method"
fi

cd "Assets\\Submodule"
cd "StudioCoreAssets"
CheckBranch "$BRANCH" "StudioCoreAssets"
echo StudioCoreAssets Checkout :: "$BRANCH"

cd "Submodules\\HoloStudioV2SDK"
CheckBranch "$BRANCH" "HoloStudioV2SDK"
echo "[ HoloStudioV2SDK ] Checkout :: ""$BRANCH"
cd ..

cd "HoloMotionSDK"
CheckBranch "$BRANCH" "HoloMotionSDK"
echo "[ HoloMotionSDK ] Checkout :: ""$BRANCH"
cd ..

cd "sdk"
CheckBranch "$BRANCH" "sdk"
echo "[ sdk ] Checkout :: ""$BRANCH"

cd .. # return StudioCoreAssets
cd .. # return Assets/Submodule
cd .. # return Assets
cd .. # return HoloStudioCore


echo -e  "[ Rom Build ] Build start!\n"

"$editor_path_win_root" -projectPath "$parent_path" -executeMethod StudioRomBuild.Editor.View.RomBuildView."$target_method" -batchmode -quit -logFile "$log_path" /root_path "$root_path" /build_version "$build_version"
while read LINE;do
    echo $LINE
done < $log_path


if echo "$(<$log_path)" | grep -sq "$unity_successed_msg"; then
    echo "[ Rom Build Main Process ] Success !!!"
else
    echo "[ Rom Build Main Process ] Fail !!!"
fi
echo -e  "[ Rom Build ] Build Finished!"

exit 0;