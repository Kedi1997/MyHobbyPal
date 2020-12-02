using System;
using System.Reflection;
using AutoMapper;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyHobbyPal.Api.Mutations;
using MyHobbyPal.Api.Queries;
using MyHobbyPal.GraphData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyHobbyPal.Api
{
    public class Startup
    {
        #region Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Configuration
        public IConfiguration Configuration { get; }
        #endregion

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            services.AddTransient(provider =>
            {
                return new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }, Formatting = Formatting.Indented };
            });

            try
            {
                var cosmosAccountName = Configuration["cosmos:cosmos-account-name"];
                var cosmosKey = Configuration["cosmos:cosmos-key"];
                var cosmosDatabaseId = Configuration["cosmos:cosmos-database-id"];
                var cosmosContainerId = Configuration["cosmos:cosmos-container-id"];
                var cosmosPartitionKeyPath = Configuration["cosmos:cosmos-partition-key-path"];
                var environmentName = Configuration["cosmos:environment-name"];
                var cosmosRepo = new Repository(cosmosAccountName, cosmosKey, cosmosDatabaseId, cosmosContainerId, cosmosPartitionKeyPath, environmentName);
                services.AddSingleton<IRepository>(cosmosRepo);
            }
            catch (Exception ex)
            {
                var baseEx = ex.GetBaseException();
                throw;
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}