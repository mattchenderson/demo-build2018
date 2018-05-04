az group create -n thr2004 -l westus2
az group create -n thr3302 -l westus2

az group deployment create -g thr2004 -n thr2004-setup --template-file .\thr2004\thr2004-template.json
az group deployment create -g thr3302 -n thr3302-setup --template-file .\thr3302\thr3302-template.json