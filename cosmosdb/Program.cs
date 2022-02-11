using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace cosmosdb
{
    internal sealed class Parent
    {
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
    }

    internal sealed class Child
    {
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int Grade { get; set; }
        public Pet[] Pets { get; set; }
    }

    internal sealed class Pet
    {
        public string GivenName { get; set; }
    }

    internal sealed class Address
    {
        public string State { get; set; }
        public string County { get; set; }
        public string City { get; set; }
    }

    internal sealed class Family
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string LastName { get; set; }
    }

    class Program
    {
        CosmosClient CosmosClient { get; set; }
        Container Container { get; set; }

        public void Initialize()
        {
            CosmosClient = new CosmosClient("https://ma2moto-cosmos.documents.azure.com:443/", "0q4cjKWu1CAnx4pr7FHbDWpxxb83K2xX3H9wxO7NHqAPFmItzGh7D05ORwDkmnx47Tee37RJCLABMO2rzhlB2A==");
            Container = CosmosClient.GetContainer("formLearning", "formLearningCollection");
        }

        public async Task Regist()
        {
            Family AndersonFamily = new Family
            {
                Id = "AndersonFamily",
                LastName = "Anderson",
            };

            await Container.UpsertItemAsync<Family>(AndersonFamily, new PartitionKey("/learningScopeId"));
        }
        static async Task Main(string[] args)
        {
            Program p = new Program();
            p.Initialize();
            await p.Regist();
        }
    }

}
