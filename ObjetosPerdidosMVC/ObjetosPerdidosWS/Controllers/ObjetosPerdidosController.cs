using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ObjetosPerdidosWS.Models;
using Newtonsoft.Json;
using ObjetosPerdidosWS.Services;

namespace ObjetosPerdidosWS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjetosPerdidosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetObjetos(string objeto)
        {
            string result = String.Empty;

            List<TaxiobjetosPerdidos> query = null;
            using (IObjetosPerdidosRepository spRepo = new ObjetosPerdidosRepository())
            {
                query = spRepo.GetObjetosPerdidos(objeto);                            
            }
            if (query != null)
                return Ok(JsonConvert.SerializeObject(query));
            else            
                return StatusCode(500);            
        }
    }
}