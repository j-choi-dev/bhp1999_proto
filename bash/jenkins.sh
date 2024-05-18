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

#########################################
# Build Process
#########################################
echo -e  "[ Rom Build ] Build start!\n"

"$editor_path_win_root" -projectPath "$parent_path" -executeMethod GameSystemSDK.Editor.Build.View.RomBuildView.BuildProcessByExternal -batchmode -quit -logFile "$log_path" /root_path "$root_path" /build_version "$build_version"
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
