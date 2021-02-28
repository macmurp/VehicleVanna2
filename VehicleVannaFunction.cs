using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureVehicleVanna2
{
    public static class VehicleVanna
    {
        [FunctionName("RunVehicleVanna")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Queue("Vehicle")] IAsyncCollector<Vehicle> v,
            ILogger log)
        {



            log.LogInformation("Received vehicle information");
            //log info of running before anything is handled


            string reqbody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Vehicle>(reqbody);
            await v.AddAsync(data);
            log.LogInformation($"Buyer {data.FirstName} {data.LastName} ({data.BuyerEmail}) purchased a {data.Year} {data.Make} {data.Model} {data.vehicleType} with list price of ${data.ListPrice.ToString("#,##0.00")}. " +
            $"With discount applied, purchase price is ${Math.Round(data.PurchasePrice, 2).ToString("#,##0.00")}");
            //log info with vehicle info taken in and deserialized

            string responseMessage = $"Buyer {data.FirstName} {data.LastName} ({data.BuyerEmail}) purchased a {data.Year} {data.Make} {data.Model} {data.vehicleType} with list price of ${data.ListPrice.ToString("#,##0.00")}. " +
            $"With discount applied, purchase price is ${Math.Round(data.PurchasePrice, 2).ToString("#,##0.00")}";


            return new OkObjectResult(responseMessage);

        }
    }
}
