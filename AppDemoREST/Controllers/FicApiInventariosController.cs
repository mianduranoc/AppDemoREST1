using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppDemoREST.Data;
using static AppDemoREST.Models.FicModInventarios;

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
        //consulta completa, consulta por id cedi, insert inventario, modificacion inventario, eliminar inventario
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
        [HttpGet]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiGetListInventarios()
        {
            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios select data_inv).ToList();
            if (zt_inventarios.Count() > 0)
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
        [HttpPost]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiSetInventario([FromForm] int id, [FromForm]short cedi, [FromForm]string sap, [FromForm] DateTime fecha, [FromForm] string user)
        {
            Console.WriteLine(id);
            zt_inventarios inventario = new zt_inventarios();
            inventario.IdInventario = id;
            inventario.IdCEDI = cedi;
            inventario.IdInventarioSAP = sap;
            inventario.FechaReg = fecha;
            inventario.UsuarioReg = user;
            inventario.Activo = "S";
            inventario.Borrado = "N";
            FicLoDBContext.zt_inventarios.Add(inventario);
            FicLoDBContext.SaveChanges();
            return Ok(inventario);
            
        }
        [HttpDelete]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiDeleteInventario([FromQuery] int id)
        {
            zt_inventarios inventario = new zt_inventarios();
            inventario.IdInventario = id;
            try
            {
                FicLoDBContext.zt_inventarios.Remove(inventario);
                FicLoDBContext.SaveChanges();
                return Ok(inventario);
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err","No se encontraron registros");
                return Ok(err);
            }  
        }
        [HttpPut]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiUpdateInventario([FromForm] int id, [FromForm]string sap, [FromForm] DateTime fecha, [FromForm] string user)
        {
            try
            {
                var inventario = FicLoDBContext.zt_inventarios.First(a => a.IdInventario == id);
                inventario.IdInventario = id;
                inventario.IdInventarioSAP = sap;
                inventario.FechaUltMod = fecha;
                inventario.UsuarioMod = user;
                FicLoDBContext.SaveChanges();
                return Ok(inventario);
            }
            catch(Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
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
