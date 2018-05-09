function superDelete {
    Param ([string]$g)
    $webAppList = az webapp list -g $g --query "[].{hostName: defaultHostName}" | ConvertFrom-Json
    foreach ($webapp in $webAppList) {
        $appUrl = "https://" + $webapp.hostName
        #Write-Host $appUrl
        $appRegList = az ad app list --identifier-uri $appUrl --query "[].{id: appId}" | ConvertFrom-Json
        foreach ($appReg in $appRegList) {
            $appId = $appReg.id
            #Write-Host $appId
            az ad app delete --id $appId
        }
    }
    az group delete -n $g --yes
}

#superDelete -g thr2004
superDelete -g thr3302