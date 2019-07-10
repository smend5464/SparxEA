# Sparx EA Repository Helper

A library of functions to access unique Sparx EA Repository instances, even if there are multiple repositories open.

The repository objects returned are sourced directly from the operating system COM (Component Object Model) objects and are associated with a currently open repository instance.

## Use Cases

- Extending a script to use a (.net) executable. The executable will have access to the objects in the calling scripts running instance. The instance is identified by its Repository.instanceGUID
- Getting a list of repository instances that are currently open. The objects in the list reference open repositories and can be used to extend their functionality

## Build Environment

- .Net Framework 4.7.2
- Windows 10 version 1809
- Platform x64
- Coded in C# v7

## Misc. Notes

- EARepository.Helpers is built as a dll and used in EARepositoryTest to provide a command line usage sample.
- The script sample indicates how to call an executable and have it attach to the EA instance the script is run from
- The Microsoft documentation indicates any version of the .NET framework should be able to support the functions.  I have not tested with anything other then the version in the Build Environment as that is the only development environment I have available.
- The Repository.instanceGUID appears to be dynamically generated when an EA instance is started
- Everything needs to be built for the x86 platform architecture and **not x64**
