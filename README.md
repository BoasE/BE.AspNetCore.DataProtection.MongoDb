# BE.AspNetCore.DataProtection.MongoDb

Extension to have the keys of the dataprotection api stored in mongodatabase.
They keys are stored unencrypted in the given collection. To encrypt it feel free to extern the repository.
Also consider to use a well protected database instance and check your mongodb user accounts.

**Be Aware**
I don't take any garantuees for the code. Review the code and use it as a starting point. Comments and pull requests are welcome!

# See Also
[Data Protection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/introduction)

# Usage

**Configuration**
```csharp
services
  .AddDataProtection()
  .SetApplicationName("MyApplication" )// Here you set a application name which is used for the encryption
  .PersistKeysToMongoDb(db, "BE_KeysSet"); 
```

**Protect and unproect in a controller**
```csharp
[HttpGet("encrypt/{value}")]
public IActionResult encrypt(string value)
{
    var result = ResolveProtector().Protect(value);

    return Ok(result);
}

[HttpGet("decrypt/{value}")]
public IActionResult decrypt(string value)
{
    try
    {
        var result = ResolveProtector().Unprotect(scope);
        return Ok(result);
    }
    catch (Exception e)
    {
        //Could not be decrypted
        return BadRequest(e);
    }
}

private IDataProtector ResolveProtector()
{
   // Here you can pass a custom scope to have areas differently encrypted. e.g. each user or tennant can have its on scope with a salt.
    return provider.CreateProtector("myScope");  
}
```

# Nuget Package

https://www.nuget.org/packages/BE.AspNetCore.DataProtection.MongoDb/0.1.1
