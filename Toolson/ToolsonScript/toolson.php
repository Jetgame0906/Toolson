<?php
function toolson_GetVersion(){
	echo "This feauture is not supported\n";
}
function toolson_DebugWait($debuginfo){
	echo (string)$debuginfo.":Press Enter to Continue\n";
	fgets(STDIN, 4096);
}
?>