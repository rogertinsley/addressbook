# Contacts

Azure CLI:

```
resourceGroupName='contacts'
location='northeurope'

# The Azure Cosmos account name must be globally unique
accountName='rdt-contacts-sql'

# Create a resource group
az group create \
    --name $resourceGroupName \
    --location $location

# Create a SQL API Cosmos DB account with session consistency and multi-master enabled
az cosmosdb create \
    --resource-group $resourceGroupName \
    --name $accountName \
    --kind GlobalDocumentDB \
    --locations regionName="North Europe" failoverPriority=0 --locations regionName="West Europe" failoverPriority=1 \
    --default-consistency-level "Session" \
    --enable-multiple-write-locations true
```

## Secrets

1. Naviate to Exploratory.csproj
2. Add secrets:

```
	dotnet user-secrets set CosmosSettings:AccountEndpoint AccountEndpoint                                         
	dotnet user-secrets set CosmosSettings:AccountKey AccountKey
	dotnet user-secrets set CosmosSettings:DatabaseName DatabaseName     
```

## Useful resources

* https://docs.microsoft.com/en-us/azure/cosmos-db/modeling-data
* https://docs.microsoft.com/en-us/ef/core/providers/cosmos/
* https://azure.microsoft.com/en-us/resources/videos/azure-documentdb-elastic-scale-partitioning/
* https://www.bruttin.com/CosmosDbExplorer/