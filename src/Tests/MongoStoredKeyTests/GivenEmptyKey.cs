using System;
using BE.AspNetCore.DataProtection.MongoDb;
using MongoDB.Bson;
using Xunit;

namespace Tests.MongoStoredKeyTests
{
    public sealed class GivenEmptyKey
    {
        public MongoStoredKey Key { get; set; } = new MongoStoredKey {Id = ObjectId.GenerateNewId()};

        [Fact]
        public void ValidateThrows()
        {
            Assert.Throws<InvalidOperationException>(() => Key.Validate());
        }
    }
}