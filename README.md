# Tempaast API

This code relies on an Azure Key Vault for secrets. To run locally you'll need to structure a `launchSettings.json` like below

```
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:21928",
      "sslPort": 44383
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "tempaast",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "tempaastapi": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "tempaast",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "KeyVaultClientId": "<KEY_VAULT_CLIENT_ID",
        "KeyVaultClientSecret": "<KEY_VAULT_CLIENT_SECRET",
        "KeyVaultName": "<KEY_VAULT_NAME"
      }
    }
  }
}
```