using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Contacts.Core.Services
{
    public class CosmosService
    {
        private async Task<Container> GetOrCreateContainerAsync(Database database, string containerId)
        {
            ContainerProperties containerProperties = new ContainerProperties(id: containerId, partitionKeyPath: "/Surname");

            return await database.CreateContainerIfNotExistsAsync(
                containerProperties: containerProperties,
                throughput: 400);
        }
    }
}