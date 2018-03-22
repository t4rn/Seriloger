using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seriloger.Core.Services;

namespace Seriloger.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IKrisLogger _krisLogger;

        public ValuesController(IKrisLogger krisLogger)
        {
            _krisLogger = krisLogger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _krisLogger.LogDebug("Hi from Get");
            _krisLogger.LogError($"I'm an error from Get");
            return new string[] { "Hello", "Seriloger" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            _krisLogger.LogDebug("Get with Id: {id}", id);
            _krisLogger.LogError("I'm an error from Id: {id}", id);
            return $"You've send '{id}'.";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
