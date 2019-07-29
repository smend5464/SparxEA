!INC Local Scripts.EAConstants-JScript

/*
 * Script Name: 
 * Author: 
 * Purpose: 
 * Date: 
 */
 
function main()
{
	// TODO: Enter script code here!
	app = "<path to the executable>\\EARepositoryTest.exe"
	run(app)
}

function run(exePath)
{
	shell = new COMObject("Shell.Application")
	shell.ShellExecute(exePath, Repository.InstanceGUID)
}

main();