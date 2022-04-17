using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using InkedUp.Domain;
using InkedUp.Framework;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace InkedUp.Api.Repositories
{
    public class PenCosmosRepository : IPenRepository
    {
        // The Azure Cosmos DB endpoint for running this sample.
        private static readonly string EndpointUri = "https://[ENTER-YOUR-COSMOS-ACCOUNT-NAME-HERE]-cosmos.documents.azure.com:443/";

        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "[ENTER-YOUR-COSMOS-ACCOUNT-KEY-HERE]";

        // The name of the database and container
        private string _databaseId = "InkedUp";
        private string _containerId = "EventStreams";
        
        // The Cosmos client instance
        private CosmosClient _cosmosClient;
        
        private Database _database;
        private Container _container;
        
        public PenCosmosRepository()
        {
            _cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "InkedUp.Api" });
            _database = _cosmosClient.GetDatabase(_databaseId);
            _container = _database.GetContainer(_containerId);
        }
        
        public async Task<bool> Exists(string id, string ownerId)
        {
            bool retVal;
            
            try
            {
                // Read the item to see if it exists.  
                ItemResponse<EventStream> eventStreamResponse = 
                    await this._container.ReadItemAsync<EventStream>(id, new PartitionKey(ownerId));
                retVal = true;
            }
            catch(CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                retVal = false;
            }

            return retVal;
        }

        public async Task<Pen> Load(string id, string ownerId)
        {
            ItemResponse<EventStream> eventStreamResponse = 
                await _container.ReadItemAsync<EventStream>(id, new PartitionKey(ownerId));
            return new Pen(eventStreamResponse.Resource);
        }

        public async Task Save(Pen entity)
        {
            // Create an EventStream from the Pen object
            EventStream eventStream = new EventStream()
            {
                Id = entity.Id.ToString(),
                OwnerId = entity.OwnerId.ToString(),
                Events = new List<EventData>()
            };
            foreach (var change in entity.GetChanges())
            {
                var streamEvent = new EventData()
                {
                    Type = change.GetType().AssemblyQualifiedName,
                    Data = Serialize(change)
                };
                eventStream.Events.Add(streamEvent);
            }

            // Could possibly replace this whole if/else block with a single Upsert statement... one to look further into.
            if (await Exists(eventStream.Id, eventStream.OwnerId))
            {
                // Replace the existing item
                await _container.ReplaceItemAsync(eventStream, eventStream.Id, new PartitionKey(eventStream.OwnerId));
            }
            else
            {
                // Create an item in the container representing the Pen. Note we provide the value of the partition key for this item, which is the OwnerId
               await this._container.CreateItemAsync(eventStream, new PartitionKey(eventStream.OwnerId));
            }
        }

        private byte[] Serialize(object data)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        }
    }
}