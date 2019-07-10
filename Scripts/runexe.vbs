option explicit

!INC Local Scripts.EAConstants-VBScript

'
' Script Name: runexe
' Author: 
' Purpose: Script to call an executable that uses the EARepository.Helper framework
' Date: 7/9/2019
'
sub run(appExe, appPath, params)
	dim shell
	dim objWMIService
	dim colItems, objItem, pid, instanceCnt, cmdLine
	
	set shell = CreateObject("Shell.Application")

	'As only a single parameter can be passed via ShellExecute the Repository GUID would need to be in a delimited string
	'of some kind.
	'The executable will need to parse out the different parameters and get the correct repository to return results to 
	'based on the instance GUID
	shell.ShellExecute appExe, Repository.InstanceGUID & params, appPath, "", 0
end sub

run "EARepositoryTest.exe", "<path to the executable i.e. C:\....\Test\", ""