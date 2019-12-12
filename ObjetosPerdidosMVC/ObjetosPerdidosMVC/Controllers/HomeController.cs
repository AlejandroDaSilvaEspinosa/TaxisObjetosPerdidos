using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ObjetosPerdidosMVC.Helpers;


namespace ObjetosPerdidosMVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("[controller]/GetObjects")]
        [HttpPost]
        public async Task<string> GetObjects([FromBody]string nameObject)
        {
            string endPoint = CallApiHelper.GetUri("ObjetosPerdidosWS");
            var result = await CallApiHelper.GetAsync(endPoint + "?objeto=" + nameObject);
            return result;
        }
    }
}
