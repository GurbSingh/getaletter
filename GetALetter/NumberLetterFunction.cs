using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using GetALetterForANumber.Interfaces;
using GetALetterForANumber.Concrete;

namespace GetALetterForANumber
{
    
    public class NumberLetterFunction
    {
        private readonly IIntegerRequest _integerRequest;

        public NumberLetterFunction(IIntegerRequest integerRequest)
        {
            _integerRequest = integerRequest;
        }

        [FunctionName("IntegerTester")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string number = req.Query["number"];

            IIntegerResponse responseMessage = _integerRequest.Test(number);

            return await Task.FromResult(new JsonResult(JsonConvert.SerializeObject(responseMessage)));
        }
    }
}
