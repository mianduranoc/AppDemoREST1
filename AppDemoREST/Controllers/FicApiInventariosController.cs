using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppDemoREST.Data;

namespace AppDemoREST.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]")]
    //[ApiController]
    public class FicApiInventariosController : Controller
    {
        private readonly FicDBContext FicLoDBContext;
        public FicApiInventariosController(FicDBContext FicPaBDContext)
        {
            FicLoDBContext = FicPaBDContext;
        }
        [HttpGet]
        [Route("/api/inventarios/invacucon")]
        public async Task<IActionResult>FicApiGetListInventarios([FromQuery]int cedi)
        {
            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios where data_inv.IdCEDI == cedi select data_inv).ToList();
            if (zt_inventarios.Count()>0)
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
            else
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
        }
        // GET: api/FicApiInventarios
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FicApiInventarios/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FicApiInventarios
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FicApiInventarios/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
