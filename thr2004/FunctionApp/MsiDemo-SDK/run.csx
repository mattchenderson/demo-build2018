using System;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;

public static async Task<string> Run(string input, TraceWriter log)
{
    var azureServiceTokenProvider = new AzureServiceTokenProvider();
    var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
    var secret = await kv.GetSecretAsync(String.Format("{0}secrets/{1}", 
        Environment.GetEnvironmentVariable("KEYVAULT_URL"),
        input
        ));
    return secret.Value;
}