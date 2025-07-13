#!/bin/sh
#########################################
# Value
#########################################
curr_time=$(date +"%Y%m%d_%H%M")
parent_path=$(dirname $(cd $(dirname $0); pwd))
target_folder="Rom"
editor_path_win_root="C:\Program Files\Unity\Hub\Editor\2022.3.22f1\Editor\Unity.exe"
unity_successed_msg="Application will terminate with return code 0"
log_path=$parent_path"/Builds/Log/"$target_folder"/"$curr_time"_log.txt"

root_path=$1
build_version=$2

echo before parent_path = $parent_path
if [[ $curr_dir == *"bash"* ]]; then
    echo "Back to ROOT"
    parent_path=$(dirname $(cd $(dirname $0); pwd))
    cd $parent_path
    curr_dir=$(pwd) 
    echo $curr_dir
fi
echo after parent_path = $parent_path

#########################################
# Build Process
#########################################
echo -e  "[ Rom Build ] Build start!\n"

"$editor_path_win_root" -projectPath "$parent_path" -executeMethod GameSystemSDK.Editor.Build.View.RomBuildView.IOSBuildProcessByExternal -batchmode -quit -logFile "$log_path" /root_path "$root_path" /build_version "$build_version"
while read LINE;do
    echo $LINE
done < $log_path

#########################################
# Build Result
#########################################
if echo "$(<$log_path)" | grep -sq "$unity_successed_msg"; then
    echo ">>>>>>>> [ Rom Build Main Process ] Success !!!"
else
    echo ">>>>>>>> [ Rom Build Main Process ] Fail !!!"
fi
echo -e  "[ Rom Build ] Build Finished!"

exit 0;
