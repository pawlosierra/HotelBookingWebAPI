using HotelBookingWebAPI.Infrastructure.Configurations;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebAPI
{
    public class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCosmosDbService<T>(this IServiceCollection services, 
                                                                        AppSettings appSettings,
                                                                        string containerName) where T : class
        {
            var databaseName = appSettings.CosmosDb.DatabaseName;
            var account = appSettings.CosmosDb.Account;
            var key = appSettings.CosmosDb.Key;

            CosmosClient client = new CosmosClient(account, key);

            return services;
        }
    }
}
