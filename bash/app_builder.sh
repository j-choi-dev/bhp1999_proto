#!/bin/sh
parent_path=$(dirname $(cd $(dirname $0); pwd))
target_folder="Rom"
#########################################
# SubScript
#########################################
source $parent_path/bash_sub/common_builder_setting.sh
source $parent_path/bash_sub/common_build_const_value.sh
source $parent_path/bash_sub/common_build_pre_process.sh
source $parent_path/bash_sub/app_build_main_process.sh

#########################################
# Local
#########################################
curr_time=$curr_system_time
log_path=$parent_path"/Builds/Log/"$target_folder"/"$curr_time"_log.txt"

clear

#########################################
# Build Process
#########################################
pre_process

echo -e  "[ Rom Build ] Build start!\n"

getval=$(main_process "$parent_path" "$editor_path_win" "$log_path") 

#########################################
# Build Result
#########################################
if echo "$getval" | grep -sq "$batch_successed_key_msg"; then
    echo "${ESC}"$color_start_successed">>>> [ Rom Build ] build complete by SUCCESSED !!!"${ESC}$color_end_code
else
    echo "${ESC}"$color_start_failed">>>> [ Rom Build ] build complete by FAILED !!!"${ESC}$color_end_code
    exit 1;
fi
echo -e "[ Rom Build ] Build Complete\n"

exit 0;
