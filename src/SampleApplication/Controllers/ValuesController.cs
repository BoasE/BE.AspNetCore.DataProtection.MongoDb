using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly string scope = "ControllerValues";
        private readonly IDataProtectionProvider provider;

        public ValuesController(IDataProtectionProvider protector)
        {
            provider = protector;
        }

        [HttpGet("encrypt/{value}")]
        public IActionResult Decrypt(string value)
        {
            var result = ResolveProtector().Protect(value);

            return Ok(result);
        }

        [HttpGet("decrypt/{value}")]
        public IActionResult Encrypt(string value)
        {
            try
            {
                var result = ResolveProtector().Unprotect(value);
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
            var tenant = ResolveTenant(); // Example to encrypt per scope and tenant, could also be a user secrect
            return provider.CreateProtector(scope, tenant);
        }

        private string ResolveTenant()
        {
            string tenant = "none";

            string tenantHeader = "X-Tenant";
            if (Request.Headers.ContainsKey(tenantHeader))
            {
                tenant = Request.Headers[tenantHeader];
            }
            return tenant;
        }
    }
}