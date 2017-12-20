using BE.AspNetCore.DataProtection.MongoDb;
using MongoDB.Bson;
using Xunit;

namespace Tests.MongoStoredKeyTests
{
    public class GivenValidKey
    {
        public MongoStoredKey Key { get; set; } = new MongoStoredKey
        {
            Id = ObjectId.GenerateNewId(),
            Xml =
                "<key id=\"924046dd-1b08-4273-81e8-0e2329533e94\" version=\"1\"><creationDate>2017-12-20T08:45:50.933664Z</creationDate><activationDate>2017-12-20T08:45:50.8118796Z</activationDate><expirationDate>2018-03-20T08:45:50.8118796Z</expirationDate><descriptor deserializerType=\"Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptorDeserializer, Microsoft.AspNetCore.DataProtection, Version=2.0.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60\"><descriptor><encryption algorithm=\"AES_256_CBC\" /><validation algorithm=\"HMACSHA256\" /><masterKey p4:requiresEncryption=\"true\" xmlns:p4=\"http://schemas.asp.net/2015/03/dataProtection\"><!-- Warning: the key below is in an unencrypted form. --><value>CFwO9FsSCSfYA2c8sErVT5bjkPr4KXxacbUcoNguEdqU4Yrm2UZPT+rONpzULmvDklQs2bXDbo7Ol6XjDUo/wA==</value></masterKey></descriptor></descriptor></key>"
        };


        [Fact]
        public void AssertSuceeds()
        {
            Key.Validate();
        }
    }
}