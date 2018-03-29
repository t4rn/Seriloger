using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seriloger.Core.Services;
using System;

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

        [HttpGet]
        public IActionResult Ping()
        {
            _krisLogger.LogDebug("[{method}] START", nameof(Ping));
            return Ok($"Ping at '{DateTime.Now}' in '{nameof(ValuesController)}'.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            IActionResult result;
            _krisLogger.LogDebug("[{method}] START -> with Id: {id}", nameof(GetById), id);
            try
            {

                if (id < 5)
                {
                    _krisLogger.LogDebug("[{method}] Ok -> with Id: {id}", nameof(GetById), id);
                    result = Ok($"You've send '{id}'.");
                }
                else if (id < 20)
                {
                    _krisLogger.LogWarning("[{method}] Ok -> with Id: {id}", nameof(GetById), id);
                    result = BadRequest($"Your Id: '{id}' was a bit to big...");
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Id exceeded our limit...");
                }
            }
            catch (Exception ex)
            {
                _krisLogger.LogError("[{method}] Ex for Id: {id}: {exception}", nameof(GetById), id, ex);
                result = StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return result;
        }
    }
}
