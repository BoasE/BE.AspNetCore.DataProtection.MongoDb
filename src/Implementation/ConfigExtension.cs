using BE.FluentGuard;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BE.AspNetCore.DataProtection.MongoDb
{
    public static class ConfigExtension
    {
        public static IDataProtectionBuilder PersistKeysToMongoDb(this IDataProtectionBuilder builder,
            IMongoDatabase db, string collectionName)
        {
            Precondition.For(() => builder).NotNull();
            Precondition.For(() => db).NotNull();
            Precondition.For(() => collectionName).NotNullOrWhiteSpace();

            builder.Services.Configure<KeyManagementOptions>(options =>
            {
                options.XmlRepository = new MongoXmlRepository(db, collectionName);
            });

            return builder;
        }
    }
}