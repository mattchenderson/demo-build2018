.\teardown.ps1
.\provision.ps1

start microsoft-edge:https://portal.azure.com?feature.customportal=false
explorer.exe .\pictures
start ${Env:ProgramFiles(x86)}\"Microsoft Azure Storage Explorer"\StorageExplorer.exe