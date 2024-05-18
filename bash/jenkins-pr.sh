#!/bin/sh
#########################################
# Value
#########################################
curr_time=$(date +"%Y%m%d_%H%M")
parent_path=$(dirname $(cd $(dirname $0); pwd))
target_folder="Rom"
editor_path_win_root="C:\Program Files\Unity\Hub\Editor\2019.4.40f1\Editor\Unity.exe"
unity_successed_msg="Application will terminate with return code 0"
log_path=$parent_path"/Builds/Log/"$target_folder"/"$curr_time"_log.txt"

"$editor_path_win_root" -projectPath "$parent_path" -executeMethod StudioRomBuild.Editor.View.RomBuildView.DoCheckCompileError -batchmode -quit -logFile "$log_path"
while read LINE;do
    echo $LINE
done < $log_path

echo "$(<$log_path)"

if echo "$(<$log_path)" | grep -sq "$unity_successed_msg"; then
    retval="Check OK"
else
    retval="Check NG"
fi

echo "$retval"

exit 0;
