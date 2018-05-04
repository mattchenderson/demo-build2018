az group create -n thr2004 -l eastus2
az group create -n thr3302 -l eastus

az group deployment create -g thr2004 -n thr2004-setup --template-file .\thr2004-template.json
az group deployment create -g thr3302 -n thr3302-setup --template-file .\thr3302-template.json

#az group deployment show -g brk2050 -n brk2050-setup --query properties.outputs.ehcxnstr.value > $env:TEMP\brk2050-scratch.txt
#az group deployment show -g brk2050 -n brk2050-setup --query properties.outputs.ehname.value >> $env:TEMP\brk2050-scratch.txt